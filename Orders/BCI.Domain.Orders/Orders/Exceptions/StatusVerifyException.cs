using System;
using BCI.Orders.Domain.Orders.Models;

namespace BCI.Orders.Domain.Orders.Exceptions
{
    public class StatusVerifyException : Exception
    {
        private readonly string errorCode = $"ord-{(int)OrderErrorCode.StatusVerifyFail}";
        private readonly string defaultErrorMessage = "Order status should follow rule";

        public StatusVerifyException(OrderStatus status, string errorMessage = "", Exception innerException = null)
            : base(errorMessage, innerException)
        {
            this.defaultErrorMessage =
                string.IsNullOrWhiteSpace(defaultErrorMessage) ? this.defaultErrorMessage : errorMessage;

            this.Data.Add("Parameter", status);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}