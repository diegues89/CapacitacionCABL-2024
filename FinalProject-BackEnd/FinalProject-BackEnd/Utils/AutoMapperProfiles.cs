﻿using AutoMapper;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Entities;



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
