using SelatoLib.Client.Misc.Game;
using SelatoLib.Client.Misc.MainMenu;

namespace SelatoLib.Client.Screens;

public class MainScreen
{
    MenuWidget singleplayer;
    MenuWidget multiplayer;
    MenuWidget exit;
    internal float windowX;
    internal float windowY;
    bool queryStringChecked;
    private bool _isCursorLoaded = false;
    private Font _defaultFont;
}