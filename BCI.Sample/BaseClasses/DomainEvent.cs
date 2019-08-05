using System;
using System.Collections.Generic;
using BCI.SharedCores.Interfaces;

namespace BCI.SharedCores.BaseClasses
{
    public abstract class DomainEvent<TaggregateId> : ValueObject<DomainEvent<TaggregateId>>, IDomainEvent
    {
        public DomainEvent()
        {
            this.EventId = Guid.NewGuid();
            this.OccuredDate = DateTimeOffset.Now;
        }

        public Guid EventId { get; private set; }

        public DateTimeOffset OccuredDate { get; private set; }

        public TaggregateId AggregateId { get; protected set; }

        protected abstract IEnumerable<object> GetDerivedEventEqualityComponents();

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.EventId;
            yield return this.OccuredDate;
            yield return this.AggregateId;
            foreach (var property in this.GetDerivedEventEqualityComponents())
            {
                yield return property;
            }
        }
    }
}