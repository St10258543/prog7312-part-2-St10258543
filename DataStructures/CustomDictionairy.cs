using System;
using System.Collections.Generic;
using System.Linq;

namespace MunicipalityApp.Data
{
    public class CustomDictionary<TKey, TValue>
    {
        // Internal list to store key-value pairs 
        private readonly List<(TKey Key, TValue Value)> _entries = new();

        // Add a new key-value pair
        public void Add(TKey key, TValue value)
        {
            if (ContainsKey(key))
                throw new ArgumentException("Key already exists");

            _entries.Add((key, value));
        }

        // Check if the dictionary contains a specific key
        public bool ContainsKey(TKey key) => 
            _entries.Any(e => EqualityComparer<TKey>.Default.Equals(e.Key, key));

        // Indexer to get or set values by key
        public TValue this[TKey key]
        {
            get
            {
                // Find the first entry with the matching key
                var entry = _entries.FirstOrDefault(e => EqualityComparer<TKey>.Default.Equals(e.Key, key));

                // If no matching entry found, throw KeyNotFoundException
                if (EqualityComparer<(TKey, TValue)>.Default.Equals(entry, default))
                    throw new KeyNotFoundException();

                return entry.Value;
            }
            set
            {
                // Search for the key and update value if found
                for (int i = 0; i < _entries.Count; i++)
                {
                    if (EqualityComparer<TKey>.Default.Equals(_entries[i].Key, key))
                    {
                        _entries[i] = (key, value); 
                        return;
                    }
                }

                // If key not found, add new key-value pair
                _entries.Add((key, value));
            }
        }

        // Enumerate all keys in the dictionary
        public IEnumerable<TKey> Keys => _entries.Select(e => e.Key);

        // Enumerate all values in the dictionary
        public IEnumerable<TValue> Values => _entries.Select(e => e.Value);

        // Count of key-value pairs in the dictionary
        public int Count => _entries.Count;
    }
}
