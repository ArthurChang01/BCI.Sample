using System;
using System.Threading;
using System.Threading.Tasks;
using BCI.Infrastructures;
using BCI.Products.Domain.Products.DomainEvents;
using MediatR;

namespace BCI.Products.Application.Products.DomainEventHandlers
{
    public class ProductAddHandler : INotificationHandler<NotificationBase<ProductCreated>>
    {
        public Task Handle(NotificationBase<ProductCreated> notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}