using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using MediatR;
using FinalProject.Application.Queries.GetUsersList;
using FinalProject.Application.Commands.CreateUser;
using FinalProject.Application.Commands.UpdateUser;
using FinalProject.Application.Commands.DeleteUser;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProject_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetUsersListQuery());
            return Ok(response);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        [Route("{userId:int}")]
        public async Task<IActionResult> Update([FromRoute] int userId, [FromBody] UpdateUserCommand command)
        {
            command.id = userId;
            await _mediator.Send(command);
            return Ok();
        }
        [HttpDelete]
        [Route("{userId:int}")]
        public async Task<IActionResult> Delete([FromRoute] int userId)
        {
            var command = new DeleteUserCommand { id = userId };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
