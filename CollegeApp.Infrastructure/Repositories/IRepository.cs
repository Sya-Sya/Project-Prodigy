using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Infrastructure.Repositories
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync(string query, object? parameters = null);
        Task<T?> GetByIdAsync(string query, object? parameters = null);
        Task<int> ExecuteAsync(string query, object? parameters = null);
    }
}
