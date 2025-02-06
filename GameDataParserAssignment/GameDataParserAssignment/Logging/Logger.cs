using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDataParserAssignment.Logging
{
    public class Logger
    {
        private readonly string LogFileName;

        public Logger(string logFileName)
        {
            LogFileName = logFileName;
        }

        public void Log(Exception ex)
        {
            string entry =
    $@"[{DateTime.Now}]
Exception message: {ex.Message}
Stack trace: {ex.StackTrace}

";

            File.AppendAllText(LogFileName, entry); // creates a log if it doesn't exist.
        }
    }

}
