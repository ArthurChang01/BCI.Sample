using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Specifications
{
    internal class ThumbnailSpec : Specification<Product>
    {
        public ThumbnailSpec(Product product)
            : base(product, prd => prd.ThumbnailPath != null &&
                          string.IsNullOrWhiteSpace(prd.ThumbnailPath.ImagePath) == false)
        {
        }
    }
}