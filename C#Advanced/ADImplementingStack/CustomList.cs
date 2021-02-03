using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ADImplementStacks
{
    public class CustomList
    {
        private const int INITIAL_CAPACITY = 2;

        private  int[] items;

        public CustomList()
        {
            this.items = new int[INITIAL_CAPACITY];
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (!this.IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (!this.IsValidIndex(index))
                {
                    throw new ArgumentOutOfRangeException();
                }
                this.items[index] = value;
            }
        }

        public void Add(int item)
        {
            if (this.Count==this.items.Length)
            {
                this.Resize();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            if (!this.IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            int removedItem = this.items[index];
            this.items[index] = default(int);
            this.ShiftLeft(index);
            this.Count--;

            if (this.Count<=this.items.Length/4)
            {
                this.Shrink();
            }
            return removedItem;
        }

        public bool Contains(int item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item==items[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int index1,int index2)
        {
            if (this.IsValidIndex(index1)
                && this.IsValidIndex(index2))
            {
                int temp = this.items[index1];
                this.items[index1] = this.items[index2];
                this.items[index2] = temp;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Insert(int index,int item )
        {
            if (!this.IsValidIndex(index))
            {
                throw new ArgumentOutOfRangeException();
            }
            if (this.Count==this.items.Length)
            {
                this.Resize();
            }
            this.ShiftRight(index);
            this.items[index] = item;
            this.Count++;
        }
        private void Resize()
        {
            int[] copy = new int[this.items.Length * 2];
            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = this.items[i];
            }
           this.items = copy;
        }

        private void Shrink()
        {
            int[] copy = new int[this.items.Length / 2];
            for (int i = 0; i < this.items.Length/2; i++)
            {
                copy[i] = this.items[i];
            }
           this.items = copy;
        }

        private void  ShiftLeft(int index)
        {
            for (int i = index; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            for (int i = this.Count - 1; i < this.items.Length; i++)
            {
                this.items[i] = default;
            }
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count; i >index; i--)
            {
                this.items[i] = this.items[i-1];
            }
        }

        private bool IsValidIndex(int index)
             => index < this.Count;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count; i++)
            {
                if (i==this.Count-1)
                {
                    sb.Append($"{this.items[i]}");
                }
                else
                {
                    sb.Append($"{this.items[i]}, ");
                }
            }
            return sb.ToString().Trim();
        }
    }
}
