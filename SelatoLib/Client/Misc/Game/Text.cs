namespace SelatoLib.Client.Misc.Game;

public class Text(string content, Font font)
{
    internal string Content { get; set; } = content;
    internal int Color { get; set; }
    internal Font Font { get; set; } = font;

    internal bool Equals(Text? other)
    {
        if(other is null)
            return false;
        if (Content != other.Content)
            return false;
        if (Color != other.Color)
            return false;
        return Font == other.Font;
    }
    
    public float GetFontSize() => Font.Size;
    public string GetFontFamily() => Font.Family;
    public FontStyle GetFontStyle() => Font.Style;
}