using Dapper;
using Microsoft.Data.SqlClient;
using POS.Web.Models;

namespace POS.Web.Services
{
    public class DapperServices
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbconnection;
        public DapperServices(IConfiguration configuration)
        {
            _configuration = configuration; 
            _dbconnection = _configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Product>> GetProjectsAsync()
        {
            using var conn = new SqlConnection(_dbconnection);
            return await conn.QueryAsync<Product>("SELECT * FROM Products");
        }
    }
}
