using System;
using Job.Logger.Core;
using Job.Logger.Services;
using Job.Logger.Services.Flags;

namespace Job.Logger.Console
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            IJobLoggerManager manager = new JobLoggerManager();
            manager.InitializeManager(ProviderKind.All, MessageKind.Error | MessageKind.Warning | MessageKind.Success);

            manager.WriteError("Testing error message");
            manager.WriteMessage("Testing message message");
            manager.WriteWarning("Testing warning message");
            manager.WriteSuccess("Testing success message");
            System.Console.ReadKey();
        }
    }
}
