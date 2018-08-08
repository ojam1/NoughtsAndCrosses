using System;

namespace NoughtsAndCrosses
{
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

        public void Write(string line)
        {
            Console.Write(line);
        }
    }
}