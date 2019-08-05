using System;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.UnitTests.Factories;
using FluentAssertions;
using NUnit.Framework;

namespace BCI.Products.UnitTests.Categories
{
    /// <summary>
    /// Event Sourcing Tests
    /// </summary>
    public class CategoryEventSourcingTests
    {
        [TestCase()]
        public void When_Category_Is_Initialed_And_Apply_CreatedEvent_Then_Category_Is_Initialed()
        {
            CategoryId id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id);
            var createdEvent = CategoryFactory.GetCreatedEvent(id);

            var actual = new Category(createdEvent);

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void When_Category_Apply_LevelUpgradedEvent_Then_Category_Level_Is_Inceased_1()
        {
            CategoryId id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, level: 1);

            var createdEvent = CategoryFactory.GetCreatedEvent(id, level: 0);
            var lvUpgradedEvent = CategoryFactory.GetLevelUpgradedEvent(id, 1);
            var actual = new Category(new[] { createdEvent, lvUpgradedEvent });

            actual.Level.Should().Be(expected.Level);
        }

        [TestCase()]
        public void When_Category_Apply_LevelDowngradedEvent_Then_CategoryLevel_Is_Reduced_1()
        {
            CategoryId id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, level: 1);

            var createdEvent = CategoryFactory.GetCreatedEvent(id, level: 2);
            var lvDowngradedEvent = CategoryFactory.GetLevelDowngradedEvent(id, 1);
            var actual = new Category(new[] { createdEvent, lvDowngradedEvent });

            actual.Level.Should().Be(expected.Level);
        }

        [TestCase()]
        public void When_Category_Apply_ParentRelationSetEvent_Then_Category_ParentId_Is_cat201908030()
        {
            DateTimeOffset date = new DateTimeOffset(2019, 08, 03, 0, 0, 0, TimeSpan.Zero);
            CategoryId id = CategoryFactory.GetCategoryId(1);
            CategoryId parentId = CategoryFactory.GetCategoryId(0, date);
            var expected = CategoryFactory.GetCategory(id, parentId: parentId);

            var createdEvent = CategoryFactory.GetCreatedEvent(id);
            var parentIdSetEvent = CategoryFactory.GetParentRelationSetEvent(id, parentId: parentId);
            var actual = new Category(new[] { createdEvent, parentIdSetEvent });

            actual.ParentCategoryId.Should().Be(expected.ParentCategoryId);
        }

        [TestCase()]
        public void When_Category_Apply_IconPathChangedEvent_Then_Category_IconPath_Is_Path()
        {
            CategoryId id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, iconPath: "Path");

            var createdEvent = CategoryFactory.GetCreatedEvent(id);
            var iconChangedEvent = CategoryFactory.GetIconPathChangedEvent(id, "Path");
            var actual = new Category(new[] { createdEvent, iconChangedEvent });

            actual.IconPath.Should().Be(expected.IconPath);
        }
    }
}