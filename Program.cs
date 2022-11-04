namespace SlotMachine
{
    internal class Program
    {
        static readonly int SMALL_WINS = 1;
        static readonly int MEDIUM_WINS = 3;
        static readonly int BIG_WINS = 7;
        static readonly int WINNING_NUMBER = 7;
        static readonly int STARTING_CREDITS = 100;
        static readonly bool TEST_MODE = true;
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
                UIMethods.PrintLineOfText("available credits: " + totalCredits);
                int linesBet = 0;
                int bettingAmount = 0;

                while (linesBet <= 0 || linesBet == 2 || linesBet == 4 || linesBet >= 6)
                {
                    linesBet = UIMethods.GetUserInput("How many lines you like to bet?\n1, 3, or 5");
                    if (linesBet > totalCredits)
                    {
                        UIMethods.NotEnoughCredits(totalCredits);
                        linesBet = 0;
                    }
                }
                while (bettingAmount <= 0 || bettingAmount * linesBet > totalCredits)
                {
                    bettingAmount = UIMethods.GetUserInput("How much would you like to bet?");
                    if (bettingAmount * linesBet > totalCredits)
                    {
                        UIMethods.NotEnoughCredits(totalCredits);
                        UIMethods.PrintLineOfText("With " + linesBet + " lines, your maximum bet is " + totalCredits / linesBet);
                    }
                }

                if (bettingAmount * linesBet >= totalCredits)
                {
                    UIMethods.PrintLineOfText("You have bet all your remainning credits");
                }

                totalCredits = LogicMethods.RemoveCostToBet(totalCredits, bettingAmount, linesBet);
                int roundStartingCredits = totalCredits;

                ranNums = LogicMethods.GetRandomNumbers(ranNums, random);

                switch (linesBet)
                {
                    case 1:
                        totalCredits = LogicMethods.CheckLine(1, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        break;
                    case 3:
                        totalCredits = LogicMethods.CheckLine(0, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        totalCredits = LogicMethods.CheckLine(1, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        totalCredits = LogicMethods.CheckLine(2, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        break;
                    case 5:
                        totalCredits = LogicMethods.CheckLine(0, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        totalCredits = LogicMethods.CheckLine(1, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        totalCredits = LogicMethods.CheckLine(2, ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        totalCredits = LogicMethods.CheckDiagonalLines(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                        break;

                }
                if (totalCredits <= roundStartingCredits)
                {
                    UIMethods.PrintLineOfText("You Lose!!!");
                }
                else
                {
                    int winningAmount = LogicMethods.CalculateWinnings(totalCredits, roundStartingCredits);
                    UIMethods.WinText(winningAmount, roundStartingCredits, totalCredits);
                }
            }
            UIMethods.PrintLineOfText("looks like you ran out of credits!!");
        }
    }
}