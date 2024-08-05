
using FinalProject.Domain.Entities;
using FinalProject.Domain.Interfaces;
using FinalProject.Infraestructure.Database;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Repositories
{
    public class UsersRepository: IUsersRepository
    {
        private readonly DBContextFinalProject _dBContextFinalProject;

        public UsersRepository(DBContextFinalProject dBContextFinalProject)
        {
            _dBContextFinalProject = dBContextFinalProject;
        }
        public async Task<IEnumerable<Users>> GetAll()
        {
            //try
            //{
            //    return await _dBContextFinalProject.Users.ToListAsync();
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}
            return await _dBContextFinalProject
            .Set<Users>()
            .Include(x => x.rol)
            .ToListAsync();
        }
        public async Task<Users?> Get(int userId)
        {
            return await _dBContextFinalProject
                .Set<Users>()
                .Where(user => user.id == userId)
                .FirstOrDefaultAsync();
        }
        public async Task Create(Users user)
        {
            _dBContextFinalProject.Add(user);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Update(Users user)
        {
            _dBContextFinalProject.Update(user);
            await _dBContextFinalProject.SaveChangesAsync();
        }
        public async Task Delete(Users userdelete)
        {
            _dBContextFinalProject.Remove(userdelete);
            await _dBContextFinalProject.SaveChangesAsync();
        }

    }
}
