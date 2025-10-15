using System.Collections.Generic;

namespace MunicipalityApp.Data
{
    public class CustomHashSet<T>
    {
        // Internal list to store unique items
        private readonly List<T> _items = new();

        // Add an item to the set
        // Returns false if the item already exists, true if added successfully
        public bool Add(T item)
        {
            if (_items.Contains(item)) // Check for duplicates
                return false;

            _items.Add(item); // Add new unique item
            return true;
        }

        // Check if the set contains a specific item
        public bool Contains(T item) => _items.Contains(item);

        // Number of unique items in the set
        public int Count => _items.Count;

        // Enumerate all items in the set
        public IEnumerable<T> Items => _items;
    }
}
