using System;

namespace Tutorial1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numbers = 6;
            int blank = numbers - 1;
            for (int i = 1; i <= numbers; i++)
            {
                for (int j = 1; j <= blank; j++)
                    Console.Write(" ");
                blank--;
                for (int x = 1; x <= (2 * i) - 1; x++)
                    Console.Write("*");
                Console.WriteLine(" ");
            }
            int count = 5;
            for (int i = 1; i <= numbers - 1; i++)
            {
                for (int j = 5; j >= count; j--)
                    Console.Write(" ");
                count--;
                for (int x = 1; x <= 2 * (numbers - i) - 1; x++)
                    Console.Write("*");
                Console.WriteLine(" ");
            }
        }
    }
}

