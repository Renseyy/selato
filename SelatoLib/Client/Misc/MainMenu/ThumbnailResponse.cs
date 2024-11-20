namespace SelatoLib.Client.Misc.MainMenu;

public class ThumbnailResponse
{
    internal bool IsDone { get; set; }
    internal bool IsError { get; set; }
    internal string? ServerMessage { get; set; }

    internal byte[] Data { get; set; } = [];
    internal int DataLength { get; set; }
}