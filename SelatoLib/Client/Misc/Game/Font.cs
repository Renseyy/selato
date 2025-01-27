namespace SelatoLib.Client.Misc.Game;

public class Font()
{
    internal string Family { get; } = "Arial";
    internal float Size { get; } = 12;
    
    internal FontStyle Style { get; } = 0;

    public Font(string family = "Arial", float size = 12, FontStyle style = 0) : this()
    {
        Family = family;
        Size = size;
        Style = style;
    }
}