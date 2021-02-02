using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            CustomStack<int> stack = new CustomStack<int>();
            while ((input=Console.ReadLine())!="END")
            {
                string[] data = input.Split(new char[] { ',',' '}
                    ,StringSplitOptions.RemoveEmptyEntries);
                if (data[0]=="Push")
                {
                    int[] numbers = data.Skip(1).Select(int.Parse).ToArray();
                    stack.Push(numbers);
                }
                else
                {
                    stack.Pop();
                }
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
