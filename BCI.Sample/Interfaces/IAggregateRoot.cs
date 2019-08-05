using System.Collections.Generic;

namespace BCI.SharedCores.Interfaces
{
    public interface IAggregateRoot
    {
        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }
    }
}