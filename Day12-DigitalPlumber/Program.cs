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

            var frank = MyPrograms.ProgramsAbleToCommunicateTo(0);
            Console.WriteLine($"the following programs can see 0, {string.Join(",", frank)}");
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
