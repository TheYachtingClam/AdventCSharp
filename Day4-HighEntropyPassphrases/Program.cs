using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4_HighEntropyPassphrases
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");
            var validCount = 0;

            foreach (var passphrase in rData)
            {
                if (IsValidPassphrase(passphrase))
                {
                    validCount++;
                    Console.WriteLine($"{string.Join(" ", passphrase)} is valid");
                }
                else
                {
                    Console.WriteLine($"{string.Join(" ", passphrase)} is invalid");
                }
            }
            Console.WriteLine($"There are {validCount} valid passphrases");
            Console.ReadKey();
        }

        private static bool IsValidPassphrase(List<string> passphrase)
        {
            var prevWords = new List<string>();
            foreach (var word in passphrase)
            {
                foreach (var oldWord in prevWords)
                {
                    if (IsAnagram(oldWord, word))
                    {
                        return false;
                    }
                }

                prevWords.Add(word);
            }
            return true;
        }

        private static bool IsAnagram(string input1, string input2)
        {
            var dict = new Dictionary<char, int>();
            foreach (var i1 in input1)
            {
                if (dict.ContainsKey(i1))
                {
                    dict[i1]++;
                }
                else
                {
                    dict[i1] = 1;
                }
            }

            foreach (var i2 in input2)
            {
                if (dict.ContainsKey(i2))
                {
                    if (dict[i2] > 1)
                    {
                        dict[i2]--;
                    }
                    else
                    {
                        dict.Remove(i2);
                    }
                }
                else
                {
                    return false;
                }
            }
            if (dict.Count > 0)
            {
                return false;
            }

            return true;
        }

        private static List<List<string>> LoadData(string path)
        {
            var rData = new List<List<string>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var bob = new List<string>();
                    var sData = s.Split(' ');
                    foreach (var s1 in sData)
                    {
                        bob.Add(s1);
                    }
                    rData.Add(bob);
                }
            }

            return rData;
        }
    }
}
