namespace NoughtsAndCrosses
{
    public class Game
    {
        private readonly IWriter _writer;
        public Player PlayerOne;
        public Player PlayerTwo;
        private readonly Grid _grid;
        private bool _isPlayerOneTurn;
        private Player _winner;

        public Game(IWriter writer)
        {
            _writer = writer;
            _grid = new Grid();
        }

        private void DisplayGrid()
        {
            new Writer(_writer).WriteGrid(
                _grid.GridLocations[0, 0], _grid.GridLocations[0, 1], _grid.GridLocations[0, 2],
                _grid.GridLocations[1, 0], _grid.GridLocations[1, 1], _grid.GridLocations[1, 2],
                _grid.GridLocations[2, 0], _grid.GridLocations[2, 1], _grid.GridLocations[2, 2]
            );
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
            _isPlayerOneTurn = true;
            while (!_grid.WinCondition)
            {
                AttemptPlayerTurn(writer, _isPlayerOneTurn ? PlayerOne : PlayerTwo);

                if (_grid.WinCondition)
                {
                    WriteWinner(_winner.Name);
                    break;
                }

                if (!_grid.IsFull) continue;
                WriteNoWinner();
                break;
            }
        }

        private void AttemptPlayerTurn(Writer writer, Player player)
        {
            writer.WriteTurn(player.Name);
            try
            {
                _grid.SetNoughtOrCross(writer.ReadLine(), player);
                if (_grid.WinCondition)
                    _winner = player;

                ChangeCurrentPlayer();
            }
            catch (Grid.IncorrectGridPostionException e)
            {
                writer.WriteLine(e.Message);
            }

            DisplayGrid();
        }

        private void ChangeCurrentPlayer()
        {
            _isPlayerOneTurn = !_isPlayerOneTurn;
        }

        private void WriteWinner(string player)
        {
            new Writer(_writer).WriteLine($"Winner {player}!");
        }

        private void WriteNoWinner()
        {
            new Writer(_writer).WriteLine("No Winner");
        }
    }
}