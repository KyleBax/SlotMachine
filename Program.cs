namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the lucky 7s");
            int totalCredits = 100;

            while (totalCredits > 0)
            {
                Console.WriteLine("available credits: " + totalCredits);
                Console.WriteLine("How much would you like to bet?");
                int bettingAmount = Convert.ToInt32(Console.ReadLine());
                int winModifier = 1;
                while (bettingAmount <= 0)
                {
                    Console.WriteLine("You must place a valid bet");
                    Console.WriteLine("How much would you like to bet?");
                    bettingAmount = Convert.ToInt32(Console.ReadLine());
                }
                if (bettingAmount > totalCredits)
                {
                    Console.WriteLine("You have bet all your remainning credit");
                    bettingAmount = totalCredits;
                }
                for (int i = 0; i < 3; i++)
                {
                    int ranNum = GetRandomNumber();
                    Console.Write(ranNum + " ");
                }
                Console.WriteLine();
                int ranNumOne = GetRandomNumber();
                int ranNumTwo = GetRandomNumber();
                int ranNumThree = GetRandomNumber();
                Console.WriteLine(ranNumOne + " " + ranNumTwo + " " + ranNumThree);
                for (int i = 0; i < 3; i++)
                {
                    int ranNum = GetRandomNumber();
                    Console.Write(ranNum + " ");
                }
                Console.WriteLine();
                if (ranNumOne == 7)
                {
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                if (ranNumTwo == 7)
                {
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                if (ranNumThree == 7)
                {
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                if (ranNumOne == ranNumTwo || ranNumTwo == ranNumThree)
                {
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                else if (ranNumOne == ranNumTwo && ranNumTwo == ranNumThree)
                {
                    if (ranNumOne == 7)
                    {
                        winModifier = 7;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                    else
                    {
                        winModifier = 2;
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                }
                else
                {
                    Console.WriteLine("You Lose!!!");
                    totalCredits -= bettingAmount;
                }
            }
            Console.WriteLine("looks like you ran out of credits!!");
        }

        public static int GetRandomNumber()
        {
            Random random = new();
            int ranNum = random.Next(0, 8);
            return ranNum;
        }

        public static int Win(int bettingAmount, int totalCredits, int winModifier)
        {
            Console.WriteLine("Winner!!!!");
            totalCredits -= bettingAmount;
            int winningAmount = bettingAmount * winModifier;
            Console.WriteLine("You win " + winningAmount + " credits");
            Console.WriteLine(totalCredits);
            totalCredits += winningAmount;
            Console.WriteLine("You have " + totalCredits + " credits");
            return totalCredits;
        }
    }
}