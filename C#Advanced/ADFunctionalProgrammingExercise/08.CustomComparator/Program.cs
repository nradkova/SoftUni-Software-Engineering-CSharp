using System;
using System.Collections;
using System.Collections.Immutable;
using System.Linq;

namespace _08.CustomComparator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split()
              .Select(int.Parse)
              .ToArray();

            Func<int[], int[]> orderByValue = Sort;
            Func<int, bool> filterEven = X => X % 2 == 0;
            int[] sortedArr = new int[numbers.Length];

            numbers = orderByValue(numbers).ToArray();
            FindEvenOdd(numbers, filterEven, sortedArr);

            Console.WriteLine(string.Join(" ", sortedArr));
        }

        private static int[] FindEvenOdd(int[] numbers, Func<int, bool> filterEven, int[] sortedArr)
        {
            int indexSortedArr = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (filterEven(numbers[i]))
                {
                    sortedArr[indexSortedArr] = numbers[i];
                    indexSortedArr++;
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                if (!filterEven(numbers[i]))
                {
                    sortedArr[indexSortedArr] = numbers[i];
                    indexSortedArr++;
                }
            }
            return sortedArr;
        }

        static int[] Sort(int[] arr)
        {
            int[] sortedArr = new int[arr.Length];
            int minValue = int.MaxValue;
            int indexSortedArr = 0;
            int indexInitialArr = 0;
            while (arr.Any(x => x != int.MaxValue))
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] < minValue)
                    {
                        minValue = arr[i];
                        sortedArr[indexSortedArr] = minValue;
                        indexInitialArr = i;
                    }
                }
                indexSortedArr++;
                arr[indexInitialArr] = int.MaxValue;
                minValue = int.MaxValue;
            }
            return sortedArr;
        }
    }
}
