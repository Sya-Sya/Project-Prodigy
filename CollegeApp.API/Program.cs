using CollegeApp.DependencyContainer;
using CollegeApp.Domain.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use the shared DI container
builder.Services.AddInfrastructure(builder.Configuration);

// Enable API controller routing
builder.Services.AddControllers(); 
var app = builder.Build();

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