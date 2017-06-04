using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Rect
    {
        int x, y;
        public int height, width;

        public Rect(int x, int y, int h , int w)
        {
            this.x = x;
            this.y = y;
            height = h;
            width = w;
        }

        public Rect(Point xy, Point size)
        {
            this.x = xy.x;
            this.y = xy.y;
            height = size.y;
            width = size.x;
        }

        public bool hasInside(Point pt)
        {
            Point origen = new Point(x, y);
            Point max = origen + new Point(width, height);
            return pt > origen && pt < max;
        }

        public Point Min
        {
            get { return new Point(x, y); }
        }

        public Point Max
        {
            get { return new Point(xMax, yMax); }
        }

        public Point Size
        {
            get { return new Point(width, height); }
        }

        public int xMax
        {
            get { return x + width; }
        }

        public int yMax
        {
            get { return y + height; }
        }

        public int xMin
        {
            get { return x; }
        }

        public int yMin
        {
            get { return y; }
        }
    }
}
