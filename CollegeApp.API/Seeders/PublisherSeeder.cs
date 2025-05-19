using Dapper;
using System.Data;

namespace CollegeApp.API.Seeders;

public class PublisherSeeder
{
    private readonly ILogger<PublisherSeeder> _logger;

    public PublisherSeeder(ILogger<PublisherSeeder> logger)
    {
        _logger = logger;
    }

    public async Task SeedAsync(IDbConnection connection)
    {
        var defaultPublishers = new[]
        {
            new { Name = "Penguin Random House", Location = "New York, USA" },
            new { Name = "HarperCollins", Location = "New York, USA" },
            new { Name = "Simon & Schuster", Location = "New York, USA" },
            new { Name = "Hachette Book Group", Location = "Paris, France" }
        };

        foreach (var publisher in defaultPublishers)
        {
            var exists = await connection.ExecuteScalarAsync<int>(
                "SELECT COUNT(1) FROM Publishers WHERE Name = @Name",
                new { publisher.Name });

            if (exists == 0)
            {
                await connection.ExecuteAsync(
                    "INSERT INTO Publishers (Name, Location) VALUES (@Name, @Location)",
                    new { publisher.Name, publisher.Location });

                _logger.LogInformation("Inserted publisher: {Publisher}", publisher.Name);
            }
            else
            {
                _logger.LogInformation("Publisher already exists: {Publisher}", publisher.Name);
            }
        }

        _logger.LogInformation("Completed seeding Publishers.");
    }
}