using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        public Engine()
        {
            soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string soldierType = tokens[0];
                int soldierId = int.Parse(tokens[1]);
                string firstName = tokens[2];
                string lastName = tokens[3];
                CreatePrivate(tokens, soldierType, soldierId, firstName, lastName);
                CreateSpy(tokens, soldierType, soldierId, firstName, lastName);
                CreateLieutenantGeneral(tokens, soldierType, soldierId, firstName, lastName);
                CreateCommando(tokens, soldierType, soldierId, firstName, lastName);
                CreateEngineer(tokens, soldierType, soldierId, firstName, lastName);
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private void CreateEngineer(string[] tokens, string soldierType, int soldierId, string firstName, string lastName)
        {
            if (soldierType == typeof(Engineer).Name)
            {
                decimal salary = decimal.Parse(tokens[4]);
                List<IRepair> repairs = new List<IRepair>();
                SoldierCropEnum crop;
                if (Enum.TryParse(tokens[5], out crop))
                {
                    for (int i = 6; i < tokens.Length - 1; i++)
                    {
                        string partName = tokens[i];
                        int hours = int.Parse(tokens[i + 1]);
                        var repair = new Repair(partName, hours);
                        repairs.Add(repair);
                        i++;
                    }

                    ISoldier currentSoldier = new Engineer(soldierId, firstName, lastName, salary, crop, repairs);
                soldiers.Add(currentSoldier);
                   
                }
            }
        }

        private void CreateCommando(string[] tokens, string soldierType, int soldierId, string firstName, string lastName)
        {
            if (soldierType == typeof(Commando).Name)
            {
                decimal salary = decimal.Parse(tokens[4]);
                List<IMission> missions = new List<IMission>();
                SoldierCropEnum crop;
                if (Enum.TryParse(tokens[5], out crop))
                {
                    for (int i = 6; i < tokens.Length - 1; i++)
                    {
                        string missionName = tokens[i];
                        string missionState = tokens[i + 1];
                        MissionStateEnum missionStateEnum;
                        if (Enum.TryParse(missionState, out missionStateEnum))
                        {
                            var mission = new Mission(missionName, missionStateEnum);
                            missions.Add(mission);
                        }
                        i++;
                    }

                ISoldier currentSoldier = new Commando(soldierId, firstName, lastName, salary, crop, missions);
                soldiers.Add(currentSoldier);
                }
            }
        }

        private void CreateLieutenantGeneral(string[] tokens, string soldierType, int soldierId, string firstName, string lastName)
        {
            if (soldierType == typeof(LieutenantGeneral).Name)
            {
                decimal salary = decimal.Parse(tokens[4]);
                List<IPrivate> privates = new List<IPrivate>();
                for (int i = 5; i < tokens.Length; i++)
                {
                    IPrivate searchedPrivate =
                        (IPrivate)soldiers.FirstOrDefault(s => s.Id == int.Parse(tokens[i])&& s.GetType().Name=="Private");
                    if (searchedPrivate != null)
                    {
                        privates.Add(searchedPrivate);
                    }
                }
                ISoldier currentSoldier = new LieutenantGeneral
                    (soldierId, firstName, lastName, salary, privates);
                soldiers.Add(currentSoldier);
            }
        }

        private void CreateSpy(string[] tokens, string soldierType, int soldierId, string firstName, string lastName)
        {
            if (soldierType == typeof(Spy).Name)
            {
                int codeNumber = int.Parse(tokens[4]);
                ISoldier currentSoldier = new Spy(soldierId, firstName, lastName, codeNumber);
                soldiers.Add(currentSoldier);
            }
        }

        private void CreatePrivate(string[] tokens, string soldierType, int soldierId, string firstName, string lastName)
        {
            if (soldierType == typeof(Private).Name)
            {
                decimal salary = decimal.Parse(tokens[4]);
                ISoldier currentSoldier = new Private(soldierId, firstName, lastName, salary);
                soldiers.Add(currentSoldier);
            }
        }
    }
}
