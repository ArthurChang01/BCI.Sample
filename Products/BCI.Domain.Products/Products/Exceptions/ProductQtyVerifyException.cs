using System;

namespace BCI.Products.Domain.Products.Exceptions
{
    public class ProductQtyVerifyException : Exception
    {
        private readonly string errorCode = $"prd-{(int)ProductErrorCode.ProductQtyIsNotQualify}";
        private readonly string defaultErrorMessage = "Qty can not be negative digital";

        public ProductQtyVerifyException(int productQty, string errorMessage = "", Exception innerException = null)
            : base(errorMessage, innerException)
        {
            this.defaultErrorMessage = string.IsNullOrWhiteSpace(errorMessage) ? this.defaultErrorMessage : errorMessage;

            this.Data.Add("Parameter", productQty);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}