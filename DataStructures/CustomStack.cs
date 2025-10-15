using System;
using System.Collections;
using System.Collections.Generic;

namespace MunicipalityApp.DataStructures
{
    public class CustomStack<T> : IEnumerable<T>
    {
        // Reference to the top node in the stack
        private Node<T>? top;

        // Count of items in the stack
        private int count;

        // Internal Node class to represent each stack element
        private class Node<TValue>
        {
            public TValue Data;          
            public Node<TValue>? Next;   

            public Node(TValue data)
            {
                Data = data;             
            }
        }

        // Push a new item onto the stack
        public void Push(T item)
        {
            var newNode = new Node<T>(item)
            {
                Next = top              
            };
            top = newNode;             
            count++;                  
        }

        // Remove and return the item at the top of the stack
        public T Pop()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty"); 

            var value = top.Data;     
            top = top.Next;            
            count--;                   
            return value;              
        }

        // Return the item at the top without removing it
        public T Peek()
        {
            if (top == null)
                throw new InvalidOperationException("Stack is empty"); // Cannot peek empty stack

            return top.Data;          
        }

        // Return the number of items in the stack
        public int Count => count;

        // Enumerate through the stack from top to bottom
        public IEnumerator<T> GetEnumerator()
        {
            var current = top;
            while (current != null)
            {
                yield return current.Data; 
                current = current.Next;   
            }
        }

        // Non-generic enumerator implementation
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
