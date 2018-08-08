using System.Reflection.Metadata.Ecma335;

namespace NoughtsAndCrosses
{
    public class Game
    {
        private readonly IWriter _writer;
        public Player PlayerOne;
        public Player PlayerTwo;
        private readonly Grid _grid;

        public Game(IWriter writer)
        {
            _writer = writer;
            _grid = new Grid();
        }

        private void DisplayGrid()
        {
            new Writer(_writer).WriteGrid(_grid.GridLocations["a"], _grid.GridLocations["b"], _grid.GridLocations["c"], _grid.GridLocations["d"], _grid.GridLocations["e"], _grid.GridLocations["f"], _grid.GridLocations["g"], _grid.GridLocations["h"], _grid.GridLocations["i"]);
        }

        public void Start()
        {
            var writer = new Writer(_writer);
            writer.WriteWelcome("one");
            PlayerOne = new Player(writer.ReadLine(), "X");
            writer.WritePlayerName(PlayerOne.Name);
            writer.WriteWelcome("two");
            PlayerTwo = new Player(writer.ReadLine(), "O");
            writer.WritePlayerName(PlayerTwo.Name);
            DisplayGrid();
            while (!_grid.WinCondition)
            {
                writer.WriteTurn(PlayerOne.Name);
                _grid.SetNoughtOrCross(writer.ReadLine(), PlayerOne);
                DisplayGrid();
                if (_grid.WinCondition)
                {
                    WriteWinner(PlayerOne.Name);
                    break;
                }
                writer.WriteTurn(PlayerTwo.Name);
                _grid.SetNoughtOrCross(writer.ReadLine(), PlayerTwo);
                DisplayGrid();
                if (_grid.WinCondition)
                {
                    WriteWinner(PlayerTwo.Name);
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