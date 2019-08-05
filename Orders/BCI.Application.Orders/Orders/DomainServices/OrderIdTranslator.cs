using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Orders.Application.Orders.DomainServices
{
    public class OrderIdTranslator : ITranslator<OrderId, string>
    {
        public OrderId Translate(string input)
        {
            throw new System.NotImplementedException();
        }
    }
}