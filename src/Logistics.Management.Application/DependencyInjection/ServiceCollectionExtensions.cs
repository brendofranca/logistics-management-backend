using Logistics.Management.Application.AutoMapper;
using Logistics.Management.Application.Commands.Orders;
using Logistics.Management.Application.Handlers.Orders;
using Logistics.Management.Application.Notifications;
using Logistics.Management.Application.Queries.Orders;
using Logistics.Management.Application.Responses;
using Logistics.Management.Data.DependencyInjection;
using MediatR;
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

            // Queries
            services.AddScoped<IOrderQuery, OrderQuery>();

            //Notifications
            services.AddScoped<IDomainNotification, DomainNotification>();

            // Commands
            services.AddScoped<IRequestHandler<RequestOrderCommand, bool>, RequestOrderCommandHandler>();
            services.AddScoped<IRequestHandler<CollectOrderCommand, CollectOrderResponse?>, CollectOrderCommandHandler>();
            services.AddScoped<IRequestHandler<SendOrderCommand, bool>, SendOrderCommandHandler>();
            services.AddScoped<IRequestHandler<ReceiveOrderCommand, bool>, ReceiveOrderCommandHandler>();
        }
    }
}