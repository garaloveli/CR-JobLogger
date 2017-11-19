using System;
using System.Collections.Generic;
using Job.Logger.Core;
using Job.Logger.Services.Flags;
using Job.Logger.Services.Providers;

namespace Job.Logger.Services
{
    public class JobLoggerManager : IJobLoggerManager
    {
        private List<IJobLoggerProvider> logProviders;
        private LogMessageFactory logFactory;

        public JobLoggerManager()
        {
            logProviders = new List<IJobLoggerProvider>();
        }

        public void InitializeManager(ProviderKind allowedProviders, MessageKind allowedMessages)
        {
            if (allowedProviders.HasFlag(ProviderKind.File) || allowedProviders.HasFlag(ProviderKind.All))
            {
                logProviders.Add(new FileProvider());
            }
            if (allowedProviders.HasFlag(ProviderKind.Console) || allowedProviders.HasFlag(ProviderKind.All))
            {
                logProviders.Add(new ConsoleProvider());
            }
            if (allowedProviders.HasFlag(ProviderKind.Database) || allowedProviders.HasFlag(ProviderKind.All))
            {
                logProviders.Add(new DBProvider());
            }
            logFactory = new LogMessageFactory(allowedMessages);
        }

        public void WriteError(string error)
        {
            var logError = this.logFactory.ErrorMessage(error);
            if (logError == null) return;
            foreach (var provider in logProviders)
            {
                provider.LogMessage(logError);
            }
        }

        public void WriteMessage(string message)
        {
            var logMessage = this.logFactory.Message(message);
            if (logMessage == null) return;
            foreach (var provider in logProviders)
            {
                provider.LogMessage(logMessage);
            }
        }

        public void WriteWarning(string warning)
        {
            var logWarning = this.logFactory.WarningMessage(warning);
            if (logWarning == null) return;
            foreach (var provider in logProviders)
            {
                provider.LogMessage(logWarning);
            }
        }

        public void WriteSuccess(string success)
        {
            var logSucccess = this.logFactory.SuccessMessage(success);
            if (logSucccess == null) return;
            foreach (var provider in logProviders)
            {
                provider.LogMessage(logSucccess);
            }
        }
    }
}
