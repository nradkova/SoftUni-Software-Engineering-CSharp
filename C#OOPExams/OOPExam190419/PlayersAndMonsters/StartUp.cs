namespace PlayersAndMonsters
{
    using IO;
    using Core;
    using Core.Contracts;
    using IO.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IManagerController managerController
                = new ManagerController();
            IEngine engine = new Engine(reader,writer,managerController);
            engine.Run();
        }
    }
}