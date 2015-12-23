using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day3
    {
        public static string Title = "--- Day 3: Perfectly Spherical Houses in a Vacuum ---";
        public static char[] NavigationalData => File.ReadAllText(@"data\Day3_HousingGrid.txt").ToCharArray();
        
        private static char Up { get; } = (char) 94 /*"^"*/;
        private static char Down { get; } = (char) 118 /*"v"*/;
        private static char Left { get; } = (char) 60 /*"<"*/;
        private static char Right { get; } = (char) 62 /*">"*/;

        public static int HousesWithAtLeastOnePresent()
        {
            return Navigate(NavigationalData).Count;
        }

        public static void QuickTest()
        {
            Console.WriteLine(Navigate(new char[] { (char) 62 }).Count);
            Console.WriteLine(Navigate("^>v<".ToCharArray()).Count);
            Console.WriteLine(Navigate("^v^v^v^v^v".ToCharArray()).Count);
            foreach (var house in Navigate("^v^v^v^v^v".ToCharArray()))
            {
                Console.WriteLine("House Presents :: " + house.Presents);
            }
        }

        public static List<House> Navigate(char[] navigationalData)
        {
            var houses = new List<House> { new House(0, 0) };
            var la = 0;
            var lo = 0;

            foreach (var action in navigationalData)
            {
                la = action.Equals(Up) ? la + 1 : action.Equals(Down) ? la - 1 : la;
                lo = action.Equals(Right) ? lo + 1 : action.Equals(Left) ? lo - 1 : lo;

                var thisHouse = houses.FirstOrDefault(h => h.Lat == la && h.Long == lo);

                if (thisHouse != null)
                {
                    thisHouse.Hit();
                }
                else
                {
                    houses.Add(new House(la, lo));
                }
            }

            return houses;
        }
    }

    public class House
    {
        public int Lat { get; set; }
        public int Long { get; set; }
        public int Presents { get; set; }

        public House(int lat, int l)
        {
            Lat = lat;
            Long = l;
            Presents = 1;
        }

        public void Hit()
        {
            Presents++;
        }
    }
}