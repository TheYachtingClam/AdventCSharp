using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_RecursiveCircuits
{
    class Node
    {
        public int Weight { get; set; }

        public List<Node> children { get; set; }

        public Node parent { get; set; }

        public string Name { get; set; }

        public Node(string name, int weight, List<string> childrenNames  )
        {
            Weight = weight;
            Name = name;
            children = childrenNames.Select(s => new Node(s, 0, new List<string>())).ToList();
        }

        public override string ToString()
        {
            return $"{Name} ({Weight}) -> {string.Join(", ", children.Select(s => s.Name))}";
        }

        public void CheckNodeBalance()
        {
            var childrenValues = new List<Tuple<int, string>>();
            foreach (var child in children)
            {
                child.CheckNodeBalance();
                childrenValues.Add(new Tuple<int, string>(child.NodeValue(), child.Name));
            }
            var nodeValue = 0;
            foreach (var childrenValue in childrenValues)
            {
                if (nodeValue == 0)
                {
                    nodeValue = childrenValue.Item1;
                }
                if (nodeValue != childrenValue.Item1)
                {
                    Console.Write($"Node {Name} is broken it's values are ");
                    foreach (var value in childrenValues)
                    {
                        Console.Write($"{value.Item2}:{value.Item1},");
                    }
                    Console.WriteLine();
                }
            }
        }

        private int NodeValue()
        {
            var totalValue = Weight;
            foreach (var inpChild in children)
            {
                totalValue += inpChild.NodeValue();
            }
            return totalValue;
        }

    }
}
