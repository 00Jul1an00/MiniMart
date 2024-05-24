using System;

namespace MiniMart
{
    [Serializable]
    public struct SerializebleKeyValuePair<TKey, TValue>
    {
        public TKey Key;
        public TValue Value;

        public SerializebleKeyValuePair(TKey key, TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}