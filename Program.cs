namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool TEST_MODE = true;

            Random random;

            if (TEST_MODE)
                random = new(5);
            else
                random = new();

            int totalCredits = 100;
            int winningNumber = 7;
            int[,] ranNums = new int[3, 3];

            Console.WriteLine("Welcome to the lucky 7s");

            while (totalCredits > 0)
            {
                Console.WriteLine("available credits: " + totalCredits);
                int winModifier = 1;

                int bettingAmount = Input("How much would you like to bet?");
                if (bettingAmount > totalCredits)
                {
                    Console.WriteLine("You have bet all your remainning credits");
                    bettingAmount = totalCredits;
                }

                int linesBet = 0;
                while (linesBet <= 0 || linesBet == 2 || linesBet == 4 || linesBet >= 6)
                {
                    linesBet = Input("How many lines you like to bet?\n1, 3, or 5");
                }

                totalCredits -= bettingAmount * linesBet;
                int roundStartingCredits = totalCredits;

                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        ranNums[i, j] = random.Next(0, 8); ;
                        Console.Write(ranNums[i, j] + " ");
                    }
                    Console.WriteLine();
                }

                if (linesBet == 1)
                {
                    if (ranNums[1, 0] == 7)
                    {
                        winModifier = 1;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    if (ranNums[1, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[1, 2])
                    {
                        winModifier = 1;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    if (ranNums[1, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[1, 2])
                    {
                        if (ranNums[1, 0] == winningNumber)
                        {
                            winModifier = winningNumber;
                            totalCredits = Win(bettingAmount, totalCredits, winModifier);
                        }
                        else
                        {
                            winModifier = 3;
                            totalCredits = Win(bettingAmount, totalCredits, winModifier);
                        }
                    }
                }
                if (linesBet == 3)
                {
                    totalCredits = SevensCheck(ranNums, winningNumber, totalCredits, bettingAmount, winModifier);
                }
                if (linesBet == 5)
                {
                    totalCredits = SevensCheck(ranNums, winningNumber, totalCredits, bettingAmount, winModifier);
                }

                if (ranNums[1, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[1, 2])
                {
                    if (ranNums[1, 0] == winningNumber)
                    {
                        winModifier = winningNumber;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    else
                    {
                        winModifier = 3;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                }
                if (totalCredits < roundStartingCredits)
                {
                    Console.WriteLine("You Lose!!!");
                }
                else
                {
                    int winningAmount = totalCredits - roundStartingCredits;
                    WinText(winningAmount, roundStartingCredits, totalCredits);
                }
            }
            Console.WriteLine("looks like you ran out of credits!!");
        }

        public static int Win(int bettingAmount, int totalCredits, int winModifier)
        {
            totalCredits += bettingAmount * winModifier;
            return totalCredits;
        }

        public static void WinText(int winningAmount, int roundStartingCredits, int totalCredits)
        {
            Console.WriteLine("Winner!!!!");
            Console.WriteLine("You win " + winningAmount + " credits");
            Console.WriteLine(roundStartingCredits);
            Console.WriteLine("You have " + totalCredits + " credits");
        }

        public static int SevensCheck(int[,] ranNums, int winningNumber, int totalCredits, int bettingAmount, int winModifier)
        {
            foreach (int i in ranNums)
            {
                if (i == winningNumber)
                {
                    totalCredits += bettingAmount * winModifier;
                }
            }
            return totalCredits;
        }

        public static int Input(string line)
        {
            Console.WriteLine(line);
            int number = 0;
            while (number <= 0)
            {
                string input = Console.ReadLine();
                if (String.IsNullOrEmpty(input) || char.IsLetter(input, 0))
                {
                    continue;
                }
                else
                {
                    number = Convert.ToInt32(input);
                }

            }
            return number;
        }
    }
}