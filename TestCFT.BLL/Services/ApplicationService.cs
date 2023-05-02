using AutoMapper;
using TestCFT.BLL.DTO;
using TestCFT.BLL.Interfaces;
using TestCFT.DAL.Entities;
using TestCFT.DAL.Interfaces;
using TestCFT.DAL.Repositories;

namespace TestCFT.BLL.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly IRepository<Application> _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationService(IRepository<Application> applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        public IEnumerable<ApplicationDto> GetAll()
        {
            return _mapper.ProjectTo<ApplicationDto>((IQueryable)_applicationRepository.GetAll()).ToList();
        }

        public void CreateApplication(string Name)
        {
            var application = new Application
            {
                Name = Name
            };

            _applicationRepository.Create(application);
        }
    }
}
