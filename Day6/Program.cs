using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Node
    {
        Node parent;
        Node[] children;
        int satellites;
        //public void Add
        public Node()
        {

        }
        public Node(Node _parent)
        {
            parent = _parent;            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Choose one:
            //var Data =getData(); //real data
            var Data = new List<string> { "COM)B","B)C","C)D","D)E","E)F","B)G","G)H","D)I","E)J","J)K","K)L",}; //sample data
            var tree = new Dictionary<string, Node>();
            foreach (var relationship in Data)
            {
                var relation = relationship.Split(')');
                Console.WriteLine(relation[0] + " / " + relation[1]);
                string parentName = relation[0];
                string childName = relation[1];
                AddNodes(parentName, childName,tree);

            }
        }
        static void AddNodes(string parent, string child, Dictionary<string,Node> tree)
        {
            if (!tree.ContainsKey(parent) && !tree.ContainsKey(child))
            {
                tree.Add(parent, new Node());
                tree.Add(child, new Node(tree[parent]));
                //tree[parent].
            }
        }

        static List<string> getData()
        {
            var data = new List<string> { };
            var path = @"C:\Users\Admin\source\repos\AdventOfCode\Day6\input.txt";
            var file = new StreamReader(path);
            string line = file.ReadLine();
            while (line != null)
            {
                line = file.ReadLine();
            }
            return data;
        }
    }
}
