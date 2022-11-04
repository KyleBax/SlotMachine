using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        //TODO add comments to improve readability of some Methods that are harder to understand at a glance
        public static int CheckDiagonalLines(int[,] ranNums, int totalCredits, int bettingAmount, int smallWins, int mediumWins, int bigWins, int winningNumber)
        {
            int winModifier = smallWins;
            if (ranNums[0, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[2, 2])
            {
                totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
            }
            if (ranNums[2, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[0, 2])
            {
                totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
            }

            if (ranNums[0, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[2, 2])
            {
                if (ranNums[0, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
                }
            }
            if (ranNums[2, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[0, 2])
            {
                if (ranNums[2, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int CheckLine(int lineNr, int[,] ranNums, int totalCredits, int bettingAmount, int smallWins, int mediumWins, int bigWins, int winningNumber)
        {
            int winModifier = smallWins;
            if (ranNums[lineNr, 0] == ranNums[lineNr, 1] || ranNums[lineNr, 1] == ranNums[lineNr, 2])
            {
                totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
            }
            if (ranNums[lineNr, 0] == ranNums[lineNr, 1] && ranNums[lineNr, 1] == ranNums[lineNr, 2])
            {
                if (ranNums[lineNr, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = IncreaseTotalCredits(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int CheckForSevens(int[,] ranNums, int totalCredits, int bettingAmount, int smallWins, int winningNumber)
        {
            foreach (int i in ranNums)
            {
                if (i == winningNumber)
                {
                    totalCredits += bettingAmount * smallWins;
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
                    //TODO remove the UI parts and put them in another method
                    Console.Write(ranNums[i, j] + " ");
                }
                Console.WriteLine();
            }
            return ranNums;
        }
    }
}
