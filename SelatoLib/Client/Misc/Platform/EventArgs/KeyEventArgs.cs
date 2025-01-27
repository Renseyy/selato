namespace SelatoLib.Client.Misc.Platform.EventArgs;

public class KeyEventArgs
{
    public Key KeyCode { get; set; }
    public bool IsHandled { get; set; }
    public bool IsCtrlPressed { get; set; }
    public bool IsShiftPressed { get; set; }
    public bool IsAltPressed { get; set; }
}