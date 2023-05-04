using Microsoft.Web.WebView2.WinForms;
using WallpaperEx.Native;

namespace WallpaperEx.Forms;

public partial class WallpaperForm : Form
{
    public Screen? CurrentScreen { get; init; }
    public string? Wallpaper { get; set; }

    private WebView2? _webView;

    public WallpaperForm()
    {
        StartPosition = FormStartPosition.Manual;

        InitializeComponent();
        InitializeWebView();
    }

    #region Initialization

    private void InitializeWallpaper()
    {
        if (string.IsNullOrEmpty(Wallpaper)) return;
        if (_webView == null || CurrentScreen == null) return;
        
        _webView.Source = new(Wallpaper);

        var primary = Screen.PrimaryScreen!;
        ClientSize = new (CurrentScreen.Bounds.Width, CurrentScreen.Bounds.Height);

        var x = primary.Bounds.Right + CurrentScreen.Bounds.Left;
        var y = 0;
        if (CurrentScreen.Bounds.Width > CurrentScreen.Bounds.Height)
        {
            // get max height of all screens
            var totalVerticalHeight = Screen.AllScreens.Where(it => it.Bounds.Width < it.Bounds.Height).Max(s => s.Bounds.Width);

            y = 0;
        }

        Location = new Point(x, y);

        var screenNum = Screen.AllScreens.ToList().IndexOf(CurrentScreen);
        var lbl = new Label
        {
            Text = "Y " + Location.Y,
            ForeColor = CurrentScreen == Screen.PrimaryScreen ? Color.Chartreuse :  Color.White,
            BackColor = Color.Black,
            Font = new Font("Segoe UI", 40),
            Visible = true,
            AutoSize = true,
            Location = new Point(Width / 2, Height / 2),
        };
        Controls.Add(lbl);
        lbl.BringToFront();
    }

    private void InitializeWebView()
    {
        Controls.Add(_webView = new()
        {
            Dock = DockStyle.Fill,
        });
    }

    #endregion

    #region Exposing Functions

    public void ChangeWallpaper(string url)
    {
        Wallpaper = url;

        if (_webView == null) return;

        _webView.Source = new(Wallpaper);
    }

    #endregion

    #region Events

    private void WrapperForm_Shown(object? sender, EventArgs e)
    {
        InitializeWallpaper();
    }
    
    #endregion
  
}