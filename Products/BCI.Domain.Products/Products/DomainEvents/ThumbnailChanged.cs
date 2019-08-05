using System.Collections.Generic;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.DomainEvents
{
    public class ThumbnailChanged : DomainEvent<ProductId>
    {
        public ThumbnailChanged(ProductId id, ImageInfo newImagePath)
        {
            this.AggregateId = id;
            this.ImagePath = newImagePath;
        }

        #region Properties

        public ImageInfo ImagePath { get; }

        #endregion Properties

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            yield return this.ImagePath;
        }
    }
}