namespace SelatoLib.Client.Misc.Collections;

public class DictionaryStringAudioSample
{
    public DictionaryStringAudioSample()
    {
        max = 1024;
        count = 0;
        keys = new string[max];
        values = new AudioSampleCi[max];
    }

    string[] keys;
    AudioSampleCi[] values;
    int max;
    int count;

    public void Set(string key, AudioSampleCi value)
    {
        int index = GetIndex(key);
        if (index != -1)
        {
            values[index] = value;
            return;
        }
        keys[count] = key;
        values[count] = value;
        count++;
    }

    public bool Contains(string key)
    {
        int index = GetIndex(key);
        return index != -1;
    }

    public AudioSampleCi Get(string key)
    {
        int index = GetIndex(key);
        return values[index];
    }

    public int GetIndex(string key)
    {
        for (int i = 0; i < count; i++)
        {
            if (keys[i] == key)
            {
                return i;
            }
        }
        return -1;
    }
}