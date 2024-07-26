using MediatR;


namespace FinalProject.Application.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public int? CUIT { get; set; } 
        public int? rolId { get; set; } 
    }
}
