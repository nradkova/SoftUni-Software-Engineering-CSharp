using System;
using System.Collections.Generic;
using System.Text;

namespace DoublyLinkedList
{
   public class ListNode<T>
    {
        public ListNode<T> NextNode { get; set; }
        public ListNode<T> PreviousNode { get; set; }
        public T Value { get; set; }
    }
}
