using System.Collections.Generic;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Interfaces
{
    public interface IProductRepository
    {
        ProductId GenerateProductId();

        Product GetBy(ProductId id);

        IEnumerable<Product> GetList(Specification<Product> spec, int pageNo = 1, int pageSize = 5);

        void Save(Product product, DomainEvent<ProductId> @event);
    }
}