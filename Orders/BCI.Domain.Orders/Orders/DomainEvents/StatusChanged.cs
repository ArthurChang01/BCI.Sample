using System.Collections.Generic;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.DomainEvents
{
    public class StatusChanged : DomainEvent<OrderId>
    {
        public StatusChanged(OrderId aggregateId, OrderStatus status)
        {
            this.AggregateId = aggregateId;
            this.Status = status;
        }

        public OrderStatus Status { get; private set; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Status;
        }
    }
}