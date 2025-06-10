using System.Text.Json;
using System.Xml;

namespace oneone2
{
    internal class Battle
    {
            private void SaveResult(string playerName, string bossName, bool survived, bool victorious)
            {
                var filePath = "GraveyardContent.json";
                List<FallenHero> heroes = new List<FallenHero>();

                if (File.Exists(filePath))
                {
                    var json = File.ReadAllText(filePath);
                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        heroes = JsonSerializer.Deserialize<List<FallenHero>>(json, new JsonSerializerOptions { IncludeFields = true }) ?? new List<FallenHero>();
                    }
                }

                heroes.Add(new FallenHero
                {
                    HeroName = playerName,
                    BossName = bossName,
                    Survived = survived,
                    Victorious = victorious,
                    Date = DateTime.Now.ToString("dd-MM-yyyy")
                });

                var output = JsonSerializer.Serialize(heroes, new JsonSerializerOptions { WriteIndented = true, IncludeFields = true });
                File.WriteAllText(filePath, output);
            }

            public void Run()
        {
            Console.Clear();
            Console.WriteLine("Please enter your name:");
            string playername = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter the boss' name:");
            string bossname = Console.ReadLine();
            GameCharacter boss = new GameCharacter(bossname, 300, 0, 10, true);
            GameCharacter hero = new GameCharacter(playername, 100, 20, 40, false);
            bool battleswitch = true;
            int roundnumber = 0;
            while (battleswitch)
            {
                if (hero.Health() <= 0 || boss.Health() <= 0)
                {
                    if (hero.Health() <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "▓██   ██▓ ▒█████   █    ██     ▄▄▄       ██▀███  ▓█████    ▓█████▄ ▓█████ ▄▄▄      ▓█████▄ \r\n ▒██  ██▒▒██▒  ██▒ ██  ▓██▒   ▒████▄    ▓██ ▒ ██▒▓█   ▀    ▒██▀ ██▌▓█   ▀▒████▄    ▒██▀ ██▌\r\n  ▒██ ██░▒██░  ██▒▓██  ▒██░   ▒██  ▀█▄  ▓██ ░▄█ ▒▒███      ░██   █▌▒███  ▒██  ▀█▄  ░██   █▌\r\n  ░ ▐██▓░▒██   ██░▓▓█  ░██░   ░██▄▄▄▄██ ▒██▀▀█▄  ▒▓█  ▄    ░▓█▄   ▌▒▓█  ▄░██▄▄▄▄██ ░▓█▄   ▌\r\n  ░ ██▒▓░░ ████▓▒░▒▒█████▓     ▓█   ▓██▒░██▓ ▒██▒░▒████▒   ░▒████▓ ░▒████▒▓█   ▓██▒░▒████▓ \r\n   ██▒▒▒ ░ ▒░▒░▒░ ░▒▓▒ ▒ ▒     ▒▒   ▓▒█░░ ▒▓ ░▒▓░░░ ▒░ ░    ▒▒▓  ▒ ░░ ▒░ ░▒▒   ▓▒█░ ▒▒▓  ▒ \r\n ▓██ ░▒░   ░ ▒ ▒░ ░░▒░ ░ ░      ▒   ▒▒ ░  ░▒ ░ ▒░ ░ ░  ░    ░ ▒  ▒  ░ ░  ░ ▒   ▒▒ ░ ░ ▒  ▒ \r\n ▒ ▒ ░░  ░ ░ ░ ▒   ░░░ ░ ░      ░   ▒     ░░   ░    ░       ░ ░  ░    ░    ░   ▒    ░ ░  ░ \r\n ░ ░         ░ ░     ░              ░  ░   ░        ░  ░      ░       ░  ░     ░  ░   ░    \r\n ░ ░                                                        ░                       ░      ");
                        Console.WriteLine("\nYou have been defeated by " + boss.Name() +
                                          ", and your family is lost forever.");
                        Thread.Sleep(1000);
                        SaveResult(hero.Name(), boss.Name(), false, false);
                        Console.WriteLine("Your fatal struggle has been recorded, and the tragedy of your fall will be writ eternally upon your gravestone.");
                        Thread.Sleep(1000);
                            Console.WriteLine("\nThank you for playing this game.");
                        Thread.Sleep(450);
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else if (boss.Health() <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗██╗\r\n╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║██║\r\n ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║██║\r\n  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚═╝\r\n   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║██╗\r\n   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝\r\n                                                         ");
                        Console.WriteLine("You have defeated " + boss.Name() + ", and your family is safe!");
                        Thread.Sleep(1000);
                        SaveResult(hero.Name(), boss.Name(), true, true);
                        Console.WriteLine("Your struggle has been recorded, and your legend will be remembered, even after living out your days in peace.");
                        Thread.Sleep(1000);
                            Console.WriteLine("\nThank you for playing this game.");
                        Thread.Sleep(450);
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                    else if (boss.Health() <= 0 && hero.Health() <= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(
                            "██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗██╗\r\n╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║██║\r\n ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║██║\r\n  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚═╝\r\n   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║██╗\r\n   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝\r\n                                                         ");
                        Console.WriteLine("You have defeated " + boss.Name() + ", and your family is safe!");
                        Thread.Sleep(1000);
                        Console.WriteLine($"However, you have also fallen in battle, and your body lies next to the beast's.");
                        Thread.Sleep(1000);
                        SaveResult(hero.Name(), boss.Name(), false, true);
                        Console.WriteLine("Your fatal struggle has been recorded, and the heroism of your martyrdom will be writ eternally upon your gravestone.");
                        Thread.Sleep(1000);
                            Console.WriteLine("\nThank you for playing this game.");
                        Thread.Sleep(450);
                        Console.WriteLine("Press any key to exit.");
                        Console.ReadKey();
                        Environment.Exit(0);
                    }
                }
                int healthcheck = hero.Health();
                roundnumber++;
                hero.Strength = 20;
                Console.Clear();
                Console.WriteLine("Round " + roundnumber + " begins!\n");
                Console.WriteLine(
                    "   ______________________________\r\n / \\                             \\.\r\n|   |        HERO STATS          |.\r\n \\_ |                            |.");
                Console.WriteLine($"    |      Hero health: {hero.Health(),3}      |.");
                Console.WriteLine($"    |      Hero strength: " + hero.Strength + "     |.");
                Console.WriteLine($"    |      Hero stamina: " + hero.Stamina() + "      |.");
                Console.WriteLine(
                    "    |   _________________________|___\r\n    |  /                            /.\r\n    \\_/____________________________/.");
                Console.WriteLine(
                    $"\n                                                                    {playername} is facing " +
                    boss.Name() + "!");
                Console.WriteLine(
                    $"                                                                         His health:  {boss.Health(),3}");
                Console.WriteLine(
                    "                                                                         His strength: ???");
                Console.WriteLine(
                    $"                                                                         His stamina: " +
                    boss.Stamina());
                Console.WriteLine($"What will {playername} do?");
                if (hero.Stamina() >= 0)
                {
                    Console.WriteLine("1). Fight");
                    Console.WriteLine("2). Recharge");
                }
                else
                {
                    Console.WriteLine("[You cannot fight while out of stamina.]");
                    Console.WriteLine("1). Recharge");
                }

                Console.WriteLine("0). Concede (Exit Program)");
                var playerinput = Console.ReadKey().KeyChar;
                boss.Strength = BossDamage(healthcheck);
                hero.Strength = CritCheck();
                switch (playerinput)
                {
                    case '1':
                        if (hero.Stamina() <= 0 && boss.Stamina() <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(hero.Name() + " takes a moment to regain their footing.");
                            Console.WriteLine("It seems " + boss.Name() +
                                              " is out of breath too, as he takes a step back.");
                            hero.Recharge();
                            Thread.Sleep(450);
                            boss.Fight(hero);
                            Thread.Sleep(450);
                            Console.WriteLine("Both combatants have recharged their stamina!");
                            Thread.Sleep(450);
                        }

                        if (hero.Stamina() <= 0 && boss.Stamina() >= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(hero.Name() + " takes a moment to regain their footing.");
                            Console.WriteLine("It seems " + boss.Name() +
                                              " still has some fight in them. They attack while " + hero.Name() +
                                              " has a breather!");
                            hero.Recharge();
                            Thread.Sleep(450);
                            boss.Fight(hero);
                            Thread.Sleep(450);
                            Console.WriteLine(hero.Name() + " has recharged their stamina!");
                            Thread.Sleep(450);
                        }
                        else
                        {
                            Console.Clear();
                            hero.Fight(boss);
                            Thread.Sleep(450);
                            boss.Fight(hero);
                            Thread.Sleep(450);
                        }
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    case '2':
                        Console.Clear();
                        if (hero.Stamina() >= 0 && boss.Stamina() >= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(hero.Name() + " takes a moment to regain their footing.");
                            Thread.Sleep(450);
                            hero.Recharge();
                            Thread.Sleep(450);
                            boss.Fight(hero);
                            Thread.Sleep(450);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else if (hero.Stamina() >= 0 && boss.Stamina() <= 0)
                        {
                            Console.Clear();
                            Console.WriteLine(hero.Name() + " takes a moment to regain their footing.");
                            hero.Recharge();
                            Thread.Sleep(450);
                            boss.Fight(hero);
                            Thread.Sleep(450);
                            Console.WriteLine("Both combatants have recharged their stamina!");
                            Thread.Sleep(450);
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            roundnumber--;
                            Console.Clear();
                        }
                        break;
                    case '0':
                        Console.Clear();
                        Console.WriteLine("You concede defeat and run away, leaving your family to their fate.");
                        Thread.Sleep(1000);
                        Console.WriteLine("You are a coward, and you will never be a hero.");
                        Thread.Sleep(1000);
                        Console.WriteLine("Press any key to exit the program.");
                        Console.ReadKey();
                        battleswitch = false;
                        break;
                    default:
                        // Console.WriteLine("Invalid input. Please try again.");
                        // Thread.Sleep(1000);
                        // Console.WriteLine("Press any key to continue...");
                        // Console.ReadKey();
                        roundnumber--;
                        Console.Clear();
                        break;
                }
            }
        }

        public static int BossDamage(int heroHealth)
        {
            Random rnd = new Random();
            if (heroHealth < 50)
            {
                return rnd.Next(0, 20);
            }

            if (heroHealth < 25)
            {
                return rnd.Next(0, 15);
            }

            if (heroHealth < 13)
            {
                return rnd.Next(0, 10);
            }
            else
            {
                return rnd.Next(0, 31);
            }
        }

        public static int CritCheck()
        {
            Random crit = new Random();
            int heroCrit = crit.Next(1, 151);
            if (heroCrit <= 85)
            {
                return 35;
            }

            if (heroCrit <= 125)
            {
                return 50;
            }
            else
            {
                return 20;
            }
        }
    }
} 
