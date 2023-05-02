using AutoMapper;
using TestCFT.BLL.DTO;

namespace TestCFT.Models.MapperProfiles
{
    public class ApplicationViewModelMapperProfile : Profile
    {
        public ApplicationViewModelMapperProfile()
        {
            CreateMap<ApplicationDto, ApplicationViewModel>();
        }
    }
}
