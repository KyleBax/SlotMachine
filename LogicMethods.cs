namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int RemoveCostToBet(int totalCredits, int bettingAmount, int linesBet)
        {
            int result = totalCredits - bettingAmount * linesBet;
            return result;
        }
        public static int[,] GetRandomNumbers(int[,] ranNums, Random random)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    ranNums[i, j] = random.Next(0, 8);
                }
            }
            return ranNums;
        }
        public static int CalculateWin(int[,] ranNums, int totalCredits, int bettingAmount, int linesBet)
        {
            totalCredits = CheckLine(1, ranNums, totalCredits, bettingAmount);
            if (linesBet > 2)
            {
                totalCredits = CheckLine(0, ranNums, totalCredits, bettingAmount);
                totalCredits = CheckLine(2, ranNums, totalCredits, bettingAmount);
                if (linesBet > 3)
                {
                    totalCredits = CheckDiagonalLines(ranNums, totalCredits, bettingAmount);
                }
            }
            return totalCredits;
        }
        //checks a line left to right for 7s and matching numbers next to each other
        public static int CheckLine(int lineNr, int[,] ranNums, int totalCredits, int bettingAmount)
        {
            if (ranNums[lineNr, 0] == Program.WINNING_NUMBER)
            {
                totalCredits += bettingAmount * Program.SMALL_WINS;
            }
            if (ranNums[lineNr, 1] == Program.WINNING_NUMBER)
            {
                totalCredits += bettingAmount * Program.SMALL_WINS;
            }
            if (ranNums[lineNr, 2] == Program.WINNING_NUMBER)
            {
                totalCredits += bettingAmount * Program.SMALL_WINS;
            }

            if (ranNums[lineNr, 0] == ranNums[lineNr, 1] || ranNums[lineNr, 1] == ranNums[lineNr, 2])
            {
                totalCredits += bettingAmount * Program.SMALL_WINS;
            }
            if (ranNums[lineNr, 0] == ranNums[lineNr, 1] && ranNums[lineNr, 1] == ranNums[lineNr, 2])
            {
                if (ranNums[lineNr, 0] == Program.WINNING_NUMBER)
                {
                    totalCredits += bettingAmount * Program.BIG_WINS;
                }
                else
                {
                    totalCredits += bettingAmount * Program.MEDIUM_WINS;
                }
            }
            return totalCredits;
        }
        //checks the 3x3 grid across the diagonals for matching numbers next to each other
        public static int CheckDiagonalLines(int[,] ranNums, int totalCredits, int bettingAmount)
        {
            if (ranNums[0, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[2, 2])
            {
                totalCredits += bettingAmount * Program.SMALL_WINS;
            }
            if (ranNums[2, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[0, 2])
            {
                totalCredits += bettingAmount * Program.SMALL_WINS;
            }

            if (ranNums[0, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[2, 2])
            {
                if (ranNums[0, 0] == Program.WINNING_NUMBER)
                {
                    totalCredits += bettingAmount * Program.BIG_WINS;
                }
                else
                {
                    totalCredits += bettingAmount * Program.MEDIUM_WINS;
                }
            }
            if (ranNums[2, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[0, 2])
            {
                if (ranNums[2, 0] == Program.WINNING_NUMBER)
                {
                    totalCredits += bettingAmount * Program.BIG_WINS;
                }
                else
                {
                    totalCredits += bettingAmount * Program.MEDIUM_WINS;
                }
            }
            return totalCredits;
        }
        public static int CalculateWinnings(int totalCredits, int roundStartingCredits)
        {
            int winningAmount = totalCredits - roundStartingCredits;
            return winningAmount;
        }
    }
}
