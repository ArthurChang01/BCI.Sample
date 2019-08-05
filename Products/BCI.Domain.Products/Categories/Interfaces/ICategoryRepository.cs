using System.Collections.Generic;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.Interfaces
{
    public interface ICategoryRepository
    {
        CategoryId GenerateCategoryId();

        Category GetBy(CategoryId id);

        IEnumerable<Category> GetList(Specification<Category> spec, int pageNo = 1, int pageSize = 5);

        void Save(Category product, DomainEvent<CategoryId> @event);
    }
}