using System.Collections.Generic;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.DomainEvents
{
    public class AddressChanged : DomainEvent<OrderId>
    {
        public AddressChanged(OrderId aggregateId, Address address)
        {
            this.AggregateId = aggregateId;
            this.Address = address;
        }

        public Address Address { get; private set; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Address;
        }
    }
}