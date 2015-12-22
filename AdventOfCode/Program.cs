using System;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            
            GoDay1();

            Console.ReadKey();
        }

        static void GoDay1()
        {
            Console.WriteLine("Day1 - " + Day1.Title + "\n");
            
            Console.WriteLine("\tPart One :: " + Day1.CheckSantasFloor());
            foreach (var moo in Day1.CheckBasementPosition().Where(x => x.Key < 0))
            {
                Console.WriteLine("\tPart Two :: " + moo.Value);
            }
        }

    }
}
