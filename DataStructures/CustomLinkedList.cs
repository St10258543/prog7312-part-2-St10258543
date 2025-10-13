using System;
using System.Collections.Generic;
using MunicipalityApp.Models;

namespace MunicipalityApp.DataStructures
{
    public class CustomLinkedList
    {
        private Node head; 
        private int count; 

        public CustomLinkedList()
        {
            head = null;
            count = 0;
        }

        // Add issue to end of list
        public void Add(Issues issue)
        {
            if (issue == null)
                throw new ArgumentNullException(nameof(issue));

            var newNode = new Node(issue);

            if (head == null)
                head = newNode;
            else
            {
                Node current = head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }

            count++;
        }

        // Get all issues
        public IEnumerable<Issues> GetAll()
        {
            Node current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        // Count property
        public int Count => count;


        // Clear all issues
        public void Clear()
        {
            head = null;
            count = 0;
        }
    }

    // Static wrapper to allow global access
    public static class CustomIssues
    {
        public static CustomLinkedList IssuesList { get; } = new CustomLinkedList();
    }
}
