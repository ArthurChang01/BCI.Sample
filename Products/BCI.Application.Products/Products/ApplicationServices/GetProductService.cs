using System.Threading;
using System.Threading.Tasks;
using BCI.Products.Application.Products.DataContracts.QueryModels;
using BCI.Products.Application.Products.DataContracts.ViewModels;
using BCI.Products.Domain.Products.Interfaces;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;
using MediatR;

namespace BCI.Products.Application.Products.ApplicationServices
{
    public class GetProductService : IRequestHandler<GetProductQry, ProductVM>
    {
        private readonly ITranslator<ProductId, string> idTranslator;
        private readonly ITranslator<ProductVM, Product> rmTranslator;
        private readonly IProductRepository repository;

        public GetProductService(ITranslator<ProductId, string> idTranslator, ITranslator<ProductVM, Product> rmTranslator, IProductRepository repository)
        {
            this.idTranslator = idTranslator;
            this.rmTranslator = rmTranslator;
            this.repository = repository;
        }

        public async Task<ProductVM> Handle(GetProductQry request, CancellationToken cancellationToken)
        {
            ProductId prdId = idTranslator.Translate(request.Id);
            Product product = this.repository.GetBy(prdId);
            if (product == null)
                return null;

            ProductVM rm = this.rmTranslator.Translate(product);
            return await Task.FromResult(rm);
        }
    }
}