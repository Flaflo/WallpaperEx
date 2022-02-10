using Microsoft.Web.WebView2.WinForms;

namespace WallpaperEx.Forms;

public partial class WallpaperForm : Form
{
    public string? Wallpaper { get; set; }
    public Screen? CurrentScreen { get; set; }

    private WebView2? _webView;

    public WallpaperForm()
    {
        InitializeComponent();

        Load += (_, _) => InitializeWallpaper();
    }
    
    public void ChangeWallpaper(string url)
    {
        Wallpaper = url;

        if (_webView == null) return;

        _webView.Source = new(Wallpaper);
    }

    private void InitializeWallpaper()
    {
        if (string.IsNullOrEmpty(Wallpaper)) return;

        Controls.Add(_webView = new()
        {
            Dock = DockStyle.Fill,
            Source = new(Wallpaper)
        });

        
        ClientSize = new (CurrentScreen.Bounds.Width, CurrentScreen.Bounds.Height);
        Location = CurrentScreen?.Bounds.Location ?? new(0, 0);
    }
}