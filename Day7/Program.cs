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
            var data = line.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
            file.Close();
            return data;
        }
        static List<int[]> GetAllSequences(int lowerBound, int upperBound)
        {
            int licznik = 0;
            var allSequences = new List<int[]>();
            for (int i = lowerBound; i <= upperBound; i++)
            {
                for (int j = lowerBound; j <= upperBound; j++)
                {
                    if (i != j)
                        for (int k = lowerBound; k <= upperBound; k++)
                        {
                            if (k != j && k != i)
                                for (int l = lowerBound; l <= upperBound; l++)
                                {
                                    if (l != j && l != k && l != i)
                                        for (int m = lowerBound; m <= upperBound; m++)
                                        {
                                            if (m != i && m != j && m != k && m != l)
                                            {
                                                var sequence = new int[5];
                                                ++licznik;
                                                sequence[0] = i; sequence[1] = j;
                                                sequence[2] = k; sequence[3] = l;
                                                sequence[4] = m;
                                                allSequences.Add(sequence);
                                                //TestSequences(sequence,licznik);
                                            }
                                        }
                                }
                        }
                }
            }
            return allSequences;
        }
        static void TestSequences(int[] sequence, int licznik)
        {
            foreach (var digit in sequence)
            {
                Console.Write(digit + " ");
            }
            Console.WriteLine(licznik);
        }
        static int TestLaunchCombination(int[] sequence, int[] program)
        {
            List<int> userInput;
            userInput = new List<int> { sequence[0], 0 };
            var thrustA = new IntCode(userInput, program);
            thrustA.Compute();
            userInput = new List<int> { sequence[1], thrustA.Output.Last() };
            var thrustB = new IntCode(userInput, program);
            thrustB.Compute();
            userInput = new List<int> { sequence[2], thrustB.Output.Last() };
            var thrustC = new IntCode(userInput, program);
            thrustC.Compute();
            userInput = new List<int> { sequence[3], thrustC.Output.Last() };
            var thrustD = new IntCode(userInput, program);
            thrustD.Compute();
            userInput = new List<int> { sequence[4], thrustD.Output.Last() };
            var thrustE = new IntCode(userInput, program);
            thrustE.Compute();
            Console.Write(thrustE.Output.Last() + "   ");
            return thrustE.Output.Last();
        }
        static int TestLaunchCombinationWithFeedback(int[] sequence, int[] program)
        {
            var thrustA = new IntCode(new List<int> { sequence[0],0 }, program);
            //Console.WriteLine("Computing:");
            thrustA.Compute();
            //Console.WriteLine("thrustB:");
            var thrustB = new IntCode(new List<int> { sequence[1] }, program);
            thrustB.Compute();
            var thrustC = new IntCode(new List<int> { sequence[2] }, program);
            thrustC.Compute();
            var thrustD = new IntCode(new List<int> { sequence[3] }, program);
            thrustD.Compute();
            var thrustE = new IntCode(new List<int> { sequence[4] }, program);
            thrustE.Compute();
            var feedBack = new List<int> { 0 };
            do
            {
                Console.WriteLine("thrustA:");
                thrustA.ComputeWithNewInput(feedBack);
                TestOutput(thrustA.Output);
                Console.WriteLine("thrustB:");                
                thrustB.ComputeWithNewInput(thrustA.Output);
                TestOutput(thrustB.Output);
                Console.WriteLine("thrustC:");
                thrustC.ComputeWithNewInput(thrustB.Output);
                TestOutput(thrustC.Output);
                Console.WriteLine("thrustD:");
                thrustD.ComputeWithNewInput(thrustC.Output);
                TestOutput(thrustD.Output);
                Console.WriteLine("thrustE:");
                thrustE.ComputeWithNewInput(thrustD.Output);
                TestOutput(thrustE.Output);
                if (thrustE != null) feedBack = thrustE.Output;
                Console.Write("tst ");
            } while (thrustE != null);
            TestLaunchCombinationWithFeedback(thrustE.Output, sequence);
            return thrustE.Output.Last();
        }
        static void TestOutput(List<int> output)
        {
            Console.Write("output:");
            foreach (var outP in output)
            {
                Console.Write(outP + ", ");
            };
            Console.WriteLine();
        }
        static void TestLaunchCombinationWithFeedback(List<int> output, int[] sequence)
        {
            Console.Write("Sequence: ");
            foreach (var digit in sequence)
            {
                Console.Write(digit + " ");
            }
            Console.WriteLine();
            Console.Write("Output: ");
            if (output != null)
            {
                foreach (var outP in output)
                {
                    Console.Write(outP + " ");
                }
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {

            int[] program = GetData();
            //int[] program = { 3,31,3,32,1002,32,10,32,1001,31,-2,31,1007,31,0,33,1002,33,7,33,1,33,31,31,1,32,31,31,4,31,99,0,0,0 };

            int[] inpucik = { 1, 0, 4, 3, 2 };
            int max = 0;
            int temp;
            var allSequences = GetAllSequences(5, 9);
            foreach (var sequence in allSequences)
            {
                Console.WriteLine("Sequence:");
                foreach (var digit in sequence)
                {
                    Console.Write(digit + "  ");
                }

                //temp = TestLaunchCombinationWithFeedback(sequence, program);
                temp = TestLaunchCombinationWithFeedback(sequence, program);
                if (temp > max) max = temp;
            }


            Console.WriteLine("Result: {0}", max);
            //Console.WriteLine("Licznik: {0}", licznik);
            //TestLaunchCombination(inpucik,program);

        }
    }
}
