using System.Linq.Expressions;
using ETradeBackend.Application.Repositories.Generics;
using ETradeBackend.Domain.Entities.Common;
using ETradeBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ETradeBackend.Persistence.Repositories;

public class ReadRepository<T>(ETradeBackendDbContext context) : IReadRepository<T> where T : BaseEntity
{
    public DbSet<T> Table { get; } = context.Set<T>();
    public IQueryable<T> GetAll(bool isTracking)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
            query = query.AsNoTracking();
        return query;
    }
    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true)
    {
        var query = Table.Where(predicate);
        if (!isTracking)
            query = query.AsNoTracking();
        return query;
    }
    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool isTracking = true)
    {
        var query =  Table.AsQueryable();
        if (!isTracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(predicate);
    }
    public async Task<T> GetByIdAsync(Guid id, bool isTracking = true)
    {
        var query = Table.AsQueryable();
        if (!isTracking)
            query = query.AsNoTracking();
        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}