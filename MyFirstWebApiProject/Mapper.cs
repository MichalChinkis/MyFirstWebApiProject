using AutoMapper;
using DTO;
using entities.Models;

namespace MyFirstWebApiProject
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<UserLoginDTO,User>().ReverseMap();
            CreateMap<User, UsersDTO>().ReverseMap();
            CreateMap<Product, ProductsDTO>()
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName)).ReverseMap();
            CreateMap<Category, CategorysDTO>().ReverseMap();
            CreateMap<Category, CategoryPostDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Order, OrdersDTO>().ReverseMap();
            CreateMap<UserRegisterDTO, User>().ReverseMap();
            CreateMap<UserRegisterDTO, UsersDTO>().ReverseMap();
            CreateMap<OrderItemPostDTO, OrderItem>().ReverseMap();
            CreateMap<ProductPostDTO, Product>().ReverseMap();
            CreateMap<Product, ProductResPostDTO>().ReverseMap();
            CreateMap<OrderPostDTO, Order>().ReverseMap();
            CreateMap<OrderItemProdIdDTO,OrderItem>().ReverseMap();
        }
    }
}