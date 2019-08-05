using System;
using System.Collections.Generic;
using BCI.Products.Domain.Categories.Exceptions;
using BCI.Products.Domain.Categories.Models;
using BCI.Products.Domain.Categories.Specifications;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Domain.Categories.Policies
{
    public class CategoryPolicy : IPolicy<Category>
    {
        private readonly List<Exception> exceptions = new List<Exception>();

        public bool IsSatisfy(Category aggregateRoot)
        {
            if (new CategoryInvariantSpec(aggregateRoot).IsSatisfy() == false)
            {
                this.exceptions.Add(new CategoryInvariantException(aggregateRoot));
                return false;
            }

            return true;
        }

        public Exception GetWrapperException => new AggregateException(this.exceptions);
    }
}