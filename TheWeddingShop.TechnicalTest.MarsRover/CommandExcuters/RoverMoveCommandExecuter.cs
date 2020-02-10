using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using TheWeddingShop.TechnicalTest.MarsRover.Rovers;

namespace TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters
{
    /// <summary>
    /// Explanation:
    /// Implement the RoverMoveCommandExecuter to process forward movement "M" of a rover received from the Console
    /// </summary>
    public class RoverMoveCommandExecuter : CommandExecuter
    {
        private readonly IRoverDeployManager _deployManager;

        public RoverMoveCommandExecuter(IRoverDeployManager deployManager)
        {
            _deployManager = deployManager;
        }

        public override Regex RegexCommandPattern => new Regex("^[LMR]+$");

        public override void ExecuteCommand(string command)
        {
            if (CheckIfActiveRoverExists(out var activeRover))
                return;

            MoveRoverByCommand(command, activeRover);
            ReportLocation(activeRover);
        }

        private static void MoveRoverByCommand(string command, Rover activeRover)
        {
            foreach (var order in command)
            {
                var movement = Enum.Parse<Movement>(order.ToString());
                activeRover.Move(movement);
            }
        }

        private static void ReportLocation(Rover activeRover)
        {
            Console.WriteLine(activeRover.ToString());
        }

        private bool CheckIfActiveRoverExists(out Rover activeRover)
        {
            activeRover = _deployManager.ActiveRover;
            return activeRover == null;
        }
    }
}
