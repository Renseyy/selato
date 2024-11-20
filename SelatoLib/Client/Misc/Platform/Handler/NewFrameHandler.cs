using SelatoLib.Client.Misc.Platform.EventArgs;

namespace SelatoLib.Client.Misc.Platform.Handler;

public abstract class NewFrameHandler
{
    public abstract void OnNewFrame(NewFrameEventArgs args);
}