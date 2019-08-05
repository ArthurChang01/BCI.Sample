using System;
using System.Collections.Generic;
using System.Linq;
using BCI.Infrastructures.Repositories.EventSourcings;
using BCI.Products.Domain.Categories.Interfaces;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Application.Categories.Repositories
{
    public class CategoryRepository : ESRepositoryBase<Category, CategoryId>, ICategoryRepository
    {
        public CategoryId GenerateCategoryId()
        {
            return new CategoryId(this.Count(), DateTimeOffset.Now);
        }

        public Category GetBy(CategoryId id)
        {
            return base.Get(id);
        }

        public IEnumerable<Category> GetList(Specification<Category> spec, int pageNo = 1, int pageSize = 5)
        {
            return this.Get(s => s, spec).Skip((pageNo - 1) * pageSize).Take(pageSize);
        }

        public void Save(Category category, DomainEvent<CategoryId> @event)
        {
            this.Append(category, @event);
        }
    }
}