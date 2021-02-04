using System;
using System.Collections.Generic;
using System.Text;
using _05.FootballTeam.Common;

namespace _05.FootballTeam.Models
{
    public class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
       
        public Player(string name, int endurance,
            int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Shooting = shooting;
            Passing = passing;
            Dribble = dribble;
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value)||string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME_EXC_MSG);
                }
                name = value;
            }
        }
        private int Endurance
        {
            get { return endurance; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.INVALID_STAT_EXC_MSG,nameof(Endurance)));
                }
               endurance = value;
            }
        }
        private int Sprint
        {
            get { return sprint; }
            set 
            {
                if (value<0||value>100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.INVALID_STAT_EXC_MSG, nameof(Sprint)));
                }
                sprint = value;
            }
        }
        private int Dribble
        {
            get { return dribble; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                       (string.Format(GlobalConstants.INVALID_STAT_EXC_MSG, nameof(Dribble)));
                }
                dribble = value;
            }
        }
        private int Passing
        {
            get { return passing; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                       (string.Format(GlobalConstants.INVALID_STAT_EXC_MSG, nameof(Passing)));
                }
                passing = value;
            }
        }
        private int Shooting
        {
            get { return shooting; }
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException
                        (string.Format(GlobalConstants.INVALID_STAT_EXC_MSG, nameof(Shooting)));
                }
                shooting = value;
            }
        }
        public double Stats
        {
            get { return (Endurance + Sprint + Shooting + Dribble + Passing) / 5.0 ; }
        }
    }
}
