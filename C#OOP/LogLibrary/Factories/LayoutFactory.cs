using System;
using System.Linq;
using System.Reflection;

using LogLibrary.Common;
using LogLibrary.Models.Contracts;

namespace LogLibrary.Factories
{
   public  class LayoutFactory
    {
        public LayoutFactory()
        {

        }
        public ILayout CreateLayout(string layoutStr)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type layoutType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.Equals( layoutStr,
                StringComparison.InvariantCultureIgnoreCase));
            if (layoutType==null)
            {
                throw new InvalidOperationException(
                    GlobalConstants.InvalidLevelType);
            }
            object[] ctorArgs = new object[] { };
            ILayout layout = (ILayout)Activator
                .CreateInstance(layoutType,ctorArgs);
            return layout;
        }
    }
}
