using System.Linq;
using BCI.Products.Domain.Products.Models;
using BCI.Products.UnitTests.Factories;
using FluentAssertions;
using NUnit.Framework;

namespace BCI.Products.UnitTests.Products
{
    /// <summary>
    /// Event Sourcing Tests
    /// </summary>
    public class ProductESTests
    {
        [TestCase()]
        public void When_Product_Is_Initialed_And_Apply_CreatedEvent_Then_Product_Is_Initialed()
        {
            ProductId id = ProductFactory.GetProductId(0);
            var expected = ProductFactory.GetProduct(id);
            var createdEvent = ProductFactory.GetProductCreatedEvent(id);

            var actual = new Product(createdEvent);

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void When_Product_Apply_QtyIncreasedEvent_Then_Product_Qty_Is_Increased_10()
        {
            ProductId id = ProductFactory.GetProductId(0);
            var expected = ProductFactory.GetProduct(id, qty: 21);

            var createdEvent = ProductFactory.GetProductCreatedEvent(id, qty: 11);
            var qtyIncreasedEvent = ProductFactory.GetQtyIncreasedEvent(id, 10);
            var actual = new Product(new[] { createdEvent, qtyIncreasedEvent });

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void When_Product_Apply_QtyReducedEvent_Then_Product_Qty_Is_Reduced_10()
        {
            ProductId id = ProductFactory.GetProductId(0);
            var expected = ProductFactory.GetProduct(id, qty: 1);

            var createdEvent = ProductFactory.GetProductCreatedEvent(id, qty: 11);
            var qtyIncreasedEvent = ProductFactory.GetQtyReducedEvent(id, 10);
            var actual = new Product(new[] { createdEvent, qtyIncreasedEvent });

            actual.Should().Be(expected);
        }

        [TestCase()]
        public void When_Product_Apply_ThumbnailChangedEvent_Then_ProductThumbnailImage_Is_Changed()
        {
            ProductId id = ProductFactory.GetProductId(0);
            var imgInfo = ProductFactory.GetImageInfo();
            var expected = ProductFactory.GetProduct(id, thumbnail: imgInfo);

            var createdEvent = ProductFactory.GetProductCreatedEvent(id);
            var thumbnailChangedEvent = ProductFactory.GetThumbnailChangedEvent(id, imgInfo);

            var actual = new Product(new[] { createdEvent, thumbnailChangedEvent });

            actual.Should().Be(expected);
            actual.ThumbnailPath.Should().Be(expected.ThumbnailPath);
        }

        [TestCase()]
        public void When_Product_Apply_SlidingImageEvent_Then_ProductSlidingImage_Is_Changed()
        {
            ProductId id = ProductFactory.GetProductId(0);
            var imgInfo = ProductFactory.GetImageInfo();
            var expected = ProductFactory.GetProduct(id, slidingImages: new[] { imgInfo });

            var createdEvent = ProductFactory.GetProductCreatedEvent(id);
            var slidingImageChangedEvent = ProductFactory.GetSlidingImageChangedEvent(id, new[] { imgInfo });

            var actual = new Product(new[] { createdEvent, slidingImageChangedEvent });

            actual.Should().Be(expected);
            actual.SlidingImgPath.Count().Should().Be(expected.SlidingImgPath.Count());
            actual.SlidingImgPath.First().Should().Be(expected.SlidingImgPath.First());
        }
    }
}