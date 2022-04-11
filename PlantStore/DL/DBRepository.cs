using System.Data;
using System.Data.SqlClient;

namespace DL

{
    //Data Storage
    public class DBRepository : IRepo
    {
        private readonly string _connectionString;
        public DBRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

