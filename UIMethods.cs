namespace SlotMachine
{
    public static class UIMethods
    {
        public static void StartingText()
        {
            Console.WriteLine($"Welcome to the lucky {Program.WINNING_NUMBER}s\nWould you like to read the rules? Y/N");
            if (Console.ReadLine().ToLower() == "y")
            {
                HowToPlay();
            }
        }
        public static void HowToPlay()
        {
            Console.WriteLine(@$"Lucky {Program.WINNING_NUMBER}s uses a 3x3 grid full of random numbers
Step 1: Enter the amount of lines you wish to play
You may select 1, 3 or 5 lines.
1 line will play all the numbers in the middle line, going left to right.
3 lines will play all the numbers in the top, middle and bottom lines, going left to right
5 lines will play the same as 3 and include going across the diagonals of the 3x3 grid
Step 2: Enter the credits you would like to bet
This will be multiplied by the number of lines you chose to play,
so you may not be able to bet your full amount of credits
Step 3: WIN BIG!! (hopefully)
The ways you win:
There are three win types. small, medium and large
1. Small wins: Get two matching numbers next to each other in a line you're playing,
and every {Program.WINNING_NUMBER} in a line you're playing will give you a small win
Each small win will give you your betting amount back
2. Medium wins: Get three matching numbers in a line you're playing.
Medium wins will give you your betting amount times {Program.MEDIUM_WINS}
3. Big wins: When you get three {Program.WINNING_NUMBER}s in a line you're playing you will win big.
Big wins will give you your betting amount times {Program.BIG_WINS}");
        }
        public static int GetLinesBet(int totalCredits)
        {
            int linesBet = 0;
            while (linesBet <= 0 || linesBet == 2 || linesBet == 4 || linesBet >= 6)
            {
                linesBet = GetUserInput("How many lines you like to bet?\n1, 3, or 5");
                if (linesBet > totalCredits)
                {
                    NotEnoughCredits(totalCredits);
                    linesBet = 0;
                }
            }
            return linesBet;
        }
        public static int GetBettingAmount(int totalCredits, int linesBet)
        {
            int bettingAmount = 0;
            while (bettingAmount <= 0 || bettingAmount * linesBet > totalCredits)
            {
                bettingAmount = GetUserInput("How much would you like to bet?");
                if (bettingAmount * linesBet > totalCredits)
                {
                    NotEnoughCredits(totalCredits);
                    Console.WriteLine($"With {linesBet} lines, your maximum bet is {totalCredits / linesBet}");
                }
            }
            if (bettingAmount * linesBet >= totalCredits)
            {
                Console.WriteLine("You have bet all your remainning credits");
            }
            return bettingAmount;
        }
        public static int GetUserInput(string line)
        {
            int number = 0;
            while (number <= 0)
            {
                Console.WriteLine(line);
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input))
                {
                    continue;
                }
                if (input.All(Char.IsNumber))
                {
                    number = Convert.ToInt32(input);
                }
                else
                {
                    continue;
                }
            }
            return number;
        }
        public static void NotEnoughCredits(int totalCredits)
        {
            Console.WriteLine($"you don't have enough credits\nyour total credits are {totalCredits}");
        }
        public static void PrintRandomNumbers(int[,] ranNums)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{ranNums[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        public static void WinText(int winningAmount, int roundStartingCredits, int totalCredits)
        {
            Console.WriteLine(@$"Winner!!!!
You win {winningAmount} credits
{roundStartingCredits}
You have {totalCredits} credits");
        }
        public static void PrintLoseOutcome(string lose)
        {
            Console.WriteLine(lose);
        }
        public static void PrintAvailableCredits(int totalCredits)
        {
            Console.WriteLine($"available credits: {totalCredits}");
        }
    }
}

