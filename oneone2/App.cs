namespace oneone2
{
    internal class App
    {
        public void Run()
        {
            Console.WriteLine("The legends once spoke of an evil beast most foul...");
            Thread.Sleep(1500);
            Console.WriteLine("...and a hero who would rise to defeat it.");
            Thread.Sleep(1500);
            Console.WriteLine(
                "During your search for knowledge about this beastly foe, your intent was noticed by one of its many spies.");
            Thread.Sleep(2000);
            Console.WriteLine(
                "...As punishment for this hubris, the agents of this dark tyrant has kidnapped your family.");
            Thread.Sleep(1500);
            Console.WriteLine("\n           You have no choice.");
            Thread.Sleep(2000);
            Console.WriteLine("\n                               You must defeat the boss once and for all.");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("MGusto presents...\n");
            Thread.Sleep(1500);
            Console.WriteLine(
                " ▄▄▄▄    ▒█████    ██████   ██████      █████▒██▓  ▄████  ██░ ██ ▄▄▄█████▓\r\n▓█████▄ ▒██▒  ██▒▒██    ▒ ▒██    ▒    ▓██   ▒▓██▒ ██▒ ▀█▒▓██░ ██▒▓  ██▒ ▓▒\r\n▒██▒ ▄██▒██░  ██▒░ ▓██▄   ░ ▓██▄      ▒████ ░▒██▒▒██░▄▄▄░▒██▀▀██░▒ ▓██░ ▒░\r\n▒██░█▀  ▒██   ██░  ▒   ██▒  ▒   ██▒   ░▓█▒  ░░██░░▓█  ██▓░▓█ ░██ ░ ▓██▓ ░ \r\n░▓█  ▀█▓░ ████▓▒░▒██████▒▒▒██████▒▒   ░▒█░   ░██░░▒▓███▀▒░▓█▒░██▓  ▒██▒ ░ \r\n░▒▓███▀▒░ ▒░▒░▒░ ▒ ▒▓▒ ▒ ░▒ ▒▓▒ ▒ ░    ▒ ░   ░▓   ░▒   ▒  ▒ ░░▒░▒  ▒ ░░   \r\n▒░▒   ░   ░ ▒ ▒░ ░ ░▒  ░ ░░ ░▒  ░ ░    ░      ▒ ░  ░   ░  ▒ ░▒░ ░    ░    \r\n ░    ░ ░ ░ ░ ▒  ░  ░  ░  ░  ░  ░      ░ ░    ▒ ░░ ░   ░  ░  ░░ ░  ░      \r\n ░          ░ ░        ░        ░             ░        ░  ░  ░  ░         \r\n      ░                                                                   ");
            Console.WriteLine(
                "\nChoose your path:\n1).Ride into battle\n2).Visit the Graveyard (hi-scores)\nPress any other key to quit the game...");
            var menuinput = Console.ReadKey().KeyChar;
            switch (menuinput)
            {
                case '1':
                    Battle battle = new Battle();
                    battle.Run();
                    break;
                case '2':
                    Graveyard graveyard = new Graveyard();
                    graveyard.Run();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("\nThank you for playing this game.");
                    Thread.Sleep(450);
                    Console.WriteLine("Press any key to exit.");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
            
    
