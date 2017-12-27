using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_RecursiveCircuits
{
    using System.ComponentModel.Design.Serialization;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            var rData = LoadData("input.txt");
            var stacks = new RecursiveStack();

            foreach (var node in rData)
            {
                stacks.AddNode(node);
            }

            stacks.HandleOrphans();
            
            stacks.root.CheckNodeBalance();
            Console.WriteLine($"root name is {stacks.root.Name}");
            Console.ReadKey();
        }

        private static List<Node> LoadData(string path)
        {
            var rData = new List<Node>();

            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var splitOne = s.Split(' ');
                    var name = splitOne[0].Trim();
                    var weight = splitOne[1].Remove(splitOne[1].Length - 1).Remove(0, 1);
                    List<string> children = new List<string>();
                    if (s.Contains("->"))
                    {
                        children = s.Split('>')[1].Split(',').ToList();
                    }

                    rData.Add(new Node(name, int.Parse(weight), children.Select(c => c.Trim()).ToList()));
                }
            }

            return rData;
        }



    }
}
