namespace Engine
{
    public class Point
    {
        public int x, y;

        public Point()
        {
            this.x = 0;
            this.y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static bool operator <(Point p1, Point p2)
        {
            return p1.x < p2.x && p1.y < p2.y;
        }

        public static bool operator >(Point p1, Point p2)
        {
            return p1.x > p2.x && p1.y > p2.y;
        }

        public static Point operator +(Point p1, Point p2)
        {
            return new Point(p1.x + p2.x, p1.y + p2.y);
        }

        public static bool operator ==(Point p1, Point p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        public static bool operator !=(Point p2, Point p1)
        {
            return !(p1 == p2);
        }


    }
}