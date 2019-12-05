/*
 * 0 - up
 * 1 - right
 * 2 - down
 * 3 - left
 */

using System;

namespace Day3
{
    public class LineAction
    {
        public LineAction()
        {
            Direction = -1;
            Distance = 0;
        }

        public LineAction(string code)
        {
            string directionCode = code.Substring(0, 1);

            switch (directionCode)
            {
                case "U":
                    Direction = 0;
                    break;
                case "R":
                    Direction = 1;
                    break;
                case "D":
                    Direction = 2;
                    break;
                case "L":
                    Direction = 3;
                    break;
                default:
                    Direction = -1;
                    break;
            }

            Distance = int.Parse(code.Substring(1, code.Length - 1));
            
        }
        
        public int Direction;
        public int Distance;
    }
}