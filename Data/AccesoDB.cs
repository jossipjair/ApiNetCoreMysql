using System;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace WebApiNetCoreMysql.Data
{
    public class AccesoDB : IDisposable
    {
        public MySqlConnection Connection { get; }

        public AccesoDB(string connectionString)
        {
            Connection = new MySqlConnection(connectionString);
        }

        public void Dispose() => Connection.Dispose();
    }
}