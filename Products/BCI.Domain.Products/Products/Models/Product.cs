using System;
using System.Collections.Generic;
using System.Linq;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.Domain.Products.DomainEvents;
using BCI.Products.Domain.Products.Exceptions;
using BCI.Products.Domain.Products.Policies;
using BCI.Products.Domain.Products.Specifications;
using BCI.SharedCores.BaseClasses;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Domain.Products.Models
{
    public class Product : AggregateRoot<ProductId>
    {
        private readonly List<ImageInfo> slidingImagePath = new List<ImageInfo>();

        #region Constructors

        public Product()
        {
            this.SlidingImgPath = this.slidingImagePath;
        }

        public Product(params IDomainEvent[] events)
        {
            foreach (var @event in events)
            {
                this.When((dynamic)@event);
            }
        }

        private Product(ProductId id, string name,
            string desc, int totalSalesQty, CategoryId categoryId,
            ImageInfo thumbnailPath, IEnumerable<ImageInfo> slidingImgPath)
        {
            this.Id = id;
            this.Name = name;
            this.Description = desc;
            this.Qty = totalSalesQty;
            this.CategoryId = categoryId;
            this.ThumbnailPath = thumbnailPath;
            this.SlidingImgPath = slidingImgPath?.ToList() ?? this.slidingImagePath;

            this.ApplyEvent(new ProductCreated(this.Id, this.Name,
                this.Description, this.Qty, this.CategoryId,
                this.ThumbnailPath, this.SlidingImgPath));
        }

        #endregion Constructors

        #region Properties

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int Qty { get; private set; }

        public CategoryId CategoryId { get; private set; }

        public ImageInfo ThumbnailPath { get; private set; }

        public IReadOnlyList<ImageInfo> SlidingImgPath { get; private set; }

        #endregion Properties

        #region Public methods

        public static Product CreateProduct(ProductId id, string name,
            string desc, int totalSalesQty, CategoryId categoryId,
            ImageInfo thumbnailPath, IEnumerable<ImageInfo> slidingImgPath)
        {
            var product = new Product(id, name, desc, totalSalesQty, categoryId, thumbnailPath, slidingImgPath);
            var policy = new ProductPolicy();
            if (policy.IsSatisfy(product) == false)
                throw policy.GetWrapperException;

            return product;
        }

        public void IncreaseQty(int number)
        {
            this.Qty += number;

            this.ApplyEvent(new QtyIncreased(this.Id, this.Qty));
        }

        public void ReduceQty(int number)
        {
            this.Qty -= number;
            if (new ProductQtySpec(this.Qty).IsSatisfy() == false)
                throw new Exception();

            this.ApplyEvent(new QtyReduced(this.Id, this.Qty));
        }

        public void ChangeThumbnailPath(ImageInfo newPath)
        {
            this.ThumbnailPath = newPath;
            if (new ThumbnailSpec(this).IsSatisfy() == false)
                throw new ThumbnailChangingException(newPath);

            this.ApplyEvent(new ThumbnailChanged(this.Id, newPath));
        }

        public void ChangeSlidingImagePath(IEnumerable<ImageInfo> imgPath)
        {
            this.SlidingImgPath = imgPath?.ToList() ?? new List<ImageInfo>();
            if (new SlidingImageSpec(this).IsSatisfy() == false)
                throw new SlidingImageChangingException(imgPath);

            this.ApplyEvent(new SlidingImageChanged(this.Id, imgPath));
        }

        #endregion Public methods

        #region Event Applying methods

        private void When(ProductCreated @event)
        {
            this.Id = @event.AggregateId;
            this.Name = @event.Name;
            this.Description = @event.Description;
            this.Qty = @event.TotalSalesQty;
            this.CategoryId = @event.CategoryId;
            this.ThumbnailPath = @event.ThumbnailPath;
            this.SlidingImgPath = @event.SlidingImgPath?.ToList() ?? new List<ImageInfo>();
        }

        private void When(QtyIncreased @event)
        {
            this.Qty = @event.Qty;
        }

        private void When(QtyReduced @event)
        {
            this.Qty = @event.Qty;
        }

        private void When(ThumbnailChanged @event)
        {
            this.ThumbnailPath = @event.ImagePath;
        }

        private void When(SlidingImageChanged @event)
        {
            this.SlidingImgPath = @event.SlidingImagePath?.ToList() ?? new List<ImageInfo>();
        }

        #endregion Event Applying methods
    }
}