using System;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Specifications
{
    internal class StatusSpec : Specification<OrderStatus>
    {
        public StatusSpec(OrderStatus oriStatus, OrderStatus newStatus)
            : base(newStatus, status => Math.Abs((int)oriStatus - (int)status) == 1)
        {
        }
    }
}