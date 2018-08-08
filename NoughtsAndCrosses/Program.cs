namespace NoughtsAndCrosses
{
    public class Program
    {
        private static void Main(string[] args)
        {
            var game = new Game(new ConsoleWriter());
            game.Start();
        }
    }
}