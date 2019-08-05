using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BCI.Infrastructures;
using BCI.Products.Application.Categories.DataContracts.Commands;
using BCI.Products.Domain.Categories.DomainEvents;
using BCI.Products.Domain.Categories.Interfaces;
using BCI.Products.Domain.Categories.Models;
using MediatR;

namespace BCI.Products.Application.Categories.ApplicationServices
{
    public class AddCategoryService : IRequestHandler<AddCategoryCmd, Category>
    {
        private readonly ICategoryRepository repository;
        private readonly IMediator mediator;

        public AddCategoryService(ICategoryRepository repository, IMediator mediator)
        {
            this.repository = repository;
            this.mediator = mediator;
        }

        public async Task<Category> Handle(AddCategoryCmd request, CancellationToken cancellationToken)
        {
            CategoryId categoryId = this.repository.GenerateCategoryId();

            Category category = Category.CreateCategory(categoryId, request.Name, request.Level, request.IconPath);
            var @event = category.DomainEvents.First(o => o is CategoryCreated) as CategoryCreated;
            this.repository.Save(category, @event);

            NotificationBase<CategoryCreated> createdNotification = new NotificationBase<CategoryCreated>(@event);
            await this.mediator.Publish(createdNotification, cancellationToken);

            return await Task.FromResult(category);
        }
    }
}