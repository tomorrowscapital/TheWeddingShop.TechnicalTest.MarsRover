using System;
using System.Collections.Generic;
using System.Text;
using TheWeddingShop.TechnicalTest.MarsRover.Areas;
using TheWeddingShop.TechnicalTest.MarsRover.Rovers;

namespace TheWeddingShop.TechnicalTest.MarsRover.Commands
{
    public interface ICommandCenter
    {
        void SendCommand(string command);
    }
}
