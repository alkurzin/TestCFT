using Microsoft.EntityFrameworkCore;
using TestCFT.DAL.DataContext;
using TestCFT.DAL.Entities;
using TestCFT.DAL.Interfaces;

namespace TestCFT.DAL.Repositories
{
    public class ApplicationRepository : IRepository<Application>
    {
        private AppDbContext _dbContext;

        public ApplicationRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Application item)
        {
            _dbContext.Applications.Add(item);
            _dbContext.SaveChanges();
        }

        public Application Get(long id)
        {
            return _dbContext.Applications.FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Application> GetAll()
        {
            return _dbContext.Applications;
        }

        public void Update(Application item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
