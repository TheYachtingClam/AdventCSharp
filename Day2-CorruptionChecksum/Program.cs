using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2_CorruptionChecksum
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            var checkSum = 0;

            foreach (var line in rData)
            {
                var found = false;
                for (int i = 0; i < line.Count && !found; ++i)
                {
                    for (int j = 0; j < line.Count; ++j)
                    {
                        if (i != j && line[i] % line[j] == 0)
                        {
                            Console.WriteLine($"{line[i]} / {line[j]}");
                            checkSum += line[i] / line[j];
                            found = true;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"checksum = {checkSum}");
            Console.ReadKey();
        }

        private static List<List<int>> LoadData(string path)
        {
            var rData = new List<List<int>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var bob = new List<int>();
                    var sData = s.Split('\t');
                    foreach (var s1 in sData)
                    {
                        bob.Add(int.Parse(s1));
                    }
                    rData.Add(bob);
                }
            }

            return rData;
        }
    }
}
