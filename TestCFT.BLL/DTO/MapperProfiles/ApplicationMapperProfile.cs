using AutoMapper;
using TestCFT.DAL.Entities;

namespace TestCFT.BLL.DTO.MapperProfiles
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<Application, ApplicationDto>();
        }
    }
}
