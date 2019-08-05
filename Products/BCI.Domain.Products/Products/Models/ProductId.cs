using System;
using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Products.Models
{
    public class ProductId : ValueObject<ProductId>
    {
        public ProductId()
        {
            this.No = 1;
            this.CreatedDate = DateTimeOffset.Now;
        }

        public ProductId(long no, DateTimeOffset createdDate)
        {
            if (no < 0)
                throw new ArgumentException("No can't be negative digit");

            this.No = no;
            this.CreatedDate = createdDate;
        }

        public long No { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        public override string ToString()
        {
            return $"Prd-{this.CreatedDate:yyyyMMdd}-{this.No}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.No;
            yield return this.CreatedDate;
        }
    }
}