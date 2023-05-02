using AutoMapper;
using TestCFT.BLL.DTO;

namespace TestCFT.Models.MapperProfiles
{
    public class OrderViewModelMapperProfile : Profile
    {
        public OrderViewModelMapperProfile()
        {
            CreateMap<OrderDto, OrderViewModel>()
                .ForMember(t => t.DataEnd, t => t.MapFrom(x => x.DataEnd.ToShortDateString()));
        }
    }
}
