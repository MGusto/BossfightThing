namespace oneone2
{
    internal class App
    {
        public void Run()
        {
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
            
    
