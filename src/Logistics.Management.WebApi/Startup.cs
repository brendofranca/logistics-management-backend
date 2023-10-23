using Logistics.Management.Data.Context;
using Logistics.Management.Data.Repositories;
using Microsoft.EntityFrameworkCore;

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
            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<RequestRepository>();

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();
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