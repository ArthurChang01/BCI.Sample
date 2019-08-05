using System;
using System.Threading.Tasks;
using BCI.Products.Application.Products.DataContracts.Commands;
using BCI.Products.Application.Products.DataContracts.QueryModels;
using BCI.Products.Application.Products.DataContracts.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BCI.Products.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("{Id}")]
        [ProducesDefaultResponseType(typeof(ProductVM))]
        public async Task<ActionResult<ProductVM>> Get([FromRoute] GetProductQry mode)
        {
            var product = await this.mediator.Send(mode);
            if (product == null)
                return this.BadRequest();

            return this.Ok(product);
        }

        [HttpPost]
        [ProducesDefaultResponseType(typeof(CreatedResult))]
        public async Task<ActionResult> Post([FromBody] AddProductCmd model)
        {
            var product = await this.mediator.Send(model);
            return this.Created(new Uri($"{this.Request.GetDisplayUrl()}/api/Product/{product.Id}"), product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromRoute] string id, [FromBody] UpdProductCmd model)
        {
            await this.mediator.Send(model);

            return this.Ok();
        }
    }
}