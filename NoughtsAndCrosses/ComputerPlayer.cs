namespace NoughtsAndCrosses
{
    public class ComputerPlayer : Player
    {
        private Game _game;
        private Grid _grid;
        public ComputerPlayer(string name, string noughtCross) : base(name, noughtCross) { }

        private void MakeMove()
        {
            var ar = _grid.AvailableLocations.ToArray();

            _grid.SetNoughtOrCross(ar[0], "X");
        }
    }
}