using ETradeBackend.Domain.Entities.Common;

namespace ETradeBackend.Domain.Entities;

public class Customer : BaseEntity
{
    public ICollection<Order> Orders { get; set; }
    public string Name { get; set; }
}