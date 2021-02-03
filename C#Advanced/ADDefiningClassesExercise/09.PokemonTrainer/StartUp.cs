using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            List<Trainer> trainers = new List<Trainer>();
            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] tokens = input.Split();
                Pokemon pokemon = new Pokemon(tokens[1], tokens[2]
                    , int.Parse(tokens[3]));
                if (!trainers.Any(x => x.Name == tokens[0]))
                {
                    Trainer trainer = new Trainer(tokens[0], 0
                        , new List<Pokemon>());
                    trainers.Add(trainer);
                }
                Trainer currentTrainer = trainers.FirstOrDefault(x => x.Name == tokens[0]);
                currentTrainer.Pokemons.Add(pokemon);
            }

            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Fire")
                {
                    Play(input, trainers);
                }
                else if (input == "Electricity")
                {
                    Play(input, trainers);
                }
                else if (input == "Water")
                {
                    Play(input, trainers);
                }
            }

            foreach (var trainer in trainers
                .OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        public static void Play(string input, List<Trainer> trainers)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(x => x.Element == input))
                {
                    trainer.Badges++;
                }
                else
                {
                    trainer.Pokemons.Select(x => x.Health -= 10).ToList();
                    trainer.Pokemons= trainer.Pokemons.Where(x => x.Health > 0).ToList();
                }
            }
        }
    }
}
