using System;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;

            int requiredFuel = 0;

            System.IO.StreamReader file =
                new System.IO.StreamReader("../../../input.txt");
            while ((line = file.ReadLine()) != null)
            {
                int result = 0;
                try
                {
                    result = Int32.Parse(line);

                    result = FuelCalculatron((result / 3) - 2);

                    requiredFuel += result;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Failed to parse input.");
                }
            }

            file.Close();
            Console.WriteLine($"It will take {requiredFuel} fuel.");
        }

        private static int FuelCalculatron(int fuel)
        {
            int fuelFuel = (fuel / 3) - 2;

            if (fuelFuel <= 0)
            {
                return fuel;
            }

            return fuel + FuelCalculatron(fuelFuel);
        }
    }
}