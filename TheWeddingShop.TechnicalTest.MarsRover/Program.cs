using Microsoft.Extensions.DependencyInjection;
using System;
using TheWeddingShop.TechnicalTest.MarsRover.App_Start;
using TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters;
using TheWeddingShop.TechnicalTest.MarsRover.Commands;

namespace TheWeddingShop.TechnicalTest.MarsRover
{
    /// <summary>
    /// Try to use this Console app to demonstrate how to solve the problem of Mars Rover with following implementations:
    /// 1) Logic to receive command line instructions from console.
    /// 2) Logic to recognize the 3 different command inputs "Command for deploy Plateau", "Command for Position a Rover", "Command for move or rotate a Rover"
    /// 3) Logic to Deploy a plateau with two coordinates inputs
    /// 4) Logic to Deploy a rover within the boundary of a plateau
    /// 5) Logic to Delegate the commands to correspondent commandExecuters
    /// 6) Logic to work out the current position of a rover within a plateau after the movements
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ContainerConfig.Init();

            var commandCenter = ContainerConfig.GetInstance<ICommandCenter>();
                
                commandCenter.SendCommand("5 5");
                commandCenter.SendCommand("1 2 N");
                commandCenter.SendCommand("LMLMLMLMM");
                commandCenter.SendCommand("3 3 E");
                commandCenter.SendCommand("MMRMMRMRRM");

                Console.ReadKey();

        }




    }
}
