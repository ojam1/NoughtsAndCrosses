using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace NoughtsAndCrosses
{
    public class Grid
    {
        private readonly Dictionary<string, string> _gridLocations;
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

        public Grid()
        {
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

        public void SetNoughtOrCross(string go, Player player)
        {
            if (!_gridLocations.ContainsKey(go.ToLower()))
                throw new IncorrectGridPostionException("Not a valid location");

            if (_gridLocations[go.ToLower()] == "X" || _gridLocations[go.ToLower()] == "O")
                throw new IncorrectGridPostionException("Postion already taken");

            _gridLocations[go.ToLower()] = player.NoughtCross;
        }

        internal class IncorrectGridPostionException : Exception
        {
            public IncorrectGridPostionException(string message) : base(message)
            {
            }
        }
    }
}