namespace SelatoLib.Client.Misc.Collections;


/// <summary>
/// TODO: migrate to Dictionary
/// </summary>
public class FixedSizeDictionary<TKey, TValue>
{
    private readonly KeyValue<TKey, TValue>?[] _items = new KeyValue<TKey, TValue>?[Max];
    private int _count = 0;
    private const int Max = 1024;

    /// <summary>
    /// Set the specified key to the specified value.
    /// </summary>
    /// <param name="key">Key</param>
    /// <param name="value">Value to set</param>
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
            _items[i] = new KeyValue<TKey, TValue>(key)
            {
                Value = value
            };
            return;
        }

        var keyValue = new KeyValueStringInt
        {
            Key = key,
            Value = value
        };
        _items[_count++] = keyValue;
    }

    /// <summary>
    /// Check if the dictionary contains the specified key.
    /// This method is case-sensitive.
    /// </summary>
    /// <param name="key">Key</param>
    /// <returns><b>true</b> if key is found</returns>
    internal bool Contains(string key)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i] == null)
            {
                continue;
            }

            if (_items[i]?.Key != key)
                continue;
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
    internal int? Get(string key)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i] == null)
            {
                continue;
            }
            if (_items[i]?.Key != key)
                continue;
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
    public bool Remove(string key)
    {
        for (var i = 0; i < _count; i++)
        {
            if (_items[i] == null)
            {
                continue;
            }

            if (_items[i]?.Key != key) continue;
            _items[i] = null;
            return true;
        }
        return false;
    }
}