using ETradeBackend.Application.Repositories.Orders;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;

namespace ETradeBackend.Persistence.Repositories.Orders;

public class OrderWriteRepository(ETradeBackendDbContext context) : WriteRepository<Order>(context), IOrderWriteRepository
{
    
}