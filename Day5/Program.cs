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

            Intcodeputer Pooter = new Intcodeputer(program);

            Pooter.Start();
        }
    }
}