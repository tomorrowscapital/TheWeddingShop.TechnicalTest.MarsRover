using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeddingShop.TechnicalTest.MarsRover.Areas
{
    /// <summary>
    /// Explanation:
    /// Define Plateau is one of landing areas or implementations of IArea
    /// </summary>
    public class Plateau : IArea
    {
        private Size size { get; set; }

        public void Define(int width, int height)
        {
            size = new Size(width, height);
        }

        public Size GetSize()
        {
            return size;
        }

        public bool IsValid(Position p)
        {
            var isValidX = p.X >= 0 && p.X <= size.Width;
            var isValidY = p.Y >= 0 && p.Y <= size.Height;
            return isValidX && isValidY;
        }
    }

}
