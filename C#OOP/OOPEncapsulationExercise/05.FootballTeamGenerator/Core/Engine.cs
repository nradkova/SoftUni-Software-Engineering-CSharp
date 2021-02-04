using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using _05.FootballTeam.Common;

using _05.FootballTeam.Models;


namespace _05.FootballTeam.Core
{
   public class Engine
    {
        private List<Team> teams;
        public Engine()
        {
            teams = new List<Team>();
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split(";");
                try
                {
                    if (tokens[0]=="Team")
                    {
                        Team team = new Team(tokens[1]);
                        teams.Add(team);
                    }

                    if (tokens[0] == "Add")
                    {
                        Team team = ValidateTeam(tokens[1]);
                        team.AddPlayer(new Player(tokens[2]
                            , int.Parse(tokens[3]), int.Parse(tokens[4])
                            , int.Parse(tokens[5]), int.Parse(tokens[6])
                            , int.Parse(tokens[7])));
                    }

                    if (tokens[0] == "Remove")
                    {
                        Team team = ValidateTeam(tokens[1]);
                        team.RemovePlayer(tokens[2]);
                    }

                    if (tokens[0] == "Rating")
                    {
                        Team team = ValidateTeam(tokens[1]);
                        Console.WriteLine($"{team.Name} - {team.Rating}");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

        }

        private Team ValidateTeam(string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);
            if (team ==null)
            {
                throw new ArgumentException
                    (string.Format(GlobalConstants.NONEXIST_TEAM_EXC_MSG, teamName));
            }
            return team;
        }
    }
}
