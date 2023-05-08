using System.Net.Mime;
using WallpaperEx.Forms;
using WallpaperEx.Native;

namespace WallpaperEx;

internal static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.PerMonitorV2);
        Application.Run(new SettingsForm());
    }
}