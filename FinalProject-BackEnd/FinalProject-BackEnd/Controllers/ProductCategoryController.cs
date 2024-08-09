using FinalProject.Application.Commands.CreateProduct;
using FinalProject.Application.Commands.CreateProductCategory;
using FinalProject.Application.Commands.DeleteProduct;
using FinalProject.Application.Commands.DeleteProductCategory;
using FinalProject.Application.Commands.UpdateProduct;
using FinalProject.Application.Commands.UpdateProductCategory;
using FinalProject.Application.Queries.GetProduct;
using FinalProject.Application.Queries.GetProductCategory;
using FinalProject.Application.Queries.GetProductCategoryList;
using FinalProject.Application.Queries.GetProductsList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetProductCategoryListQuery());
            return Ok(response);
        }
        [HttpGet]
        [Route("{idCategory:int}")]
        public async Task<IActionResult> Get([FromRoute] int idCategory)
        {
            var response = await _mediator.Send(new GetProductCategoryQuery { idCategory = idCategory });
            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateProductCategoryCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("{idCategory:int}")]
        public async Task<IActionResult> Update([FromRoute] int idCategory, [FromBody] UpdateProductCategoryCommand command)
        {
            command.idCategory = idCategory;
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("{idCategory:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idCategory)
        {
            var command = new DeleteProductCategoryCommand { idCategory = idCategory };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
