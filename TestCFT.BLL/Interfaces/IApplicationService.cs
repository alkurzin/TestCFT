using TestCFT.BLL.DTO;

namespace TestCFT.BLL.Interfaces
{
    public interface IApplicationService
    {
        public IEnumerable<ApplicationDto> GetAll();
        public void CreateApplication(string Name);
    }
}
