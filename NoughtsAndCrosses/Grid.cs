using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses
{
    public class Grid
    {
        private readonly Dictionary<string, string> _gridLocations;
        public bool WinCondition => HorizontalWin() || VerticalWin() || DiagonalWin();
        private readonly IWriter _iWriter;
        public string[,] GridLocationsArray { get; }
        private readonly int _gridSize;
        public bool IsFull
        {
            get
            {
                var countOfLocationsSet = GridLocationsArray.Cast<string>().Count(value => value == "X" || value == "O");

                return countOfLocationsSet == _gridSize * _gridSize && !WinCondition;
            }
        }

        public Grid(IWriter iWriter, int gridSize)
        {
            _iWriter = iWriter;
            _gridSize = gridSize;
            _gridLocations = new Dictionary<string, string>();

            GridLocationsArray = new string[_gridSize, _gridSize];

            var gridNumbers = 1;

            for (var row = 0; row < _gridSize; row++)
            {
                for (var column = 0; column < _gridSize; column++)
                {
                    GridLocationsArray[row, column] = gridNumbers.ToString();
                    _gridLocations.Add(gridNumbers.ToString(), $"{row},{column}");
                    gridNumbers++;
                }
            }
        }

        public void SetNoughtOrCross(string playerTurn, string noughtOrCross)
        {
            if (!IsPlayerTurnValid(playerTurn))
                throw new IncorrectGridPostionException("Not a valid location");

            if (IsIntendedPlayerTurnAlreadyTaken(playerTurn))
                throw new IncorrectGridPostionException("Postion already taken");

            GridLocationsArray[int.Parse(_gridLocations[playerTurn].Split(',')[0]), int.Parse(_gridLocations[playerTurn].Split(',')[1])] = noughtOrCross;
        }

        public void DisplayGrid()
        {
            _iWriter.WriteLine($"+---+---+---+\n| {GridLocationsArray[0,0]} | {GridLocationsArray[0,1]} | {GridLocationsArray[0,2]} " +
                              $"|\n+---+---+---+\n| {GridLocationsArray[1,0]} | {GridLocationsArray[1,1]} | {GridLocationsArray[1,2]} " +
                              $"|\n+---+---+---+\n| {GridLocationsArray[2,0]} | {GridLocationsArray[2,1]} | {GridLocationsArray[2,2]} " +
                              "|\n+---+---+---+");
        }

        private bool HorizontalWin()
        {
            return IsNeighbourSame(0, 1, 0 ,-1) && IsNeighbourSame(0, 1, 0, 1) ||
                   IsNeighbourSame(1, 1, 0, -1) && IsNeighbourSame(1, 1, 0, 1) ||
                   IsNeighbourSame(2, 1, 0, -1) && IsNeighbourSame(2, 1, 0, 1);
        }

        private bool VerticalWin()
        {
            return IsNeighbourSame(1, 0, -1, 0) && IsNeighbourSame(1, 0, 1, 0) ||
                   IsNeighbourSame(1, 1, -1, 0) && IsNeighbourSame(1, 1, 1, 0) ||
                   IsNeighbourSame(1, 2, -1, 0) && IsNeighbourSame(1, 2, 1, 0);
        }

        private bool DiagonalWin()
        {
            return IsNeighbourSame(1, 1, -1, -1) && IsNeighbourSame(1, 1, 1, 1) ||
                   IsNeighbourSame(1, 1, 1, -1) && IsNeighbourSame(1, 1, -1, 1);
        }

        private bool IsIntendedPlayerTurnAlreadyTaken(string playerTurn)
        {
            return GridLocationsArray[int.Parse(_gridLocations[playerTurn].Split(',')[0]), int.Parse(_gridLocations[playerTurn].Split(',')[1])] == "X" || GridLocationsArray[int.Parse(_gridLocations[playerTurn].Split(',')[0]), int.Parse(_gridLocations[playerTurn].Split(',')[1])] == "O";
        }

        private bool IsPlayerTurnValid(string playerTurn)
        {
            return _gridLocations.ContainsKey(playerTurn);
        }

        private bool IsNeighbourSame(int row, int column, int offSetX, int offSetY)
        {
            var rowToCheck = row + offSetX;
            var columnToCheck = column + offSetY;

            var outOfBounds = rowToCheck < 0 || rowToCheck >= _gridSize || columnToCheck < 0 || columnToCheck >= _gridSize;

            if (!outOfBounds)
            {
                return GridLocationsArray[row, column] == GridLocationsArray[rowToCheck, columnToCheck];
            }

            return false;
        }

        internal class IncorrectGridPostionException : Exception
        {
            public IncorrectGridPostionException(string message) : base(message)
            {
            }
        }
    }
}