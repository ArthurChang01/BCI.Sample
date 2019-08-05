using System.Threading;
using System.Threading.Tasks;
using BCI.Orders.Application.Orders.DataContracts.Commands;
using BCI.Orders.Domain.Orders.Models;
using MediatR;

namespace BCI.Orders.Application.Orders.ApplicationServices
{
    public class AddOrderService : IRequestHandler<AddOrderCmd, Order>
    {
        public Task<Order> Handle(AddOrderCmd request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}