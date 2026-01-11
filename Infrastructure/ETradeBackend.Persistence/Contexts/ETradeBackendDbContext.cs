using ETradeBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ETradeBackend.Persistence.Contexts;

public class ETradeBackendDbContext : DbContext
{
    public ETradeBackendDbContext(DbContextOptions<ETradeBackendDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ETradeBackendDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
}