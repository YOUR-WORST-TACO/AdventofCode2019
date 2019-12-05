using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*
 * 0 - up
 * 1 - right
 * 2 - down
 * 3 - left
 */

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<LineAction[]> lines = File.ReadAllLines("../../../input.txt")
                .Select(x => x.Split(',')
                    .Select(y => new LineAction(y))
                    .ToArray())
                .ToList();

            int centerX = 10000;
            int centerY = 10000;
            int cursorX = centerX;
            int cursorY = centerY;
            int[,] grid = new int[30000, 30000];
            List<Intersection> intersections = new List<Intersection>();
            List<int> distances = new List<int>();
            
            lines[0].ToList().ForEach(x =>
            {
                switch (x.Direction)
                {
                    case 0:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY++;
                            grid[cursorX, cursorY] += 1;
                        }
                        break;
                    case 1:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX++;
                            grid[cursorX, cursorY] += 1;
                        }
                        break;
                    case 2:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY--;
                            grid[cursorX, cursorY] += 1;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX--;
                            grid[cursorX, cursorY] += 1;
                        }
                        break;
                }
            });

            cursorX = centerX;
            cursorY = centerY;

            lines[1].ToList().ForEach(x =>
            {
                switch (x.Direction)
                {
                    case 0:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY++;
                            grid[cursorX, cursorY] += 100;
                        }
                        break;
                    case 1:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX++;
                            grid[cursorX, cursorY] += 100;
                        }
                        break;
                    case 2:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY--;
                            grid[cursorX, cursorY] += 100;
                        }
                        break;
                    case 3:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX--;
                            grid[cursorX, cursorY] += 100;
                        }
                        break;
                }
            });
            
            cursorX = centerX;
            cursorY = centerY;
            
            int line2Distance = 0;
            int line1Distance = 0;
            
            lines[0].ToList().ForEach(x =>
            {
                switch (x.Direction)
                {
                    case 0:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY++;
                            line1Distance++;
                            //grid[cursorX, cursorY] += 1;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                int distance = Math.Abs(centerX - cursorX) + Math.Abs(centerY - cursorY);
                                intersections.Add(new Intersection(cursorX, cursorY, distance, line1Distance));
                            }
                        }
                        break;
                    case 1:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX++;
                            line1Distance++;
                            //grid[cursorX, cursorY] += 1;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                int distance = Math.Abs(centerX - cursorX) + Math.Abs(centerY - cursorY);
                                intersections.Add(new Intersection(cursorX, cursorY, distance, line1Distance));
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY--;
                            line1Distance++;
                            //grid[cursorX, cursorY] += 1;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                int distance = Math.Abs(centerX - cursorX) + Math.Abs(centerY - cursorY);
                                intersections.Add(new Intersection(cursorX, cursorY, distance, line1Distance));
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX--;
                            line1Distance++;
                            //grid[cursorX, cursorY] += 1;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                int distance = Math.Abs(centerX - cursorX) + Math.Abs(centerY - cursorY);
                                intersections.Add(new Intersection(cursorX, cursorY, distance, line1Distance));
                            }
                        }
                        break;
                }
            });

            cursorX = centerX;
            cursorY = centerY;

            lines[1].ToList().ForEach(x =>
            {
                switch (x.Direction)
                {
                    case 0:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY++;
                            line2Distance++;
                            //grid[cursorX, cursorY] += 100;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                intersections.Find(inter => inter.X == cursorX && inter.Y == cursorY).LineRun+=line2Distance;
                            }
                        }
                        break;
                    case 1:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX++;
                            line2Distance++;
                            //grid[cursorX, cursorY] += 100;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                intersections.Find(inter => inter.X == cursorX && inter.Y == cursorY).LineRun+=line2Distance;
                            }
                        }
                        break;
                    case 2:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorY--;
                            line2Distance++;
                            //grid[cursorX, cursorY] += 100;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                intersections.Find(inter => inter.X == cursorX && inter.Y == cursorY).LineRun+=line2Distance;
                            }
                        }
                        break;
                    case 3:
                        for (int i = 0; i < x.Distance; i++)
                        {
                            cursorX--;
                            line2Distance++;
                            //grid[cursorX, cursorY] += 100;
                            if (grid[cursorX, cursorY] == 101)
                            {
                                intersections.Find(inter => inter.X == cursorX && inter.Y == cursorY).LineRun+=line2Distance;
                            }
                        }
                        break;
                }
            });

            List<Intersection> orderedIntersections = (from intersection in intersections
                orderby intersection.LineRun
                select intersection).ToList();

            Intersection smallest = orderedIntersections.ToList()[0];
            
            /*int horiz = 0, verti = 0;

            int maxu = 0, maxd = 0, maxl = 0, maxr = 0;
            
            lines[0].ToList().ForEach(x =>
            {
                switch (x.Direction)
                {
                    case 0:
                        verti += x.Distance;
                        if (verti > maxu)
                        {
                            maxu = verti;
                        }
                        break;
                    case 1:
                        horiz += x.Distance;
                        if (horiz > maxr)
                        {
                            maxr = horiz;
                        }
                        break;
                    case 2:
                        verti -= x.Distance;
                        if (verti < maxd)
                        {
                            maxd = verti;
                        }
                        break;
                    case 3:
                        horiz -= x.Distance;
                        if (horiz < maxl)
                        {
                            maxl = horiz;
                        }
                        break;
                }
            });

            verti = 0;
            horiz = 0;
            
            lines[1].ToList().ForEach(x =>
            {
                switch (x.Direction)
                {
                    case 0:
                        verti += x.Distance;
                        if (verti > maxu)
                        {
                            maxu = verti;
                        }
                        break;
                    case 1:
                        horiz += x.Distance;
                        if (horiz > maxr)
                        {
                            maxr = horiz;
                        }
                        break;
                    case 2:
                        verti -= x.Distance;
                        if (verti < maxd)
                        {
                            maxd = verti;
                        }
                        break;
                    case 3:
                        horiz -= x.Distance;
                        if (horiz < maxl)
                        {
                            maxl = horiz;
                        }
                        break;
                }
            });

            Console.WriteLine($"u:{maxu} | r:{maxr} | d:{maxd} | l:{maxl}");
            Console.WriteLine($"int[,] = new int[{maxu - maxd},{maxr - maxl}]; center is {Math.Abs(maxd)}, {Math.Abs(maxl)}");*/
            
            Console.WriteLine("Hello World!");
        }
    }
}