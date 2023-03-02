using AutoMapper;
using JustEnough.Dto;
using JustEnough.Models;

namespace JustEnough.Helper
{
    public class ModelMap : Profile
    {
        public ModelMap()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Product, ProductDto>();
            CreateMap<Purchase, PurchaseDto>();

            CreateMap<CustomerDto, Customer>();
            CreateMap<ProductDto, Product>();
            CreateMap<PurchaseDto, Purchase>();
        }
    }
}