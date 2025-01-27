using SelatoLib.Client.Misc.Game;

namespace SelatoLib.Client.Misc.MainMenu;

public class MenuWidget(string text)
{
    public string Text { get; set; } = text;
    private float _x;
    private float _y;
    private float _sizex;
    private float _sizey;
    private bool _pressed;
    private bool _hover;
    public WidgetType Type { get; set; }
    public bool Editing { get; set; }
    private bool _visible = true;
    private string _description;
    private bool _password;
    private bool _selected;
    private ButtonStyle _buttonStyle;
    private string _image;
    public uint? NextWidget { get; set; }
    public bool HasKeyboardFocus { get; set; } = false;
    private int _color;
    private string _id;
    private bool _isButton;
    private Font _font = new Font(size: 14);
    
    public void GetFocus()
    {
        HasKeyboardFocus = true;
        if (Type == WidgetType.Textbox)
        {
            Editing = true;
        }
    }
    public void LoseFocus()
    {
        HasKeyboardFocus = false;
        if (Type == WidgetType.Textbox)
        {
            Editing = false;
        }
    }
}