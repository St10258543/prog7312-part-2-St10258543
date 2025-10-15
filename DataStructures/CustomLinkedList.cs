using System;
using System.Collections.Generic;
using MunicipalityApp.Models;


namespace MunicipalityApp.DataStructures
{
    // A simple custom singly linked list used to store and retrieve issues
    public class CustomLinkedList
    {
        private Node head;   // First node in the list
        private int count;   // Tracks number of issues

        public CustomLinkedList()
        {
            head = null;
            count = 0;
        }

        // Adds a new issue to the end of the linked list
        public void Add(Issues issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            var newNode = new Node(issue);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            count++;
        }

        // Retrieves all issues currently stored in the list
        public IEnumerable<Issues> GetAll()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Gets the total number of issues in the list
        public int Count => count;

        // Clears all issues from the list
        public void Clear()
        {
            head = null;
            count = 0;
        }

        // Node class used internally by CustomLinkedList
        private class Node
        {
            public Issues Data { get; }
            public Node? Next { get; set; }

            public Node(Issues data)
            {
                Data = data;
                Next = null;
            }
        }
    }

    // Static wrapper to provide global access to the in-memory Issues list.
    public static class CustomIssues
    {
        public static CustomLinkedList IssuesList { get; } = new CustomLinkedList();
    }
}
