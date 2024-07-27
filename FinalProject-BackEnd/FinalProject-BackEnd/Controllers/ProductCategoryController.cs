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
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetProductCategoryListQuery());
            return Ok(response);
        }
    }
}
