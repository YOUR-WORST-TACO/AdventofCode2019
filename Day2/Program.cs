using System;
using System.Collections.Generic;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Intcodeputer computer = new Intcodeputer();
            
            computer.LoadProgram("../../../input.txt");

            List<int> backupProgram = new List<int>(computer.program);

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    computer.program = new List<int>(backupProgram);
                    computer.program[1] = i;
                    computer.program[2] = j;
                    computer.Run();

                    if (computer.program[0] == 19690720)
                    {
                        Console.WriteLine(100 * i + j);
                        Environment.Exit(0);
                    }
                }
            }
        }
    }
}