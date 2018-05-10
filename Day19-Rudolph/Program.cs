using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Day19_Rudolph
{
    using System.Runtime.CompilerServices;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var newMolecules = Replace(rData.originalString, rData.replacements);
            var str = rData.originalString;
            var steps = 0;
            while (str != "e")
            {
                str = ReplaceLargestString(str, rData.replacements);
                steps++;
            }

            Console.WriteLine($"Count is {steps}");
            Console.ReadKey();
        }

        private static string ReplaceLargestString(string str, List<Tuple<string, string>> rDataReplacements)
        {
            var sortedList = rDataReplacements.OrderByDescending(i => i.Item2.Length).ToList();
            foreach (var repl in sortedList)
            {
                if (str.Contains(repl.Item2))
                {
                    var index = str.IndexOf(repl.Item2);
                    str = str.Remove(index, repl.Item2.Length);
                    return str.Insert(index, repl.Item1);
                }
            }
            throw new Exception("Aargh, couldn't replace anything.");
        }

        private static List<string> Replace(string originalString, List<Tuple<string, string>> replacements)
        {
            var newMolecules = new Dictionary<string, int>();
            foreach (var replacement in replacements)
            {
                int subStringIndex;
                int startIndex = 0;
                do
                {
                    subStringIndex = originalString.IndexOf(replacement.Item1, startIndex);
                    if (subStringIndex >= 0)
                    {
                        var newString = originalString;
                        newString = newString.Remove(subStringIndex, replacement.Item1.Count());
                        newString = newString.Insert(subStringIndex, replacement.Item2);
                        newMolecules[newString] = 0;
                        startIndex = subStringIndex + 1;
                    }
                }
                while (subStringIndex >= 0);
            }
            return newMolecules.Select(s => s.Key).ToList();
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
