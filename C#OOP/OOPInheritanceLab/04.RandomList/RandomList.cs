using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        //private List<T> list;
        ////private int index;

        public string RandomString()
        {
            Random rand = new Random();
            int index = rand.Next(0, this.Count);
            string item = this[index];
            this.RemoveAt(index);
            return item;
        }
    }
}
