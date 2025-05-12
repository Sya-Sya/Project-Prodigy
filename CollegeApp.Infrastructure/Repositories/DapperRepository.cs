using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Infrastructure.Repositories
{
    public class DapperRepository<T> : IRepository<T>
    {
        private readonly IDbConnection _dbConnection;

        public DapperRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public Task<int> ExecuteAsync(string query, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllAsync(string query, object? parameters = null)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetByIdAsync(string query, object? parameters = null)
        {
            throw new NotImplementedException();
        }
    }
}
