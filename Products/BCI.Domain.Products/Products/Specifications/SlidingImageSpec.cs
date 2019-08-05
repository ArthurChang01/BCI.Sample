using System.Linq;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Specifications
{
    internal class SlidingImageSpec : Specification<Product>
    {
        public SlidingImageSpec(Product product)
            : base(product, prd => prd.SlidingImgPath.Any() &&
                          prd.SlidingImgPath.All(sp => string.IsNullOrWhiteSpace(sp.ImagePath) == false) &&
                          prd.SlidingImgPath.Select(sp => sp.Order).Distinct().Count() == prd.SlidingImgPath.Count())
        {
        }
    }
}