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
            //int[] input = { 3,21,1008,21,8,20,1005,20,22,107,8,21,20,1006,20,31,1106,0,36,98,0,0,1002,21,125,20,4,20,1105,1,46,104,999,1105,1,46,1101,1000,1,20,4,20,1105,1,46,98,99 };
            var computer = new IntCode(5, input);
            computer.Compute();
            //Console.WriteLine(input[0]);
            
            
        }
    }
}
