using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day14_Reindeer
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = LoadData("input.txt");
            var longestDistance = 0;
            var distanceLeader = "";
            var points = new Dictionary<string, int>();

            for(int i = 1;i <= 2503;++i)
            {
                foreach (var reindeer in data)
                {
                    var travelled = reindeer.TravelledDistance(i);
                    if (travelled > longestDistance)
                    {
                        longestDistance = travelled;
                        distanceLeader = reindeer.Name;
                    }
                }
                if(points.ContainsKey(distanceLeader))
                {
                    points[distanceLeader]++;
                }
                else
                {
                    points[distanceLeader] = 1;
                }
                Console.WriteLine("{0} has {1} points", distanceLeader, points[distanceLeader]);
            }
            foreach(var leader in points)
            {
                Console.WriteLine("{0} has {1} points", leader.Key, leader.Value);
            }

            Console.WriteLine("travelled {0} km", longestDistance);
            Console.ReadKey();
        }

        private static List<Reindeer> LoadData(string path)
        {
            var reindeer = new List<Reindeer>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var line = s.Split(' ');
                    var name = line[0];
                    int speed = int.Parse(line[3]);
                    int goLength = int.Parse(line[6]);
                    int stopLength = int.Parse(line[13]);

                    var newReindeer = new Reindeer
                    {
                        Name = name,
                        Speed = speed,
                        GoLength = goLength,
                        StopLength = stopLength
                    };
                    reindeer.Add(newReindeer);
                }
            }

            return reindeer;
        }
    }
}
