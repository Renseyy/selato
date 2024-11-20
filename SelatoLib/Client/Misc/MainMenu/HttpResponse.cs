using SelatoLib.Client.Misc.Platform;

namespace SelatoLib.Client.Misc.MainMenu;

/// <summary>
///  Transform to out class
/// </summary>
public class HttpResponse
{
    internal bool IsDone { get; set; }
    internal byte[] Value { get; set; } = [];
    internal int ValueLength { get; set; }
    internal bool IsError { get; set; }

    internal string GetValueAsString(GamePlatform platform)
    {
        return platform.StringFromUtf8ByteArray(Value, ValueLength);
    }
}