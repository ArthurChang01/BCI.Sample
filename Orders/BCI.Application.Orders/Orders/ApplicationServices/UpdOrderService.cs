using System.Threading;
using System.Threading.Tasks;
using BCI.Orders.Application.Orders.DataContracts.Commands;
using MediatR;

namespace BCI.Orders.Application.Orders.ApplicationServices
{
    public class UpdOrderService : IRequestHandler<UpdOrderCmd>
    {
        public Task<Unit> Handle(UpdOrderCmd request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Unit());
        }
    }
}