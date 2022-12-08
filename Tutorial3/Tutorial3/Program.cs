using System;

namespace Tutorial3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type a number, and then press Enter:");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("Type a number, and then press Enter:");
            double secNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("a - Add, s - Subtract, m - Multiply, d - Divide");
            string option = Console.ReadLine();
            double result;
            if (option == "a")
            {
                result = firstNumber + secNumber;
                Console.WriteLine(result);
            }
            else if (option == "s")
            {
                result = firstNumber - secNumber;
                Console.WriteLine(result);
            }
            else if (option == "m")
            {
                result = firstNumber * secNumber;
                Console.WriteLine(result);
            }
            else if (option == "d")
            {
                result = firstNumber / secNumber;
                Console.WriteLine(result);
            }
        }
    }
}
