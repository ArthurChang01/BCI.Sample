using System.Collections.Generic;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.DomainEvents
{
    public class CategoryCreated : DomainEvent<CategoryId>
    {
        public CategoryCreated(
            CategoryId id, string name, int lv, string iconPath, CategoryId parentCategoryId, IEnumerable<CategoryProperty> categoryProperties)
        {
            this.AggregateId = id;
            this.Name = name;
            this.Level = lv;
            this.IconPath = iconPath;
            this.ParentCategoryId = parentCategoryId;
            this.CategoryProperties = categoryProperties;
        }

        #region Properties

        public string Name { get; }

        public int Level { get; }

        public string IconPath { get; }

        public CategoryId ParentCategoryId { get; }

        public IEnumerable<CategoryProperty> CategoryProperties { get; }

        #endregion Properties

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Name;
            yield return this.Level;
            yield return this.IconPath;
            yield return this.ParentCategoryId;
            foreach (var categoryProperty in this.CategoryProperties)
            {
                yield return categoryProperty;
            }
        }
    }
}