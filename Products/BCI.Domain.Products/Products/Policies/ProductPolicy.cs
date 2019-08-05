using System;
using System.Collections.Generic;
using System.Linq;
using BCI.Products.Domain.Products.Exceptions;
using BCI.Products.Domain.Products.Models;
using BCI.Products.Domain.Products.Specifications;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Domain.Products.Policies
{
    public class ProductPolicy : IPolicy<Product>
    {
        private readonly List<Exception> exceptions = new List<Exception>();

        public bool IsSatisfy(Product product)
        {
            if (new ProductNameSpec(product.Name).IsSatisfy() == false)
                this.exceptions.Add(new ProductNameVerifyException(product.Name));

            if (new ProductQtySpec(product.Qty).IsSatisfy() == false)
                this.exceptions.Add(new ProductQtyVerifyException(product.Qty));

            if (product.ThumbnailPath != null && new ThumbnailSpec(product).IsSatisfy() == false)
                this.exceptions.Add(new ThumbnailChangingException(product.ThumbnailPath));

            if (product.SlidingImgPath.Any() && new SlidingImageSpec(product).IsSatisfy() == false)
                this.exceptions.Add(new SlidingImageChangingException(product.SlidingImgPath));

            return this.exceptions.Count == 0;
        }

        public Exception GetWrapperException => new AggregateException(this.exceptions);
    }
}