using BCI.Infrastructures.Repositories.EventSourcings;
using BCI.Orders.Domain.Orders.Interfaces;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Application.Orders.Repositories
{
    public class OrderRepository : ESRepositoryBase<Order, OrderId>, IOrderRepository
    {
        public Order Get(OrderId id)
        {
            return base.First(s => s, new Specification<Order>(o => o.Id.Equals(id)));
        }

        public void Save(Order order, DomainEvent<OrderId> @event)
        {
            this.Append(order, @event);
        }
    }
}