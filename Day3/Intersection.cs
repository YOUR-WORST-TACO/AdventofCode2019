namespace Day3
{
    public class Intersection
    {
        public Intersection(int x, int y, int distance, int lineRun)
        {
            X = x;
            Y = y;
            Distance = distance;
            LineRun = lineRun;
        }

        public int Distance;
        public int X;
        public int Y;
        public int LineRun;
    }
}