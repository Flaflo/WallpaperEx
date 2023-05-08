using System.Runtime.InteropServices;

namespace WallpaperEx.Native;

public static class User32
{
    #region Constants

    public const int WM_SPAWN_WORKER = 0x052C;

    public const int MONITOR_DEFAULTTONULL = 0;
    public const int MONITOR_DEFAULTTOPRIMARY = 1;
    public const int MONITOR_DEFAULTTONEAREST = 2;
    
    #endregion
    
    #region Delegates

    public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

    #endregion

    #region P/Invokes

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, IntPtr lParam);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindow(string lpClassName, string? lpWindowName);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className,
        IntPtr windowTitle);

    [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
    public static extern IntPtr SendMessageTimeout(IntPtr windowHandle, uint msg, IntPtr wParam, IntPtr lParam,
        SendMessageTimeoutFlags flags, uint timeout, out IntPtr result);

    [DllImport("user32.dll", SetLastError = true)]
    public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

    [DllImport("user32.dll", EntryPoint = "GetDesktopWindow")]
    public static extern IntPtr GetDesktopWindow();

    [DllImport("user32.dll")]
    public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFOEX lpmi);
    
    [DllImport("user32.dll")]
    public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);
    
    #endregion

    #region Wrapper

    
    public static int GetMonitorRotation(IntPtr hWnd)
    {
        var hMonitor = MonitorFromWindow(hWnd, MONITOR_DEFAULTTONEAREST);
        var mi = new MONITORINFOEX();
        
        mi.cbSize = Marshal.SizeOf(mi);
        
        GetMonitorInfo(hMonitor, ref mi);
        
        var cx = mi.rcMonitor.Right - mi.rcMonitor.Left;
        var cy = mi.rcMonitor.Bottom - mi.rcMonitor.Top;

        return cx == cy ? 0 : // Monitor is not rotated
            cx > cy ? 90 : // Monitor is landscape rotated 90 degrees clockwise
            180; // Monitor is portrait rotated 180 degrees clockwise
    }

    #endregion
}

#region Enums

[Flags]
public enum SendMessageTimeoutFlags : uint
{
    SMTO_NORMAL = 0x0,
    SMTO_BLOCK = 0x1,
    SMTO_ABORTIFHUNG = 0x2,
    SMTO_NOTIMEOUTIFNOTHUNG = 0x8,
    SMTO_ERRORONEXIT = 0x20
}

#endregion

#region Structs

[StructLayout(LayoutKind.Sequential)]
public struct MONITORINFOEX
{
    public int cbSize;
    public RECT rcMonitor;
    public RECT rcWork;
    public uint dwFlags;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
    public char[] szDevice;
}

[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}

#endregion
