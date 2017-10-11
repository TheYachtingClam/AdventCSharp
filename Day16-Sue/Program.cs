using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Day16_Sue
{
    class Program
    {
        static void Main(string[] args)
        {
            var aunts = LoadData("input.txt");

            var masterData = new SueData
            {
                children = 3,
                cats = 7,
                samoyeds = 2,
                pomeranians = 3,
                akitas = 0,
                vizslas = 0,
                goldfish = 5,
                trees = 3,
                cars = 2,
                perfumes = 1,
            };

            foreach(var aunt in aunts)
            {
                if(masterData.compare(aunt.Value))
                {
                    Console.WriteLine($"I found the aunt, it's number {aunt.Key}");
                }
            }

            Console.ReadKey();
        }

        private static Dictionary<int, SueData> LoadData(string path)
        {
            var sues = new Dictionary<int, SueData>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var nameSplit = s.Split(':');
                    var sueNumber = int.Parse(nameSplit[0].Split(' ')[1]);

                    var list = s.Substring(nameSplit[0].Length + 2);
                    var listSplit = list.Split(',');

                    var newSue = new SueData();

                    foreach (var item in listSplit)
                    {
                        string itemName = item.Split(':')[0].Trim(' ');
                        int itemValue = int.Parse(item.Split(':')[1]);

                        Type type = newSue.GetType();
                        PropertyInfo prop = type.GetProperty(itemName);
                        prop.SetValue(newSue, itemValue, null);
                    }

                    sues[sueNumber] = newSue;
                }
            }

            return sues;
        }
    }
}
