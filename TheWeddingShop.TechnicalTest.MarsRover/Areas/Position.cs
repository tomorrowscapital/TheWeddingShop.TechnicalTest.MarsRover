using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeddingShop.TechnicalTest.MarsRover.Areas
{
    /// <summary>
    /// Explanation:
    /// A rover's position can be represented by a combination of x and y co-ordinates
    /// </summary>
    public class Position
    {
        public int X;
        public int Y;

        public Position(int anX, int aY)
        {
            X = anX;
            Y = aY;
        }
    }
}
