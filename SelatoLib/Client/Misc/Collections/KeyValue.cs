namespace SelatoLib.Client.Misc.Collections;

public class KeyValue<TKey, TValue>(TKey key, TValue value)
{
    public readonly TKey Key = key;
    public TValue Value = value;
}