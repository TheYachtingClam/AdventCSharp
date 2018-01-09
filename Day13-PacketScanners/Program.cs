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
            var data = LoadData("input.txt");
            var frank = FirewallCost(data, 4);
            var pathCost = 0;
            for(int i = 0;true;++i)
            {
                pathCost = FirewallCost(data, i);
                if (pathCost == 0)
                {
                    Console.WriteLine($"skip time for 0 path cost is {i}");
                    break;
                }
            }
            

            Console.WriteLine($"cost of firewal traversal is {pathCost}");
            Console.ReadKey();
        }

        public static int FirewallCost(List<Tuple<int, int>> firewall, int skip)
        {
            var cost = 0;
            foreach (var d in firewall)
            {
                if ((d.Item1 + skip) % (2 * (d.Item2 - 1)) == 0)
                {
                    //cost += d.Item1 * d.Item2;
                    cost += 1;
                }
            }
            return cost;
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
