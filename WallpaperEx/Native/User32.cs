using System.Runtime.InteropServices;

namespace WallpaperEx.Native;

public static class User32
{
    #region Constants

    public const int WM_SPAWN_WORKER = 0x052C;

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
