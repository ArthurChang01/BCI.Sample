﻿using System.Collections.Generic;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.DomainEvents
{
    public class LevelUpgraded : DomainEvent<CategoryId>
    {
        public LevelUpgraded(CategoryId aggregateId, int level)
        {
            this.AggregateId = aggregateId;
            this.Level = level;
        }

        public int Level { get; }

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Level;
        }
    }
}