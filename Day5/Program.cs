using System;
using System.Linq;
using System.IO;
using System.Reflection;

namespace Day5
{
    class Program
    {
        static int[] GetData()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)+"//input.txt";
            var file = new StreamReader(path);
            string line = file.ReadLine();            
            int[] data = line.Split(",").Select(x=>Convert.ToInt32(x)).ToArray();        
            file.Close();
            return data;
        }
        //static bool IntCode(int userInput, int[] program)        {                 }
        static void Main(string[] args)
        {

             int[] input = GetData();
            //int[] input = { 3, 12, 6, 12, 15, 1, 13, 14, 13, 4, 13, 99, -1, 0, 1, 9 };
            var computer = new IntCode(0, input);
            computer.Compute();
            //Console.WriteLine(input[0]);
            
            
        }
    }
}
