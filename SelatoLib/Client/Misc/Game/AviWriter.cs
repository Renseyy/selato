namespace SelatoLib.Client.Misc.Game;

public abstract class AviWriter
{
    public abstract void Open(string filename, int framerate, int width, int height);
    public abstract void AddFrame(Bitmap bitmap);
    public abstract void Close();
}