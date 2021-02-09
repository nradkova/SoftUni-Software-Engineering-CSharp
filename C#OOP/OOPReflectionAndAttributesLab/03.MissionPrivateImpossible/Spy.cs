using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fieldsNames)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] fieldsSearched = classType
                .GetFields(BindingFlags.NonPublic
                | BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.Static);
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
        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] nonPublicFields = classType
                .GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] publicMethods = classType
               .GetMethods(BindingFlags.Instance
               | BindingFlags.Public | BindingFlags.Static);
            MethodInfo[] nonPublicMethods = classType
               .GetMethods(BindingFlags.Instance| BindingFlags.NonPublic);


            foreach (var field in nonPublicFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
            foreach (var method in nonPublicMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                sb.AppendLine($"{method.Name} have to be public!");
                }
            }
            foreach (var method in publicMethods)
            {
                if (method.Name.StartsWith("set"))
                {
                sb.AppendLine($"{method.Name} have to be private!");
                }
            }
            return sb.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string  className)
        {
            Type classType =Type.GetType(className);
            MethodInfo[] privateMethods = classType.
                GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType}");
            foreach (var method in privateMethods)
            {
                sb.AppendLine($"{method.Name}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
