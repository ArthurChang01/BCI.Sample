using System;
using BCI.Products.Domain.Categories.Models;

namespace BCI.Products.Domain.Categories.Exceptions
{
    public class CategoryInvariantException : Exception
    {
        private readonly string errorCode = $"cat-{(int)CategoryErrorCode.CategoryInvariantFail}";
        private readonly string defaultErrorMessage = "Category Invariant fail";

        public CategoryInvariantException(Category category,
            string errorMessage = "",
            Exception innerException = null)
            : base(errorMessage, innerException)
        {
            this.defaultErrorMessage =
                string.IsNullOrWhiteSpace(errorMessage) ?
                    this.defaultErrorMessage : errorMessage;

            this.Data.Add("Parameter", category);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}