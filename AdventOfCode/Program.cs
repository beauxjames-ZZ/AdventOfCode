using System;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GoDay1();
            GoDay2();

            Console.ReadKey();
        }

        private static void GoDay2()
        {
            //Day2.QuickTest();
            Console.WriteLine("\n" + Day2.Title + "\n");
            Console.WriteLine("\tPart One :: " + Day2.GetTotalWrappingPaper() + " sq/ft Wrapping Paper");
            Console.WriteLine("\tPart Two :: " + Day2.GetTotalRibbon() + " ft Ribbon");
        }

        private static void GoDay1()
        {
            Console.WriteLine("\n" + Day1.Title + "\n");
            Console.WriteLine("\tPart One :: " + Day1.CheckSantasFloor() + " Floor");
            Console.WriteLine("\tPart Two :: " + Day1.CheckBasementPosition().First(x => x.Key < 0).Value + " Position");
        }

    }
}
