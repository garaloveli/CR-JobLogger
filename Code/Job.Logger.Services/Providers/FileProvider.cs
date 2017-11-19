using System;
using System.Configuration;
using System.IO;

using Job.Logger.Core;

namespace Job.Logger.Services.Providers
{
    public class FileProvider : IJobLoggerProvider
    {
        protected string fileName;
        public FileProvider()
        {
            var path = ConfigurationManager.AppSettings["LogFileDirectory"];
            var name = ConfigurationManager.AppSettings["LogFileName"];
            fileName = string.Format(@"{0}/{1}", (string.IsNullOrWhiteSpace(path) ? "." : path), (string.IsNullOrWhiteSpace(name) ? "logger.log" : name));
        }

        public void LogMessage(LogMessageEntity message)
        {
#if DEBUG
            System.Console.WriteLine("File: {0}", message.FormattedMessage);
#endif
            var logText = message.FormattedMessage;
            if (File.Exists(fileName))
            {
                using (StreamWriter fileWriter = File.AppendText(fileName))
                {
                    fileWriter.WriteLine(logText);
                }
            }
            else
            {
                File.WriteAllText(fileName, logText);
            }
        }
    }
}
