using System;
using Job.Logger.Core;
using Job.Logger.Services.Flags;

namespace Job.Logger.Services
{
    public interface IJobLoggerManager
    {
        void InitializeManager(ProviderKind allowedProviders, MessageKind allowedMessages);
        void WriteMessage(string message);
        void WriteError(string error);
        void WriteWarning(string warning);
        void WriteSuccess(string success);
    }
}
