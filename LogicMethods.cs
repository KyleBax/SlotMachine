using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class LogicMethods
    {
        public static int CheckDiagonalLines(int[,] ranNums, int totalCredits, int bettingAmount, int smallWins, int mediumWins , int bigWins, int winningNumber)
        {
            int winModifier = smallWins;
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
                if (ranNums[0, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            if (ranNums[2, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[0, 2])
            {
                if (ranNums[2, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int CheckTopAndBottomLines(int[,] ranNums, int totalCredits, int bettingAmount, int smallWins, int mediumWins, int bigWins, int winningNumber)
        {
            int winModifier = smallWins;
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
                if (ranNums[0, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            if (ranNums[2, 0] == ranNums[2, 1] && ranNums[2, 1] == ranNums[2, 2])
            {
                if (ranNums[2, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
            }
            return totalCredits;
        }
        public static int CheckMiddleLine(int[,] ranNums, int totalCredits, int bettingAmount, int smallWins, int mediumWins, int bigWins, int winningNumber)
        {
            int winModifier = smallWins;
            if (ranNums[1, 0] == ranNums[1, 1] || ranNums[1, 1] == ranNums[1, 2])
            {
                totalCredits = Win(bettingAmount, totalCredits, winModifier);
            }
            if (ranNums[1, 0] == ranNums[1, 1] && ranNums[1, 1] == ranNums[1, 2])
            {
                if (ranNums[1, 0] == winningNumber)
                {
                    winModifier = bigWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else
                {
                    winModifier = mediumWins;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
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
        public static int Win(int bettingAmount, int totalCredits, int winModifier)
        {
            totalCredits += bettingAmount * winModifier;
            return totalCredits;
        }
    }
}
