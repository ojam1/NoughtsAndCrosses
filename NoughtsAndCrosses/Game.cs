namespace NoughtsAndCrosses
{
    public class Game
    {
        private static IWriter _iWriter;
        public Player PlayerOne;
        public Player PlayerTwo;
        private readonly Grid _grid;
        private bool _isPlayerOneTurn;
        private string _winner;


        public Game(IWriter iWriter)
        {
            _iWriter = iWriter;
            _grid = new Grid(_iWriter, 3);
        }

        public void Start()
        {
            PlayerOne = PlayerInitialisation("one", "X");
            PlayerTwo = PlayerInitialisation("two", "O");
            _grid.DisplayGrid();
            _isPlayerOneTurn = true;
            while (!_grid.WinCondition)
            {
                AttemptPlayerTurn(_isPlayerOneTurn ? PlayerOne : PlayerTwo);

                if (_grid.WinCondition)
                {
                    WriteWinner(_winner);
                    break;
                }

                if (!_grid.IsFull) continue;
                WriteNoWinner();
                break;
            }
        }

        private static Player PlayerInitialisation(string playerNumber, string playerSymbol)
        {
            WriteWelcome(playerNumber);
            var playerName = _iWriter.ReadLine();
            WritePlayerName(playerName);
            return new Player(playerName, playerSymbol);
        }

        private void AttemptPlayerTurn(Player player)
        {
            WriteTurn(player.Name);
            try
            {
                _grid.SetNoughtOrCross(_iWriter.ReadLine(), player.NoughtCross);
                if (_grid.WinCondition)
                    _winner = player.Name;

                ChangeCurrentPlayer();
            }
            catch (Grid.IncorrectGridPostionException e)
            {
                _iWriter.WriteLine(e.Message);
            }

            _grid.DisplayGrid();
        }

        private void ChangeCurrentPlayer()
        {
            _isPlayerOneTurn = !_isPlayerOneTurn;
        }

        private static void WriteWelcome(string playerNumber)
        {
            _iWriter.WriteLine($"Enter player {playerNumber} name");
        }

        private static void WritePlayerName(string name)
        {
            _iWriter.WriteLine($"Hello {name}");
        }

        private static void WriteTurn(string player)
        {
            _iWriter.WriteLine($"{player}, please enter your move");
        }

        private static void WriteWinner(string player)
        {
            _iWriter.WriteLine($"Winner {player}!");
        }

        private static void WriteNoWinner()
        {
            _iWriter.WriteLine("No Winner");
        }
    }
}