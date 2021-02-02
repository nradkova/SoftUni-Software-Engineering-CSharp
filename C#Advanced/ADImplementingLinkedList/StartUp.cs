using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    class StartUp
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            for (int i = 0; i < 10; i++)
            {
                list.AddHead(new Node(i));
            }
            // 9 8 7 6 5 4 3 2 1 0
           
            list.Print();
            //list.Pop(); //9
            //list.Pop(); //8

            Console.WriteLine("--------");
            list.AddTail(new Node(1000));

            // 7 6 5 4 3 2 1 0 1000
            list.Print();

            List<int> values = list.ToListValues();
            Console.WriteLine(string.Join(" * ",values));
        }
    }
}
