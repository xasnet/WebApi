using AutoMapper;
using WebApi.Dtos;
using WebApi.Models;

namespace WebApi.Profiles
{
    public class CustomersProfile : Profile
    {
        public CustomersProfile()
        {
            // Source -> Target
            CreateMap<Customer, CustomerReadDto>();
            CreateMap<CustomerCreateDto, Customer>();
        }
    }
}
