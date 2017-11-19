using NUnit.Framework;
using System;
using Job.Logger.Services;
using Job.Logger.Services.Flags;
using System.Configuration;
using System.IO;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Job.Logger.IntegrationTests
{
    [TestFixture()]
    public class Test
    {
        [Test()]
        public void TestWriteFile()
        {
            var message = String.Format("Integration test for FILE logger on {0}", DateTime.UtcNow.ToString());

            IJobLoggerManager manager = Shell.Logger;
            manager.InitializeManager(ProviderKind.File, Core.MessageKind.All);

            manager.WriteError(message);
            manager.WriteMessage(message);
            manager.WriteWarning(message);
            manager.WriteSuccess(message);

            var path = ConfigurationManager.AppSettings["LogFileDirectory"];
            var name = ConfigurationManager.AppSettings["LogFileName"];
            var fileName = string.Format(@"{0}/{1}", (string.IsNullOrWhiteSpace(path) ? "." : path), (string.IsNullOrWhiteSpace(name) ? "logger.log" : name));

            Assert.IsTrue(File.Exists(fileName), "File '{0}' does not exist", fileName);

            var fileTextArray = File.ReadAllLines(fileName);
            var lastWrittenMessages = fileTextArray.Skip(Math.Max(0, fileTextArray.Count() - 4));

            Assert.AreEqual(4, lastWrittenMessages.Count(), "Messages were not written on file.");

            var recentWrittenMessagesList = lastWrittenMessages.ToList();

            Assert.IsTrue(recentWrittenMessagesList[0].Contains(message) && recentWrittenMessagesList[0].Contains("Error"));
            Assert.IsTrue(recentWrittenMessagesList[1].Contains(message) && recentWrittenMessagesList[1].Contains("Message"));
            Assert.IsTrue(recentWrittenMessagesList[2].Contains(message) && recentWrittenMessagesList[2].Contains("Warning"));
            Assert.IsTrue(recentWrittenMessagesList[3].Contains(message) && recentWrittenMessagesList[3].Contains("Success"));
        }

        [Test()]
        public void TestWriteDB()
        {
            var message = String.Format("Integration test for DATABASE logger on {0}", DateTime.UtcNow.ToString());

            IJobLoggerManager manager = Shell.Logger;
            manager.InitializeManager(ProviderKind.Database, Core.MessageKind.All);

            manager.WriteError(message);
            manager.WriteMessage(message);
            manager.WriteWarning(message);
            manager.WriteSuccess(message);

            string mySqlConnectionString = ConfigurationManager.ConnectionStrings["Log"].ConnectionString;
            Assert.IsNotNullOrEmpty(mySqlConnectionString, "Connection string is Empty");

            int rowsInserted = 0;
            using (MySqlConnection mcon = new MySqlConnection(mySqlConnectionString))
            {
                mcon.Open();
                // Should be better to use a store procedure, but for demo purposes this will work as excpected
                string cmdText = "SELECT COUNT(1) FROM Log WHERE Message LIKE CONCAT('%', @message, '%')";
                MySqlCommand cmd = new MySqlCommand(cmdText, mcon);
                cmd.Parameters.AddWithValue("@message", message);
                rowsInserted = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Assert.AreEqual(4, rowsInserted);
        }
    }
}
