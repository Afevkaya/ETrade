using ETradeBackend.Domain.Entities;
using ETradeBackend.Domain.Entities.Common;
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

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<BaseEntity>();
        var utcNow = DateTime.UtcNow;

        foreach (var entry in entries)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDate = utcNow;
                    entry.Property(nameof(BaseEntity.UpdatedDate)).IsModified = false;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDate = utcNow;
                    entry.Property(nameof(BaseEntity.CreatedDate)).IsModified = false;
                    break;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
}