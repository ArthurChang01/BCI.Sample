using System.Collections.Generic;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.DomainEvents
{
    public class QtyIncreased : DomainEvent<ProductId>
    {
        public QtyIncreased(ProductId aggregateId, int qty)
        {
            this.AggregateId = aggregateId;
            this.Qty = qty;
        }

        public int Qty { get; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Qty;
        }
    }
}