using CashFlowInputs.API.Domain.Models;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace CashFlowInputs.API.Infraestructure.DBContext;

public class CashFlowInputsDbContext(DbContextOptions<CashFlowInputsDbContext> options) : DbContext(options)
{    
    public DbSet<CashFlowInput> CashFlowInputs { get; set; }

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