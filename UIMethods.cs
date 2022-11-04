using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    public static class UIMethods
    {
        public static void WinText(int winningAmount, int roundStartingCredits, int totalCredits)
        {
            Console.WriteLine("Winner!!!!");
            Console.WriteLine("You win " + winningAmount + " credits");
            Console.WriteLine(roundStartingCredits);
            Console.WriteLine("You have " + totalCredits + " credits");
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
        public static void HowToPlay()
        {
            Console.WriteLine("Lucky 7s uses a 3x3 grid full of random numbers");
            Console.WriteLine("Step 1: Enter the amount of lines you wish to play \nYou may select 1, 3 or 5 lines.");
            Console.WriteLine("1 line will play all the numbers in the middle line, going left to right.");
            Console.WriteLine("3 lines will play all the numbers in the top, middle and bottom lines, going left to right");
            Console.WriteLine("5 lines will play the same as 3 and include going across the diagonals of the 3x3 grid");
            Console.WriteLine("Step 2: Enter the credits you would like to bet");
            Console.WriteLine("This will be multiplied by the number of lines you chose to play,\nso you may not be able to bet your full amount of credits");
            Console.WriteLine("Step 3: WIN BIG!! (hopefully)");
            Console.WriteLine("The ways you win:");
            Console.WriteLine("There are three win types. small, medium and large");
            Console.WriteLine("1. Small wins: Get two matching numbers next to each other in a line you're playing,\nand every 7 in a line you're playing will give you a small win");
            Console.WriteLine("Each small win will give you your betting amount back");
            Console.WriteLine("2. Medium wins: Get three matching numbers in a line you're playing.\nMedium wins will give you your betting amount times 3");
            Console.WriteLine("3. Big wins: When you get three 7s in a line you're playing you will win big.\nBig wins will give you your betting amount times 7");
        }
        public static void StartingText()
        {
            Console.WriteLine("Welcome to the lucky 7s");
            Console.WriteLine("Would you like to read the rules? Y/N");
            if (Console.ReadLine().ToLower() == "y")
            {
                HowToPlay();
            }
        }
        public static void NotEnoughCredits(int totalCredits)
        {
            Console.WriteLine("you don't have enough credits");
            Console.WriteLine("your total credits are " + totalCredits);
        }
        public static void PrintLineOfText(string line)
        {
            Console.WriteLine(line);
        }
        public static void PrintRandomNumbers(int[,] ranNums, int lineNr)
        {
            Console.Write(ranNums[lineNr, 0] + " ");
            Console.Write(ranNums[lineNr, 1] + " ");
            Console.Write(ranNums[lineNr, 2] + " ");
            Console.WriteLine();
        }
    }
}

