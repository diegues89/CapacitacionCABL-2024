using FinalProject.Application.Commands.CreateSupplier;
using FinalProject.Application.Commands.DeleteProduct;
using FinalProject.Application.Commands.DeleteSupplier;
using FinalProject.Application.Commands.UpdateProduct;
using FinalProject.Application.Commands.UpdateSupplier;
using FinalProject.Application.Queries.GetSupplier;
using FinalProject.Application.Queries.GetSuppliersList;
using FinalProject.Application.Queries.GetUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SuppliersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var response = await _mediator.Send(new GetSuppliersListQuery());
            return Ok(response);
        }
        [HttpGet]
        [Route("{idSupplier:int}")]
        public async Task<IActionResult> Get([FromRoute] int idSupplier)
        {
            var response = await _mediator.Send(new GetSupplierQuery { idSupplier = idSupplier });
            return Ok(response);
        }
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateSupplierCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("{idSupplier:int}")]
        public async Task<IActionResult> Update([FromRoute] int idSupplier, [FromBody] UpdateSupplierCommand command)
        {
            command.idSupplier = idSupplier;
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("{idSupplier:int}")]
        public async Task<IActionResult> Delete([FromRoute] int idSupplier)
        {
            var command = new DeleteSupplierCommand { idSupplier = idSupplier };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
