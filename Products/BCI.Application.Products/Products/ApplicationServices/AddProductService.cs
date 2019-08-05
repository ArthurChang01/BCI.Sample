using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BCI.Products.Application.Products.DataContracts.Commands;
using BCI.Products.Application.Products.DataContracts.ViewModels;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.Domain.Products.DomainEvents;
using BCI.Products.Domain.Products.Interfaces;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;
using MediatR;

namespace BCI.Products.Application.Products.ApplicationServices
{
    public class AddProductService : IRequestHandler<AddProductCmd, ProductVM>
    {
        private readonly ITranslator<CategoryId, string> categoryIdTranslator;
        private readonly ITranslator<ProductVM, Product> productRMTranslator;
        private readonly IProductRepository repository;

        public AddProductService(ITranslator<CategoryId, string> categoryIdTranslator, ITranslator<ProductVM, Product> productRMTranslator,
            IProductRepository repository)
        {
            this.categoryIdTranslator = categoryIdTranslator;
            this.productRMTranslator = productRMTranslator;
            this.repository = repository;
        }

        public async Task<ProductVM> Handle(AddProductCmd request, CancellationToken cancellationToken)
        {
            ProductId productId = this.repository.GenerateProductId();
            CategoryId categoryId = this.categoryIdTranslator.Translate(request.CategoryId);

            Product product = Product.CreateProduct(productId, request.Name,
                request.Description, request.TotalSalesQty, categoryId,
                request.ThumbnailPath, request.SlidingImgPath);
            ProductCreated @event = product.DomainEvents.First(evt => evt is ProductCreated) as ProductCreated;
            this.repository.Save(product, @event);

            ProductVM rm = this.productRMTranslator.Translate(product);

            return await Task.FromResult(rm);
        }
    }
}