using System;
using System.Linq;

namespace Day2
{

    class Program
    {
        static bool IntCode(int noun, int verb, int[] input)
        {
            input[1] = noun;
            input[2] = verb;
            var length = input.Length;
            for (int i = 0; i < length; i += 4)
            {
                if (input[i] == 99) break;
                if (input[i] == 1)
                {
                    input[input[i + 3]] = input[input[i + 1]] + input[input[i + 2]];
                }
                else if (input[i] == 2)
                {
                    input[input[i + 3]] = input[input[i + 1]] * input[input[i + 2]];
                }
            }
            if (input[0] == 19690720)
            {
                Console.WriteLine("verb: {0}, noun: {1}", verb, noun);
                return true;
            }
            else
            {
                Console.WriteLine("Fail, input[0] = {0}, verb: {1}, noun: {2}", input[0], verb, noun);
                return false;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string input = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,10,1,19,1,5,19,23,1,23,5,27,2,27,10,31,1,5,31,35,2,35,6,39,1,6,39,43,2,13,43,47,2,9,47,51,1,6,51,55,1,55,9,59,2,6,59,63,1,5,63,67,2,67,13,71,1,9,71,75,1,75,9,79,2,79,10,83,1,6,83,87,1,5,87,91,1,6,91,95,1,95,13,99,1,10,99,103,2,6,103,107,1,107,5,111,1,111,13,115,1,115,13,119,1,13,119,123,2,123,13,127,1,127,6,131,1,131,9,135,1,5,135,139,2,139,6,143,2,6,143,147,1,5,147,151,1,151,2,155,1,9,155,0,99,2,14,0,0";
            //string input = "1,1,1,4,99,5,6,0,99";
            //string input = "1,0,0,0,99";
            int[] inputInt = input.Split(",").Select(x => Convert.ToInt32(x)).ToArray();
            inputInt[1] = 12;
            inputInt[2] = 2;
            for (int i = 0; i < 165; i++)
            {
                for (int j = 0; j < 165; j++)
                {
                    var inpucik = new int[inputInt.Length];
                    for (int z = 0; z < inputInt.Length; z++)
                    {
                        inpucik[z] = inputInt[z];
                    }
                    if (IntCode(i, j, inpucik)) Console.ReadKey();
                }

            }



        }
    }
}
