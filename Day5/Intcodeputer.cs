using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Day5
{
    public class Intcodeputer
    {
        public enum States
        {
            Ready,
            Running,
            Halted,
            Errored,
        }
        public States State;
        public int[] Stack;

        private int[] _backup;
        private int _cursor;
        private int _stackSize;

        public Intcodeputer()
        {
            State = States.Halted;
            _cursor = 0;
        }
        
        public Intcodeputer(int[] program)
        {
            State = States.Halted;
            _cursor = 0;
            
            LoadProgram(program);
        }

        public void LoadProgram(int[] program)
        {
            _stackSize = program.Length + (4 - (program.Length % 4));
            Stack = new int[_stackSize];

            for (int i = 0; i < program.Length; i++)
            {
                Stack[i] = program[i];
            }
            
            _backup = Stack;
            State = States.Ready;
        }

        public void Start()
        {
            State = States.Running;
            while (State == States.Running)
            {
                int opcode = Stack[_cursor];
                switch (opcode)
                {
                    case 1:
                        OperationOne(
                            Stack[_cursor + 1], 
                            Stack[_cursor + 2], 
                            Stack[_cursor + 3]);
                        break;
                    case 2:
                        OperationTwo(
                            Stack[_cursor + 1], 
                            Stack[_cursor + 2], 
                            Stack[_cursor + 3]);
                        break;
                    case 99:
                        State = States.Halted;
                        break;
                    default:
                        Console.WriteLine(
                            $"ERROR!!! Unknown opcode {opcode} at instruction {_cursor}! Program halting."
                        );
                        State = States.Errored;
                        break;
                }
            }
        }

        public void Reset()
        {
            Stack = _backup;
            _cursor = 0;
        }

        public void OperationOne(int noun, int verb, int result)
        {
            Stack[result] = Stack[noun] + Stack[verb];
        }
        
        public void OperationTwo(int noun, int verb, int result)
        {
            Stack[result] = Stack[noun] * Stack[verb];
        }
    }
}