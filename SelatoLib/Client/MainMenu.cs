using SelatoLib.Client.Misc.MainMenu;
using SelatoLib.Client.Misc.Platform;

namespace SelatoLib.Client;

public class MainMenu(GamePlatform platform)
{
    public GamePlatform Platform { get; set; } = platform;
    public Language 
    private float One { get; set; }= 1;
    private Dictionary<string, int> _textures = new Dictionary<string, int>();
    private TextTexture[] _textTextures = new TextTexture[256];
    
}