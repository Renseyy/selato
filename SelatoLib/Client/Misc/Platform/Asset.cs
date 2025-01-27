namespace SelatoLib.Client.Misc.Platform;

public class Asset(string name, string md5, byte[] data, int dataLength)
{
    public string Name { get; set; } = name;
    public string Md5 { get; set; } = md5;
    public byte[] Data { get; set; } = data;
    public int DataLength { get; set; } = dataLength;
}