using System.Threading;
using System.Threading.Tasks;
using BCI.Products.Application.Categories.DataContracts.Commands;
using MediatR;

namespace BCI.Products.Application.Categories.ApplicationServices
{
    public class UpdCategoryService : IRequestHandler<UpdCategoryCmd>
    {
        public async Task<Unit> Handle(UpdCategoryCmd request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(new Unit());
        }
    }
}