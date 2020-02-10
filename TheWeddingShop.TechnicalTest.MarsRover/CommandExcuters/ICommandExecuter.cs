using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters
{
    /// <summary>
    /// Explanation:
    /// define an ICommandExecuter interface to execute all different commands respectively with RegexCommandPattern. 
    /// </summary>
    public interface ICommandExecuter
    {
        Regex RegexCommandPattern { get; }
        void ExecuteCommand(string command);
        bool MatchCommand(string command);
    }
}
