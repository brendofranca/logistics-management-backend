using Logistics.Management.Application.DependencyInjection;
using System.Reflection;

namespace Logistics.Management.WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _environment;
        public IConfiguration Configuration { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            _environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(delegate (IEndpointRouteBuilder endpoints)
            {
                endpoints.MapControllers();
            });
        }
    }
}