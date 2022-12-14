namespace SlotMachine
{
    internal class Program
    {
        public static readonly int SMALL_WINS = 1;
        public static readonly int MEDIUM_WINS = 3;
        public static readonly int BIG_WINS = 7;
        public static readonly int WINNING_NUMBER = 7;
        static readonly int STARTING_CREDITS = 100;
        static readonly bool TEST_MODE = false;
        static void Main(string[] args)
        {
            int totalCredits = STARTING_CREDITS;
            int[,] ranNums = new int[3, 3];
            Random random;
            if (TEST_MODE)
                random = new(5);
            else
                random = new();
            UIMethods.StartingText();
            while (totalCredits > 0)
            {
                UIMethods.PrintAvailableCredits(totalCredits);
                int linesBet = UIMethods.GetLinesBet(totalCredits);
                int bettingAmount = UIMethods.GetBettingAmount(totalCredits, linesBet);

                totalCredits = LogicMethods.RemoveCostToBet(totalCredits, bettingAmount, linesBet);
                int roundStartingCredits = totalCredits;

                ranNums = LogicMethods.GetRandomNumbers(ranNums, random);
                UIMethods.PrintRandomNumbers(ranNums);

                totalCredits = LogicMethods.CalculateWin(ranNums, totalCredits, bettingAmount, linesBet);

                if (totalCredits <= roundStartingCredits)
                {
                    UIMethods.PrintLoseOutcome("You Lose!!!");
                }
                else
                {
                    int winningAmount = LogicMethods.CalculateWinnings(totalCredits, roundStartingCredits);
                    UIMethods.WinText(winningAmount, roundStartingCredits, totalCredits);
                }
            }
            UIMethods.PrintLoseOutcome("looks like you ran out of credits!!");
        }
    }
}