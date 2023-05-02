using Microsoft.EntityFrameworkCore;
using TestCFT.DAL.DataContext;
using TestCFT.DAL.Entities;
using TestCFT.DAL.Interfaces;

namespace TestCFT.DAL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private AppDbContext _dbContext;

        public OrderRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Order item)
        {
            _dbContext.Orders.Add(item);
            _dbContext.SaveChanges();
        }

        public Order Get(long id)
        {
            return _dbContext.Orders.Include(o => o.Application).FirstOrDefault(o => o.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _dbContext.Orders;
        }

        public void Update(Order item)
        {
            var order = _dbContext.Orders.FirstOrDefault(o => o.Id == item.Id);
            if (order != null)
            {
                order.Name = item.Name;
                order.DataEnd = item.DataEnd;
                order.Description = item.Description;
                order.Email = item.Email;
                order.ApplicationId = item.ApplicationId;
            }
            _dbContext.SaveChanges();
        }
    }
}
