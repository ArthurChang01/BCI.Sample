using MediatR;

namespace BCI.Products.Application.Products.DataContracts.Commands
{
    public class UpdProductCmd : IRequest
    {
        public string Id { get; set; }
    }
}