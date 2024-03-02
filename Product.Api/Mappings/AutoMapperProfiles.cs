using AutoMapper;
using Product.Api.DTOs;
using Product.Api.Models;

namespace Product.Api.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProductDto, Models.Product>().ReverseMap();
        CreateMap<AddProductRequestDto, Models.Product>().ReverseMap();
        CreateMap<ProductDto, Vegetables>().ReverseMap();
        CreateMap<AddProductRequestDto, Vegetables>().ReverseMap();
    }
}