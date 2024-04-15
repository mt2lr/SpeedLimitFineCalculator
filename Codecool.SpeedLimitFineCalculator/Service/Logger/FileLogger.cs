using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.SpeedLimitFineCalculator.Service.Logger
{
    public class FileLogger : ILogger
    {
        private readonly string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;
        }

        public void LogInfo(string message)
        {
            LogMessage(message, "INFO");
        }

        public void LogError(string message)
        {
            LogMessage(message, "ERROR");
        }

        private void LogMessage(string message, string type)
        {
            var entry = $"[{DateTime.Now}] {type}: {message}";
            File.AppendAllText(filePath, entry + Environment.NewLine);
        }
    }
}
