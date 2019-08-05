using System;
using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Models
{
    public class OrderId : ValueObject<OrderId>
    {
        #region Contructors

        public OrderId()
        {
            this.No = 1;
            this.CreatedDate = DateTimeOffset.Now;
        }

        public OrderId(int no, DateTimeOffset createdDate)
        {
            if (no < 0)
                throw new ArgumentException("No can't be negative digit");

            this.No = no;
            this.CreatedDate = createdDate;
        }

        #endregion Contructors

        #region Properties

        public int No { get; private set; }

        public DateTimeOffset CreatedDate { get; private set; }

        #endregion Properties

        public override string ToString()
        {
            return $"Ord-{this.CreatedDate:yyyyMMdd}-{this.No}";
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.No;
            yield return this.CreatedDate;
        }
    }
}