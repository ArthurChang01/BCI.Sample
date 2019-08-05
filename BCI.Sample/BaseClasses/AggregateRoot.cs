using System.Collections.Generic;
using BCI.SharedCores.Interfaces;

namespace BCI.SharedCores.BaseClasses
{
    public abstract class AggregateRoot<TId> : Entity<TId>, IAggregateRoot
        where TId : ValueObject<TId>
    {
        protected readonly List<IDomainEvent> domainEvents = new List<IDomainEvent>();

        public AggregateRoot(params IDomainEvent[] events)
        {
            this.DomainEvents = this.domainEvents;
        }

        public IReadOnlyCollection<IDomainEvent> DomainEvents { get; protected set; }

        protected void ApplyEvent(IDomainEvent @event)
        {
            this.domainEvents.Add(@event);
            this.DomainEvents = this.domainEvents;
        }
    }
}