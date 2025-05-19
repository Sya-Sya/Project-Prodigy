using CollegeApp.API.Seeders;
using CollegeApp.DependencyContainer;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use the shared DI container
builder.Services.AddInfrastructure(builder.Configuration);

// Enable API controller routing
builder.Services.AddControllers(); 
var app = builder.Build();

// Seed formats during startup
using (var scope = app.Services.CreateScope())
{
    var configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
    var loggerFactory = scope.ServiceProvider.GetRequiredService<ILoggerFactory>();
    var connectionString = configuration.GetConnectionString("DefaultConnection");

    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    var formatLogger = loggerFactory.CreateLogger<FormatSeeder>();
    var publisherLogger = loggerFactory.CreateLogger<PublisherSeeder>();

    var formatSeeder = new FormatSeeder(formatLogger);
    await formatSeeder.SeedAsync(connection);

    var publisherSeeder = new PublisherSeeder(publisherLogger);
    await publisherSeeder.SeedAsync(connection);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Use routing for API controllers
app.MapControllers();  // This ensures API controllers are mapped

app.Run();