using Logistics.Management.Data.Context;
using Logistics.Management.Data.Repositories.Requests;
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
            services.AddScoped<IRequestRepository, RequestRepository>();
        }
    }
}