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
            _stackSize = program.Length;
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
                int code = opcode % 100;
                Instruction instruction;
                switch (code)
                {
                    case 1:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1],
                            Stack[_cursor + 2],
                            Stack[_cursor + 3]
                        );
                        
                        OperationOne(instruction);
                        _cursor += instruction.Size;
                        break;
                    case 2:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1],
                            Stack[_cursor + 2],
                            Stack[_cursor + 3]
                        );
                        
                        OperationTwo(instruction);
                        _cursor += instruction.Size;
                        break;
                    case 3:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1]
                        );
                        
                        OperationThree(instruction);
                        _cursor += instruction.Size;
                        break;
                    case 4:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1]
                        );
                        
                        OperationFour(instruction);
                        _cursor += instruction.Size;
                        break;
                    case 5:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1],
                            Stack[_cursor + 2]
                        );
                        
                        OperationFive(instruction);
                        break;
                    case 6:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1],
                            Stack[_cursor + 2]
                        );
                        
                        OperationSix(instruction);
                        break;
                    case 7:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1],
                            Stack[_cursor + 2],
                            Stack[_cursor + 3]
                        );
                        
                        OperationSeven(instruction);
                        _cursor += instruction.Size;
                        break;
                    case 8:
                        instruction = new Instruction(
                            opcode,
                            Stack[_cursor + 1],
                            Stack[_cursor + 2],
                            Stack[_cursor + 3]
                        );
                        
                        OperationEight(instruction);
                        _cursor += instruction.Size;
                        break;
                    case 99:
                        State = States.Halted;
                        break;
                    default:
                        Console.WriteLine(
                            $"ERROR!!! Unknown opcode {code} at instruction {_cursor}! Program halting."
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

        public void OperationOne(Instruction operation)
        {
            List<Argument> args = new List<Argument>(operation.Arguments);
            
            int noun = args[0].State ? args[0].Value : Stack[args[0].Value];
            int verb = args[1].State ? args[1].Value : Stack[args[1].Value];

            Stack[args[2].Value] = noun + verb;
        }

        public void OperationTwo(Instruction operation)
        {
            List<Argument> args = new List<Argument>(operation.Arguments);

            int noun = args[0].State ? args[0].Value : Stack[args[0].Value];
            int verb = args[1].State ? args[1].Value : Stack[args[1].Value];

            Stack[args[2].Value] = noun * verb;
        }

        public void OperationThree(Instruction operation)
        {
            int userInput;
            do
            {
                Console.Write(">");
            } while (!int.TryParse(Console.ReadLine(), out userInput));

            Stack[operation.Arguments[0].Value] = userInput;
        }

        public void OperationFour(Instruction operation)
        {
            Console.WriteLine(Stack[operation.Arguments[0].Value]);
        }

        public void OperationFive(Instruction operation)
        {
            List<Argument> args = new List<Argument>(operation.Arguments);

            int noun = args[0].State ? args[0].Value : Stack[args[0].Value];
            int verb = args[1].State ? args[1].Value : Stack[args[1].Value];

            if (noun != 0)
            {
                _cursor = verb;
            }
            else
            {
                _cursor += operation.Size;
            }
        }
        public void OperationSix(Instruction operation)
        {
            List<Argument> args = new List<Argument>(operation.Arguments);

            int noun = args[0].State ? args[0].Value : Stack[args[0].Value];
            int verb = args[1].State ? args[1].Value : Stack[args[1].Value];

            if (noun == 0)
            {
                _cursor = verb;
            }
            else
            {
                _cursor += operation.Size;
            }
        }
        public void OperationSeven(Instruction operation)
        {
            List<Argument> args = new List<Argument>(operation.Arguments);

            int noun = args[0].State ? args[0].Value : Stack[args[0].Value];
            int verb = args[1].State ? args[1].Value : Stack[args[1].Value];

            Stack[args[2].Value] = noun < verb ? 1 : 0;
        }
        public void OperationEight(Instruction operation)
        {
            List<Argument> args = new List<Argument>(operation.Arguments);

            int noun = args[0].State ? args[0].Value : Stack[args[0].Value];
            int verb = args[1].State ? args[1].Value : Stack[args[1].Value];

            Stack[args[2].Value] = noun == verb ? 1 : 0;
        }
    }
}