using WallpaperEx.Native;

namespace WallpaperEx.Forms;

public partial class SettingsForm : Form
{
    private bool _closeApp;
    
    private List<WallpaperForm>? _forms;
    private IntPtr _drawingWorker;

    public SettingsForm()
    {
        InitializeComponent();
        InitializeDrawingWorker();
    }

    private void InitializeDrawingWorker()
    {
        #region Constants

        const string wndProgman = "Progman";
        const string clsShellDefView = "SHELLDLL_DefView";
        const string clsWorkerW = "WorkerW";
        
        #endregion

        User32.SendMessageTimeout(
            User32.FindWindow(wndProgman, null),
            User32.WM_SPAWN_WORKER,
            IntPtr.Zero,
            IntPtr.Zero,
            SendMessageTimeoutFlags.SMTO_NORMAL,
            1000,
            out _);

        User32.EnumWindows((handle, _) =>
        {
            var pointer = User32.FindWindowEx(handle,
                IntPtr.Zero,
                clsShellDefView,
                IntPtr.Zero);

            if (pointer != IntPtr.Zero)
            {
                _drawingWorker = User32.FindWindowEx(
                    IntPtr.Zero,
                    handle,
                    clsWorkerW,
                    IntPtr.Zero);
            }

            return true;
        }, IntPtr.Zero);
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        InitializeWallpapers(tbUrl.Text);
    }

    private void InitializeWallpapers(string url)
    {
        if (_forms == null)
        {
            _forms = Screen.AllScreens.Select(it => new WallpaperForm
            {
                CurrentScreen = it,
                Wallpaper = url,
            }).ToList();

            _forms.ForEach(it => {
                it.Show();

                // Attach Form to Wallpaper
                User32.SetParent(it.Handle, _drawingWorker);
            });
        }
        else
        {
            _forms.ForEach(it => it.ChangeWallpaper(url));
        }
    }

    private void MinimizeToTray()
    {
        trayIcon.ShowBalloonTip(1000, "Wallpaper", "The App has been hidden into the tray menu.", ToolTipIcon.Info);
        Hide();
    }

    private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (_closeApp) return;

        e.Cancel = true;
        MinimizeToTray();
    }

    private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        Show();
        WindowState = FormWindowState.Normal;
    }

    private void SettingsForm_Resize(object sender, EventArgs e)
    {
        if (WindowState == FormWindowState.Minimized)
        {
            MinimizeToTray();
        }
    }

    private void itmExit_Click(object sender, EventArgs e)
    {
        _closeApp = true;
        _forms?.ForEach(it => it.Close());

        // Restore Wallpaper
        User32.SetParent(_drawingWorker, User32.GetDesktopWindow());

        Application.Exit();
    }

    private void itmSettings_Click(object sender, EventArgs e)
    {
        Show();
        WindowState = FormWindowState.Normal;
    }
}