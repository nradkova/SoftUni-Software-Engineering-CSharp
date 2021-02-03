using System;

namespace SelectionSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] num = new int[] { 3, 3, 5, 1, 3, 9, 0 };
            for (int i = 0; i < num.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < num.Length; j++)
                {
                    if (num[min] > num[j])
                    {
                        min = j;
                    }
                }
                int temp = num[min];
                num[min] = num[i];
                num[i] = temp;
              
            }
            Console.WriteLine(string.Join(" ",num));
        }
    }
}
