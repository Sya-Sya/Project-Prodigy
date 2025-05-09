using CollegeApp.Application.Interface;
using CollegeApp.Domain.EntityFrameworkCore;
using CollegeApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CollegeApp.DependencyContainer;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("DbConnection:CoreSystem:ConnectionString").Value;
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString));

        // Register all services here (Web + API share this setup)
        services.AddScoped<IStudentServices, StudentService>();
        services.AddScoped<IBookService, BookService>();
    }
}