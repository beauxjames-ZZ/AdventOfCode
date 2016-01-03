using System;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {

            /*GoDay1();
            GoDay2();
            GoDay3();
            GoDay4();*/
            GoDay5();

            Console.ReadKey();
        }

        private static void GoDay5()
        {
            var day5 = new Day5();
            Console.WriteLine("\n" + Day5.Title + "\n");
            //day5.Test();
            Console.WriteLine(day5.NiceStringCount() + " nice strings");
        }

        private static void GoDay4()
        {
            var day4 = new Day4();
            Console.WriteLine(("\n" + Day4.Title + "\n"));
            //day4.Md5Test();
            //day4.GetSantaHash("abcdef", 5);
            //day4.GetSantaHash("pqrstuv", 5);
            day4.GetSantaHash("yzbqklnj", 6);
        }

        private static void GoDay3()
        {
            var day3 = new Day3();
            Console.WriteLine("\n" + Day3.Title + "\n");
            day3.HousesWithAtLeastOnePresent();
            Console.WriteLine("\tPart One :: " + day3.Houses.Count + " Houses with at least one present with just Santa.");

            day3 = new Day3();
            Console.WriteLine("\n" + Day3.Title + "\n");
            day3.HousesWithAtLeastOnePresentForSantaAndRobot();
            Console.WriteLine("\tPart One :: " + day3.Houses.Count + " Houses with at least one present Santa and Robot.");
        }

        private static void GoDay2()
        {
            Console.WriteLine("\n" + Day2.Title + "\n");
            //Day2.QuickTest();
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
