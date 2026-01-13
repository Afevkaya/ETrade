using System.Linq.Expressions;
using ETradeBackend.Application.Repositories.Generics;
using ETradeBackend.Domain.Entities.Common;
using ETradeBackend.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ETradeBackend.Persistence.Repositories;

public class ReadRepository<T>(ETradeBackendDbContext context) : IReadRepository<T> where T : BaseEntity
{
    public DbSet<T> Table { get; } = context.Set<T>();
    public IQueryable<T> GetAll() => Table.AsNoTracking();
   

    public IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate) => Table.Where(predicate).AsNoTracking();
    

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate) => await Table.SingleOrDefaultAsync(predicate);

    public Task<T> GetByIdAsync(Guid id) => Table.SingleOrDefaultAsync(e => e.Id == id);
}