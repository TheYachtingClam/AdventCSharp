using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12_DigitalPlumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = LoadData("input.txt");

            MyPrograms.SetData(data);

            var foundVersions = new List<int>();
            var groups = new List<List<int>>();

            foreach (var prog in data)
            {
                Console.WriteLine($"{prog.Key}");
                if (!foundVersions.Contains(prog.Key))
                {
                    var frank = MyPrograms.ProgramsAbleToCommunicateTo(prog.Key);
                    groups.Add(frank);
                    foundVersions.AddRange(frank);
                }
            }
            Console.WriteLine($"There are {groups.Count} number of groups");
            //Console.WriteLine($"the following programs can see 0, {string.Join(",", frank)} there are {frank.Count} items");
            Console.ReadKey();
        }

        private static Dictionary<int, List<int>> LoadData(string path)
        {
            var rData = new Dictionary<int, List<int>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var id = int.Parse(s.Split('<')[0].Trim());
                    var ids = s.Split('>')[1].Trim().Split(',');
                    var listIds = new List<int>();
                    foreach(var linkedId in ids)
                    {
                        listIds.Add(int.Parse(linkedId.Trim()));
                    }
                    rData[id] = listIds;
                }
            }

            return rData;
        }
    }
}
