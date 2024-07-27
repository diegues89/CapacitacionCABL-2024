using FinalProject.Application.Commands.CreateProduct;
using FinalProject.Application.Commands.CreateUser;
using FinalProject.Application.Commands.DeleteProduct;
using FinalProject.Application.Commands.DeleteUser;
using FinalProject.Application.Commands.UpdateProduct;
using FinalProject.Application.Commands.UpdateUser;
using FinalProject.Application.Queries.GetProductsList;
using FinalProject.Application.Queries.GetUsersList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetProductsListQuery());
            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("{idProduct:int}")]
        public async Task<IActionResult> Update([FromRoute] int idProduct, [FromBody] UpdateProductCommand command)
        {
            command.idProduct = idProduct;
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("{idProduct:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idProduct)
        {
            var command = new DeleteProductCommand { idProduct = idProduct };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
