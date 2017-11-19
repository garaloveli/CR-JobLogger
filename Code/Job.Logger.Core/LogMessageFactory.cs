using System;
namespace Job.Logger.Core
{
    public class LogMessageFactory
    {

        public MessageKind AllowedMessages { get; private set; }
        public LogMessageFactory(MessageKind allowedKindMessages)
        {
            AllowedMessages = allowedKindMessages;
        }

        public LogMessageEntity ErrorMessage(string errorMessage)
        {
            LogMessageEntity response = null;
            if (AllowedMessages.HasFlag(MessageKind.Error))
            {
                response = new LogMessageEntity(errorMessage, MessageType.Error);
            }
            return response;
        }

        public LogMessageEntity Message(string message)
        {
            LogMessageEntity response = null;
            if (AllowedMessages.HasFlag(MessageKind.Message))
            {
                response = new LogMessageEntity(message, MessageType.Message);
            }
            return response;
        }

        public LogMessageEntity WarningMessage(string warningMessage)
        {
            LogMessageEntity response = null;
            if (AllowedMessages.HasFlag(MessageKind.Error))
            {
                response = new LogMessageEntity(warningMessage, MessageType.Warning);
            }
            return response;
        }

        public LogMessageEntity SuccessMessage(string successMessage)
        {
            LogMessageEntity response = null;
            if (AllowedMessages.HasFlag(MessageKind.Error))
            {
                response = new LogMessageEntity(successMessage, MessageType.Success);
            }
            return response;
        }
    }
}
