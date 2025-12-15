using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConnectedWorld.Server.Contracts
{
    public interface IServiceLogger
    {
        void LogSystemInformation(string message);
        void LogRequestInformation(string message);
    }
}
