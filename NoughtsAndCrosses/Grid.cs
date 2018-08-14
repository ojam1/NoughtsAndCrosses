using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace NoughtsAndCrosses
{
    public class Grid
    {
        public Dictionary<string, string> GridLocations;
        public bool WinCondition => GridLocations["a"] == GridLocations["b"] && GridLocations["b"] == GridLocations["c"] ||
                                    GridLocations["d"] == GridLocations["e"] && GridLocations["e"] == GridLocations["f"] ||
                                    GridLocations["g"] == GridLocations["h"] && GridLocations["h"] == GridLocations["i"] ||
                                    GridLocations["a"] == GridLocations["d"] && GridLocations["d"] == GridLocations["g"] ||
                                    GridLocations["b"] == GridLocations["e"] && GridLocations["e"] == GridLocations["h"] ||
                                    GridLocations["c"] == GridLocations["f"] && GridLocations["f"] == GridLocations["i"] ||
                                    GridLocations["a"] == GridLocations["e"] && GridLocations["e"] == GridLocations["i"] ||
                                    GridLocations["g"] == GridLocations["e"] && GridLocations["e"] == GridLocations["c"];
        public bool IsFull => GridLocations["a"] != "a" && GridLocations["b"] != "b" && GridLocations["c"] != "c"
                              && GridLocations["d"] != "d" && GridLocations["e"] != "e" && GridLocations["f"] != "f"
                              && GridLocations["g"] != "g" && GridLocations["h"] != "h" && GridLocations["i"] != "i"
                              && !WinCondition;

        public Grid()
        {
            GridLocations = new Dictionary<string, string>
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
            if (!GridLocations.ContainsKey(go.ToLower()))
                throw new IncorrectGridPostionException("Not a valid location");

            if (GridLocations[go.ToLower()] == "X" || GridLocations[go.ToLower()] == "O")
                throw new IncorrectGridPostionException("Postion already taken");

            GridLocations[go.ToLower()] = player.NoughtCross;
        }

        internal class IncorrectGridPostionException : Exception
        {
            public IncorrectGridPostionException(string message) : base(message)
            {
            }
        }
    }
}