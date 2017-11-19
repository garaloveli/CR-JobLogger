using System;
using Job.Logger.Core;

namespace Job.Logger.Services.Providers
{
    public interface IJobLoggerProvider
    {
        void LogMessage(LogMessageEntity message);
    }
}
