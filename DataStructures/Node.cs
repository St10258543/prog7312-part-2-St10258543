using MunicipalityApp.Models;

namespace MunicipalityApp.DataStructures
{
    public class Node
    {
        // Stores the actual issue object
        public Issues Data { get; set; }

        // Pointer to the next node in the list
        public Node Next { get; set; }

        // Constructor initializes the node with an issue
        public Node(Issues data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data), "Issue data cannot be null");

            Data = data;
            Next = null;
        }
    }
}