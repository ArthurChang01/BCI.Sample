using System;
using System.Linq;
using BCI.Products.Domain.Products.Models;
using BCI.Products.UnitTests.Factories;
using FluentAssertions;
using NUnit.Framework;

namespace BCI.Products.UnitTests.Products
{
    public class ProductTests
    {
        [TestCase()]
        public void When_ProductId_Is_The_Same_Then_Equality_Comparison_Is_True()
        {
            DateTimeOffset now = DateTimeOffset.Now;
            var expected = new ProductId(0, now);

            var actual = new ProductId(0, now);

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void When_ProductId_Of_Product_Is_The_Same_Then_Equality_Comparison_Is_Equal()
        {
            ProductId id = ProductFactory.GetProductId(0);
            var expected = ProductFactory.GetProduct(id, "prd1");

            var actual = ProductFactory.GetProduct(id, "prd2");

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void Given_ProductQty_Is_13_When_IncreaseQty_Is_Called_And_Number_Is_10_Then_ProductQty_Is_23()
        {
            var id = ProductFactory.GetProductId(0);
            var expected = ProductFactory.GetProduct(id, qty: 23);

            var actual = ProductFactory.GetProduct(id, qty: 13);
            actual.IncreaseQty(10);

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void Given_ProductQty_Is_13_When_ReduceQty_Is_Called_And_Number_Is_7_Then_ProductQty_Is_6()
        {
            var id = ProductFactory.GetProductId(0);
            var expected = ProductFactory.GetProduct(id, qty: 6);

            var actual = ProductFactory.GetProduct(id, qty: 13);
            actual.ReduceQty(7);

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void Give_ProductThumbnailImagePath_Is_Path_When_ChangeThumbnailPath_Is_Called_Then_ProductThumbnailImage_Is_Changed_To_path()
        {
            var id = ProductFactory.GetProductId(0);
            var imgInfo = ProductFactory.GetImageInfo(1, "Path");
            var expected = ProductFactory.GetProduct(id, thumbnail: imgInfo);

            var actual = ProductFactory.GetProduct(id, thumbnail: new ImageInfo(0, "path"));
            actual.ChangeThumbnailPath(imgInfo);

            actual.ThumbnailPath.Should().Be(expected.ThumbnailPath);
        }

        [TestCase()]
        public void Give_ProductSlidingImages_Is_Path_When_ChangeSlidingImagePath_Is_Called_Then_ProductSlidingImages_Is_Changed_To_path()
        {
            var id = ProductFactory.GetProductId(0);
            var imgInfos = new ImageInfo[] { ProductFactory.GetImageInfo(1, "Path") };
            var expected = ProductFactory.GetProduct(id, slidingImages: imgInfos);

            var actual = ProductFactory.GetProduct(id, slidingImages: new[] { new ImageInfo(0, "path"), });
            actual.ChangeSlidingImagePath(imgInfos);

            actual.SlidingImgPath.First().Should().Be(expected.SlidingImgPath.First());
        }
    }
}