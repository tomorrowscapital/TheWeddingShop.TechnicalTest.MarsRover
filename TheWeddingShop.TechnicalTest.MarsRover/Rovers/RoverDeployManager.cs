using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;



namespace TheWeddingShop.TechnicalTest.MarsRover.Rovers
{
    /// <summary>
    /// Explanation:
    /// Use factory design pattern to define a RoverDeployManager for deploying a rover with validation of appropriate location boundary check. 
    /// </summary>
    public class RoverDeployManager : IRoverDeployManager
    {
        public List<Rover> Rovers { get; } = new List<Rover>();

        public IArea Area { get; }

        public Rover ActiveRover { get; private set; }

        public RoverDeployManager(IArea area)
        {
            Area = area;
        }

        public void DeployRover(int x, int y, Direction direction)
        {
            CheckIfLocationToDeployIsValid(x, y);
            var rover = new Rover(x, y, direction, Area);
            Rovers.Add(rover);
            ActiveRover = rover;
        }

        private void CheckIfLocationToDeployIsValid(int x, int y)
        {
            if (!IsAppropriateLocationToDeployRover(x, y))
                throw new Exception("Rover outside of bounds");
        }

        private bool IsAppropriateLocationToDeployRover(int x, int y)
        {
            return x >= 0 && x < Area.GetSize().Width &&
                   y >= 0 && y < Area.GetSize().Height;
        }
    }
}
