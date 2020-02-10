using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters
{
    /// <summary>
    /// Explanation:
    /// define an abstract type CommandExecuter with a common method MatchCommand()
    /// </summary>
    public abstract class CommandExecuter : ICommandExecuter
    {
        public abstract Regex RegexCommandPattern { get; }

        public abstract void ExecuteCommand(string command);

        public bool MatchCommand(string command)
        {
            return RegexCommandPattern.IsMatch(command);
        }
    }
}
