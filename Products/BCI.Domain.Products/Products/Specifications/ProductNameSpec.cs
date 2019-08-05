using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Specifications
{
    internal class ProductNameSpec : Specification<string>
    {
        public ProductNameSpec(string productName)
            : base(productName, name =>
                string.IsNullOrWhiteSpace(name) == false && name.Trim().Length >= 3)
        {
        }
    }
}