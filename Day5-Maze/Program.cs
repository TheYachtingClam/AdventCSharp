using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5_Maze
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");
            var steps = 1;
            var currentLocation = 0;
            while (true)
            {
                var spot = currentLocation;
                currentLocation = currentLocation + rData[spot];

                if (currentLocation >= rData.Count || currentLocation < 0)
                {
                    Console.WriteLine($"Steps = {steps}");
                    break;
                }

                steps++;
                if (rData[spot] >= 3)
                {
                    rData[spot]--;
                }
                else
                {
                    rData[spot]++;
                }
            }
            Console.ReadKey();

        }

        private static List<int> LoadData(string path)
        {
            var rData = new List<int>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    rData.Add(int.Parse(s));
                }
            }

            return rData;
        }
    }
}
