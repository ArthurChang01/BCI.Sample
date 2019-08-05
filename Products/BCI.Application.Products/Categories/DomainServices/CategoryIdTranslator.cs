using System;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Application.Categories.DomainServices
{
    public class CategoryIdTranslator : ITranslator<CategoryId, string>
    {
        public CategoryId Translate(string input)
        {
            string[] idString = input.Split("-");
            idString[1] = idString[1].Insert(4, "/").Insert(7, "/");
            return new CategoryId(int.Parse(idString[2]), DateTimeOffset.Parse(idString[1]));
        }
    }
}