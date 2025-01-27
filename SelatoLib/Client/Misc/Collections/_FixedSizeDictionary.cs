namespace SelatoLib.Client.Misc.Collections;

public class _FixedSizeDictionary<TKey, TValue> 
    where TKey : struct
    where TValue : struct
{
    private readonly KeyValue<TKey, TValue>?[] _items = new KeyValue<TKey, TValue>?[Max];
    private int _count;
    private const int Max = 1024;
    
    public void Set(TKey key, TValue value)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i] == null)
                continue;
            
            
            if (!EqualityComparer<TKey>.Default.Equals(_items[i]!.Key, key)) continue;
                _items[i]!.Value = value;
                return;
        }
        for (var i = 0; i < _count; i++)
        {
            if (_items[i] != null) continue;
            _items[i] = new KeyValue<TKey, TValue>(key, value);
            return;
        }

        var keyValue = new KeyValue<TKey, TValue>(key, value);
        _items[_count++] = keyValue;
    }

    /// <summary>
    /// Check if the dictionary contains the specified key.
    /// This method is case-sensitive.
    /// </summary>
    /// <param name="key">Key</param>
    /// <returns><b>true</b> if key is found</returns>
    internal bool Contains(TKey key)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i]?.Key.Equals(key) != true)
            {
                continue;
            }
            
            return true;
        }
        return false;
    }

    /// <summary>
    /// Get the specified key.
    /// This method is case-sensitive.
    /// </summary>
    /// <param name="key">Key</param>
    /// <returns><b>Stored value</b> when key is found in collection, <b>-1</b> otherwise.</returns>
    internal TValue? Get(TKey key)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i]?.Key.Equals(key) != true)
            {
                continue;
            }
            
            return _items[i]?.Value;
        }
        return null;
    }

    /// <summary>
    /// Remove the specified key.
    /// This method is case-sensitive.
    /// </summary>
    /// <param name="key">Key</param>
    /// <returns><b>true</b> if key is found in collection, <b>false</b> otherwise.</returns>
    public bool Remove(TKey key)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i]?.Key.Equals(key) != true)
            {
                continue;
            }
            
            _items[i] = null;
            return true;
        }
        return false;
    }
}