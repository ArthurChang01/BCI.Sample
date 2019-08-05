using BCI.Products.Application.Categories.DataContracts.ViewModels;
using MediatR;

namespace BCI.Products.Application.Categories.DataContracts.QueryModels
{
    public class GetCategoryQry : IRequest<CategoryRM>
    {
        public string Id { get; internal set; }
    }
}