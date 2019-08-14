using System.Collections.Generic;

namespace Reggora.Api.Util
{
    public class EventEmittingDictionary<K, V> : Dictionary<K, V>
    {
        public delegate void DictionaryChanged();

        private readonly DictionaryChanged _modifyCallback;

        public EventEmittingDictionary(DictionaryChanged modifyCallback)
        {
            _modifyCallback = modifyCallback;
        }

        public new void Add(K key, V value)
        {
            base.Add(key, value);

            _modifyCallback?.Invoke();
        }

        public new void Remove(K key)
        {
            base.Remove(key);

            _modifyCallback?.Invoke();
        }

        public new void Clear()
        {
            base.Clear();

            _modifyCallback?.Invoke();
        }
    }
}