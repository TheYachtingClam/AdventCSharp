using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Day17_NoSuchThing
{
    class Program
    {
        static void Main(string[] args)
        {
            var containers = LoadData("input.txt");

            var solution = fillCups(containers, 150);

            var quality = new Dictionary<int, int>();
            foreach(var sol in solution)
            {
                if(!quality.ContainsKey(sol.Count))
                {
                    quality[sol.Count] = 1;
                }
                else
                {
                    quality[sol.Count]++;
                }
            }



            Console.WriteLine("number of solutions: " + solution.Count());
            Console.ReadKey();
        }
        


        private static List<List<int>> fillCups(List<int> cups, int volume)
        {
            var retVal = new List<List<int>>();
            var diminishingCups = new List<int>(cups);

            foreach (var cup in cups)
            {
                diminishingCups.Remove(cup);
                if(cup == volume)
                {
                    retVal.Add(new List<int> { cup });
                }
                else if(cup < volume)
                {
                    foreach(var ret in fillCups(diminishingCups, volume - cup))
                    {
                        ret.Add(cup);
                        retVal.Add(ret);
                    }
                }
            }

            return retVal;
        }

        private static List<int> LoadData(string path)
        {
            var retData = new List<int>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    retData.Add(int.Parse(s));
                }
            }

            return retData;
        }
    }
}
