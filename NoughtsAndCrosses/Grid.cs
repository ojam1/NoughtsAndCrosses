using System;
using System.Collections.Generic;
using System.Linq;

namespace NoughtsAndCrosses
{
    public class Grid
    {
        public string[,] GridLocationsArray { get; }
        public bool WinCondition => HorizontalWin() || VerticalWin() || DiagonalWin();
        public bool IsFull
        {
            get
            {
                var countOfLocationsSet = GridLocationsArray.Cast<string>().Count(value => value == "X" || value == "O");

                return countOfLocationsSet == _gridSize * _gridSize && !WinCondition;
            }
        }
        private readonly IWriter _iWriter;
        private readonly int _gridSize;
        private readonly Dictionary<string, string> _gridLocations;

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

            GridLocationsArray[ConvertPlayerTurnToGridLocationRow(playerTurn), ConvertPlayerTurnToGridLocationColumn(playerTurn)] = noughtOrCross;
        }

        public void DisplayGrid()
        {
            _iWriter.WriteLine($"+---+---+---+\n| {GridLocationsArray[0,0]} | {GridLocationsArray[0,1]} | {GridLocationsArray[0,2]} " +
                              $"|\n+---+---+---+\n| {GridLocationsArray[1,0]} | {GridLocationsArray[1,1]} | {GridLocationsArray[1,2]} " +
                              $"|\n+---+---+---+\n| {GridLocationsArray[2,0]} | {GridLocationsArray[2,1]} | {GridLocationsArray[2,2]} " +
                              "|\n+---+---+---+");
        }

        private bool IsHorizontalWin(int row, int column)
        {
            var matches = new List<bool>();

            for (var i = 1; i < _gridSize; i++)
            {
                    matches.Add(IsNeighbourSame(row, column, 0, column + i));
                    matches.Add(IsNeighbourSame(row, column, 0, column - i));
            }

            return matches.Count(x => x) >= _gridSize - 1;
        }

        private bool HorizontalWin()
        {
            for (var row = 0; row < _gridSize; row++)
            {
                if (IsHorizontalWin(row, 0))
                    return true;
            }

            return false;
        }

        private bool IsVerticalWin(int row, int column)
        {
            var matches = new List<bool>();

            for (var i = 1; i < _gridSize; i++)
            {
                matches.Add(IsNeighbourSame(row, column, row + i, 0));
                matches.Add(IsNeighbourSame(row, column, row - i, 0));
            }

            return matches.Count(x => x) >= _gridSize - 1;
        }

        private bool VerticalWin()
        {
            for (var column = 0; column < _gridSize; column++)
            {
                if (IsVerticalWin(0, column))
                    return true;
            }

            return false;
        }

        private bool DiagonalWin()
        {
            if (_gridSize % 2 == 1)
            {
                return IsNeighbourSame(1, 1, -1, -1) && IsNeighbourSame(1, 1, 1, 1) ||
                       IsNeighbourSame(1, 1, 1, -1) && IsNeighbourSame(1, 1, -1, 1);
            }

            return false;
        }

        private int ConvertPlayerTurnToGridLocationRow(string playerTurn)
        {
            return int.Parse(_gridLocations[playerTurn].Split(',')[0]);
        }

        private int ConvertPlayerTurnToGridLocationColumn(string playerTurn)
        {
            return int.Parse(_gridLocations[playerTurn].Split(',')[1]);
        }

        private bool IsIntendedPlayerTurnAlreadyTaken(string playerTurn)
        {
            return GridLocationsArray[ConvertPlayerTurnToGridLocationRow(playerTurn), ConvertPlayerTurnToGridLocationColumn(playerTurn)] == "X" || 
                   GridLocationsArray[ConvertPlayerTurnToGridLocationRow(playerTurn), ConvertPlayerTurnToGridLocationColumn(playerTurn)] == "O";
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