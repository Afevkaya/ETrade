using ETradeBackend.Application.Repositories.Customers;
using ETradeBackend.Application.Repositories.Generics;
using ETradeBackend.Application.Repositories.Orders;
using ETradeBackend.Application.Repositories.Products;
using ETradeBackend.Persistence.Contexts;
using ETradeBackend.Persistence.Repositories.Customers;
using ETradeBackend.Persistence.Repositories.Orders;
using ETradeBackend.Persistence.Repositories.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ETradeBackend.Persistence.Extensions;

public static class ServiceRegistration
{
   public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
   {
      services.AddDbContext<ETradeBackendDbContext>(options=>
      {
         options.UseNpgsql(configuration.GetConnectionString("ETradeBackendConnectionString"));
      }, ServiceLifetime.Singleton);

      services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();
      services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();
      services.AddSingleton<IOrderReadRepository, OrderReadRepository>();
      services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();
      services.AddSingleton<IProductReadRepository, ProductReadRepository>();
      services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();
      
      return services;
   }
}