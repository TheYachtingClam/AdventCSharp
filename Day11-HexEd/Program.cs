using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11_HexEd
{
    class Program
    {        
        static void Main(string[] args)
        {
            var data = LoadData("input.txt");
            
            foreach(var inp in data)
            {
                var furthestDistance = 0;

                for (int i = 1;i <= inp.Count;++i)
                {
                    var subPath = inp.GetRange(0, i);
                    var currentDistance = CountDistanceInSteps(subPath);
                    if(currentDistance > furthestDistance)
                    {
                        furthestDistance = currentDistance;
                    }
                }
                Console.WriteLine($"{string.Join(",", inp)} is {CountDistanceInSteps(inp)} steps away, but it's furthest distance away was {furthestDistance}");
            }
            Console.ReadKey();
        }

        static int CountDistanceInSteps(List<directions> input)
        {
            var distance = new Dictionary<directions, int>()
            {
                {directions.northWest, 0},
                {directions.north, 0 },
                {directions.northEast, 0 },
            };
            
            foreach(var dir in input)
            {
                switch (dir)
                {
                    case directions.northWest:
                        distance[directions.northWest]++;
                        break;
                    case directions.northEast:
                        distance[directions.northEast]++;
                        break;
                    case directions.north:
                        // distance[directions.north]++;
                        distance[directions.northEast]++;
                        distance[directions.northWest]++;
                        break;
                    case directions.south:
                        // distance[directions.north]--;
                        distance[directions.northEast]--;
                        distance[directions.northWest]--;
                        break;
                    case directions.southEast:
                        distance[directions.northWest]--;
                        break;
                    case directions.southWest:
                        distance[directions.northEast]--;
                        break;
                }
            }

            if(distance[directions.northEast] > 0 && distance[directions.northWest] > 0)
            {
                var northNumber = Math.Min(distance[directions.northEast], distance[directions.northWest]);
                distance[directions.north] = northNumber;
                distance[directions.northEast] -= northNumber;
                distance[directions.northWest] -= northNumber;
            }
            else if (distance[directions.northEast] < 0 && distance[directions.northWest] < 0)
            {
                var southNumber = Math.Min(-distance[directions.northEast], -distance[directions.northWest]);
                distance[directions.north] = -southNumber;
                distance[directions.northEast] -= -southNumber;
                distance[directions.northWest] -= -southNumber;
            }

            return Math.Abs(distance[directions.northEast]) + Math.Abs(distance[directions.northWest]) + Math.Abs(distance[directions.north]);
        }

        public enum directions
        {
            northWest,
            north,
            northEast,
            southWest,
            south,
            southEast,
        }

        private static List<List<directions>> LoadData(string path)
        {
            var rData = new List<List<directions>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var lineData = new List<directions>();
                    foreach(var dir in s.Split(','))
                    {
                        switch(dir)
                        {
                            case "nw":
                                lineData.Add(directions.northWest);
                                break;
                            case "n":
                                lineData.Add(directions.north);
                                break;
                            case "ne":
                                lineData.Add(directions.northEast);
                                break;
                            case "sw":
                                lineData.Add(directions.southWest);
                                break;
                            case "s":
                                lineData.Add(directions.south);
                                break;
                            case "se":
                                lineData.Add(directions.southEast);
                                break;
                            default:
                                throw new ApplicationException($"unknown data in input. {dir}");
                        }
                    }
                    rData.Add(lineData);
                }
            }

            return rData;
        }
    }
}
