using AutoMapper;
using DTO;
using entities.Models;

namespace MyFirstWebApiProject
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<userLoginDTO,User>().ReverseMap();
            CreateMap<User, UsersDTO>();
            CreateMap<Product, ProductsDTO>();
            CreateMap<Category, CategorysDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<Order, OrdersDTO>();
        }
    }
}