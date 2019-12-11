using System;
using System.Linq;
using System.IO;
using System.Reflection;

namespace Day5
{
    class Program
    {
        static int[] getData()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"//input.txt";
            //string path = @"C:\Users\User\source\repos\AoC19\Day6\input.txt";
            var file = new StreamReader(path);
            string line = file.ReadLine();
            Console.WriteLine(line);
            int[] data = line.Split(",").Select(x=>Convert.ToInt32(x)).ToArray();
            foreach (var inp in data)
            {
                Console.WriteLine("{0}  ",inp);
            }
            return data;
        }
        static bool IntCode(int userInput, int[] input)
        {
            input[0] = userInput;;
            int i = 0;            
            do
            {
                if (input[i] == 99) break;
                if (input[i] == 1)
                {
                    input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                    i += 4;
                }
                else if (input[i] == 2)
                {
                    input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                    i += 4;
                }
            }while (input[i]!=99)
            return false;
        }
        static void Main(string[] args)
        {
            
            int[] input = getData();
            
        }
    }
}
