using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeddingShop.TechnicalTest.MarsRover.Areas
{
    /// <summary>
    /// Explanation:
    /// The size of an area (square as plateau) can be descripted by using it's width and height 
    /// </summary>
    public class Size
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
