using BCI.SharedCores.Interfaces;
using MediatR;

namespace BCI.Infrastructures
{
    public class NotificationBase<T> : INotification
        where T : IDomainEvent
    {
        public NotificationBase(T @event)
        {
            this.PayloadEvent = @event;
        }

        public T PayloadEvent { get; private set; }
    }
}