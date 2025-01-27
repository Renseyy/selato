namespace SelatoLib.Client.Misc.Platform;

interface IRandom
{
    public float NextFloat();

    public int NextInt();

    public int MaxNext(int range);
}