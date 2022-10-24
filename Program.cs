namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalCredits = 100;

            while (totalCredits > 0)
            {
                Console.WriteLine("available balance");
                Console.WriteLine(totalCredits);
                Console.WriteLine("How much would you like to bet?");
                int bettingAmount = Convert.ToInt32(Console.ReadLine());
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
                int ranNumOne = GetRandomNumber();
                int ranNumTwo = GetRandomNumber();
                int ranNumThree = GetRandomNumber();
                Console.WriteLine(ranNumOne + " " + ranNumTwo + " " + ranNumThree);
                if (ranNumOne == ranNumTwo || ranNumTwo == ranNumThree)
                {
                    //TODO remove magic number win mmodifiers
                    totalCredits = Win(bettingAmount, totalCredits, 1);
                }
                else if (ranNumOne == ranNumTwo && ranNumTwo == ranNumThree)
                {
                    if (ranNumOne == 7)
                    {
                        totalCredits = Win(bettingAmount, totalCredits, 7);
                    }
                    else
                    {
                        totalCredits = Win(bettingAmount, totalCredits, 2);
                    }
                }
                else
                {
                    Console.WriteLine("You Lose!!!");
                    totalCredits -= bettingAmount;
                }
            }
            Console.WriteLine("looks like you ran out of credit!!");
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