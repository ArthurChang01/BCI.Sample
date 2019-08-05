using System.Threading;
using System.Threading.Tasks;
using BCI.Products.Application.Products.DataContracts.Commands;
using BCI.Products.Domain.Products.Interfaces;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;
using MediatR;

namespace BCI.Products.Application.Products.ApplicationServices
{
    public class UpdProductService : IRequestHandler<UpdProductCmd>
    {
        private readonly ITranslator<ProductId, string> productIdTranslator;
        private readonly IProductRepository repository;

        public UpdProductService(IProductRepository repository, ITranslator<ProductId, string> productIdTranslator)
        {
            this.repository = repository;
            this.productIdTranslator = productIdTranslator;
        }

        public async Task<Unit> Handle(UpdProductCmd request, CancellationToken cancellationToken)
        {
            ProductId id = this.productIdTranslator.Translate(request.Id);
            Product product = this.repository.GetBy(id);

            return await Task.FromResult(new Unit());
        }
    }
}