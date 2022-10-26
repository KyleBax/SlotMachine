namespace SlotMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new();
            int totalCredits = 100;
            int winningNumber = 7;

            Console.WriteLine("Welcome to the lucky 7s");

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
                //TODO make it possible to select how many lines you play & make it possible to play diagonal lines. make the machine check each line that you choose to play
                int[,] array = new int[3, 3];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        array[i, j] = GetRandomNumber(random);
                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                foreach (int i in array)
                {
                    if(i == winningNumber)
                    {
                        totalCredits = Win(bettingAmount, totalCredits, winModifier);
                    }
                }



                if (array[0,0] == array[0,1] || array[0,1] == array[0,2])
                {
                    winModifier = 2;
                    totalCredits = Win(bettingAmount, totalCredits, winModifier);
                }
                if (array[0, 0] == array[0, 1] && array[0, 1] == array[0, 2])
                {
                    if (array[0, 0] == winningNumber)
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
                else
                {
                    Console.WriteLine("You Lose!!!");
                    totalCredits -= bettingAmount;
                }
            }
            Console.WriteLine("looks like you ran out of credits!!");
        }

        public static int GetRandomNumber(Random random)
        {
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