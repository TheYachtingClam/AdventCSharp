using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day7_RecursiveCircuits
{
    using System.Data.OleDb;

    class RecursiveStack
    {
        public Node root;

        private List<Node> orphans = new List<Node>();

        public void AddNode(Node node)
        {
            if (root == null)
            {
                root = node;
                return;
            }
            var t = AttachNode(node, root);
            if (t != null)
            {
                root = t;
                return;
            }
            orphans.Add(node);
        }

        public void HandleOrphans()
        {
            while (CycleOrphans() > 0)
            {
                Console.WriteLine($"I have {orphans.Count} left");
            }
        }

        private int CycleOrphans()
        {
            var orphansToRemove = new List<Node>();
            foreach (var orphan in orphans)
            {
                var index = orphans.IndexOf(orphan);
                var t = AttachNode(orphan, root);
                if (t != null)
                {
                    root = t;
                    orphansToRemove.Add(orphan);
                }
            }

            foreach (var i in orphansToRemove)
            {
                orphans.Remove(i);
            }
            return orphans.Count;
        }

        private Node AttachNode(Node newNode, Node oldNode)
        {
            if (newNode.children.Any(s => s.Name.Equals(oldNode.Name)))
            {
                var tempNode = oldNode;
                var itemToRemove = newNode.children.First(s => s.Name == tempNode.Name);
                newNode.children.Remove(itemToRemove);
                newNode.children.Add(tempNode);
                return newNode;
            }
            else if (newNode.Name == oldNode.Name)
            {
                return newNode;
            }
            else
            {
                foreach (var node in oldNode.children)
                {
                    var n = AttachNode(newNode, node);
                    if (n != null)
                    {
                        oldNode.children.Remove(oldNode.children.First(s => s.Name == n.Name));
                        oldNode.children.Add(n);
                        return oldNode;
                    }
                }
                return null;
            }
        }
    }
}
