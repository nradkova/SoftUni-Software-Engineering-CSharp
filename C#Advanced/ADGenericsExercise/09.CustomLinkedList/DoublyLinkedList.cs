using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private class ListNode
        {
            public ListNode(T value)
            {
                Value = value;
            }
            public ListNode NextNode { get; set; }
            public ListNode PreviousNode { get; set; }
            public T Value { get; set; }
        }

        private ListNode head;
        private ListNode tail;
        
        public int Count { get; set; }

        public void AddFirst(T element)
        {
            var currentNode = new ListNode(element);
            if (Count == 0)
            {
                this.head = this.tail = currentNode;
            }
            else
            {
                currentNode.NextNode = this.head;
                this.head.PreviousNode = currentNode;
                this.head = currentNode;
            }
            Count++;
        }
        public void AddLast(T element)
        {
            var currentNode = new ListNode(element);

            if (Count == 0)
            {
                this.head = this.tail = currentNode;
            }
            else
            {
                currentNode.PreviousNode = this.tail;
                this.tail.NextNode = currentNode;
                this.tail = currentNode;
            }
            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T firstElement = this.head.Value;
            if (Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.head = this.head.NextNode;
                this.head.PreviousNode = null;
            }
            Count--;
            return firstElement;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            T lastElement = this.tail.Value;
            if (Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                this.tail = this.tail.PreviousNode;
                this.tail.NextNode = null;

            }
            Count--;
            return lastElement;
        }
        public void ForEach(Action<T> action)
        {
            var element = this.head;
            while (element != null)
            {
                action(element.Value);
                element = element.NextNode;
            }
        }
        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            var element = this.head;
            while (element != null)
            {
                array[index] = element.Value;
                element = element.NextNode;
                index++;
            }
            return array;
        }
    }

}
