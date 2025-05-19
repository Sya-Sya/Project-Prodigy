using CollegeApp.Domain.Enums.Books;
using Dapper;
using System.Data;

namespace CollegeApp.API.Seeders;

public class FormatSeeder
{
    private readonly ILogger<FormatSeeder> _logger;

    public FormatSeeder(ILogger<FormatSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(IDbConnection connection)
    {
        var formats = Enum.GetNames(typeof(Format));

        foreach (var format in formats)
        {
            var exists = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM Formats WHERE FormatName = @FormatName",
                new { FormatName = format });

            if (exists == 0)
            {
                await connection.ExecuteAsync(
                    "INSERT INTO Formats (FormatName) VALUES (@FormatName)",
                    new { FormatName = format });

                _logger.LogInformation("Inserted new format: {FormatName}", format);
            }
            else
            {
                _logger.LogInformation("Format already exists: {FormatName}", format);
            }
        }

        _logger.LogInformation("Completed seeding Formats.");
    }
}