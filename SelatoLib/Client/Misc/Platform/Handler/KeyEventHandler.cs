using SelatoLib.Client.Misc.Platform.EventArgs;

namespace SelatoLib.Client.Misc.Platform.Handler;

public abstract class KeyEventHandler
{
    public abstract void OnKeyDown(KeyEventArgs args);
    public abstract void OnKeyPress(KeyPressEventArgs args);
    public abstract void OnKeyUp(KeyEventArgs args);
}