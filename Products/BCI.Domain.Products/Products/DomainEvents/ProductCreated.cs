using System.Collections.Generic;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.DomainEvents
{
    public class ProductCreated : DomainEvent<ProductId>
    {
        public ProductCreated(ProductId id, string name,
            string desc, int totalSalesQty, CategoryId categoryId,
            ImageInfo thumbnailPath, IEnumerable<ImageInfo> slidingImgPath)
        {
            this.AggregateId = id;
            this.Name = name;
            this.Description = desc;
            this.TotalSalesQty = totalSalesQty;
            this.CategoryId = categoryId;
            this.ThumbnailPath = thumbnailPath;
            this.SlidingImgPath = slidingImgPath;
        }

        #region Properties

        public string Name { get; }

        public string Description { get; }

        public int TotalSalesQty { get; }

        public CategoryId CategoryId { get; }

        public ImageInfo ThumbnailPath { get; }

        public IEnumerable<ImageInfo> SlidingImgPath { get; }

        #endregion Properties

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.Name;
            yield return this.Description;
            yield return this.TotalSalesQty;
            yield return this.CategoryId;
            yield return this.ThumbnailPath;
            foreach (var imageInfo in this.SlidingImgPath)
            {
                yield return imageInfo;
            }
        }
    }
}