using System.Collections.Generic;
using System.Linq;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.DomainEvents
{
    public class OrderCreated : DomainEvent<OrderId>
    {
        public OrderCreated(OrderId id, Address address, decimal shippingPrice, decimal totalPrice, OrderStatus status,
            PaymentMethod payMethod, IEnumerable<Product> products)
        {
            this.AggregateId = id;
            this.Address = address;
            this.ShippingPrice = shippingPrice;
            this.TotalPrice = totalPrice;
            this.Status = status;
            this.PaymentMethod = payMethod;
            this.Products = products?.ToList() ?? new List<Product>();
        }

        #region Properties

        public Address Address { get; private set; }

        public decimal ShippingPrice { get; private set; }

        public decimal TotalPrice { get; private set; }

        public OrderStatus Status { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public ICollection<Product> Products { get; private set; }

        #endregion Properties

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Address;
            yield return this.ShippingPrice;
            yield return this.TotalPrice;
            yield return this.Status;
            yield return this.PaymentMethod;
            foreach (var product in this.Products)
            {
                yield return product;
            }
        }
    }
}