

using System;

namespace Tutorial2
{
    internal class Program
    {
        public class DateTimeUtility
        {
            public int Century;
            public int Leap;
            public void GetCenturyAndCheckLeapYear(int year)
            {
                if (!(year >= 1000))
                {
                    Century = -1;
                    Leap = -1;
                    Console.WriteLine("Output:{0},{1}", Century, Leap);
                }
                else if (year >= 1000)
                {
                    if(year % 100 == 0)
                    {
                        Century = year / 100;
                    }
                    else
                    {
                        Century = year / 100 + 1;
                    }

                    Leap = (year % 4 == 0 || year % 400 == 0) ? 1 : -1;

                    Console.WriteLine("Output:{0},{1}", Century, Leap);
                }
            }
        }
        static void Main(string[] args)
        {
            var century = new DateTimeUtility();
            Console.WriteLine("Input year:");
            int year = Convert.ToInt32(Console.ReadLine());
            century.GetCenturyAndCheckLeapYear(year);
        }
    }
}
