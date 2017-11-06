using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Day19_Rudolph
{
    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var newMolecules = new Dictionary<string, int>();
            foreach(var replacement in rData.replacements)
            {
                int subStringIndex;
                int startIndex = 0;
                do
                {
                    subStringIndex = rData.originalString.IndexOf(replacement.Item1, startIndex);
                    if(subStringIndex >= 0)
                    {
                        var newString = rData.originalString;
                        newString = newString.Remove(subStringIndex, replacement.Item1.Count());
                        newString = newString.Insert(subStringIndex, replacement.Item2);
                        newMolecules[newString] = 0;
                        startIndex = subStringIndex + 1;
                    }
                }
                while (subStringIndex >= 0);   
            }

            foreach(var bob in newMolecules)
            {
                Console.WriteLine($"{bob.Key}");
            }
            Console.WriteLine($"Count is {newMolecules.Count}");
            Console.ReadKey();
        }

        private static RudolphData LoadData(string path)
        {
            var rData = new RudolphData();
            rData.replacements = new List<Tuple<string, string>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    if(s.Contains("=>"))
                    {
                        var bob = new string[] { "=>" };
                        var split = s.Split(bob, StringSplitOptions.None);
                        var r1 = new Tuple<string, string>(split[0].Trim(), split[1].Trim());
                        rData.replacements.Add(r1);
                    }
                    else if(!string.IsNullOrEmpty(s))
                    {
                        rData.originalString = s;
                    }
                }
            }

            return rData;
        }
    }
}
