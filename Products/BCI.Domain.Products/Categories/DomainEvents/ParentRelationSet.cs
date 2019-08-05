using System.Collections.Generic;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.DomainEvents
{
    public class ParentRelationSet : DomainEvent<CategoryId>
    {
        public ParentRelationSet(CategoryId aggregateId, CategoryId parentId)
        {
            this.AggregateId = aggregateId;
            this.ParentId = parentId;
        }

        public CategoryId ParentId { get; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.ParentId;
        }
    }
}