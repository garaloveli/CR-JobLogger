using System;
using Job.Logger.Core;

namespace Job.Logger.Services.Providers
{
    public class ConsoleProvider : IJobLoggerProvider
    {
        public ConsoleProvider() { }

        public void LogMessage(LogMessageEntity message)
        {
            switch(message.LogMessageType)
            {
                case MessageType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case MessageType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case MessageType.Message:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case MessageType.Success:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
            Console.WriteLine("Console: {0}", message.FormattedMessage);
        }
    }
}
