using System;
using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.Models
{
    public class CategoryId : ValueObject<CategoryId>
    {
        #region Constructors

        public CategoryId()
        {
            this.No = 1;
            this.CreatedDate = DateTimeOffset.Now;
        }

        public CategoryId(long no, DateTimeOffset createdDate)
        {
            if (no < 0)
                throw new ArgumentException("No can't be negative digit");

            this.No = no;
            this.CreatedDate = createdDate;
        }

        #endregion Constructors

        #region Properties

        public long No { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        #endregion Properties

        public override string ToString()
        {
            return $"cat-{this.CreatedDate:yyyyMMdd}-{this.No}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.No;
            yield return this.CreatedDate;
        }
    }
}