using Microsoft.Web.WebView2.WinForms;

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
        // We cannot initialize the wallpaper without a wallpaper, a screen or a webview
        if (string.IsNullOrEmpty(Wallpaper)) return;
        if (_webView == null || CurrentScreen == null) return;
        
        // Set wallpaper webview source
        _webView.Source = new(Wallpaper);
        
        // Calculate window bounds for the current screen
        var currentScreenBounds = CurrentScreen.Bounds;
        
        // Calculate offset between working area and virtual screen
        var offsetX = SystemInformation.WorkingArea.Left - SystemInformation.VirtualScreen.Left;
        var offsetY = SystemInformation.WorkingArea.Top - SystemInformation.VirtualScreen.Top;

        // Offset current screen bounds with working area
        var x = currentScreenBounds.Left + offsetX;
        var y = currentScreenBounds.Top + offsetY;

        // Set the bounds of the form to the bounds of the current screen
        Bounds = currentScreenBounds with { X = x, Y = y };
    }

    private void InitializeWebView()
    {
        if (_webView == null)
        {
            Controls.Add(_webView = new() { Dock = DockStyle.Fill });
        }

        _webView.BringToFront();
    }

    #endregion

    #region Exposing Functions

    public void ChangeWallpaper(string url)
    {
        if (_webView == null) return;
        
        _webView.Source = new(Wallpaper = url);
    }

    #endregion

    #region Events

    private void WrapperForm_Shown(object? sender, EventArgs e)
    {
        InitializeWallpaper();
    }
    
    #endregion
  
}