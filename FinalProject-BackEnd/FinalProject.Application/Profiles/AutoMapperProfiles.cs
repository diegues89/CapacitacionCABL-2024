
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
            CreateMap<Users, UsersDTO>()
                .ForMember(x => x.RoleName, opt => opt.MapFrom(x => x.rol.descripcionRol));
            CreateMap<products, productsDTO>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.category.descriptionCategory))
                .ForMember(x => x.supplierName, opt => opt.MapFrom(x => x.suppliers.name));
            CreateMap<Suppliers, SuppliersDTO>();
            CreateMap<productCategory, productCategoryDTO>();
        }
    }
}
