using ApiShop.Dto;
using ApiShop.Model;
using AutoMapper;

namespace ApiShop.Helper
{
    public class MapingProfiles : Profile
    {
        public MapingProfiles()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.ProductCategory, opt => opt.MapFrom(src => src.ProductCategoryNavigation.NameCategory));
                          
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.UserRole,  opt => opt.MapFrom(src => src.UserRoleNavigation.RoleName));
  
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.OrderPickupPoint, opt => opt.MapFrom(src => src.OrderPickupPointNavigation.AdressPickPoint));
        }
    }
}
