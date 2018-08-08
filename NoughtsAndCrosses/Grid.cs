namespace NoughtsAndCrosses
{
    public class Grid
    {
        public string PositionA { get; private set; }
        public string PositionB { get; private set; }
        public string PositionC { get; private set; }
        public string PositionD { get; private set; }
        public string PositionE { get; private set; }
        public string PositionF { get; private set; }
        public string PositionG { get; private set; }
        public string PositionH { get; private set; }
        public string PositionI { get; private set; }
        public bool WinCondition => PositionA == PositionB && PositionB == PositionC ||
                                    PositionD == PositionE && PositionE == PositionF ||
                                    PositionG == PositionH && PositionH == PositionI ||
                                    PositionA == PositionD && PositionD == PositionG ||
                                    PositionB == PositionE && PositionE == PositionH ||
                                    PositionC == PositionF && PositionF == PositionI ||
                                    PositionA == PositionE && PositionE == PositionI ||
                                    PositionG == PositionE && PositionE == PositionC;

        public Grid()
        {
            PositionA = "a";
            PositionB = "b";
            PositionC = "c";
            PositionD = "d";
            PositionE = "e";
            PositionF = "f";
            PositionG = "g";
            PositionH = "h";
            PositionI = "i";
        }

        public void SetNoughtOrCross(string go, Player player)
        {
            switch (go.ToLower())
            {
                case "a":
                    PositionA = player.NoughtCross;
                    break;
                case "b":
                    PositionB = player.NoughtCross;
                    break;
                case "c":
                    PositionC = player.NoughtCross;
                    break;
                case "d":
                    PositionD = player.NoughtCross;
                    break;
                case "e":
                    PositionE = player.NoughtCross;
                    break;
                case "f":
                    PositionF = player.NoughtCross;
                    break;
                case "g":
                    PositionG = player.NoughtCross;
                    break;
                case "h":
                    PositionH = player.NoughtCross;
                    break;
                case "i":
                    PositionI = player.NoughtCross;
                    break;
            }
        }
    }
}