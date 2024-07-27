using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Entities;



namespace FinalProject_BackEnd.Utils
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<products, productsDTO>().ReverseMap();
            CreateMap<Suppliers, SuppliersDTO>().ReverseMap();
            CreateMap<productCategory, productCategoryDTO>().ReverseMap();
        }
    }
}
