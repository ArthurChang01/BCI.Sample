using BCI.Orders.Domain.Orders.Models;
using MediatR;

namespace BCI.Orders.Application.Orders.DataContracts.Commands
{
    public class AddOrderCmd : IRequest<Order>
    {
    }
}