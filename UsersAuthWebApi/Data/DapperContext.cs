using System.Data;
using System.Data.SqlClient;

namespace UsersAuthWebApi.Data
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("MainDB"); // Configurar Secrets!
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_connectionString);
    }
}
