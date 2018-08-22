namespace NoughtsAndCrosses
{
    public class Program
    {
        private static void Main()
        {
            var game = new Game(new ConsoleWriter());
            game.Start();
        }
    }
}