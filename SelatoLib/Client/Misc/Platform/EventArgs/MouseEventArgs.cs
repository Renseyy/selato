namespace SelatoLib.Client.Misc.Platform.EventArgs;

public class MouseEventArgs(int x, int y)
{
    public int X { get; set; } = x;
    public int Y { get; set; } = y;
    public int MovementX { get; set; }
    public int MovementY { get; set; }
    public int Button { get; set; }
    public bool IsHandled { get; set; }
    public bool IsForcedUsage { get; set; }
    public bool IsEmulated { get; set; }
}