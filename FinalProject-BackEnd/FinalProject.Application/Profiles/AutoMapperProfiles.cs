
using AutoMapper;
using FinalProject.Application.Models.DTOs;
using FinalProject.Applications.Models.DTOs;
using FinalProject.Domain.Entities;


namespace FinalProject.Application.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Users, UsersDTO>().ReverseMap();
            CreateMap<products, productsDTO>().ReverseMap();
            //.ForMember(x => x.Category, opt => opt.MapFrom(x => x.productCategory.descriptionCategory));
            CreateMap<Suppliers, SuppliersDTO>().ReverseMap();
        }
    }
}
