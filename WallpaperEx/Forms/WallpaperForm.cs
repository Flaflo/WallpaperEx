using Microsoft.Web.WebView2.WinForms;

namespace WallpaperEx.Forms;

public partial class WallpaperForm : Form
{
    public Screen? CurrentScreen { get; init; }
    public string? Wallpaper { get; set; }

    private WebView2? _webView;

    public WallpaperForm()
    {
        InitializeComponent();
        InitializeWebView();
    }

    #region Initialization

    private void InitializeWallpaper()
    {
        if (string.IsNullOrEmpty(Wallpaper)) return;
        if (_webView == null || CurrentScreen == null) return;
        
        _webView.Source = new(Wallpaper);

        ClientSize = new(CurrentScreen.Bounds.Width, CurrentScreen.Bounds.Height);
        
        var location = CurrentScreen.Bounds.Location;
        if (location.X < 0 || location.Y < 0)
        {
            location = Screen.PrimaryScreen.Bounds.Location - (Size) location;
        }
        
        Location = location;
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