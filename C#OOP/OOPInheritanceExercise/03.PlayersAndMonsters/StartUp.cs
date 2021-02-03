using System;
namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("ddd", 20);
            Console.WriteLine(hero);
            Elf elf = new Elf("sss", 100);
            Console.WriteLine(elf);
            BladeKnight player = new BladeKnight("bbb", 30);
            Console.WriteLine(player);
        }
    }
}