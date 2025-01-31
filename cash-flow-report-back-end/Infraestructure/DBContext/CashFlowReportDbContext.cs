using CashFlowReport.API.Domain.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CashFlowReport.API.Infraestructure.DBContext;

public class CashFlowReportDbContext(DbContextOptions<CashFlowReportDbContext> options) : DbContext(options)
{    
    public DbSet<CashFlowInput> CashFlowInput { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }
}