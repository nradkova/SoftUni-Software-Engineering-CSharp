using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
   public class StackOfStrings:Stack<string>
    {

        public bool IsEmpty()
        {
            if (this.Count==0)
            {
                return true;
            }
            return false;
        }
        public Stack<string> AddRange()
        {
            Stack<string> stack = new Stack<string>();
            while (this.Count>0)
            {
                stack.Push(this.Pop());
            }
            return stack;
        }
    }
}
