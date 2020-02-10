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
    /// Implement the RoverRotateCommandExecuter to process the rotate movements ("L", "R") of a rover received from the Console
    /// </summary>
    public class RoverRotateCommandExecuter : CommandExecuter
    {
        private readonly IRoverDeployManager _deployManager;

        public RoverRotateCommandExecuter(IRoverDeployManager deployManager)
        {
            _deployManager = deployManager;
        }

        public override Regex RegexCommandPattern => new Regex("^\\d+ \\d+ [NSWE]$");

        public override void ExecuteCommand(string command)
        {
            ParseCommand(command, out var x, out var y, out var direction);
            _deployManager.DeployRover(x, y, direction);
        }

        private static void ParseCommand(string command, out int x, out int y, out Direction direction)
        {
            var splitCommand = command.Split(' ');
            x = int.Parse(splitCommand[0]);
            y = int.Parse(splitCommand[1]);
            direction = Enum.Parse<Direction>(splitCommand[2]);
        }
    }
}
