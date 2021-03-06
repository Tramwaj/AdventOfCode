﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Day5
{
    class IntCode
    {
        int inputCounter = 0;
        int opcode, param1, param2;
        public List<int> Input;
        public List<int> Output;
        int[] program;
        int counter = 0;
        bool endCalc = false;
        public IntCode(List<int> _userInput, int[] _program)
        {
            Input = _userInput;
            program = CopyArr(_program);
            Output = new List<int>();
        }
        public void ComputeWithNewInput(List<int> _userInput)
        {
            Input=_userInput;
            counter = 0;
            inputCounter = 0;
            endCalc = false;
            //Output = null;
            Compute();
        }
        private int[] CopyArr(int[] array)
        {
            int length = array.Length;
            var copiedArr = new int[length];
            for (int i = 0; i < length; i++)
            {
                copiedArr[i] = array[i];
            }
            return copiedArr;
        }
        public int Compute()
        {
            int mode1, mode2, mode3;
            do
            {
                int ABCDE = program[counter];
                mode3 = ABCDE / 10000;
                ABCDE -= mode3 * 10000;
                mode2 = ABCDE / 1000;
                ABCDE -= mode2 * 1000;
                mode1 = ABCDE / 100;
                opcode = program[counter] % 100;
                if ((opcode == 99)||(endCalc==true)) break;
                if (opcode <= 2 || opcode > 6) TernaryOperation(mode1, mode2, mode3);
                if ((opcode > 2) && (opcode < 5)) UnaryOperation(mode1);
                if (opcode == 5 || opcode == 6) BinaryOperation(mode1, mode2);
            } while (opcode != 99);
            return program[0];
        }
        private void BinaryOperation(int mode1, int mode2) //5 - jump if true, 6 - jump if false
        {
            if (mode1 == 0) param1 = program[program[counter + 1]];
            else param1 = program[counter + 1];

            param2 = program[counter + 2];
            bool paramIsNotZero = (param1 != 0);
            int ptr = mode2 == 0 ? program[param2] : param2;
            counter += 3;

            if (paramIsNotZero && opcode == 5) counter = ptr;
            if (!paramIsNotZero && opcode == 6) counter = ptr;


            //if (mode2 == 1) Console.WriteLine("ERROR: Operation output address is in mode 1! counter: {0}",counter);
        }
        private void TernaryOperation(int mode1, int mode2, int mode3)
        {
            int _result = 1337;
            if (mode2 == 0) param2 = program[program[counter + 2]];
            else param2 = program[counter + 2];
            if (mode1 == 0) param1 = program[program[counter + 1]];
            else param1 = program[counter + 1];

            if (opcode == 1)
            {
                _result = param1 + param2;
            }
            if (opcode == 2)
            {
                _result = param1 * param2;
            }
            if (opcode == 7) _result = Convert.ToInt32(param1 < param2);
            if (opcode == 8) _result = Convert.ToInt32(param1 == param2);
            if (mode3 == 0) program[program[counter + 3]] = _result;
            if (mode3 == 1) program[counter + 3] = _result;
            counter += 4;
        }
        private void UnaryOperation(int mode)
        {
            if (opcode == 3)
            {
                if (mode == 0) program[program[counter + 1]] = Input[inputCounter++];
                if (inputCounter == Input.Count - 1) endCalc=true ;
                if (mode == 1) Console.WriteLine("Cannot write to value");
            }
            if (opcode == 4)
            {
                int _out = 1337;
                if (mode == 0) _out = program[program[counter + 1]];
                if (mode == 1) _out = program[counter + 1];
                Output.Add(_out);
                //Console.WriteLine("Output no. {0}: {1}", output.Count, _out);
            }
            counter += 2;
        }
    }
}

