using System;

namespace ADImplementStacks
{
    class StartUp
    {
        static void Main(string[] args)
        {
            //CustomList list = new CustomList();

            //for (int i = 1; i <= 5; i++)
            //{
            //    list.Add(i);
            //}
            //list.Insert(1, 6);
            //list.RemoveAt(1);
            //list.Swap(1, 3);
            //Console.WriteLine(list);

            CustomStack stack = new CustomStack();
            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i);
            }

            stack.ForEach(num => Console.WriteLine(num));

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine(stack.Pop());
            }

            stack.Pop(); //exception

            
        }
    }
}
