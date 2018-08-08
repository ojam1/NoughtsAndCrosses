namespace NoughtsAndCrosses
{
    public class Grid
    {
        public static Game Game;
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

        public void SetNoughtOrCross(string go, string player)
        {
            switch (go.ToLower())
            {
                case "a":
                    PositionA = CheckPlayer(player);
                    break;
                case "b":
                    PositionB = CheckPlayer(player);
                    break;
                case "c":
                    PositionC = CheckPlayer(player);
                    break;
                case "d":
                    PositionD = CheckPlayer(player);
                    break;
                case "e":
                    PositionE = CheckPlayer(player);
                    break;
                case "f":
                    PositionF = CheckPlayer(player);
                    break;
                case "g":
                    PositionG = CheckPlayer(player);
                    break;
                case "h":
                    PositionH = CheckPlayer(player);
                    break;
                case "i":
                    PositionI = CheckPlayer(player);
                    break;
            }
        }

        private static string CheckPlayer(string player)
        {
            return player == Game.PlayerOne ? "X" : "O";
        }
    }
}