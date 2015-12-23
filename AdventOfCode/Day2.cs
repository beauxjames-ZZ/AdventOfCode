using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public static class Day2
    {
        public static string Title = "--- Day 2: I Was Told There Would Be No Math ---";
        public static string[] PackageData => File.ReadAllLines(@"data\Day2_Packages.txt");
        private static IEnumerable<Box> Boxes => PackageData.Select(x => new Box(x));

        public static int GetTotalWrappingPaper()
        {
            return Boxes.Sum(x => x.PaperRequirement);
        }

        public static int GetTotalRibbon()
        {
            return Boxes.Sum(x => x.RibbonRequirement);
        }

        public static void QuickTest()
        {
            var strDim = "2x3x4";
            var box = new Box(strDim);
            Console.WriteLine(strDim);
            Console.WriteLine("width : " + box.Width);
            Console.WriteLine("Volume : " + box.Volume);
            Console.WriteLine("AreaOfSmallestSide : " + box.AreaOfSmallestSide);
            Console.WriteLine("Paper Required : " + box.PaperRequirement);
            Console.WriteLine("Ribbon Required : " + box.RibbonRequirement);

            strDim = "1x1x10";
            box = new Box(strDim);
            Console.WriteLine(strDim);
            Console.WriteLine("width : " + box.Width);
            Console.WriteLine("Volume : " + box.Volume);
            Console.WriteLine("AreaOfSmallestSide : " + box.AreaOfSmallestSide);
            Console.WriteLine("Paper Required : " + box.PaperRequirement);
            Console.WriteLine("Ribbon Required : " + box.RibbonRequirement);
        }
    }

    public class Box
    {
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int Volume => Length*Width*Height;

        public int PaperRequirement => 2*(Length*Width + Length*Height + Width*Height) + AreaOfSmallestSide;
        public int RibbonRequirement => 2*(SidesOrderedAscending[0] + SidesOrderedAscending[1]) + Volume;

        public int[] SidesOrderedAscending => new List<int> { Length, Width, Height }.OrderBy(x => x).ToArray();
        public int AreaOfSmallestSide => Math.Min(Math.Min(Length*Width, Length*Height), Width*Height);

        public Box(string stringDimensions)
        {
            char[] delimeter = { 'x' };
            string[] splitStr = stringDimensions.Split(delimeter);

            Length = int.Parse(splitStr[0]);
            Width = int.Parse(splitStr[1]);
            Height = int.Parse(splitStr[2]);
        }
    }
}