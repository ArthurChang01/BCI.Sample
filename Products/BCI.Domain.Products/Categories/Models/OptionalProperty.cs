using System.Collections.Generic;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.Models
{
    public class OptionalProperty : ValueObject<OptionalProperty>
    {
        #region Constructors

        public OptionalProperty()
        {
            this.Name = string.Empty;
            this.Option = string.Empty;
        }

        public OptionalProperty(string name, string opt)
        {
            this.Name = name;
            this.Option = opt;
        }

        #endregion Constructors

        #region Properties

        public string Name { get; private set; }

        public string Option { get; private set; }

        #endregion Properties

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.Name;
            yield return this.Option;
        }
    }
}