namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int totalAmount = 100;

            while (totalAmount > 0)
            {
                Console.WriteLine("available balance");
                Console.WriteLine(totalAmount);
                Console.WriteLine("How much would you like to bet?");
                int bettingAmount = Convert.ToInt32(Console.ReadLine());
                while (bettingAmount <= 0)
                {
                    Console.WriteLine("You must place a valid bet");
                    Console.WriteLine("How much would you like to bet?");
                    bettingAmount = Convert.ToInt32(Console.ReadLine());
                }
                if (bettingAmount > totalAmount)
                {
                    Console.WriteLine("You have bet all your remainning credit");
                    bettingAmount = totalAmount;
                }
                int ranNumOne = GetRandomNumber();
                int ranNumTwo = GetRandomNumber();
                int ranNumThree = GetRandomNumber();
                Console.WriteLine(ranNumOne + " " + ranNumTwo + " " + ranNumThree);
                if (ranNumOne == ranNumTwo || ranNumTwo == ranNumThree)
                {
                    //TODO remove magic number win mmodifiers
                    totalAmount = Win(bettingAmount, totalAmount, 1);
                }
                else if (ranNumOne == ranNumTwo && ranNumTwo == ranNumThree)
                {
                    if (ranNumOne == 7)
                    {
                        totalAmount = Win(bettingAmount, totalAmount, 7);
                    }
                    else
                    {
                        totalAmount = Win(bettingAmount, totalAmount, 2);
                    }
                }
                else
                {
                    Console.WriteLine("You Lose!!!");
                    totalAmount -= bettingAmount;
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
        public static int Win(int bettingAmount, int totalAmount, int winModifier)
        {
            Console.WriteLine("Winner!!!!");
            totalAmount -= bettingAmount;
            int winningAmount = bettingAmount * winModifier;
            Console.WriteLine("You win " + winningAmount + " credits");
            Console.WriteLine(totalAmount);
            totalAmount += winningAmount;
            Console.WriteLine(totalAmount);
            return totalAmount;
        }
    }
}