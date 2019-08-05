using System;
using System.Collections.Generic;
using BCI.Products.Domain.Products.DomainEvents;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.UnitTests.Factories
{
    internal static class ProductFactory
    {
        public static ProductId GetProductId(long seqNo)
        {
            return new ProductId(seqNo, DateTimeOffset.Now);
        }

        public static Product GetProduct(ProductId id = null, string name = "name", int qty = 0, ImageInfo thumbnail = null,
            IEnumerable<ImageInfo> slidingImages = null)
        {
            id = id ?? GetProductId(0);
            return Product.CreateProduct(id, name, "desc", qty, categoryId: null, thumbnail, slidingImages);
        }

        public static ImageInfo GetImageInfo(int order = 0, string path = "path")
        {
            return new ImageInfo(order, path);
        }

        public static IDomainEvent GetProductCreatedEvent(ProductId id = null, string name = "name", int qty = 0, ImageInfo thumbnail = null,
            IEnumerable<ImageInfo> slidingImages = null)
        {
            id = id ?? GetProductId(0);
            return new ProductCreated(id, name, "desc", qty, null, thumbnail, slidingImages);
        }

        public static IDomainEvent GetQtyIncreasedEvent(ProductId id = null, int qty = 0)
        {
            id = id ?? GetProductId(0);
            return new QtyIncreased(id, qty);
        }

        public static IDomainEvent GetQtyReducedEvent(ProductId id = null, int qty = 0)
        {
            id = id ?? GetProductId(0);
            return new QtyReduced(id, qty);
        }

        public static IDomainEvent GetThumbnailChangedEvent(ProductId id = null, ImageInfo imgInfo = null)
        {
            id = id ?? GetProductId(0);
            return new ThumbnailChanged(id, imgInfo);
        }

        public static IDomainEvent GetSlidingImageChangedEvent(ProductId id = null, IEnumerable<ImageInfo> imageInfos = null)
        {
            id = id ?? GetProductId(0);
            return new SlidingImageChanged(id, imageInfos);
        }
    }
}