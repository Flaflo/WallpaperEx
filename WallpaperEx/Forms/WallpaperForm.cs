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
        
        ClientSize = new (CurrentScreen.Bounds.Width, CurrentScreen.Bounds.Height);
        Location = CurrentScreen?.Bounds.Location ?? new(0, 0);
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

    private void WrapperForm_Load(object? sender, EventArgs e)
    {
        InitializeWallpaper();
    }

    #endregion
}