using AutoMapper;
using Product.Api.DTOs;

namespace Product.Api.Mappings;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ProductDto, Models.Product>().ReverseMap();
        CreateMap<AddProductRequestDto, Models.Product>();
    }
}