using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue,int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }
        public int MinValue { get;}
        public int MaxValue { get;}

        public override bool IsValid(object obj)
        {
            if ((int)obj>=MinValue&&(int)obj<=MaxValue)
            {
                return true;
            }
            return false;
        }
    }
}
