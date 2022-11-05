namespace SlotMachine
{
    public static class LogicMethods
    {
        //checks the 3x3 grid across the diagonals for matching numbers next to each other
        public static int CheckDiagonalLines(int[,] ranNums, int totalCredits, int bettingAmount)
        {
            int winModifier = Program.SMALL_WINS;
            if (ranNums[0, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[2, 2])
            {
                totalCredits += bettingAmount * winModifier;
            }
            if (ranNums[2, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[0, 2])
            {
                totalCredits += bettingAmount * winModifier;
            }

            if (ranNums[0, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[2, 2])
            {
                if (ranNums[0, 0] == Program.WINNING_NUMBER)
                {
                    winModifier = Program.BIG_WINS;
                    totalCredits += bettingAmount * winModifier;
                }
                else
                {
                    winModifier = Program.MEDIUM_WINS;
                    totalCredits += bettingAmount * winModifier;
                }
            }
            if (ranNums[2, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[0, 2])
            {
                if (ranNums[2, 0] == Program.WINNING_NUMBER)
                {
                    winModifier = Program.BIG_WINS;
                    totalCredits += bettingAmount * winModifier;
                }
                else
                {
                    winModifier = Program.MEDIUM_WINS;
                    totalCredits += bettingAmount * winModifier;
                }
            }
            return totalCredits;
        }
        //checks a line left to right for 7s and matching numbers next to each other
        public static int CheckLine(int lineNr, int[,] ranNums, int totalCredits, int bettingAmount)
        {
            int winModifier = Program.SMALL_WINS;
            if (ranNums[lineNr, 0] == Program.WINNING_NUMBER)
            {
                totalCredits += bettingAmount * winModifier;
            }
            if (ranNums[lineNr, 1] == Program.WINNING_NUMBER)
            {
                totalCredits += bettingAmount * winModifier;
            }
            if (ranNums[lineNr, 2] == Program.WINNING_NUMBER)
            {
                totalCredits += bettingAmount * winModifier;
            }

            if (ranNums[lineNr, 0] == ranNums[lineNr, 1] || ranNums[lineNr, 1] == ranNums[lineNr, 2])
            {
                totalCredits += bettingAmount * winModifier;
            }
            if (ranNums[lineNr, 0] == ranNums[lineNr, 1] && ranNums[lineNr, 1] == ranNums[lineNr, 2])
            {
                if (ranNums[lineNr, 0] == Program.WINNING_NUMBER)
                {
                    winModifier = Program.BIG_WINS;
                    totalCredits += bettingAmount * winModifier;
                }
                else
                {
                    winModifier = Program.MEDIUM_WINS;
                    totalCredits += bettingAmount * winModifier;
                }
            }
            return totalCredits;
        }
        public static int IncreaseTotalCredits(int bettingAmount, int totalCredits, int winModifier)
        {
            totalCredits += bettingAmount * winModifier;
            return totalCredits;
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
        public static int CalculateWinnings(int totalCredits, int roundStartingCredits)
        {
            int winningAmount = totalCredits - roundStartingCredits;
            return winningAmount;
        }
        public static int RemoveCostToBet(int totalCredits, int bettingAmount, int linesBet)
        {
            return totalCredits -= bettingAmount * linesBet;
        }
    }
}
