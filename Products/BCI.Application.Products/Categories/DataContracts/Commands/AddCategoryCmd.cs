using BCI.Products.Domain.Categories.Models;
using MediatR;

namespace BCI.Products.Application.Categories.DataContracts.Commands
{
    public class AddCategoryCmd : IRequest<Category>
    {
        public string Name { get; set; }

        public int Level { get; set; }

        public string IconPath { get; set; }
    }
}