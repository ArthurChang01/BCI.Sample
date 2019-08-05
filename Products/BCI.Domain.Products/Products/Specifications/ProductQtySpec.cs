using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Specifications
{
    internal class ProductQtySpec : Specification<int>
    {
        public ProductQtySpec(int productQty)
        : base(productQty, qty => qty >= 0)
        {
        }
    }
}