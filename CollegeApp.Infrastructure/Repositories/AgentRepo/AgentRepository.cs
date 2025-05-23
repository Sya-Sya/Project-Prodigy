﻿using CollegeApp.Domain.BookModels;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeApp.Infrastructure.Repositories.AgentRepo
{
    public class AgentRepository : IAgentRepository
    {
        private readonly IDbConnection _dbConnection;

        public AgentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<agentContact>> GetAllAgentAsync()
        {
            Console.WriteLine("Fetching all agents...");
            const string query = "SELECT * FROM agentContact";

            try
            {
                var result = await _dbConnection.QueryAsync<agentContact>(query);
                Console.WriteLine($"Fetched {result.Count()} agents.");
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Enumerable.Empty<agentContact>();
            }
        }

        public Task<int> AddAgentAsync(agentContact Agent)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAgentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<agentContact?> GetAgentByIdAsync(int id)
        {
            const string query = "SELECT * FROM agentContact WHERE agentId = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<agentContact>(query, new { Id = id });
        }

        public async Task<int> UpdateAgentAsync(agentContact Agent)
        {
            const string query = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName WHERE agentId = @Id";
            return await _dbConnection.ExecuteAsync(query, Agent);
        }

        //Using Dapper in SP
        public async Task<IEnumerable<int>> GetMemberOrdersAsync(int memberId) // int replace with model (int ~ Order)
        {
            const string storedProcedure = "GetMemberOrders";

            try
            {
                using (var connection = _dbConnection)
                {
                    var orders = await connection.QueryAsync<int>(
                        storedProcedure,
                        new { memberId },
                        commandType: CommandType.StoredProcedure);
                    return orders;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Enumerable.Empty<int>();
            }
        }

        public async Task<IEnumerable<int>> GetOrderDetailsAsync(char flag) // int replace with model (int ~ Order)
        {
            const string storedProcedure = "GetOrderDetails";

            try
            {
                using (var connection = _dbConnection)
                {
                    var orders = await connection.QueryAsync<int>(
                        storedProcedure,
                        new { flag },
                        commandType: CommandType.StoredProcedure);
                    return orders;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return Enumerable.Empty<int>();
            }
        }


    }
}
