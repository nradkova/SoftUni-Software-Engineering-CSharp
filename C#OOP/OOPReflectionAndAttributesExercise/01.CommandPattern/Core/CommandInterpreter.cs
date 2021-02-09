using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core

{
    public class CommandInterpreter : ICommandInterpreter
    {
       
        public string Read(string args)
        {
            string[] commandArgs = args.Split
                (" ",StringSplitOptions.RemoveEmptyEntries);
            
            string commandType = (commandArgs[0] + "Command").ToLower();

            Type type = Assembly.GetCallingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandType);

            ICommand command = (ICommand)Activator.CreateInstance(type);
           
            return command.Execute(commandArgs.Skip(1).ToArray());
        }
    }
}
