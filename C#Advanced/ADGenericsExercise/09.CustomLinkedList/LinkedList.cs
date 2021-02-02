using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class CustomLinkedList<T>
    {
      
        public Element<T> Head { get; set; }
        public Element<T> Tail { get; set; }

        public void AddHead(Element<T> element)
        {
            if (Head == null)
            {
                Head = element;
                Tail = element;
            }
            else
            {
                element.Next = Head; 
                Head.Previous = element;
                Head = element; 
            }
        }
        public void AddTail(Element<T> element)
        {
            if (Tail == null)
            {
                Head = element;
                Tail = element;
            }
            else
            {
                Tail.Next = element;
                element.Previous = Tail;
                Tail = element;
            }
        }
    }
       
}
