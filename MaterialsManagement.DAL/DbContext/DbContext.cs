using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;
using Npgsql;
namespace MaterialsManagement.DAL.DbContext
{
    public class MaterialsDbContext
    {
        private ConnectionStringOptions connectionStringOptions;
        public MaterialsDbContext(IOptionsMonitor<ConnectionStringOptions> optionsMonitor)
        {
            connectionStringOptions = optionsMonitor.CurrentValue;
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionStringOptions.SqlConnection);
        public IDbConnection CreatePostgreSqlConnection() => new NpgsqlConnection(connectionStringOptions.PostgreSqlConnection);
    }
}
