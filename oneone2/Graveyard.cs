using System.Text.Json;
using System.Linq;

namespace oneone2
{
    internal class Graveyard
    {
        public void Run()
        {
            var filePath = "GraveyardContent.json";
            List<FallenHero> graveyard = new List<FallenHero>();
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    try
                    {
                        graveyard = JsonSerializer.Deserialize<List<FallenHero>>(json, new JsonSerializerOptions { IncludeFields = true }) ?? new List<FallenHero>();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Deserialization error: " + ex.Message);
                        Console.ReadKey();
                    }
                }
            }

            Console.Clear();
            Console.WriteLine(
                "   █████████                                                                              █████\r\n  ███░░░░░███                                                                            ░░███ \r\n ███     ░░░  ████████   ██████   █████ █████  ██████  █████ ████  ██████   ████████   ███████ \r\n░███         ░░███░░███ ░░░░░███ ░░███ ░░███  ███░░███░░███ ░███  ░░░░░███ ░░███░░███ ███░░███ \r\n░███    █████ ░███ ░░░   ███████  ░███  ░███ ░███████  ░███ ░███   ███████  ░███ ░░░ ░███ ░███ \r\n░░███  ░░███  ░███      ███░░███  ░░███ ███  ░███░░░   ░███ ░███  ███░░███  ░███     ░███ ░███ \r\n ░░█████████  █████    ░░████████  ░░█████   ░░██████  ░░███████ ░░████████ █████    ░░████████\r\n  ░░░░░░░░░  ░░░░░      ░░░░░░░░    ░░░░░     ░░░░░░    ░░░░░███  ░░░░░░░░ ░░░░░      ░░░░░░░░ \r\n                                                        ███ ░███                               \r\n                                                       ░░██████                                \r\n                                                        ░░░░░░                                 ");
            Console.WriteLine("\n + Here lies fallen heroes +");
            Console.WriteLine(
                "\n Choose your path:\n1).Shrine of Survivors\n2).Field of the Fallen\n3).Mausoleum of Martyrs\nPress any other key to return to menu...");
            var graveyardinput = Console.ReadKey().KeyChar;
            switch (graveyardinput)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("+ Here lies those who lived out their days after defeating an evil boss +");
                    foreach (var hero in graveyard.Where(h => h.Victorious && h.Survived))
                        Console.WriteLine($"- {hero.HeroName}, who fought {hero.BossName} on {hero.Date}, triumphed against evil and lived happily ever after -\n");
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    Run();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("+ Here lies those who tragically fell, failing to defeat an evil boss +");
                    foreach (var hero in graveyard.Where(h => !h.Survived && !h.Victorious))
                        Console.WriteLine($"- {hero.HeroName}, who fought {hero.BossName} on {hero.Date}, tragically fell against the might of evil - \n");
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    Run();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("+ Here lies those who paid the ultimate price of martyrdom, sacrificing their lives to defeat an evil boss +");
                    foreach (var hero in graveyard.Where(h => h.Victorious && !h.Survived))
                        Console.WriteLine($"- {hero.HeroName}, who fought {hero.BossName} on {hero.Date}, vanquished evil but paid the ultimate price -\n");
                    Console.WriteLine("\nPress any key to return...");
                    Console.ReadKey();
                    Run();
                    break;
                default:
                    Console.Clear();
                    App app = new App();
                    app.Run();
                    break;
            }
        }
    }
}