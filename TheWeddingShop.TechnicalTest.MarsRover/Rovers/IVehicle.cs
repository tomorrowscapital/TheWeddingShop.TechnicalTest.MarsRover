using System;
using System.Collections.Generic;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;

namespace TheWeddingShop.TechnicalTest.MarsRover.Rovers
{
    /// <summary>
    /// Define the interface of the base model type of a Rover
    /// </summary>
    public interface IVehicle
    {
        int X { get; }

        int Y { get; }

        Direction Direction { get; }

        void Move(IEnumerable<Movement> movements);
        void Move(Movement movement);
    }
}
