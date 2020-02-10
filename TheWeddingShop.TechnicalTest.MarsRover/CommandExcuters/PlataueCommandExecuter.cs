using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyInjection;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;

namespace TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters
{
    /// <summary>
    /// Explanation:
    /// Implement the PlataueCommandExecuter which can be used to deploy plateau by receiving command arguments like Width and Height from the console. 
    /// </summary>
    public class PlataueCommandExecuter : CommandExecuter
    {
        private readonly IArea _plataeu;

        public PlataueCommandExecuter(IArea plataeu)
        {
            _plataeu = plataeu;
        }

        public override Regex RegexCommandPattern => new Regex("^\\d+ \\d+$");

        public override void ExecuteCommand(string command)
        {
            ParseCommand(command, out var width, out var height);
            _plataeu.Define(width, height);
        }

        private static void ParseCommand(string command, out int width, out int height)
        {
            var splitCommand = command.Split(' ');
            width = int.Parse(splitCommand[0]) + 1;
            height = int.Parse(splitCommand[1]) + 1;
        }
    }
}
