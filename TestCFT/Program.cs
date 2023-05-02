using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TestCFT.BLL.DTO.MapperProfiles;
using TestCFT.BLL.Interfaces;
using TestCFT.BLL.Services;
using TestCFT.DAL.DataContext;
using TestCFT.DAL.Entities;
using TestCFT.DAL.Interfaces;
using TestCFT.DAL.Repositories;
using TestCFT.Models.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<Order>), typeof(OrderRepository));
builder.Services.AddScoped(typeof(IRepository<Application>), typeof(ApplicationRepository));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService)); 
builder.Services.AddScoped(typeof(IApplicationService), typeof(ApplicationService)); 

var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new OrderMapperProfile());
    mc.AddProfile(new OrderViewModelMapperProfile()); 
    mc.AddProfile(new ApplicationMapperProfile()); 
    mc.AddProfile(new ApplicationViewModelMapperProfile()); 
});
IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{page?}"
);

app.Run();
