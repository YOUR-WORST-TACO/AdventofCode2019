using System;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] program = File.ReadAllText("../../../input.txt")
                .Split(',')
                .Select(int.Parse)
                .ToArray();

            string testCase = "3,9,8,9,10,9,4,9,99,-1,8";
            int[] testProgram = testCase.Split(',').Select(int.Parse).ToArray();

            Intcodeputer Pooter = new Intcodeputer(program);

            Pooter.Start();
            
            Console.WriteLine("Hello World!");
        }
    }
}