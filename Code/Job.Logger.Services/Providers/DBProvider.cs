using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Job.Logger.Core;

namespace Job.Logger.Services.Providers
{
    public class DBProvider : IJobLoggerProvider
    {
        protected string logConnectionString = string.Empty;
        public DBProvider()
        {
            logConnectionString = ConfigurationManager.ConnectionStrings["Log"].ConnectionString;
        }

        public void LogMessage(LogMessageEntity message)
        {
#if DEBUG
            System.Console.WriteLine("DB: {0}", message.FormattedMessage);
#endif
            using (MySqlConnection mcon = new MySqlConnection(logConnectionString))
            {
                mcon.Open();
                // Should be better to use a store procedure, but for demo purposes this will work as excpected
                string cmdText = "INSERT INTO Log (message) VALUES (@message)";
                MySqlCommand cmd = new MySqlCommand(cmdText, mcon);
                cmd.Parameters.AddWithValue("@message", message.FormattedMessage);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
