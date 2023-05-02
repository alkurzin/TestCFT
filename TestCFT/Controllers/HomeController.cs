using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestCFT.BLL.DTO;
using TestCFT.BLL.Interfaces;
using TestCFT.Models;

namespace TestCFT.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IApplicationService _applicationService;
        private readonly IMapper _mapper;

        public HomeController(IOrderService orderService,
                              IMapper mapper,
                              IApplicationService applicationService)
        {
            _orderService = orderService;
            _applicationService = applicationService;
            _mapper = mapper;

            if (!_applicationService.GetAll().Any())
            {
                _applicationService.CreateApplication("Uber");
                _applicationService.CreateApplication("Ozon");
                _applicationService.CreateApplication("Asus");
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Обновление дизайна",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 05, 12),
                    Description = "Обновление дизайна",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Проработка доп.маршрутов",
                    ApplicationId = 1,
                    DataEnd = new DateTime(2023, 05, 23),
                    Description = "Обновить алгоритм поиска",
                    Email = "uber@uber.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Исправить баг",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 06, 11),
                    Description = "Исправить баг в корзине",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Обновление дизайна",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 05, 12),
                    Description = "Обновление дизайна",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Проработка доп.маршрутов",
                    ApplicationId = 1,
                    DataEnd = new DateTime(2023, 05, 23),
                    Description = "Обновить алгоритм поиска",
                    Email = "uber@uber.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Исправить баг",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 06, 11),
                    Description = "Исправить баг в корзине",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Обновление дизайна",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 05, 12),
                    Description = "Обновление дизайна",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Проработка доп.маршрутов",
                    ApplicationId = 1,
                    DataEnd = new DateTime(2023, 05, 23),
                    Description = "Обновить алгоритм поиска",
                    Email = "uber@uber.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Исправить баг",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 06, 11),
                    Description = "Исправить баг в корзине",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Обновление дизайна",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 05, 12),
                    Description = "Обновление дизайна",
                    Email = "ozon@ozon.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Проработка доп.маршрутов",
                    ApplicationId = 1,
                    DataEnd = new DateTime(2023, 05, 23),
                    Description = "Обновить алгоритм поиска",
                    Email = "uber@uber.com"
                });
                _orderService.CreateOrder(new OrderDto
                {
                    Name = "Исправить баг",
                    ApplicationId = 2,
                    DataEnd = new DateTime(2023, 06, 11),
                    Description = "Исправить баг в корзине",
                    Email = "ozon@ozon.com"
                });
            }
        }

        public IActionResult Index(int page = 1)
        {
            var pageSize = 10;
            var orders = _mapper.ProjectTo<OrderViewModel>(_orderService.GetAllOrders().AsQueryable());
            var pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = orders.ToList().Count };
            ViewBag.PageInfo = pageInfo;
            orders = orders.Skip((page - 1) * pageSize)
                .Take(pageSize);

            return View(orders);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var applications = _mapper.ProjectTo<ApplicationViewModel>(_applicationService.GetAll().AsQueryable());
            ViewBag.Applications = applications;
            return View();
        }

        [HttpPost]
        public IActionResult Add(OrderViewModel order)
        {
            var applications = _mapper.ProjectTo<ApplicationViewModel>(_applicationService.GetAll().AsQueryable());
            ViewBag.Applications = applications;
            var appMap = new Dictionary<string, long>();
            foreach (var app in applications)
            {
                appMap.Add(app.Name, app.Id);
            }

            if (ModelState.IsValid)
            {
                var date = DateTime.ParseExact(order.DataEnd, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                var newOrder = new OrderDto
                {
                    Name = order.Name,
                    ApplicationId = appMap[order.ApplicationName],
                    DataEnd = date,
                    Description = order.Description,
                    Email = order.Email
                };

                _orderService.CreateOrder(newOrder);

                return Redirect("~/");
            }
            else
            {
                return View(order);
            }
        }

        [HttpGet("Home/Update/{Id}")]
        public IActionResult Update(string Id)
        {
            int id = int.Parse(Id);
            var order = _mapper.Map<OrderViewModel>(_orderService.Get(id));
            var applications = _mapper.ProjectTo<ApplicationViewModel>(_applicationService.GetAll().AsQueryable());
            ViewBag.Applications = applications;
            return View(order);
        }

        [HttpPost]
        public IActionResult Update(OrderViewModel order)
        {
            var applications = _mapper.ProjectTo<ApplicationViewModel>(_applicationService.GetAll().AsQueryable());
            ViewBag.Applications = applications;
            var appMap = new Dictionary<string, long>();
            foreach (var app in applications)
            {
                appMap.Add(app.Name, app.Id);
            }

            if (ModelState.IsValid)
            {
                var date = DateTime.ParseExact(order.DataEnd, "dd.MM.yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);
                var newOrder = new OrderDto
                {
                    Id = order.Id,
                    Name = order.Name,
                    ApplicationId = appMap[order.ApplicationName],
                    DataEnd = date,
                    Description = order.Description,
                    Email = order.Email
                };

                _orderService.Update(newOrder);

                return Redirect("~/");
            }
            else
            {
                return View(order);
            }
        }


        [HttpGet]
        public IActionResult Application()
        {
            var applications = _mapper.ProjectTo<ApplicationViewModel>(_applicationService.GetAll().AsQueryable());
            ViewBag.Applications = applications;

            return View();
        }
    }
}
