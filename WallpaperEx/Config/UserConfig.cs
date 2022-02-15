using System.Text.Json;
using System.Text.Json.Serialization;

namespace WallpaperEx.Config;

public class UserConfig
{
    public static UserConfig Current { get; } = LoadFromFile("wpx_config.json");

    public string? Url { get; set; }

    [JsonIgnore]
    private string? _path;
    
    public UserConfig()
    {
    }
    
    private static UserConfig LoadFromFile(string path)
    {
        var config = new UserConfig();

        if (!File.Exists(path))
        {
            config._path = path;
            config.Save();
        }
        else
        {
            config = JsonSerializer.Deserialize<UserConfig>(File.ReadAllText(path)) ?? config;
            config._path = path;
        }
        
        return config;
    }

    public void Save()
    {
        if (_path == null) return;
        
        File.WriteAllText(_path, JsonSerializer.Serialize(this));
    }
}