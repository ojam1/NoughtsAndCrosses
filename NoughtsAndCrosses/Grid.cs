using System.Collections.Generic;

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
            GridLocations[go.ToLower()] = player.NoughtCross;
        }
    }
}