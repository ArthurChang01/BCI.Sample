using System;
using BCI.Products.Domain.Products.Models;

namespace BCI.Products.Domain.Products.Exceptions
{
    public class ThumbnailChangingException : Exception
    {
        private readonly string errorCode = $"prd-{(int)ProductErrorCode.SlidingImagesAreChangedFail}";
        private readonly string defaultErrorMessage = "Change Thumbnail fail";

        public ThumbnailChangingException(ImageInfo thumbnailPath,
            string errorMsg = "",
            Exception innerException = null)
            : base(errorMsg, innerException)
        {
            this.defaultErrorMessage = string.IsNullOrWhiteSpace(errorMsg) ?
                this.defaultErrorMessage : errorMsg;

            base.Data.Add("Parameter", thumbnailPath);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}