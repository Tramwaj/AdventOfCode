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
            var file = new StreamReader(path);
            string line = file.ReadLine();
            //Console.WriteLine(line);
            int[] data = line.Split(",").Select(x=>Convert.ToInt32(x)).ToArray();
            //foreach (var inp in data)
            //{
            //    Console.WriteLine("{0}  ",inp);
            //}
            return data;
        }
        //static bool IntCode(int userInput, int[] program)        {                 }
        static void Main(string[] args)
        {

             int[] input = getData();
            //int[] input = { 1002, 4, 3, 4, 33 };
            var computer = new IntCode(5, input);
            computer.Compute();
            //Console.WriteLine(input[0]);
            
            
        }
    }
}
