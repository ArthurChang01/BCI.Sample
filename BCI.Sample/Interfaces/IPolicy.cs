using System;

namespace BCI.SharedCores.Interfaces
{
    public interface IPolicy<T>
        where T : IAggregateRoot
    {
        bool IsSatisfy(T aggregateRoot);

        Exception GetWrapperException { get; }
    }
}