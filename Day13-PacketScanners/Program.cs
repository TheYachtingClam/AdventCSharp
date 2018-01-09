using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day13_PacketScanners
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var data = LoadData("test.txt");
        }

        private static List<Tuple<int, int>> LoadData(string path)
        {
            var rData = new List<Tuple<int, int>>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var depth = int.Parse(s.Split(':')[0]);
                    var range = int.Parse(s.Split(':')[1].Trim());
                    rData.Add(new Tuple<int, int>(depth, range));
                }
            }

            return rData;
        }
    }
}
