using TestCFT.BLL.DTO;

namespace TestCFT.BLL.Interfaces
{
    public interface IOrderService
    {
        public IEnumerable<OrderDto> GetAllOrders();
        public void CreateOrder(OrderDto order);
        public OrderDto Get(long id);
        public void Update(OrderDto item);
    }
}
