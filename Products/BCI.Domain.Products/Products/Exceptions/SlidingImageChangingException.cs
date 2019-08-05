using System;
using System.Collections.Generic;
using BCI.Products.Domain.Products.Models;

namespace BCI.Products.Domain.Products.Exceptions
{
    public class SlidingImageChangingException : Exception
    {
        private readonly string errorCode = $"prd-{(int)ProductErrorCode.ThumbnailImageIsChangedFail}";
        private readonly string defaultErrorMessage = "Change sliding images fail";

        public SlidingImageChangingException(IEnumerable<ImageInfo> slidingImages,
            string errorMessage = "",
            Exception innerException = null)
            : base(errorMessage, innerException)
        {
            this.defaultErrorMessage = string.IsNullOrWhiteSpace(errorMessage) ?
                this.defaultErrorMessage : errorMessage;

            this.Data.Add("Parameter", slidingImages);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}