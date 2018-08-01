using System;

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

    public class Game
    {
        private readonly IWriter _writer;

        public Game(IWriter writer)
        {
            _writer = writer;
        }

        public void Start()
        {
            var other = new Writer(_writer);
            other.WriteWelcome();
            other.WritePlayerName(other.ReadNextLine());
        }
    }

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }

    public class Writer
    {
        private readonly IWriter _writer;

        public Writer(IWriter writer)
        {
            _writer = writer;
        }

        public void WriteWelcome()
        {
            _writer.WriteLine("Enter player 1 name:");
        }

        public void WritePlayerName(string name)
        {
            _writer.WriteLine($"Hello {name}");
        }

        public string ReadLine()
        {
            return _writer.ReadLine();
        }
    }

    public interface IWriter
    {
        void WriteLine(string a);
        string ReadLine();
    }
}
