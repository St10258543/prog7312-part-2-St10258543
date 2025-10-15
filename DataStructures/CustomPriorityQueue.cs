using System;
using System.Collections.Generic;
using System.Linq;
using MunicipalityApp.Models;

namespace MunicipalityApp.DataStructures
{
    public class CustomPriorityQueue<T>
    {
        // Internal list storing items along with their priority
        private readonly List<(T Item, DateTime Priority)> _items = new();

        // Add an item with a specified priority to the queue
        // The queue is sorted by priority (earliest date first)
        public void Enqueue(T item, DateTime priority)
        {
            _items.Add((item, priority));
            _items.Sort((a, b) => a.Priority.CompareTo(b.Priority)); // Keep items sorted by priority
        }

        // Remove and return the item with the highest priority (earliest date)
        public T Dequeue()
        {
            if (_items.Count == 0)
                throw new InvalidOperationException("Queue is empty"); // Error if queue is empty

            var item = _items[0]; // Get first item
            _items.RemoveAt(0);   // Remove it from the list
            return item.Item;     // Return the dequeued item
        }

        // Enumerate items without their priority
        public IEnumerable<T> UnorderedItems => _items.Select(x => x.Item);

        // Get all items as a list (ignores priority)
        public List<T> GetAllElements()
        {
            return _items.Select(x => x.Item).ToList();
        }

        // Duplicate of GetAllElements; returns all items as a list
        public List<T> dGetAllElements()
        {
            return _items.Select(x => x.Item).ToList();
        }

        // Number of items currently in the queue
        public int Count => _items.Count;
    }
}
