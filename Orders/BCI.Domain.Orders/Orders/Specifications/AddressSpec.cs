using BCI.Orders.Domain.Orders.Models;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Specifications
{
    internal class AddressSpec : Specification<Address>
    {
        public AddressSpec(Address address)
            : base(address, adr => string.IsNullOrWhiteSpace(adr.Country) == false && string.IsNullOrWhiteSpace(adr.City) == false)
        {
        }
    }
}