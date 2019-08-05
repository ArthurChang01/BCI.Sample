using System.Threading.Tasks;
using BCI.Products.Application.Categories.DataContracts.Commands;
using BCI.Products.Application.Categories.DataContracts.QueryModels;
using BCI.Products.Domain.Categories.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BCI.Products.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CategoryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get([FromRoute] GetCategoryQry model)
        {
            var result = await this.mediator.Send(model);
            if (result == null)
                return this.BadRequest();

            return this.Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddCategoryCmd model)
        {
            Category category = await this.mediator.Send(model);

            return this.Ok(this.Created($"api/Category/{category.Id}", category));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] string id, [FromBody] UpdCategoryCmd model)
        {
            await this.mediator.Send(model);

            return this.Ok();
        }
    }
}