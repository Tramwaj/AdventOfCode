using System;
using System.IO;

namespace AoC19_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines(@"G:\input.txt");
            int sum=0;
            foreach (var item in input)
            {
                int module = Convert.ToInt32(item);
                sum += module / 3 - 2;
            }
            int fuelWeight=sum;            
            do
            {
                fuelWeight = fuelWeight / 3 - 2;
                if (fuelWeight>0)
                    sum += fuelWeight;                
            } while (fuelWeight >= 0);
            Console.WriteLine(sum);
        }
    }
}
//3429947
//5144878