

using FinalProject.Applications.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Queries.GetUsersList
{
    public class GetUsersListResponse
    {
        public List<UsersDTO> UserList { get; set; } = [];
    }
}
