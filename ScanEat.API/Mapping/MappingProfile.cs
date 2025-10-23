using AutoMapper;
using ScanEat.Application.DTOs.Category;
using ScanEat.Application.DTOs.Product;
using ScanEat.Application.DTOs.Tenant;
using ScanEat.Domain.Entities;

namespace ScanEat.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tenant, TenantDto>().ReverseMap();

            CreateMap<Category, CategoryDto>().ReverseMap();

            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
