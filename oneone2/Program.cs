namespace oneone2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameCharacter boss = new GameCharacter("Boss McEvil", 400, BossDamage(), 10);
            GameCharacter hero = new GameCharacter("Hero McGood", 100, 20, 40);

        }

        public static int BossDamage()
        {
            Random rnd = new Random();
            return rnd.Next(0, 31);
        }
    }
}
