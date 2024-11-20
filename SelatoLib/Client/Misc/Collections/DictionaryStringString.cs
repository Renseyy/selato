namespace SelatoLib.Client.Misc.Collections;

public class DictionaryStringString(int size)
{
    private KeyValue<string, string>?[] _items = new KeyValue<string, string>?[size];
    internal int size;
    
    public DictionaryStringString()
    {
        Start(64);
    }

    public void Start(int size_)
    {
        items = new KeyValue[size_];
        size = size_;
    }

    
    
    public int GetSize() { return size; }

    public void Set(string key, string value)
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (Game.StringEquals(items[i].key, key))
            {
                items[i].value = value;
                return;
            }
        }
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                items[i] = new KeyValueStringString();
                items[i].key = key;
                items[i].value = value;
                return;
            }
        }
    }

    internal bool ContainsKey(string key)
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (Game.StringEquals(items[i].key, key))
            {
                return true;
            }
        }
        return false;
    }

    internal string Get(string key)
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (Game.StringEquals(items[i].key, key))
            {
                return items[i].value;
            }
        }
        return null;
    }

    internal void Remove(string key)
    {
        for (int i = 0; i < size; i++)
        {
            if (items[i] == null)
            {
                continue;
            }
            if (Game.StringEquals(items[i].key, key))
            {
                items[i] = null;
            }
        }
    }
}