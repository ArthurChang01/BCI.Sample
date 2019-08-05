using System;
using System.Collections.Generic;
using BCI.Products.Domain.Categories.DomainEvents;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.UnitTests.Factories
{
    internal static class CategoryFactory
    {
        public static CategoryId GetCategoryId(long seqNo, DateTimeOffset? date = null)
        {
            return new CategoryId(seqNo, date ?? DateTimeOffset.Now);
        }

        public static Category GetCategory(CategoryId id = null, string name = "name", int level = 0,
            string iconPath = "path", CategoryId parentId = null,
            IEnumerable<CategoryProperty> categoryProperties = null)
        {
            id = id ?? GetCategoryId(0);
            return Category.CreateCategory(id, name, level, iconPath, parentId, categoryProperties);
        }

        public static CategoryProperty GetCategoryProperty(string displayName = "name", string backOfficeName = "name",
            string desc = "desc", IEnumerable<OptionalProperty> optionalProperties = null)
        {
            return new CategoryProperty(displayName, backOfficeName, desc, optionalProperties);
        }

        public static IDomainEvent GetCreatedEvent(CategoryId id = null, string name = "name", int level = 0,
            string iconPath = "path", CategoryId parentId = null,
            IEnumerable<CategoryProperty> categoryProperties = null)
        {
            id = id ?? GetCategoryId(0);
            return new CategoryCreated(id, name, level, iconPath, parentId, categoryProperties);
        }

        public static IDomainEvent GetIconPathChangedEvent(CategoryId id = null, string iconPath = "path")
        {
            id = id ?? GetCategoryId(0);
            return new IconPathChanged(id, iconPath);
        }

        public static IDomainEvent GetLevelUpgradedEvent(CategoryId id = null, int level = 0)
        {
            id = id ?? GetCategoryId(0);
            return new LevelUpgraded(id, level);
        }

        public static IDomainEvent GetLevelDowngradedEvent(CategoryId id = null, int level = 0)
        {
            id = id ?? GetCategoryId(0);
            return new LevelDowngraded(id, level);
        }

        public static IDomainEvent GetParentRelationSetEvent(CategoryId id = null, CategoryId parentId = null)
        {
            id = id ?? GetCategoryId(0);
            return new ParentRelationSet(id, parentId);
        }
    }
}