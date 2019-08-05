using System.Collections.Generic;

namespace BCI.Products.Application.Products.DataContracts.ViewModels
{
    public class ProductVM
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ThumbnailPath { get; set; }

        public IEnumerable<string> SlidingImgPath { get; set; }

        public string Description { get; set; }

        public int TotalSalesQty { get; set; }

        public string CategoryId { get; set; }
    }
}