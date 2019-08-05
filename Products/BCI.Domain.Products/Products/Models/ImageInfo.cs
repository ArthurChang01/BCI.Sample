using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Models
{
    public class ImageInfo : ValueObject<ImageInfo>
    {
        #region Conctructor

        public ImageInfo(int order, string imgPath)
        {
            this.Order = order;
            this.ImagePath = imgPath;
        }

        #endregion Conctructor

        #region Properties`

        public int Order { get; private set; }

        public string ImagePath { get; private set; }

        #endregion Properties`

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Order;
            yield return this.ImagePath;
        }
    }
}