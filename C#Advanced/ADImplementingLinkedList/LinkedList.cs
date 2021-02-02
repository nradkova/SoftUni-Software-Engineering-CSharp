using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        public void AddHead(Node newHead)
        {
            if (Head == null)
            {
                Head = newHead;
                Tail = newHead;
            }
            else
            {
                newHead.Next = Head; //next of newHead is Head
                Head.Previous = newHead; //previous of Head is newHead
                Head = newHead;  //newHead becomes Head
            }
        }

        public void AddTail(Node newTail)
        {
            if (Tail == null)
            {
                Head = newTail;
                Tail = newTail;
            }
            else
            {
                Tail.Next = newTail;
                newTail.Previous = Tail;
                Tail = newTail;
            }
        }
        public void ForEach(Action<Node>action)
        {
            Node currentNode = Head;  //foreach is function to declared to 
            while (currentNode!=null) // each element
            {
                action(currentNode);
                currentNode = currentNode.Next;
            }
        }
        public void Print()
        {
            ForEach(node => Console.WriteLine(node.Value));

            //    Node currentNode = Head;
            //    while (currentNode != null)
            //    {
            //        Console.WriteLine(currentNode.Value);
            //        currentNode = currentNode.Next;
            //    }
        }
        public void ReversePrint()
        {
            Node currentNode = Tail;
            while (currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                currentNode = currentNode.Previous;
            }
        }
        public int RemoveFirst() //Pop()
        {
            Node oldHead = Head;
            Head = oldHead.Next;
            return oldHead.Value;
        }
        public int RemoveLast() //Pop()
        {
            Node oldTail = Tail;
            Tail = oldTail.Previous;
            return oldTail.Value;
        }
        public int Peek()
        {
            return Head.Value;
        }
        public List<Node> TurnToList()
        {
            List<Node> newList = new List<Node>();
            ForEach(node => newList.Add(node));
            return newList;
        }

        public List<int> ToListValues()
        {
            List<int> newList = new List<int>();
            ForEach(node => newList.Add(node.Value));
            return newList;
        }
    }
}
