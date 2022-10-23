namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INSERT COINS");
            int totalAmount = 100;
            while (totalAmount > 0)
            {
                Console.WriteLine("available balance");
                Console.WriteLine(totalAmount);
                Console.WriteLine("How much would you like to bet?");
                int bettingAmount = 0;
                bettingAmount = Convert.ToInt32(Console.ReadLine());
                while (bettingAmount <= 0)
                {
                    Console.WriteLine("You must place a valid bet");
                    Console.WriteLine("How much would you like to bet?");
                    bettingAmount = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("How many lines are you betting on?");
                Console.WriteLine("1 3 5");
                int linesBet = Convert.ToInt32(Console.ReadLine());
                bettingAmount *= linesBet;
                if (bettingAmount > totalAmount)
                {
                    Console.WriteLine("You do not have that much to bet");
                }

                PullTheLever(bettingAmount, linesBet);
                totalAmount -= bettingAmount;
            }
        }

        public static void PullTheLever(int bettingAmount, int linesBet)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int a = 0; a < 3; a++)
                {
                    Random random = new Random();
                    int ranNum = random.Next(0, 8);
                    Console.Write(ranNum + " ");
                }
                Console.WriteLine();
            }
        }
    }
}