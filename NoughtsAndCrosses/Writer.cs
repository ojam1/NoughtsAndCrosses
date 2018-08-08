namespace NoughtsAndCrosses
{
    public class Writer
    {
        private readonly IWriter _writer;

        public Writer(IWriter writer)
        {
            _writer = writer;
        }

        public void WriteLine(string line)
        {
            _writer.WriteLine(line);
        }

        public void WriteEmpty()
        {
            _writer.Write(string.Empty);
        }

        public void WriteWelcome(string playerNumber)
        {
            _writer.WriteLine($"Enter player {playerNumber} name");
        }

        public void WriteTurn(string player)
        {
            _writer.WriteLine($"{player}, please enter your move");
        }

        public void WritePlayerName(string name)
        {
            _writer.WriteLine($"Hello {name}");
        }

        public string ReadLine()
        {
            return _writer.ReadLine();
        }

        public void WriteGrid(string a, string b, string c, string d, string e, string f, string g, string h, string i)
        {
            _writer.WriteLine(
                $"+---+---+---+\n| {a} | {b} | {c} |\n+---+---+---+\n| {d} | {e} | {f} |\n+---+---+---+\n| {g} | {h} | {i} |\n+---+---+---+");
        }
    }
}