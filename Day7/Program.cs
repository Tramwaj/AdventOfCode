using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Day5
{
    class Program
    {
        static int[] GetData()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//input.txt";
            var file = new StreamReader(path);
            string line = file.ReadLine();
            int[] data = line.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
            file.Close();
            return data;
        }
        static List<int[]> GetAllSequences()
        {
            int licznik = 0;            
            var allSequences = new List<int[]>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i != j)
                        for (int k = 0; k < 5; k++)
                        {
                            if (k != j && k != i)
                                for (int l = 0; l < 5; l++)
                                {
                                    if (l != j && l != k && l != i)
                                        for (int m = 0; m < 5; m++)
                                        {
                                            if (m != i && m != j && m != k && m != l)
                                            {
                                                var sequence = new int[5];
                                                ++licznik;
                                                sequence[0]=i; sequence[1]=j;
                                                sequence[2]=k; sequence[3]=l;
                                                sequence[4]=m;
                                                allSequences.Add(sequence);
                                                foreach (var digit in sequence)
                                                {
                                                    Console.Write(digit + " ");
                                                }
                                                Console.WriteLine(licznik);
                                            }
                                        }
                                }
                        }
                }
            }            
            return allSequences;
        }        
        static int TestLaunchCombination(int[] seq, int[] program)
        {
            int[] userInput;
            userInput = new int[2] { seq[0], 0 };
            var thrustA = new IntCode(userInput, program);
            thrustA.Compute();
            userInput = new int[2] { seq[1], thrustA.output.Last() };
            var thrustB = new IntCode(userInput, program);
            thrustB.Compute();
            userInput = new int[2] { seq[2], thrustB.output.Last() };
            var thrustC = new IntCode(userInput, program);
            thrustC.Compute();
            userInput = new int[2] { seq[3], thrustC.output.Last() };
            var thrustD = new IntCode(userInput, program);
            thrustD.Compute();
            userInput = new int[2] { seq[4], thrustD.output.Last() };
            var thrustE = new IntCode(userInput, program);
            thrustE.Compute();
            Console.Write(thrustE.output.Last() + "   ");
            return thrustE.output.Last();
        } 
        static void Main(string[] args)
        {

            int[] program = GetData();
            //int[] program = { 3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0 };

            int[] inpucik = { 1, 0, 4, 3, 2 };
            int max = 0;
            int temp;
            var allSequences = GetAllSequences();
            foreach (var item in allSequences)
            {
                Console.WriteLine("Sequence:");
                foreach (var digit in item)
                {
                    Console.Write(digit + "  ");
                }
                
                temp = TestLaunchCombination(item, program);
                if (temp > max) max = temp;
            }
            

            Console.WriteLine("Result: {0}", max);
            //Console.WriteLine("Licznik: {0}", licznik);
            //TestLaunchCombination(inpucik,program);

        }
    }
}
