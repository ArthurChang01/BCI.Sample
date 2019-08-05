using System.Collections.Generic;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.DomainEvents
{
    public class SlidingImageChanged : DomainEvent<ProductId>
    {
        public SlidingImageChanged(ProductId id, IEnumerable<ImageInfo> newSlidingImagePath)
        {
            this.AggregateId = id;
            this.SlidingImagePath = newSlidingImagePath;
        }

        #region Properties

        public IEnumerable<ImageInfo> SlidingImagePath { get; }

        #endregion Properties

        protected override IEnumerable<object> GetDerivedEventEqualityComponents()
        {
            foreach (var imageInfo in this.SlidingImagePath)
            {
                yield return imageInfo;
            }
        }
    }
}