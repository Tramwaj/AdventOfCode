using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    class IntCode
    {
        static void Compute(int userInput, int[] program)
        {
            int input = userInput;
            int output = 1337;
            int counter = 0;
            int opcode, param1, param2, param3;
            int mode1, mode2, mode3;
            do
            {
                mode3 = program[counter] / 10000;
                mode2 = program[counter] / 1000;
                mode1 = program[counter] / 100;
                opcode = program[counter] % 100;
                if (mode3 == 0) param3 = program[program[counter + 3]];
                else param3 = program[counter + 3];
                if (mode2 == 0) param2 = program[program[counter + 2]];
                else param2 = program[counter + 2];
                if (mode1 == 0) param1 = program[program[counter + 1]];
                else param1 = program[counter + 1];
                if (opcode == 99) break;
                if (opcode == 1)
                {

                    program[program[counter + 3]] = program[program[counter + 1]] + program[program[counter + 2]];
                    counter += 4;
                }
                else if (opcode == 2)
                {
                    program[program[counter + 3]] = program[program[counter + 1]] * program[program[counter + 2]];
                    counter += 4;
                }
            } while (opcode != 99);           
        }
        private 
    }
}
