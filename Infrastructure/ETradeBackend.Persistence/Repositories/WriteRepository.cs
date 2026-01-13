using ETradeBackend.Application.Repositories.Generics;
using ETradeBackend.Domain.Entities.Common;
using ETradeBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ETradeBackend.Persistence.Repositories;

public class WriteRepository<T>(ETradeBackendDbContext context) : IWriteRepository<T> where T : BaseEntity
{
    public DbSet<T> Table { get; } = context.Set<T>();
    public async Task<T> AddAsync(T entity)
    {
        var result = await Table.AddAsync(entity);
        return result.Entity;
    }

    public async Task<List<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await Table.AddRangeAsync(entities);
        return entities.ToList();
    }
    public bool Remove(T entity)
    {
        var result = Table.Remove(entity);
        return result.State == EntityState.Deleted;
    }

    public bool Remove(Guid id)
    {
        var entity = Table.Find(id);
        return entity != null && Remove(entity);
    }

    public bool RemoveRange(IEnumerable<T> entities)
    {
        Table.RemoveRange(entities);
        return true;
    }

    public bool Update(T entity)
    {
        var result = Table.Update(entity);
        return result.State == EntityState.Modified;
    }
    
    public async Task<int> SaveChangesAsync() => await context.SaveChangesAsync();
}