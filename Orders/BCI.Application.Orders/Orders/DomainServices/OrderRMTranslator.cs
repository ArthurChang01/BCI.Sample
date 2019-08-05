using BCI.Orders.Application.Orders.DataContracts.ViewModels;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Orders.Application.Orders.DomainServices
{
    public class OrderRMTranslator : ITranslator<OrderRM, Order>
    {
        public OrderRM Translate(Order input)
        {
            throw new System.NotImplementedException();
        }
    }
}