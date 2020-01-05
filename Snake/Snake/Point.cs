using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Point()
        {

        }

        public int x { set; get; }
        public int y { set; get; }
    }
}
