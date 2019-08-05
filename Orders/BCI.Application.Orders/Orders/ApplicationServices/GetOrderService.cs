using System;
using System.Threading;
using System.Threading.Tasks;
using BCI.Orders.Application.Orders.DataContracts.QueryModels;
using BCI.Orders.Application.Orders.DataContracts.ViewModels;
using MediatR;

namespace BCI.Orders.Application.Orders.ApplicationServices
{
    internal class GetOrderService : IRequestHandler<GetOrderQry, OrderRM>
    {
        public async Task<OrderRM> Handle(GetOrderQry request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}