using System.Collections.Generic;
using System.Linq;
using BCI.Products.Domain.Categories.DomainEvents;
using BCI.SharedCores.BaseClasses;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Domain.Categories.Models
{
    public class Category : AggregateRoot<CategoryId>
    {
        private readonly List<CategoryProperty> categoryProperties = new List<CategoryProperty>();
        private readonly List<IDomainEvent> domainEvent = new List<IDomainEvent>();

        #region Constructors

        public Category()
        {
            this.CategoryProperties = this.categoryProperties;
            this.DomainEvents = this.domainEvent;
        }

        public Category(params IDomainEvent[] events)
        {
            foreach (var @event in events)
            {
                this.When((dynamic)@event);
            }
        }

        private Category(CategoryId id, string name, int level, string iconPath, CategoryId parentId, IEnumerable<CategoryProperty> categoryProperties = null)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.IconPath = iconPath;
            this.ParentCategoryId = parentId;
            this.CategoryProperties = categoryProperties?.ToList() ?? this.categoryProperties;

            this.DomainEvents = new List<IDomainEvent>()
            {
                new CategoryCreated(this.Id, this.Name, this.Level,   this.IconPath,this.ParentCategoryId,this.CategoryProperties)
            };
        }

        #endregion Constructors

        #region Properties

        public string Name { get; private set; }

        public int Level { get; private set; }

        public CategoryId ParentCategoryId { get; private set; }

        public string IconPath { get; private set; }

        public IReadOnlyList<CategoryProperty> CategoryProperties { get; private set; }

        #endregion Properties

        #region Public methods

        public static Category CreateCategory(CategoryId id, string name, int level, string iconPath, CategoryId parentId = null, IEnumerable<CategoryProperty> categoryProperties = null)
        {
            return new Category(id, name, level, iconPath, parentId, categoryProperties);
        }

        public void Upgrade(int level = 1)
        {
            this.Level += level;

            this.ApplyEvent(new LevelUpgraded(this.Id, this.Level));
        }

        public void Downgrade(int level = 1)
        {
            this.Level -= level;

            this.ApplyEvent(new LevelDowngraded(this.Id, this.Level));
        }

        public void SetParentRelation(CategoryId parentId)
        {
            this.ParentCategoryId = parentId;

            this.ApplyEvent(new ParentRelationSet(this.Id, parentId));
        }

        public void ChangeIconPath(string iconPath)
        {
            this.IconPath = iconPath;

            this.ApplyEvent(new IconPathChanged(this.Id, iconPath));
        }

        #endregion Public methods

        #region Private methods

        private void InitialCategory(CategoryId id, string name, int level, string iconPath, CategoryId parentId,
            IEnumerable<CategoryProperty> categoryProperties = null)
        {
            this.Id = id;
            this.Name = name;
            this.Level = level;
            this.IconPath = iconPath;
            this.ParentCategoryId = parentId;
            this.CategoryProperties = categoryProperties?.ToList() ?? this.categoryProperties;
        }

        #endregion Private methods

        #region Event Applied methods

        private void When(CategoryCreated @event)
        {
            this.InitialCategory(@event.AggregateId, @event.Name, @event.Level, @event.IconPath, @event.ParentCategoryId,
                @event.CategoryProperties);
        }

        private void When(LevelUpgraded @event)
        {
            this.Level = @event.Level;
        }

        private void When(LevelDowngraded @event)
        {
            this.Level = @event.Level;
        }

        private void When(ParentRelationSet @event)
        {
            this.ParentCategoryId = @event.ParentId;
        }

        private void When(IconPathChanged @event)
        {
            this.IconPath = @event.IconPath;
        }

        #endregion Event Applied methods
    }
}