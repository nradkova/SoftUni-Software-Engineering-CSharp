using System;
using System.Linq;

using PlayersAndMonsters.IO.Contracts;
using PlayersAndMonsters.Core.Contracts;

namespace PlayersAndMonsters.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IManagerController managerController;

        public Engine(IReader reader, IWriter writer,
            IManagerController managerController)
        {
            this.reader = reader;
            this.writer = writer;
            this.managerController = managerController;
        }

        public void Run()
        {
            while (true)
            {
                string line = reader.ReadLine();
                if (line == "Exit")
                {
                    break;
                }
                string[] lineArgs = line.Split();
                string command = lineArgs[0];
                string[] inputArgs = lineArgs.Skip(1).ToArray();
                string output = string.Empty;

                try
                {
                    output = ExecuteCommand(command, inputArgs);
                }
                catch (ArgumentException ae)
                {

                    output = ae.Message;
                }
              
                writer.WriteLine(output);
            }
        }

        private string ExecuteCommand(string command, string[] inputArgs)
        {
            string output = string.Empty;
            if (command == "AddPlayer")
            {
                output = managerController.AddPlayer(inputArgs[0],
                   inputArgs[1]);
            }
            else if (command == "AddCard")
            {
                output = managerController.AddCard(inputArgs[0],
                   inputArgs[1]);
            }
            else if (command == "AddPlayerCard")
            {
                output = managerController.AddPlayerCard(inputArgs[0],
                   inputArgs[1]);
            }
            else if (command == "Fight")
            {
                output = managerController.Fight(inputArgs[0],
                   inputArgs[1]);
            }
            else if (command == "Report")
            {
                output = managerController.Report();
            }
            return output;
        }
    }
}
