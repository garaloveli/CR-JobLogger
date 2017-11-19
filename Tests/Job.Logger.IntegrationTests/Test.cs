using NUnit.Framework;
using System;
using Job.Logger.Services;
using Job.Logger.Services.Flags;

namespace Job.Logger.IntegrationTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestWriteFile()
        {
            var message = String.Format("Integration test for FILE logger on {0}", DateTime.UtcNow.ToString());

            IJobLoggerManager manager = new JobLoggerManager();
            manager.InitializeManager(ProviderKind.File, Core.MessageKind.All);

            manager.WriteError(message);
            manager.WriteMessage(message);
            manager.WriteWarning(message);
            manager.WriteSuccess(message);

        }

        [Test()]
        public void TestWriteConsole()
        {
            var message = String.Format("Integration test for CONSOLE logger on {0}", DateTime.UtcNow.ToString());

            IJobLoggerManager manager = new JobLoggerManager();
            manager.InitializeManager(ProviderKind.Console, Core.MessageKind.All);

            manager.WriteError(message);
            manager.WriteMessage(message);
            manager.WriteWarning(message);
            manager.WriteSuccess(message);

        }

        [Test()]
        public void TestWriteDB()
        {
            var message = String.Format("Integration test for DATABASE logger on {0}", DateTime.UtcNow.ToString());

            IJobLoggerManager manager = new JobLoggerManager();
            manager.InitializeManager(ProviderKind.Database, Core.MessageKind.All);

            manager.WriteError(message);
            manager.WriteMessage(message);
            manager.WriteWarning(message);
            manager.WriteSuccess(message);
        }
    }
}
