using System;
using System.Collections.Generic;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;

namespace TheWeddingShop.TechnicalTest.MarsRover.Rovers
{
    public interface IRoverDeployManager
    {
        List<Rover> Rovers { get; }

        Rover ActiveRover { get; }

        IArea Area { get; }

        void DeployRover(int x, int y, Direction direction);
    }
}
