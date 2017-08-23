using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_Knights
{
    class Program
    {
        List<string> bestCasePath;
        int bestCaseValue;

        static void Main(string[] args)
        {
            var data = LoadData("test.txt");

            var bestCase = new List<string>();

            AddNode(data[0], new List<GuestNode>());
        }

        static void AddNode(GuestData data, List<GuestNode> currentPath)
        {
            foreach(var neighbor in data.happiness)
            {
                
            }
        }

        private static List<GuestData> LoadData(string path)
        {
            var guests = new List<GuestData>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var line = s.Split(' ');
                    var name = line[0];
                    var newNeighbor = line[10].Remove(line[10].Count() - 1, 1);
                    int happiness = int.Parse(line[3]);

                    if (line[2].Contains("lose"))
                    {
                        happiness = -happiness;
                    }

                    if(guests.Any(gs => gs.Name == name))
                    {
                        var guest = guests.First(gs => gs.Name == name);
                        guest.happiness[newNeighbor] = happiness;
                    }
                    else
                    {
                        var guest = new GuestData();
                        guest.happiness = new Dictionary<string, int>();
                        guest.Name = name;
                        guest.happiness[newNeighbor] = happiness;
                        guests.Add(guest);
                    }
                }
            }
            return guests;
        }
    }
}
