using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day9_StreamProcessing
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");

            foreach (var stream in rData)
            {
                var bob = ProcessStream(stream);
                Console.WriteLine($"value for {stream} is \n{bob.Value}\ngarbage removed: {Garbage.TotalGarbage}");
            }
            Console.ReadKey();
        }

        private static Group ProcessStream(string stream)
        {
            var group = new Group();
            var tempString = stream;

            if (tempString[0].Equals('{'))
            {
                tempString = tempString.Remove(0, 1);
                var tGroup = new Group();
                tempString = tGroup.ProcessStream(tempString, 1);
                if (tempString.Length > 0)
                {
                    throw  new ApplicationException("aaarhg, more than one root group.");
                }
                group = tGroup;
            }

            return group;
        }

        private static List<string> LoadData(string path)
        {
            var rData = new List<string>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    rData.Add(s);
                }
            }

            return rData;
        }

    }
}
