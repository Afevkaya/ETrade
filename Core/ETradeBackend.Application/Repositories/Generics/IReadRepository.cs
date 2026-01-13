using System.Linq.Expressions;
using ETradeBackend.Domain.Entities.Common;

namespace ETradeBackend.Application.Repositories.Generics;

public interface IReadRepository<T>: IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll(bool isTracking = true);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool isTracking = true);
    Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, bool isTracking = true);
    Task<T> GetByIdAsync(Guid id, bool isTracking = true);
    
}