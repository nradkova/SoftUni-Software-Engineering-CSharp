using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
      public  string StealFieldInfo(string className,params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsSearched = classType
                .GetFields(BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Public|BindingFlags.Static);
            var classInstance = Activator
                .CreateInstance(classType, new object[] { });
            sb.AppendLine($"Class under investigation: {classInstance.GetType().FullName}");
            foreach (var field in fieldsSearched)
            {
                if (fieldsNames.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
