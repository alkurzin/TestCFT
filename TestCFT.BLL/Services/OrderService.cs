using AutoMapper;
using TestCFT.BLL.DTO;
using TestCFT.BLL.Interfaces;
using TestCFT.DAL.Entities;
using TestCFT.DAL.Interfaces;

namespace TestCFT.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IRepository<Order> orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public IEnumerable<OrderDto> GetAllOrders()
        {
            return _mapper.ProjectTo<OrderDto>((IQueryable)_orderRepository.GetAll()).ToList();
        }

        public void CreateOrder(OrderDto order)
        {
            var newOrder = new Order
            {
                Name = order.Name,
                ApplicationId = order.ApplicationId,
                DataEnd = order.DataEnd,
                Description = order.Description,
                Email = order.Email
            };

            _orderRepository.Create(newOrder);
        }

        public OrderDto Get(long id)
        {
            return _mapper.Map<OrderDto>(_orderRepository.Get(id));
        }

        public void Update(OrderDto item)
        {
            var order = new Order
            {
                Id = item.Id,
                Name = item.Name,
                ApplicationId = item.ApplicationId,
                DataEnd = item.DataEnd,
                Description = item.Description,
                Email = item.Email
            };

            _orderRepository.Update(order);
        }
    }
}
