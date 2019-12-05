using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] passwordFloor = new[] {1, 3, 8, 3, 0, 7};
            //int[] passwordCeiling = new[] {6, 5, 4, 5, 0, 4};

            int passwordFloor = 138888;
            
            //SetupPasswordFloor(passwordFloor);

            bool valid = false;

            int validPasswords = 0;

            while (!valid)
            {
                if (ValidPassword(passwordFloor))
                {
                    validPasswords++;
                }
                
                passwordFloor++;
                if (passwordFloor >= 654504)
                {
                    valid = true;
                }
            }
            
            Console.WriteLine(validPasswords);
        }
        
        
        static bool ValidPassword(int password)
        {
            string test = password.ToString();
            bool ascendingOnly = true;
            bool inMultiple = false;
            int multipleCount = 1;
            bool doubledOnce = false;
            
            List<int> doubles = new List<int>();

            for (int i = 0; i < test.Length - 1; i++)
            {
                if (test[i] == test[i + 1])
                {
                    inMultiple = true;
                    multipleCount++;
                } else if (inMultiple)
                {
                    doubles.Add(multipleCount);
                    multipleCount = 1;
                    inMultiple = false;
                }

                if (i == test.Length - 2 && inMultiple)
                {
                    doubles.Add(multipleCount);
                    multipleCount = 1;
                    inMultiple = false;
                }

                if (test[i] > test[i + 1])
                { 
                    ascendingOnly = false;
                }
            }

            foreach (var doubled in doubles)
            {
                if (doubled == 2)
                {
                    doubledOnce = true;
                }
            }

            return ascendingOnly && doubledOnce;
        }
    }
}