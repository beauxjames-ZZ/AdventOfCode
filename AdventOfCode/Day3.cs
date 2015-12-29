using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day3
    {
        public static string Title = "--- Day 3: Perfectly Spherical Houses in a Vacuum ---";
        public static char[] NavigationalData => File.ReadAllText(@"data\Day3_HousingGrid.txt").ToCharArray();
        
        private static char Up { get; } = (char) 94 /*"^"*/;
        private static char Down { get; } = (char) 118 /*"v"*/;
        private static char Left { get; } = (char) 60 /*"<"*/;
        private static char Right { get; } = (char) 62 /*">"*/;

        public int LaSanta { get; set; } = 0;
        public int LoSanta { get; set; } = 0;
        public int LaRobot { get; set; } = 0;
        public int LoRobot { get; set; } = 0;
        public List<House> Houses { get; set; } = new List<House>(); 

        public int HousesWithAtLeastOnePresent()
        {
            NavigateSanta(NavigationalData);
            return Houses.Count;
        }

        public int HousesWithAtLeastOnePresentForSantaAndRobot()
        {
            NavigateSantaRobot(NavigationalData);
            return Houses.Count;
        }

        public void QuickTest()
        {
/*
            Console.WriteLine(NavigateSanta(new char[] { (char) 62 }).Count);
            Console.WriteLine(NavigateSanta("^>v<".ToCharArray()).Count);
            Console.WriteLine(NavigateSanta("^v^v^v^v^v".ToCharArray()).Count);
            foreach (var house in NavigateSanta("^v^v^v^v^v".ToCharArray()))
            {
                Console.WriteLine("House Presents :: " + house.Presents);
            }*/
        }

        public void NavigateSanta(char[] navigationalData)
        {
            foreach (var action in navigationalData)
            {
                MakeMove(action, false);
            }
        }

        public void NavigateSantaRobot(char[] navigationalData)
        {
            var isRobot = false;

            foreach (var action in navigationalData)
            {
                MakeMove(action, isRobot);
                isRobot = !isRobot;
            }
        }

        private void MakeMove(char action, bool isRobot)
        {
            var la = isRobot ? LaRobot : LaSanta;
            var lo = isRobot ? LoRobot : LoSanta;

            la = action.Equals(Up) ? la + 1 : action.Equals(Down) ? la - 1 : la;
            lo = action.Equals(Right) ? lo + 1 : action.Equals(Left) ? lo - 1 : lo;

            var thisHouse = Houses.FirstOrDefault(h => h.Lat == la && h.Long == lo);

            if (thisHouse != null)
            {
                thisHouse.Hit();
            }
            else
            {
                Houses.Add(new House(la, lo));
            }

            LaSanta = isRobot ? LaSanta : la;
            LoSanta = isRobot ? LoSanta : lo;
            LaRobot = isRobot ? la : LaRobot;
            LoRobot = isRobot ? lo : LoRobot;
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