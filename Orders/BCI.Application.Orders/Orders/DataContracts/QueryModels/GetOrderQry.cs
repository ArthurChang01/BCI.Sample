using BCI.Orders.Application.Orders.DataContracts.ViewModels;
using MediatR;

namespace BCI.Orders.Application.Orders.DataContracts.QueryModels
{
    public class GetOrderQry : IRequest<OrderRM>
    {
    }
}