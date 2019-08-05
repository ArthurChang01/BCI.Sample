using BCI.Products.Application.Categories.DataContracts.ViewModels;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Application.Categories.DomainServices
{
    public class CategoryRMTranslator : ITranslator<CategoryRM, Category>
    {
        public CategoryRM Translate(Category input)
        {
            return new CategoryRM()
            {
                Name = input.Name,
                Level = input.Level,
                IconPath = input.IconPath
            };
        }
    }
}