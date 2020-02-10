using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;
using TheWeddingShop.TechnicalTest.MarsRover.CommandExcuters;
using TheWeddingShop.TechnicalTest.MarsRover.Rovers;

namespace TheWeddingShop.TechnicalTest.MarsRover.Commands
{
    /// <summary>
    /// Explanation:
    /// CommandCenter acts as coordinator to delegate receiving commands to corresponding  commandExecuters
    /// </summary>
    public class CommandCenter : ICommandCenter
    {
        private readonly IEnumerable<ICommandExecuter> _commandExecuters;
        public CommandCenter(IEnumerable<ICommandExecuter> commandExecuters)
        {
            _commandExecuters = commandExecuters;
        }


        public void SendCommand(string command)
        {
            var executer = _commandExecuters.SingleOrDefault(x => x.MatchCommand(command));
            executer?.ExecuteCommand(command);
        }

    }
}
