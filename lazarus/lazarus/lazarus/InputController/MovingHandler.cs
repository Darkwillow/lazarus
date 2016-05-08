using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lazarus
{
    public static class MovingHandler
    {
        //Handling of Direction
        public static int moveLeft(int x)
        {
            return x = x - 4;
        }

        public static int moveRight(int x)
        {
            return x = x + 4;
        }

        public static int moveUp(int y)
        {
            return y = y - 4;
        }

        public static int moveDown(int y)
        {
            return y = y + 4;
        }
    }
}
