using System;
using System.Collections.Generic;

namespace Day4
{    
    class Program
    {
        static bool TestPair(string number,int digits)
        {
            for (int i = 0; i < digits-1; i++)
            {
                if (number[i] == number[i + 1]) return true;
            }
            return false;
        }
        static bool TestPaird2(string number, int digits)
        {
            var pairs = new int[10];
            for (int i = 0; i < digits - 1; i++)
            {
                if (number[i] == number[i + 1])
                {                    
                    pairs[int.Parse(number[i].ToString())]++;
                }
            }
            foreach (var item in pairs)
            {
                if (item == 1) return true;
            }
            return false;
        }
        static bool TestDecreaseness(string number,int digits)
        {
            for (int i = 0; i < digits - 1; i++)
            {
                if (number[i + 1] < number[i]) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            int counter=0;
            var results=new List<int>();
            int digits = 6;
            for (int x = 265275; x<= 781584; x++)
            {
                var number = x.ToString();
                if (TestPaird2(number, digits) && TestDecreaseness(number, digits))
                {
                    ++counter;
                    results.Add(x);
                }
            }
            Console.WriteLine(counter);
        }
    }
}

//It is a six-digit number.
//The value is within the range given in your puzzle input.
//Two adjacent digits are the same (like 22 in 122345).
//    Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).

//Your puzzle input is 265275-781584.