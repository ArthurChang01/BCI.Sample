using System;
using BCI.Orders.Domain.Orders.Models;

namespace BCI.Orders.Domain.Orders.Exceptions
{
    public class OrderAddressVerifyException : Exception
    {
        private readonly string errorCode = $"ord-{(int)OrderErrorCode.AddressVerifyFail}";
        private readonly string defaultErrorMessage = "Address country or city can not be empty";

        public OrderAddressVerifyException(Address address, string errorMessage = "", Exception innerException = null)
            : base(errorMessage, innerException)
        {
            this.defaultErrorMessage =
                string.IsNullOrWhiteSpace(errorMessage) ? this.defaultErrorMessage : errorMessage;

            this.Data.Add("Parameter", address);
        }

        public override string Message => $"Code:{this.errorCode}, Message:{this.defaultErrorMessage}";
    }
}