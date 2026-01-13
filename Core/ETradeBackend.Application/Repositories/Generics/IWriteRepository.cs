using ETradeBackend.Domain.Entities.Common;

namespace ETradeBackend.Application.Repositories.Generics;

public interface IWriteRepository<T>: IRepository<T> where T : BaseEntity
{
    Task<T> AddAsync(T entity);
    Task<List<T>> AddRangeAsync(IEnumerable<T> entities);
    bool Remove(T entity);
    bool Remove(Guid id);
    bool RemoveRange(IEnumerable<T> entities);
    bool Update(T entity);
    Task<int> SaveChangesAsync();
}