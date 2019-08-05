using System.Collections.Generic;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.DomainEvents
{
    public class IconPathChanged : DomainEvent<CategoryId>
    {
        public IconPathChanged(CategoryId aggregateId, string iconPath)
        {
            this.AggregateId = aggregateId;
            this.IconPath = iconPath;
        }

        public string IconPath { get; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.IconPath;
        }
    }
}