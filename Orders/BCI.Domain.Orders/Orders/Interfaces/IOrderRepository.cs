using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Interfaces
{
    public interface IOrderRepository
    {
        Order Get(OrderId id);

        void Save(Order order, DomainEvent<OrderId> @event);
    }
}