using SelatoLib.Client.Misc.Platform.EventArgs;

namespace SelatoLib.Client.Misc.Platform.Handler;

public abstract class MouseEventHandler
{
    public abstract void OnMouseDown(MouseEventArgs args);
    public abstract void OnMouseUp(MouseEventArgs args);
    public abstract void OnMouseMove(MouseEventArgs args);
    public abstract void OnMouseWheel(MouseWheelEventArgs args);
}