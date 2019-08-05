using System.Collections.Generic;
using System.Linq;
using BCI.Products.Application.Products.DataContracts.ViewModels;
using BCI.Products.Domain.Products.Models;
using BCI.SharedCores.Interfaces;

namespace BCI.Products.Application.Products.DomainServices
{
    public class ProductRMTranslator : ITranslator<ProductVM, Product>
    {
        public ProductVM Translate(Product input)
        {
            return new ProductVM()
            {
                Id = input.Id?.ToString() ?? string.Empty,
                Name = input.Name,
                ThumbnailPath = input.ThumbnailPath?.ImagePath ?? string.Empty,
                SlidingImgPath = input.SlidingImgPath?.OrderBy(si => si.Order).Select(si => si.ImagePath) ?? new List<string>(),
                Description = input.Description,
                TotalSalesQty = input.Qty,
                CategoryId = input.CategoryId == null ? string.Empty : $"api/Category/{input.CategoryId}",
            };
        }
    }
}