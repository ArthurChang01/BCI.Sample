using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Models
{
    public class Address : ValueObject<Address>
    {
        public string Country { get; private set; }

        public string City { get; private set; }

        public string District { get; private set; }

        public string Street { get; private set; }

        public int No { get; private set; }

        public int Floor { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Country;
            yield return this.City;
            yield return this.District;
            yield return this.Street;
            yield return this.No;
            yield return this.Floor;
        }
    }
}