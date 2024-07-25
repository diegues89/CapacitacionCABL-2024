
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
            try
            {
                return await _dBContextFinalProject.Users.ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

    }
}
