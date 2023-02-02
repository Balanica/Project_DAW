using AutoMapper;
using Project_DAW.Models;
using Project_DAW.Models.DTOs;

namespace Project_DAW.Helpers
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Customer, CustomerDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Stock, StockDTO>();
            CreateMap<OrderProduct, OrderProductDTO>();
            CreateMap<CustomerDTO, Customer>();
            CreateMap<OrderDTO, Order>();
            CreateMap<ProductDTO, Product>();
            CreateMap<StockDTO, Stock>();
            CreateMap<OrderProductDTO, OrderProduct>();
            CreateMap<Customer, CustomerRequestDTO>();
            CreateMap<CustomerRequestDTO, Customer>();
            CreateMap<Customer, CustomerResponseDTO>();
            CreateMap<CustomerResponseDTO, Customer>();
        }
    }
}
