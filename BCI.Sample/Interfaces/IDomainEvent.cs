using System;

namespace BCI.SharedCores.Interfaces
{
    public interface IDomainEvent
    {
        Guid EventId { get; }

        DateTimeOffset OccuredDate { get; }
    }
}