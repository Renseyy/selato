namespace SelatoLib.Client.Misc.Collections;

public class KeyValue<TKey, TValue>(TKey key, TValue value)
    where TKey : notnull
{
    public readonly TKey Key = key;
    public TValue Value = value;
}