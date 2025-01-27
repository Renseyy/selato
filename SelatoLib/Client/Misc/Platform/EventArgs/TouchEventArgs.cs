namespace SelatoLib.Client.Misc.Platform.EventArgs;

public class TouchEventArgs(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int Id { get; set; }
    public bool IsHandled { get; set; }
}