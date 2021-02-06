using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Factories
{
   public  class FoodFactory
    {
        public Food CreateFood(string strType,int quantity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes()
                .FirstOrDefault(x => x.Name == strType);
            if (type==null)
            {
                throw new InvalidOperationException
                    (Common.ExceptionMessages.InvalidType);
            }
            object[] ctorParams = new object[] { quantity };
            Food food =(Food) Activator.CreateInstance(type, ctorParams);
            return food;
        }
    }
}
