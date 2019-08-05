using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Orders.Domain.Orders.Models
{
    public class Product : ValueObject<Product>
    {
        #region Contructors

        public Product()
        {
            this.Id = string.Empty;
            this.Name = string.Empty;
            this.ThumbnailPath = string.Empty;
            this.Qty = 0;
            this.Price = 0;
        }

        public Product(string id, string name, string thumbnailPath, int qty, decimal price)
        {
            this.Id = id;
            this.Name = name;
            this.ThumbnailPath = thumbnailPath;
            this.Qty = qty;
            this.Price = price;
        }

        #endregion Contructors

        #region Properties

        public string Id { get; private set; }

        public string Name { get; private set; }

        public string ThumbnailPath { get; private set; }

        public int Qty { get; private set; }

        public decimal Price { get; private set; }

        #endregion Properties

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Id;
            yield return this.Name;
            yield return this.ThumbnailPath;
            yield return this.Qty;
            yield return this.Price;
        }
    }
}