using Project_DAW.Helpers.JwtToken;
using Project_DAW.Repositories.CustomerRepository;
using Project_DAW.Repositories.Inventory;
using Project_DAW.Repositories.InventoryRepository;
using Project_DAW.Repositories.OrderProductRepository;
using Project_DAW.Repositories.OrderRepository;
using Project_DAW.Repositories.ProductRepository;
using Project_DAW.Repositories.UnitOfWork;
using Project_DAW.Services.CustomerService;
using Project_DAW.Services.OrderProductService;
using Project_DAW.Services.OrderService;
using Project_DAW.Services.ProductService;
using Project_DAW.Services.StockService;
using System.Runtime.CompilerServices;

namespace Project_DAW.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IStockRepository, StockRepository>();
            services.AddTransient<IOrderProductRepository, OrderProductRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IStockService, StockService>();
            services.AddTransient<IOrderProductService, OrderProductService>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddScoped<IJwtUtils, JwtUtils.JwtUtils>();
            return services;
        }
    }
}
