using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    class Node
    {
        public string name;
        Node parent;
        List<Node> children;
        public int satellites;
        //public void Add
        public Node(string _name)
        {
            children = new List<Node>();
            name = _name;
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
        internal int smell = -1;
        public void Fart(int distance = -1)
        {
            smell = distance;
            Console.Write("{0} feels {1}....", name,smell);
            if (parent != null)
                parent.Fart(distance+1);
            
        }
        internal static int Route = 0;
        public static void Go(Node currentNode)
        {
            ++Route;
            if (currentNode.smell < 0)
            {
                Go(currentNode.parent);
                
            }
            if (currentNode.smell > 0)
            {
                foreach (var child in currentNode.children)
                {
                    if (child.smell >= 0) Go(child);
                }
            }
            if (currentNode.smell == 0)
            {
                Console.WriteLine(Route);
                //return;
            };

        }
    }
    class Program
    {
        static void AddNodes(string parent, string child, Dictionary<string, Node> tree)
        {
            if (!tree.ContainsKey(child))
            {
                tree.Add(child, new Node(child));
            }
            if (!tree.ContainsKey(parent))
            {
                tree.Add(parent, new Node(parent));
            }
            tree[parent].AddChild(tree[child]);
            tree[child].AddParent(tree[parent]);
        }
        static void Main(string[] args)
        {
            //Choose one:
            var Data = getData(); //real data
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
            int sum = tree.Sum(x => x.Value.satellites);
            Console.WriteLine(sum);
            tree["SAN"].Fart();
            Node.Go(tree["YOU"]);
        }


        static List<string> getData()
        {
            var data = new List<string> { };
            var path = @"C:\Users\Admin\source\repos\AdventOfCode\Day6\input.txt";
            //string path = @"C:\Users\User\source\repos\AoC19\Day6\input.txt";
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
