namespace SelatoLib.Client.Misc.Game;

public class Font()
{
    internal string Family { get; } = "Arial";
    internal float Size { get; } = 12;
    
    internal FontStyle Style { get; } = 0;

    public Font(string family, float size, FontStyle style) : this()
    {
        Family = family;
        Size = size;
        Style = style;
    }
}