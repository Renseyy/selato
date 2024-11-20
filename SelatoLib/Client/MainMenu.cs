namespace SelatoLib.Client;

public class MainMenu
{
    private int one = 1;
    private DictionaryStringInt1024 textures = new DictionaryStringInt1024();
    textTextures = new TextTexture[256];
    textTexturesCount = 0;
    screen = new ScreenMain();
    screen.menu = this;
    loginClient = new LoginClientCi();
    assets = new AssetList();
    assetsLoadProgress = new FloatRef();
    fontMenuHeading = new FontCi();
    fontMenuHeading.size = 20;
    public MainMenu()
    {
        one = 1;
    }
}