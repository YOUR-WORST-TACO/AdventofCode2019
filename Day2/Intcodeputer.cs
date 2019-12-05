using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    public class Intcodeputer
    {
        public List<int> program;
        public int instruction;

        public Intcodeputer()
        {
            program = new List<int>();
            instruction = 0;
        }

        public void LoadProgram(string programFile)
        {
            string[] instructions = File.ReadAllText(programFile).Split(',');

            program = instructions.Select(int.Parse).ToList();
        }

        public void Run()
        {
            int opcode;
            instruction = 0;
            while (instruction < program.Count && (opcode = program[instruction]) != 99)
            {
                if (instruction < program.Count - 3)
                {
                    switch (opcode)
                    {
                        case 1:
                            OP1();
                            break;
                        case 2:
                            OP2();
                            break;
                        default:
                            Console.WriteLine(
                                $"ERROR!!! Unknown opcode {opcode} at instruction {instruction}! Program halting."
                            );
                            Environment.Exit(3);
                            break;
                    }

                    instruction += 4;
                }
                else
                {
                    Console.WriteLine(
                        $"ERROR!!! Malformed instruction at {instruction}! Program halting."
                    );
                    Environment.Exit(4);
                }
            }
        }

        private void OP1()
        {
            if (instruction < program.Count - 3)
            {
                int noun = program[instruction + 1];
                int verb = program[instruction + 2];
                int storage = program[instruction + 3];
                
                if (noun < program.Count && verb < program.Count && storage < program.Count)
                {
                    program[storage] = program[noun] + program[verb];
                }
                else
                {
                    Console.WriteLine($"ERROR!!! OP1 failed at instruction {instruction}! Location out of bounds! Program Halting.");
                    Environment.Exit(1);
                }
            }
            else
            {
                Console.WriteLine($"ERROR!!! OP1 failed at instruction {instruction}! Location out of bounds! Program Halting.");
                Environment.Exit(1);
            }
            
        }
        
        private void OP2()
        {
            if (instruction < program.Count - 3)
            {
                int noun = program[instruction + 1];
                int verb = program[instruction + 2];
                int storage = program[instruction + 3];
                
                if (noun < program.Count && verb < program.Count && storage < program.Count)
                {
                    program[storage] = program[noun] * program[verb];
                }
                else
                {
                    Console.WriteLine($"ERROR!!! OP2 failed at instruction {instruction}! Location out of bounds! Program Halting.");
                    Environment.Exit(2);
                }
            }
            else
            {
                Console.WriteLine($"ERROR!!! OP2 failed at instruction {instruction}! Location out of bounds! Program Halting.");
                Environment.Exit(2);
            }
        }
    }
}