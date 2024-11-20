namespace SelatoLib.Client.Misc.Platform.EventArgs;

public class MouseEventArgs
{
    public int X { get; set; }
    public int Y { get; set; }
    public int MovementX { get; set; }
    public int MovementY { get; set; }
    public int Button { get; set; }
    public bool IsHandled { get; set; }
    public bool IsForcedUsage { get; set; }
    public bool IsEmulated { get; set; }
}