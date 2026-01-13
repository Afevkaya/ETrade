using ETradeBackend.Application.Repositories.Products;
using ETradeBackend.Domain.Entities;
using ETradeBackend.Persistence.Contexts;

namespace ETradeBackend.Persistence.Repositories.Products;

public class ProductReadRepository(ETradeBackendDbContext context) : ReadRepository<Product>(context),IProductReadRepository
{
    
    
}