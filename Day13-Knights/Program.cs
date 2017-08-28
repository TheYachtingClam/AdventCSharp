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

            var node = new GuestNode();
            node.Name = data[0].Name;

            var options = CreateOptions(data);

            var highestArrangement = new List<string>();
            int highestValue = 0;

            foreach(var opt in options)
            {
                var bob = ArrangementCost(opt, data);
                if(bob > highestValue)
                {
                    highestValue = bob;
                    highestArrangement = opt;
                }
            }
            Console.WriteLine("Best Arrangement is \" {0} with a value of {1}", string.Join(",", highestArrangement), highestValue);
            Console.ReadKey();
        }

        private static List<List<string>> CreateOptions(List<GuestData> data)
        {
            var returnList = new List<List<string>>();

            if(data.Count == 2)
            {
                returnList.Add(new List<string> { data[0].Name, data[1].Name });
                returnList.Add(new List<string> { data[1].Name, data[0].Name });
                return returnList;
            }

            for(int i = 0;i < data.Count();++i)
            {
                var smallerData = new List<GuestData>(data);
                smallerData.Remove(smallerData[i]);

                var opt = CreateOptions(smallerData);

                foreach (var option in opt)
                {
                    var lis = new List<string> { smallerData[0].Name };
                    lis.AddRange(option);
                    returnList.Add(lis);
                }
            }

            return returnList;
        }

        private static int ArrangementCost(List<string> arrangement, List<GuestData> data)
        {
            int totalCost = 0;

            for(int i = 0;i < arrangement.Count();++i)
            {
                if(i == 0)
                {
                    totalCost += NeighborCost(arrangement[0], arrangement[arrangement.Count() - 1], data);
                }
                else
                {
                    totalCost += NeighborCost(arrangement[i], arrangement[i - 1], data);
                }
            }
            return totalCost;
        }

        private static int NeighborCost(string n1, string n2, List<GuestData> data)
        {
            return data.Single(n => n.Name == n1).happiness[n2] + 
                   data.Single(n => n.Name == n2).happiness[n1];
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
