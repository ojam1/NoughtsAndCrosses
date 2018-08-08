namespace NoughtsAndCrosses
{
    public class Game
    {
        private readonly IWriter _writer;
        public string PlayerOne { get; private set; }
        public string PlayerTwo { get; private set; }
        private string _positionA = "a";
        private string _positionB = "b";
        private string _positionC = "c";
        private string _positionD = "d";
        private string _positionE = "e";
        private string _positionF = "f";
        private string _positionG = "g";
        private string _positionH = "h";
        private string _positionI = "i";

        public Game(IWriter writer)
        {
            _writer = writer;
        }

        private void DisplayGrid()
        {
            new Writer(_writer).WriteGrid(_positionA, _positionB, _positionC, _positionD, _positionE, _positionF, _positionG, _positionH, _positionI);
        }

        public void Start()
        {
            var writer = new Writer(_writer);
            writer.WriteWelcome("one");
            PlayerOne = writer.ReadLine();
            writer.WritePlayerName(PlayerOne);
            writer.WriteWelcome("two");
            PlayerTwo = writer.ReadLine();
            writer.WritePlayerName(PlayerTwo);
            DisplayGrid();
            while (!WinCondition())
            {
                writer.WriteTurn(PlayerOne);
                SetNoughtOrCross(writer.ReadLine(), PlayerOne);
                if (WinCondition())
                    break;
                writer.WriteTurn(PlayerTwo);
                SetNoughtOrCross(writer.ReadLine(), PlayerTwo);
            }
        }

        private void Winner(string player)
        {
            if (WinCondition())
                WriteWinner(player);

            WriteEmpty();
        }

        private void WriteWinner(string player)
        {
            new Writer(_writer).WriteLine($"Winner {player}!");
        }

        private void WriteEmpty()
        {
            new Writer(_writer).Write(string.Empty);
        }

        private bool WinCondition()
        {
            return _positionA == _positionB && _positionB == _positionC ||
                   _positionD == _positionE && _positionE == _positionF ||
                   _positionG == _positionH && _positionH == _positionI ||
                   _positionA == _positionD && _positionD == _positionG ||
                   _positionB == _positionE && _positionE == _positionH ||
                   _positionC == _positionF && _positionF == _positionI ||
                   _positionA == _positionE && _positionE == _positionI ||
                   _positionG == _positionE && _positionE == _positionC;
        }

        public void SetNoughtOrCross(string go, string player)
        {
            switch (go.ToLower())
            {
                case "a":
                    _positionA = CheckPlayer(player);
                    break;
                case "b":
                    _positionB = CheckPlayer(player);
                    break;
                case "c":
                    _positionC = CheckPlayer(player);
                    break;
                case "d":
                    _positionD = CheckPlayer(player);
                    break;
                case "e":
                    _positionE = CheckPlayer(player);
                    break;
                case "f":
                    _positionF = CheckPlayer(player);
                    break;
                case "g":
                    _positionG = CheckPlayer(player);
                    break;
                case "h":
                    _positionH = CheckPlayer(player);
                    break;
                case "i":
                    _positionI = CheckPlayer(player);
                    break;
            }

            DisplayGrid();
            Winner(player);
        }

        private string CheckPlayer(string player)
        {
            return player == PlayerOne ? "X" : "O";
        }
    }
}