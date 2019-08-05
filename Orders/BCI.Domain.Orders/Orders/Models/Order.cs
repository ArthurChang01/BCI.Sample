using System;
using System.Collections.Generic;
using System.Linq;
using BCI.Orders.Domain.Orders.DomainEvents;
using BCI.Orders.Domain.Orders.Exceptions;
using BCI.Orders.Domain.Orders.Specifications;
using BCI.SharedCores.BaseClasses;
using BCI.SharedCores.Interfaces;

namespace BCI.Orders.Domain.Orders.Models
{
    public class Order : AggregateRoot<OrderId>
    {
        private List<Product> products = new List<Product>();

        #region Contructors

        public Order()
        {
            this.Products = this.products;
            this.DomainEvents = new List<IDomainEvent>();
        }

        public Order(IEnumerable<IDomainEvent> domainEvents)
        {
            foreach (var @event in domainEvents)
            {
                this.When((dynamic)@event);
            }
        }

        public Order(OrderId id, Address address, decimal shippingPrice, decimal totalPrice,
            OrderStatus status, PaymentMethod paymethod, IEnumerable<Product> products)
        {
            this.InitialOrder(id, address, shippingPrice, totalPrice, status, paymethod, products);

            this.DomainEvents = new List<IDomainEvent>()
            {
                new OrderCreated(this.Id, this.Address, this.ShippingPrice, this.TotalPrice, this.Status, this.PaymentMethod, this.Products)
            };
        }

        #endregion Contructors

        #region Properties

        public Address Address { get; private set; }

        public decimal ShippingPrice { get; private set; }

        public decimal TotalPrice { get; private set; }

        public OrderStatus Status { get; private set; }

        public PaymentMethod PaymentMethod { get; private set; }

        public IReadOnlyList<Product> Products { get; private set; }

        #endregion Properties

        #region Public Methods

        public static Order CreateOrder(int seqNo, Address address, decimal shippingPrice, decimal totalPrice,
            IEnumerable<Product> products)
        {
            return new Order(
                new OrderId(seqNo, DateTimeOffset.Now), address, shippingPrice, totalPrice,
                OrderStatus.WaitForPaying, PaymentMethod.Cash, products);
        }

        public void ChangeAddress(Address address)
        {
            this.Address = address;
            if (new AddressSpec(this.Address).IsSatisfy() == false)
                throw new OrderAddressVerifyException(this.Address);

            this.ApplyEvent(new AddressChanged(this.Id, this.Address));
        }

        public void TransitToNextStatus()
        {
            OrderStatus oriStatus = this.Status;
            int currentStatusNumber = (int)oriStatus;
            this.Status = (OrderStatus)Enum.ToObject(typeof(OrderStatus), currentStatusNumber + 1);

            if (new StatusSpec(oriStatus, this.Status).IsSatisfy() == false)
                throw new StatusVerifyException(this.Status);

            this.ApplyEvent(new StatusChanged(this.Id, this.Status));
        }

        public void ChangeProducts(IEnumerable<Product> products)
        {
            this.Products = products?.ToList();
            if (new ProductSpec(this.Products).IsSatisfy() == false)
                throw new Exception();

            this.TotalPrice = this.products.Sum(prd => prd.Price * prd.Qty);

            this.ApplyEvent(new ProductChanged(this.Id, this.Products, this.TotalPrice));
        }

        #endregion Public Methods

        #region Private Event Apply

        private void InitialOrder(OrderId id, Address address, decimal shippingPrice, decimal totalPrice,
            OrderStatus status, PaymentMethod paymethod, IEnumerable<Product> products)
        {
            this.Id = id;
            this.Address = address;
            this.ShippingPrice = shippingPrice;
            this.TotalPrice = totalPrice;
            this.Status = status;
            this.PaymentMethod = paymethod;
            this.Products = products?.ToList() ?? new List<Product>();
        }

        private void When(OrderCreated @event)
        {
            this.InitialOrder(@event.AggregateId, @event.Address, @event.ShippingPrice, @event.TotalPrice,
                @event.Status, @event.PaymentMethod, @event.Products);
        }

        private void When(AddressChanged @event)
        {
            this.Address = @event.Address;
        }

        private void When(StatusChanged @event)
        {
            this.Status = @event.Status;
        }

        private void When(ProductChanged @event)
        {
            this.products = @event.Products.ToList();
            this.TotalPrice = @event.TotalPrice;
        }

        #endregion Private Event Apply
    }
}