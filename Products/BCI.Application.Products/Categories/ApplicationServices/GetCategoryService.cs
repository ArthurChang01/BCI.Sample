using System.Threading;
using System.Threading.Tasks;
using BCI.Products.Application.Categories.DataContracts.QueryModels;
using BCI.Products.Application.Categories.DataContracts.ViewModels;
using BCI.Products.Domain.Categories.Interfaces;
using BCI.Products.Domain.Categories.Models;
using BCI.SharedCores.Interfaces;
using MediatR;

namespace BCI.Products.Application.Categories.ApplicationServices
{
    public class GetCategoryService : IRequestHandler<GetCategoryQry, CategoryRM>
    {
        private readonly ITranslator<CategoryId, string> idTranslator;
        private readonly ITranslator<CategoryRM, Category> rmTranslator;
        private readonly ICategoryRepository repository;

        public GetCategoryService(ITranslator<CategoryId, string> idTranslator, ITranslator<CategoryRM, Category> rmTranslator, ICategoryRepository repository)
        {
            this.idTranslator = idTranslator;
            this.rmTranslator = rmTranslator;
            this.repository = repository;
        }

        public async Task<CategoryRM> Handle(GetCategoryQry request, CancellationToken cancellationToken)
        {
            CategoryId categoryId = idTranslator.Translate(request.Id);
            Category category = this.repository.GetBy(categoryId);
            if (category == null)
                return null;

            CategoryRM rm = this.rmTranslator.Translate(category);

            return await Task.FromResult(rm);
        }
    }
}