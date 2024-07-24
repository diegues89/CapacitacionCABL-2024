using FinalProject_BackEnd.Models;

namespace FinalProject_BackEnd.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAll();
    }
}
