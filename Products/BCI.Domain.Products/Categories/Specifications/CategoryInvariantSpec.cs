using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.Specifications
{
    public class CategoryInvariantSpec : Specification<Category>
    {
        public CategoryInvariantSpec(Category category)
            : base(ct => string.IsNullOrWhiteSpace(ct.Name) == false &&
                         ct.Level > 0 &&
                         string.IsNullOrWhiteSpace(ct.IconPath) == false)
        {
        }
    }
}