using AutoMapper;
using FinalProject_BackEnd.Models;
using FinalProject_BackEnd.Models.DTOs;

namespace FinalProject_BackEnd.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
        }
    }
}
