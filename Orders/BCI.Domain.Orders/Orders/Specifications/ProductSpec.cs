using System.Collections.Generic;
using System.Linq;
using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Specifications
{
    internal class ProductSpec : Specification<IEnumerable<Product>>
    {
        public ProductSpec(IEnumerable<Product> products)
        {
            this.Entity = products;
            this.Predicate = prd => prd.Any() &&
                                    prd.All(p =>
                                        string.IsNullOrWhiteSpace(p.Name) == false &&
                                        string.IsNullOrWhiteSpace(p.Id) == false &&
                                        p.Price >= 0 &&
                                        p.Qty > 0);
        }
    }
}