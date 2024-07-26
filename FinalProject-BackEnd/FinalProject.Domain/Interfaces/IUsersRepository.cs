using FinalProject.Domain.Entities;


namespace FinalProject.Domain.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<Users>> GetAll();
        Task<Users?> Get(int userId);
        Task Create(Users user);
        Task Update(Users user);
        Task Delete(Users userdelete);
    }
}
