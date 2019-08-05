using System.Collections.Generic;
using System.Linq;
using BCI.SharedCores.BaseClasses;

namespace BCI.Products.Domain.Categories.Models
{
    public class CategoryProperty : ValueObject<CategoryProperty>
    {
        #region Constructors

        public CategoryProperty()
        {
            this.DisplayName = string.Empty;
            this.BackOfficeName = string.Empty;
            this.Description = string.Empty;
            this.OptionalProperties = new List<OptionalProperty>();
        }

        public CategoryProperty(string displayName, string boName, string desc, IEnumerable<OptionalProperty> optProperties)
        {
            this.DisplayName = displayName;
            this.BackOfficeName = boName;
            this.Description = desc;
            this.OptionalProperties = optProperties.ToList();
        }

        #endregion Constructors

        #region Properties

        public string DisplayName { get; private set; }

        public string BackOfficeName { get; private set; }

        public string Description { get; private set; }

        public ICollection<OptionalProperty> OptionalProperties { get; private set; }

        #endregion Properties

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return this.DisplayName;
            yield return this.BackOfficeName;
            yield return this.Description;
            foreach (var optionalProperty in this.OptionalProperties)
            {
                yield return optionalProperty;
            }
        }
    }
}