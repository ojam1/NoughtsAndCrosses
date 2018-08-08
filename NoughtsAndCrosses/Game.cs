namespace NoughtsAndCrosses
{
    public class Game
    {
        private readonly IWriter _writer;
        public string PlayerOne { get; private set; }
        public string PlayerTwo { get; private set; }
        private readonly Grid _grid;

        public Game(IWriter writer)
        {
            _writer = writer;
            _grid = new Grid();
        }

        private void DisplayGrid()
        {
            new Writer(_writer).WriteGrid(_grid.PositionA, _grid.PositionB, _grid.PositionC, _grid.PositionD, _grid.PositionE, _grid.PositionF, _grid.PositionG, _grid.PositionH, _grid.PositionI);
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
            while (!_grid.WinCondition)
            {
                writer.WriteTurn(PlayerOne);
                _grid.SetNoughtOrCross(writer.ReadLine(), PlayerOne);
                if (_grid.WinCondition)
                {
                    WriteWinner(PlayerOne);
                    break;
                }
                writer.WriteTurn(PlayerTwo);
                _grid.SetNoughtOrCross(writer.ReadLine(), PlayerTwo);
                if (_grid.WinCondition)
                {
                    WriteWinner(PlayerTwo);
                    break;
                }
            }
        }

        private void WriteWinner(string player)
        {
            new Writer(_writer).WriteLine($"Winner {player}!");
        }
    }
}