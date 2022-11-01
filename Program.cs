﻿namespace SlotMachine
{
    internal class Program
    {
        static readonly int SMALL_WINS = 1;
        static readonly int MEDIUM_WINS = 3;
        static readonly int BIG_WINS = 7;
        static readonly int WINNING_NUMBER = 7;
        static readonly int STARTING_CREDITS = 100;
        static void Main(string[] args)
        {
            bool TEST_MODE = true;
            Random random;

            if (TEST_MODE)
                random = new(5);
            else
                random = new();

            int totalCredits = STARTING_CREDITS;
            int[,] ranNums = new int[3, 3];

            Console.WriteLine("Welcome to the lucky 7s");

            while (totalCredits > 0)
            {
                Console.WriteLine("available credits: " + totalCredits);
                int winModifier = SMALL_WINS;

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
                
                //single central line
                if (linesBet == 1)
                {
                    if (ranNums[1, 0] == WINNING_NUMBER)
                    {
                        winModifier = SMALL_WINS;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    if (ranNums[1, 1] == WINNING_NUMBER)
                    {
                        winModifier = SMALL_WINS;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    if (ranNums[1, 2] == WINNING_NUMBER)
                    {
                        winModifier = SMALL_WINS;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    totalCredits = MiddleLineCheck(ranNums, totalCredits, bettingAmount);
                }
                //3 lines going from left to right
                if (linesBet == 3)
                {
                    totalCredits = SevensCheck(ranNums, totalCredits, bettingAmount);
                    totalCredits = MiddleLineCheck(ranNums, totalCredits, bettingAmount);
                    totalCredits = TopAndBottomLineCheck(ranNums, totalCredits, bettingAmount);
                }
                //3 lines left to right and diagonals
                if (linesBet == 5)
                {
                    totalCredits = SevensCheck(ranNums, totalCredits, bettingAmount);
                    totalCredits = MiddleLineCheck(ranNums, totalCredits, bettingAmount);
                    totalCredits = TopAndBottomLineCheck(ranNums, totalCredits, bettingAmount);
                    totalCredits = DiagonalLineCheck(ranNums, totalCredits, bettingAmount);
                }
                if (totalCredits <= roundStartingCredits)
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

        public static int DiagonalLineCheck(int[,] ranNums, int totalCredits, int bettingAmount)
        {
            int winModifier = SMALL_WINS;
            if (ranNums[0, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[2, 2])
            {
                totalCredits = Win(bettingAmount, totalCredits, winModifier);
            }
            if (ranNums[2, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[0, 2])
            {
                totalCredits = Win(bettingAmount, totalCredits, winModifier);
            }

            if (ranNums[0, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[2, 2])
            {
                if (ranNums[0, 0] == WINNING_NUMBER)
                {
                    winModifier = BIG_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = MEDIUM_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            if (ranNums[2, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[0, 2])
            {
                if (ranNums[2, 0] == WINNING_NUMBER)
                {
                    winModifier = BIG_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = MEDIUM_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int TopAndBottomLineCheck(int[,] ranNums, int totalCredits, int bettingAmount)
        {
            int winModifier = SMALL_WINS;
            if (ranNums[0, 0] == ranNums[0, 1] || ranNums[0, 1] == ranNums[0, 2])
            {
                totalCredits = Win(bettingAmount, totalCredits, winModifier);
            }
            if (ranNums[2, 0] == ranNums[2, 1] || ranNums[2, 1] == ranNums[2, 2])
            {
                totalCredits = Win(bettingAmount, totalCredits, winModifier);
            }

            if (ranNums[0, 0] == ranNums[0, 1] && ranNums[0, 1] == ranNums[0, 2])
            {
                if (ranNums[0, 0] == WINNING_NUMBER)
                {
                    winModifier = BIG_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = MEDIUM_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            if (ranNums[2, 0] == ranNums[2, 1] && ranNums[2, 1] == ranNums[2, 2])
            {
                if (ranNums[2, 0] == WINNING_NUMBER)
                {
                    winModifier = BIG_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = MEDIUM_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int MiddleLineCheck(int[,] ranNums, int totalCredits, int bettingAmount)
        {
            int winModifier = SMALL_WINS;
            if (ranNums[1, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[1, 2])
            {
                totalCredits = Win(bettingAmount, totalCredits, winModifier);
            }
            if (ranNums[1, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[1, 2])
            {
                if (ranNums[1, 0] == WINNING_NUMBER)
                {
                    winModifier = BIG_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = MEDIUM_WINS;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int Win(int bettingAmount, int totalCredits, int winModifier)
        {
            totalCredits += bettingAmount * winModifier;
            return totalCredits;
        }
        public static int SevensCheck(int[,] ranNums, int totalCredits, int bettingAmount)
        {
            foreach (int i in ranNums)
            {
                if (i == WINNING_NUMBER)
                {
                    totalCredits += bettingAmount * SMALL_WINS;
                }
            }
            return totalCredits;
        }

        public static void WinText(int winningAmount, int roundStartingCredits, int totalCredits)
        {
            Console.WriteLine("Winner!!!!");
            Console.WriteLine("You win " + winningAmount + " credits");
            Console.WriteLine(roundStartingCredits);
            Console.WriteLine("You have " + totalCredits + " credits");
        }
        public static int Input(string line)
        {
            int number = 0;
            while (number <= 0)
            {
                Console.WriteLine(line);
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