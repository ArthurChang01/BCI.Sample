using System;
using System.Collections.Generic;
using System.Linq;
using BCI.Products.Domain.Products.Exceptions;
using BCI.Products.Domain.Products.Models;
using BCI.Products.UnitTests.Factories;
using FluentAssertions;
using NUnit.Framework;

namespace BCI.Products.UnitTests.Products
{
    public class ProductVerifyTests
    {
        [TestCase()]
        public void When_Product_Is_Creating_And_Name_Is_NullOrEmpty_Then_Product_Creating_Is_Fail()
        {
            Action act = () => ProductFactory.GetProduct(name: "");

            var isContained = act.Should().Throw<AggregateException>().And.InnerExceptions.Select(o => o.GetType())
                .Contains(typeof(ProductNameVerifyException));
            isContained.Should().BeTrue();
        }

        [TestCase()]
        public void When_Product_Is_Creating_And_TotalSalesQty_Is_Negative_Digit_Then_Product_Creating_Is_Fail()
        {
            Action act = () => ProductFactory.GetProduct(qty: -1);

            var isContained = act.Should().Throw<AggregateException>().And.InnerExceptions.Select(o => o.GetType())
                .Contains(typeof(ProductQtyVerifyException));
            isContained.Should().BeTrue();
        }

        [TestCase()]
        public void When_Product_Is_Creating_And_ThumbnailImagePath_Is_Empty_Then_Product_Creating_Is_Fail()
        {
            ImageInfo thumbnail = new ImageInfo(0, "");

            Action act = () => ProductFactory.GetProduct(thumbnail: thumbnail);

            var isContained = act.Should().Throw<AggregateException>().And.InnerExceptions.Select(o => o.GetType())
                .Contains(typeof(ThumbnailChangingException));
            isContained.Should().BeTrue();
        }

        [TestCase()]
        public void When_Product_Is_Creating_And_SlidingImagePath_Is_Empty_Then_Product_Creating_Is_Fail()
        {
            IEnumerable<ImageInfo> slidingImages = new List<ImageInfo>()
            {
               ProductFactory.GetImageInfo(path:"")
            };

            Action act = () => ProductFactory.GetProduct(slidingImages: slidingImages);

            var isContained = act.Should().Throw<AggregateException>().And.InnerExceptions.Select(o => o.GetType())
                .Contains(typeof(SlidingImageChangingException));
            isContained.Should().BeTrue();
        }

        [TestCase()]
        public void When_Product_Is_Creating_And_SlidingImage_Order_Is_Duplicated_Then_Product_Creating_Is_Fail()
        {
            IEnumerable<ImageInfo> slidingImages = new List<ImageInfo>()
            {
                ProductFactory.GetImageInfo(0), ProductFactory.GetImageInfo(0)
            };

            Action act = () => ProductFactory.GetProduct(slidingImages: slidingImages);

            var isContained = act.Should().Throw<AggregateException>().And.InnerExceptions.Select(o => o.GetType())
                .Contains(typeof(SlidingImageChangingException));
            isContained.Should().BeTrue();
        }
    }
}