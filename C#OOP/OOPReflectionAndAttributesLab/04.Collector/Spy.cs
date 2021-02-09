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
        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] requiredMethods = classType.GetMethods
                (BindingFlags.Public | BindingFlags.Instance
                | BindingFlags.NonPublic | BindingFlags.Static);

            MethodInfo[] getMethods = requiredMethods.Where(m => m.Name.StartsWith("get")).ToArray();
            
            MethodInfo[] setMethods = requiredMethods.Where(m => m.Name.StartsWith("set")).ToArray();
           
            //MethodInfo[] sortedMethods = getMethods.Concat(setMethods).ToArray();

           StringBuilder sb = new StringBuilder();
            foreach (var method in getMethods)
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            foreach (var method in setMethods)
            {
                sb.AppendLine($"{ method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
