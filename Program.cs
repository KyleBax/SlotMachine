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
            Random random;
            if (TEST_MODE)
                random = new(5);
            else
                random = new();

            int totalCredits = STARTING_CREDITS;
            int[,] ranNums = new int[3, 3];

            Console.WriteLine("Welcome to the lucky 7s");
            Console.WriteLine("Would you like to read the rules? Y/N");
            if (Console.ReadLine().ToLower() == "y")
            {
                UIMethods.HowToPlay();
            }

            while (totalCredits > 0)
            {
                Console.WriteLine("available credits: " + totalCredits);
                int winModifier = SMALL_WINS;
                int linesBet = 0;
                int bettingAmount = 0;

                while (linesBet <= 0 || linesBet == 2 || linesBet == 4 || linesBet >= 6)
                {
                    linesBet = UIMethods.GetUserInput("How many lines you like to bet?\n1, 3, or 5");
                    if (linesBet > totalCredits)
                    {
                        Console.WriteLine("you don't have enough credits");
                        Console.WriteLine("your total credits are " + totalCredits);
                        linesBet = 0;
                    }
                }
                while (bettingAmount <= 0 || bettingAmount * linesBet > totalCredits)
                {
                    bettingAmount = UIMethods.GetUserInput("How much would you like to bet?");
                    if (bettingAmount * linesBet > totalCredits)
                    {
                        Console.WriteLine("you don't have enough credits");
                        Console.WriteLine("your total credits are " + totalCredits);
                        Console.WriteLine("With " + linesBet + " lines, your maximum bet is " + totalCredits / linesBet);
                    }
                }

                if (bettingAmount * linesBet >= totalCredits)
                {
                    Console.WriteLine("You have bet all your remainning credits");
                }

                totalCredits -= bettingAmount * linesBet;
                int roundStartingCredits = totalCredits;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ranNums[i, j] = random.Next(0, 8);
                        Console.Write(ranNums[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                //single central line
                if (linesBet == 1)
                {
                    if (ranNums[1, 0] == WINNING_NUMBER)
                    {
                        totalCredits = LogicMethods.Win(bettingAmount, totalCredits, winModifier);
                    }
                    if (ranNums[1, 1] == WINNING_NUMBER)
                    {
                        totalCredits = LogicMethods.Win(bettingAmount, totalCredits, winModifier);
                    }
                    if (ranNums[1, 2] == WINNING_NUMBER)
                    {
                        totalCredits = LogicMethods.Win(bettingAmount, totalCredits, winModifier);
                    }
                    totalCredits = LogicMethods.CheckMiddleLine(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                }
                //3 lines going from left to right
                if (linesBet == 3)
                {
                    totalCredits = LogicMethods.CheckForSevens(ranNums, totalCredits, bettingAmount, SMALL_WINS, WINNING_NUMBER);
                    totalCredits = LogicMethods.CheckMiddleLine(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                    totalCredits = LogicMethods.CheckTopAndBottomLines(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                }
                //3 lines left to right and diagonals
                if (linesBet == 5)
                {
                    totalCredits = LogicMethods.CheckForSevens(ranNums, totalCredits, bettingAmount, SMALL_WINS, WINNING_NUMBER);
                    totalCredits = LogicMethods.CheckMiddleLine(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                    totalCredits = LogicMethods.CheckTopAndBottomLines(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                    totalCredits = LogicMethods.CheckDiagonalLines(ranNums, totalCredits, bettingAmount, SMALL_WINS, MEDIUM_WINS, BIG_WINS, WINNING_NUMBER);
                }
                if (totalCredits <= roundStartingCredits)
                {
                    Console.WriteLine("You Lose!!!");
                }
                else
                {
                    int winningAmount = totalCredits - roundStartingCredits;
                    UIMethods.WinText(winningAmount, roundStartingCredits, totalCredits);
                }
            }
            Console.WriteLine("looks like you ran out of credits!!");
        } 
    }
}