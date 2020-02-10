using System;
using System.Collections.Generic;
using System.Text;

namespace TheWeddingShop.TechnicalTest.MarsRover.Areas
{
    /// <summary>
    /// Explanation:
    /// Define IArea as Generic interface for all landing areas of a Rover to be deployed to
    /// </summary>
    public interface IArea
    {
        Size GetSize();

        void Define(int width, int height);

        bool IsValid(Position p);
    }
}
