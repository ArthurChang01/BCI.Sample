using System;
using System.Collections.Generic;
using System.Linq;
using BCI.Infrastructures.Repositories.EventSourcings;
using BCI.Products.Domain.Products.Interfaces;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Application.Products.Repositories
{
    public class ProductRepository : ESRepositoryBase<Product, ProductId>, IProductRepository
    {
        public ProductId GenerateProductId()
        {
            return new ProductId(base.Count(), DateTimeOffset.Now);
        }

        public Product GetBy(ProductId id)
        {
            return base.Get(id);
        }

        public IEnumerable<Product> GetList(Specification<Product> spec, int pageNo = 1, int pageSize = 5)
        {
            return base.Get(s => s, spec).Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

        public void Save(Product product, DomainEvent<ProductId> @event)
        {
            base.Append(product, @event);
        }
    }
}