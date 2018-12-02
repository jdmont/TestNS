using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test_utils.contracts
{
    public interface ILoggerService
    {
        void LogWarn(string message);
        void LogError(string message);
        void LogInfo(string message);
    }
}
