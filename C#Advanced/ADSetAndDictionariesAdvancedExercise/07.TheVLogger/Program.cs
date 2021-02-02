using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheVLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Status> vloggers = new Dictionary<string, Status>();
            string input = string.Empty;
            while ((input = Console.ReadLine())!= "Statistics")
            {
                string name = input.Split()[0];
                string command = input.Split()[1];
                if (command=="joined")
                {
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers.Add(name, new Status());
                    }
                }
                else
                {
                    string toFollow = input.Split()[2];
                    if (name!=toFollow
                        && vloggers.ContainsKey(name)
                        && vloggers.ContainsKey(toFollow))
                    {
                            vloggers[toFollow].Followers.Add(name);
                            vloggers[name].Following.Add(toFollow);
                    }
                }
            }
            vloggers = vloggers.OrderByDescending(x => x.Value.Followers.Count)
                .ThenBy(x => x.Value.Following.Count)
                .ToDictionary(x => x.Key, x => x.Value);
            Console.WriteLine($"The V-Logger has a total of" +
                $" {vloggers.Count} vloggers in its logs.");
            int position = 1;
            foreach (var vlogger in vloggers)
            {
                Console.WriteLine($"{position}. {vlogger.Key} : " +
                    $"{vlogger.Value.Followers.Count} followers, " +
                    $"{vlogger.Value.Following.Count} following");
                if (position==1&& vlogger.Value.Followers.Count>0)
                {
                    foreach (var follower in vlogger.Value.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
                position++;
            }
        }
        public class    Status
        {
            public SortedSet<string> Followers { get; set; }
            public HashSet<string> Following { get; set; }
            public Status()
            {
                Followers = new SortedSet<string>();
                Following = new HashSet<string>();

            }
        }
    }
}
