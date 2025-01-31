using CashFlowReport.API.Infraestructure.DBContext;
using Microsoft.EntityFrameworkCore;

namespace CashFlowReport.API.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = 
            Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
            configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CashFlowReportDbContext>(options =>
        {
            options.UseNpgsql(
                connectionString,
                npgsqlOptions =>
                {
                    npgsqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 3,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorCodesToAdd: null);
                    npgsqlOptions.MigrationsHistoryTable("__ef_migration_history", "transactions");
                });

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                options.EnableSensitiveDataLogging();
                options.EnableDetailedErrors();
            }
        });
    }
}