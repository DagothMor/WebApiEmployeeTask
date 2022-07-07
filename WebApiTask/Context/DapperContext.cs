using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace WebApiTask.Context
{
    public class DapperContext
    {
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			_configuration = configuration;
			_connectionString = _configuration.GetConnectionString("Server=DESKTOP-S53KNVB;Database=FirstDataBase;User Id=Eggman;Password=aHR0cHM6Ly93d3cueW91dHViZS5jb20vd2F0Y2g/dj1kUXc0dzlXZ1hjUQ==;");
		}

		public IDbConnection CreateConnection()
			=> new SqlConnection(_connectionString);
	}
}
