using System.Collections.Generic;
using BCI.Products.Application.Products.DataContracts.ViewModels;
using BCI.Products.Domain.Products.Models;
using MediatR;

namespace BCI.Products.Application.Products.DataContracts.Commands
{
    public class AddProductCmd : IRequest<ProductVM>
    {
        public string Name { get; set; }

        public ImageInfo ThumbnailPath { get; set; }

        public IEnumerable<ImageInfo> SlidingImgPath { get; set; }

        public string Description { get; set; }

        public int TotalSalesQty { get; set; }

        public string CategoryId { get; set; }
    }
}