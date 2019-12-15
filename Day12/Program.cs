using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.Diagnostics;

namespace Day12
{
    class Program
    {
        static List<Moon> Test1()
        {
            var moonList = new List<Moon>
            {
                new Moon(-1, 0, 2),
                new Moon(2, -10, -7),
                new Moon(4, -8, 8),
                new Moon(3, 5, -1)
            };
            return moonList;
        }
        static List<Moon> Test2()
        {
            var moonList = new List<Moon>
            {
                new Moon(-8, -10, 0),
                new Moon(5, 5, 10),
                new Moon(2, -7, 3),
                new Moon(9, -8, -3)
            };
            return moonList;
        }
        static List<Moon> Real()
        {
            var moonList = new List<Moon>
            {
                new Moon(0, 4, 0),
                new Moon(-10, -6, -14),
                new Moon(9, -16, -3),
                new Moon(6, -1, 2)
            };
            return moonList;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<Moon> moons = Test1();

            var moonArchive = new HashSet<string>();
            //MoonSystem currentPos;// = new List<int[]>();
            string currentPos;
            
            for (long i = 0; i < 10077417410; i++)
            {

                if (i % 1000000 == 0)
                {
                    //Console.WriteLine("i={0}, t1(sum 4 strings): {1}, t2(search): {2}, t3(add currentPos): {3}, t4(moving moons): {4} ", i, time1.Elapsed, time2.Elapsed, time3.Elapsed, time4.Elapsed);
                    Console.Write("{0}  ", i);
                }
                
                currentPos = moons[0].ToString() + moons[1].ToString() + moons[2].ToString() + moons[3].ToString();
                //currentPos = new MoonSystem(moons[0], moons[1], moons[2], moons[3]);
                
                if (moonArchive.Contains(currentPos)) { Console.WriteLine(i); break; }
                
                moonArchive.Add(currentPos);
              
                for (int j = 0; j < 3; j++)
                {
                    for (int k = j; k < 4; k++)
                    {
                        moons[j].ChangeV(moons[k]);
                        moons[k].ChangeV(moons[j]);
                    }
                }
                moons[0].Move();
                moons[3].Move();
                moons[2].Move();
                moons[1].Move();          
            }
            Console.WriteLine("Final:");
            foreach (var moon in moons)
            {
                Console.WriteLine(moon);
            }
            int totalEnergy = 0;
            foreach (var moon in moons)
            {
                Console.WriteLine(moon.Energy());
                totalEnergy += moon.Energy();
            }
            Console.WriteLine("Total Energy: {0}", totalEnergy);
        }
    }
}
