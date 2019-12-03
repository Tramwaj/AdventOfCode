using System;
using System.Collections.Generic;
using System.Linq;

namespace Day3
{
    class Program
    {
        static List<int,int> CreateRoute(List<bool> route, string[] input)
        {
            int posx, posy;
            var _route = new List<bool>();
            foreach (var coords in input)
            {
                char direction = coords[0];
                coords.Remove(0, 1);
                int distance = Convert.ToInt32(coords);                
                switch (direction)
                {
                    case 'R':
                        for (int i = 0; i < distance; i++)
                        {
                            ++posx;
                            _route.Add(posx,)
                        }

                }
            }

            
        }
        static void Main(string[] args)
        {
            string input1 = "R75,D30,R83,U83,L12,D49,R71,U7,L72";

            string input2 = "U62, R66, U55, R34, D71, R55, D58, R83";
            string[] in1 = input1.Split(',');
            string[] in2 = input2.Split(',');
            var coord = new Tuple<int, int>();
            var route1 = new List<int,int>();
            var route2 = new List<int,int>();
           
        }
    }
}
