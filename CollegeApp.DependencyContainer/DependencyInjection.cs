using CollegeApp.Application.Interface;
using CollegeApp.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CollegeApp.DependencyContainer;

public static class DependencyInjection
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        // Register all services here (Web + API share this setup)
        services.AddScoped<IStudentServices, StudentService>();
    }
}
