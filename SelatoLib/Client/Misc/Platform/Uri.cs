using SelatoLib.Client.Misc.Collections;

namespace SelatoLib.Client.Misc.Platform;

public class Uri
{
    internal string Url { get; set; }
    internal string Ip { get; set; }
    internal int Port { get; set; }
    internal Dictionary<string, string> Get { get; set; }
}