namespace SelatoLib.Client.Misc.Platform.EventArgs;

public class TouchEventArgs
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Id { get; set; }
    public bool IsHandled { get; set; }
}