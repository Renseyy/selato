using SelatoLib.Client.Misc.Platform.EventArgs;

namespace SelatoLib.Client.Misc.Platform.Handler;

public abstract class TouchEventHandler
{
    public abstract void OnTouchStart(TouchEventArgs args);
    public abstract void OnTouchMove(TouchEventArgs args);
    public abstract void OnTouchEnd(TouchEventArgs args);
}