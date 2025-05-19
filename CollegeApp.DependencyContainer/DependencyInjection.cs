using CollegeApp.Application.Interface;
using CollegeApp.Infrastructure.Repositories;
using CollegeApp.Infrastructure.Repositories.AgentRepo;
using CollegeApp.Infrastructure.Services;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;


namespace CollegeApp.DependencyContainer;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Fetch the connection string using the correct method
        string connectionString = configuration["ConnectionString"];

        if (string.IsNullOrEmpty(connectionString))
        {
            throw new Exception("Database connection string is missing or empty.");
        }

        services.AddScoped<IDbConnection>(db => new SqlConnection(connectionString));
        services.AddScoped(typeof(IRepository<>), typeof(DapperRepository<>));


        // Register application services
        services.AddScoped<IStudentServices, StudentService>();
        //services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAgentRepository, AgentRepository>();
    }
}