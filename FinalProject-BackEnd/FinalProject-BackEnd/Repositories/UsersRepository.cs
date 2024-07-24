using FinalProject_BackEnd.DataBase;
using FinalProject_BackEnd.Models;
using FinalProject_BackEnd.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinalProject_BackEnd.Repositories
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
            catch (Exception e)
            {

                throw e;
            }


        }

    }
}
