using System.Collections.Generic;
using System.Linq;

namespace Day5
{
    public class Argument
    {
        public Argument(int value, bool state)
        {
            Value = value;
            State = state;
        }
        public int Value;
        public bool State;
    }
    
    public class Instruction
    {
        public List<Argument> Arguments;
        public int Operation;
        public int Size;

        public Instruction(int opcode, params int[] list)
        {
            Operation = opcode % 100;
            opcode = opcode / 10;

            Size = 1 + list.Length;
            
            Arguments = list.ToList()
                .Select(x => new Argument(x, (opcode /= 10) % 10 != 0))
                .ToList();
        }
    }
}