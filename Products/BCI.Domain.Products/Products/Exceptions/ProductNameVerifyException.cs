using System;

namespace BCI.Products.Domain.Products.Exceptions
{
    public class ProductNameVerifyException : Exception
    {
        private readonly string errorCode = $"prd-{(int)ProductErrorCode.ProductNameIsNotQualify}";
        private readonly string defaultErrorMessage = "Product name is not qualify";

        public ProductNameVerifyException(string productName, string errorMessage = "", Exception innerException = null)
            : base(errorMessage, innerException)
        {
            this.defaultErrorMessage =
                string.IsNullOrWhiteSpace(errorMessage) ? this.defaultErrorMessage : errorMessage;

            this.Data.Add("Parameter", productName);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}