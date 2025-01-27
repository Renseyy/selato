namespace SelatoLib.Client.Misc.Platform;

public class Preferences(GamePlatform platform)
{
    public GamePlatform Platform { get; set; } = platform;
    public readonly Dictionary<string, string> Items = new();

    public int GetKeysCount()
    {
        return Items.Count;
    }

    public string GetString(string key, string @default)
    {
        return Items.GetValueOrDefault(key, @default);
    }
    public void SetString(string key, string value)
    {
        Items[key] = value;
    }

    public bool GetBool(string key, bool @default)
    {
        return GetString(key, "") switch
        {
            "0" => false,
            "1" => true,
            _ => @default
        };
    }
    
    public void SetBool(string key, bool value)
    {
        SetString(key, value ? "1" : "0");
    }

    public int GetInt(string key, int @default)
    {
        return Platform.IntTryParse(GetString(key, ""), out var result) ? result : @default;
    }

    public void SetInt(string key, int value)
    {
        SetString(key, Platform.IntToString(value));
    }

    internal void Remove(string key)
    {
        Items.Remove(key);
    }
}