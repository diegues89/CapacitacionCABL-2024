using FinalProject.Domain.Entities;


namespace FinalProject.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAll();
    }
}
