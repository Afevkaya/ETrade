using ETradeBackend.Application.Repositories.Orders;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;

namespace ETradeBackend.Persistence.Repositories.Orders;

public class OrderReadRepository(ETradeBackendDbContext context) : ReadRepository<Order>(context),IOrderReadRepository
{
    
}