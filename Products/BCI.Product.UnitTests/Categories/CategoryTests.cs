using System;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.UnitTests.Factories;
using FluentAssertions;
using NUnit.Framework;

namespace BCI.Products.UnitTests.Categories
{
    public class CategoryTests
    {
        [TestCase()]
        public void When_CategoryId_Is_The_Same_Then_Equality_Comparison_Is_True()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            var expected = new CategoryId(0, now);

            var actual = new CategoryId(0, now);

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void When_CategoryId_Of_Category_Is_Then_Same_Then_Equality_Comparison_Is_True()
        {
            CategoryId id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, "cat1");

            var actual = CategoryFactory.GetCategory(id, "cat2");

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void Given_CategoryLevel_Is_2_When_Upgrade_Is_Called_And_Parameter_Is_3_Then_CategoryLevel_Is_5()
        {
            var id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, level: 5);

            var actual = CategoryFactory.GetCategory(id, level: 2);
            actual.Upgrade(3);

            actual.Level.Should().Be(expected.Level);
        }

        [TestCase()]
        public void Given_CategoryLevel_Is_3_When_Downgrade_Is_Called_And_Parameter_1_Then_CategoryLevel_Is_2()
        {
            var id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, level: 2);

            var actual = CategoryFactory.GetCategory(id, level: 3);
            actual.Downgrade();

            actual.Level.Should().Be(expected.Level);
        }

        [TestCase()]
        public void
            Give_CategoryParentId_Is_cat201908030_When_SetParentRelation_Is_Called_And_Parameter_Is_cat201908031_Then_CategoryParentId_Is_cat201908031()
        {
            DateTimeOffset date = new DateTimeOffset(2019, 8, 3, 0, 0, 0, TimeSpan.Zero);
            var id = CategoryFactory.GetCategoryId(2);
            var expected = CategoryFactory.GetCategory(id, parentId: CategoryFactory.GetCategoryId(0, date));

            var actual = CategoryFactory.GetCategory(id, parentId: CategoryFactory.GetCategoryId(1, date));
            actual.SetParentRelation(CategoryFactory.GetCategoryId(0, date));

            actual.ParentCategoryId.Should().Be(expected.ParentCategoryId);
        }

        [TestCase()]
        public void
            Give_CategoryIconPath_Is_Path_When_ChangeIconPath_And_Parameter_Is_path_Then_CategoryIconPath_Is_path()
        {
            var id = CategoryFactory.GetCategoryId(0);
            var expected = CategoryFactory.GetCategory(id, iconPath: "path");

            var actual = CategoryFactory.GetCategory(id, iconPath: "Path");
            actual.ChangeIconPath("path");

            actual.IconPath.Should().Be(expected.IconPath);
        }
    }
}