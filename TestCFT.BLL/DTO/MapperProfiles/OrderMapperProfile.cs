using AutoMapper;
using TestCFT.DAL.Entities;

namespace TestCFT.BLL.DTO.MapperProfiles
{
    public class OrderMapperProfile : Profile
    {
        public OrderMapperProfile()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(t => t.ApplicationName, t => t.MapFrom(x => x.Application.Name));
        }
    }
}
