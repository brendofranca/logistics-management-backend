using Logistics.Management.Data.Context;
using Logistics.Management.Data.Repositories.Avgs;
using Logistics.Management.Data.Repositories.Items;
using Logistics.Management.Data.Repositories.Locations;
using Logistics.Management.Data.Repositories.Orders;
using Logistics.Management.Data.Repositories.Status;
using Microsoft.Extensions.DependencyInjection;

namespace Logistics.Management.Data.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDataServices(this IServiceCollection services)
        {
            // Database
            services.AddDbContext<ApplicationDbContext>();

            // Repositories
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IAvgRepository, AvgRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IStatusEnumRepository, StatusEnumRepository>();
        }
    }
}