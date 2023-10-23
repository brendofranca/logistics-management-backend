using Logistics.Management.Application.AutoMapper;
using Logistics.Management.Application.Services.Orders;
using Logistics.Management.Data.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Logistics.Management.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // AutoMapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Data
            services.AddDataServices();

            // Services
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}