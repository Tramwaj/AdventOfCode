using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Node
    {
        Node parent;
        List<Node> children;
        public int satellites;
        //public void Add
        public Node()
        {
            children = new List<Node>();
        }
        public Node(Node _parent)
        {
            parent = _parent;
            children = new List<Node>();
            //satellites = 1;
        }
        public void AddChild(Node child)
        {
            children.Add(child);
            Update();
        }
        public void AddParent(Node _parent)
        {
            parent = _parent;
        }
        //private void Update() { }
        internal void Update()
        {
            satellites = children.Select(x => (x.satellites + 1)).Sum();
            if (parent != null) parent.Update();
        }
    }
    class Program
    {
        static void AddNodes(string parent, string child, Dictionary<string, Node> tree)
        {
            if (!tree.ContainsKey(parent) && !tree.ContainsKey(child))
            {
                tree.Add(parent, new Node());
                tree.Add(child, new Node(tree[parent]));
            }
            if (tree.ContainsKey(parent)&&!tree.ContainsKey(child))
            {
                tree.Add(child, new Node(tree[parent]));               
            }
            if (!tree.ContainsKey(parent)&&tree.ContainsKey(child))
            {
                tree.Add(parent, new Node());
                tree[child].AddParent(tree[parent]);
            }
            if (tree.ContainsKey(parent) && tree.ContainsKey(child))
            {
                tree[child].AddParent(tree[parent]);
            }
                tree[parent].AddChild(tree[child]);
        }
        static void Main(string[] args)
        {
            //Choose one:
            var Data =getData(); //real data
            //var Data = new List<string> { "COM)B", "B)C", "C)D", "D)E", "E)F", "B)G", "G)H", "D)I", "D)J", "J)K", "K)L", }; //sample data
            var tree = new Dictionary<string, Node>();
            foreach (var relationship in Data)
            {
                if (relationship != null)
                {
                    var relation = relationship.Split(')');                
                    string parentName = relation[0];
                    string childName = relation[1];
                    AddNodes(parentName, childName, tree);
                }
            }
            int sum=tree.Sum(x=>x.Value.satellites);
            Console.WriteLine(sum);
            foreach (var item in tree)
            {
                Console.WriteLine("{0}: {1} satellites",item.Key,item.Value.satellites.ToString());
            }
           
        }
        

        static List<string> getData()
        {
            var data = new List<string> { };
            //var path = @"C:\Users\Admin\source\repos\AdventOfCode\Day6\input.txt";
            string path = @"C:\Users\User\source\repos\AoC19\Day6\input.txt";
           var file = new StreamReader(path);
            string line = file.ReadLine();
            data.Add(line);
            while (line != null)
            {
                line = file.ReadLine();
                data.Add(line);
            }
            return data;
        }
    }
}
