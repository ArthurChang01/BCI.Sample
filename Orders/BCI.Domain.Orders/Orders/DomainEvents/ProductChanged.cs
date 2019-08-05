using System.Collections.Generic;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.DomainEvents
{
    public class ProductChanged : DomainEvent<OrderId>
    {
        public ProductChanged(OrderId aggregateId, IEnumerable<Product> products, decimal totalPrice)
        {
            this.AggregateId = aggregateId;
            this.Products = products;
            this.TotalPrice = totalPrice;
        }

        public IEnumerable<Product> Products { get; private set; }

        public decimal TotalPrice { get; private set; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Products;
            yield return this.TotalPrice;
        }
    }
}