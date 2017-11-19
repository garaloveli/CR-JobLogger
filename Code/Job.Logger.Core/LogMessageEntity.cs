using System;
namespace Job.Logger.Core
{
    public class LogMessageEntity
    {
        public string Message { get; private set; }

        public MessageType LogMessageType { get; private set; }

        public string FormattedMessage
        {
            get
            {
                return String.Format("DATE: {0}, MESSAGE: {1}, TYPE: {2}", DateTime.UtcNow, Message, LogMessageType);
            }
        }

        internal LogMessageEntity() { }
        internal LogMessageEntity(string message, MessageType type)
        {
            this.Message = message;
            this.LogMessageType = type;
        }


    }
}
