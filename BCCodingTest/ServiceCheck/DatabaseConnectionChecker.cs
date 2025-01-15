
using System;
namespace BCCodingTest.ServiceCheck
{

    public class DatabaseConnectionChecker
    {
        private readonly string _connectionString;

        public DatabaseConnectionChecker(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool CheckConnection()
        {
            //Database Check(Not Use)
            return true;
        }
    }
}
