using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
   public class EqualityScale<T> where T : IComparable
    {
        private T left;
        private T right;

        public EqualityScale(T left,T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            if (this.right.CompareTo(this.left)==0)
            {
                return true;
            }
            return false;
        }


    }
}
