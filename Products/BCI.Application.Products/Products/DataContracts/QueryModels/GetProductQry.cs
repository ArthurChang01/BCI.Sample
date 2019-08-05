using BCI.Products.Application.Products.DataContracts.ViewModels;
using MediatR;

namespace BCI.Products.Application.Products.DataContracts.QueryModels
{
    public class GetProductQry : IRequest<ProductVM>
    {
        public string Id { get; set; }
    }
}