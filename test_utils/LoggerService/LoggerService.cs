using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test_utils.contracts;

namespace test_utils.LoggerService
{
    public class LoggerService : ILoggerService
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void LogError(string message)
        {
            log.Error(message);
        }

        public void LogInfo(string message)
        {
            log.Info(message);
        }

        public void LogWarn(string message)
        {
            log.Warn(message);
        }
    }
}
