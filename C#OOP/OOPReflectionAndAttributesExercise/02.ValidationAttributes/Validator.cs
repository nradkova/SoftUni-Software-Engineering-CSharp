using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var allProperties = obj.GetType().GetProperties();
            foreach (var prop in allProperties)
            {
                var currPropValue = prop.GetValue(obj);
                var attributes = prop.GetCustomAttributes<MyValidationAttribute>();
                foreach (var attr in attributes)
                {
                    if (!attr.IsValid(currPropValue))
                    {
                        return false;
                    }
                    //if (attr is MyRangeAttribute)
                    //{
                    //   if(((MyRangeAttribute)attr).IsValid(currPropValue)==false)
                    //    {
                    //        return false;
                    //    }
                    //}
                    //if (attr is MyRequiredAttribute)
                    //{
                    //    if (((MyRequiredAttribute)attr).IsValid(currPropValue) == false)
                    //    {
                    //        return false;
                    //    }
                    //}
                }
            }
            return true;
        }
    }
}
