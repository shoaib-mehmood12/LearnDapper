using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.Data;

namespace LearnDapper.Models.Data
{
    public class DapperDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string connectionstring;
        
        public DapperDbContext(IConfiguration configuration)
        {
            this._configuration = configuration;
            this.connectionstring = _configuration.GetConnectionString("connection");
        }
        public IDbConnection createConnection() => new SqlConnection(connectionstring);
    }
}
