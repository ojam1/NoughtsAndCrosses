using System;
using System.Collections.Generic;

namespace NoughtsAndCrosses
{
    public class Grid
    {
        private readonly Dictionary<string, string> _gridLocations;
        private readonly IWriter _writer;

        public bool WinCondition => _gridLocations["a"] == _gridLocations["b"] && _gridLocations["b"] == _gridLocations["c"] ||
                                    _gridLocations["d"] == _gridLocations["e"] && _gridLocations["e"] == _gridLocations["f"] ||
                                    _gridLocations["g"] == _gridLocations["h"] && _gridLocations["h"] == _gridLocations["i"] ||
                                    _gridLocations["a"] == _gridLocations["d"] && _gridLocations["d"] == _gridLocations["g"] ||
                                    _gridLocations["b"] == _gridLocations["e"] && _gridLocations["e"] == _gridLocations["h"] ||
                                    _gridLocations["c"] == _gridLocations["f"] && _gridLocations["f"] == _gridLocations["i"] ||
                                    _gridLocations["a"] == _gridLocations["e"] && _gridLocations["e"] == _gridLocations["i"] ||
                                    _gridLocations["g"] == _gridLocations["e"] && _gridLocations["e"] == _gridLocations["c"];

        public bool IsFull => _gridLocations["a"] != "a" && _gridLocations["b"] != "b" && _gridLocations["c"] != "c"
                              && _gridLocations["d"] != "d" && _gridLocations["e"] != "e" && _gridLocations["f"] != "f"
                              && _gridLocations["g"] != "g" && _gridLocations["h"] != "h" && _gridLocations["i"] != "i"
                              && !WinCondition;

        public string[,] GridLocations => new[,]
        {
            { _gridLocations["a"], _gridLocations["b"], _gridLocations["c"] },
            { _gridLocations["d"], _gridLocations["e"], _gridLocations["f"] },
            { _gridLocations["g"], _gridLocations["h"], _gridLocations["i"] }
        };

        public Grid(IWriter writer)
        {
            _writer = writer;
            _gridLocations = new Dictionary<string, string>
            {
                { "a", "a" },
                { "b", "b" },
                { "c", "c" },
                { "d", "d" },
                { "e", "e" },
                { "f", "f" },
                { "g", "g" },
                { "h", "h" },
                { "i", "i" }
            };
        }

        public void DisplayGrid()
        {
            _writer.WriteLine(
                $"+---+---+---+\n| {_gridLocations["a"]} | {_gridLocations["b"]} | {_gridLocations["c"]} " +
                $"|\n+---+---+---+\n| {_gridLocations["d"]} | {_gridLocations["e"]} | {_gridLocations["f"]} " +
                $"|\n+---+---+---+\n| {_gridLocations["g"]} | {_gridLocations["h"]} | {_gridLocations["i"]} " +
                "|\n+---+---+---+");
        }

        public void SetNoughtOrCross(string playerTurn, string noughtOrCross)
        {
            if (!IsPlayerTurnValid(playerTurn))
                throw new IncorrectGridPostionException("Not a valid location");

            if (IsIntendedPlayerTurnAlreadyTaken(playerTurn))
                throw new IncorrectGridPostionException("Postion already taken");

            _gridLocations[playerTurn.ToLower()] = noughtOrCross;
        }

        private bool IsIntendedPlayerTurnAlreadyTaken(string playerTurn)
        {
            return _gridLocations[playerTurn.ToLower()] == "X" || _gridLocations[playerTurn.ToLower()] == "O";
        }

        private bool IsPlayerTurnValid(string playerTurn)
        {
            return _gridLocations.ContainsKey(playerTurn.ToLower());
        }

        internal class IncorrectGridPostionException : Exception
        {
            public IncorrectGridPostionException(string message) : base(message)
            {
            }
        }
    }
}