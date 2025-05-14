using CollegeApp.Domain.BookModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Infrastructure.Repositories.AgentRepo
{
    public interface IAgentRepository
    {
        Task<IEnumerable<agentContact>> GetAllAgentAsync();
        Task<agentContact?> GetAgentByIdAsync(int id);
        Task<int> AddAgentAsync(agentContact Agent);
        Task<int> UpdateAgentAsync(agentContact Agent);
        Task<int> DeleteAgentAsync(int id);
    }
}
