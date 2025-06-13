namespace oneone2
{
    internal class Program
    {
        static void Main(string[] args)
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
            App app = new App();
            app.Run();
        }
    }
}
