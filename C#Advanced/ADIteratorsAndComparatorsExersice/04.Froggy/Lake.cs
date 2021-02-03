using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;
        private int count;
        public Lake(params int[] stones)
        {
            this.stones = stones.ToList();
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stones.Count; i ++)
            {
                if (i % 2 == 0)
                {
                    yield return stones[i];
                }
            }
            for (int i = stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
