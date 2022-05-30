using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using MediatR;
using AA.CommoditiesDashboard.Infrastructure;
using AA.CommoditiesDashboard.Infrastructure.Mapping;
using AA.CommoditiesDashboard.ApplicationService.Mapping;
using System.Reflection;
using AA.CommoditiesDashboard.ApplicationService;
using AA.CommoditiesDashboard.Infrastructure.Repository;

namespace AA.CommoditiesDashboard.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options => options.AddPolicy("AllowSpecificOrigin", p => p.SetIsOriginAllowed(_ => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
            
            services.AddDbContext<AAContext>(
               options =>
                   options
                       .UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                       .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddTransient<IAARepository, AARepository>();
            services.AddSingleton<IApplicationDataMapper, ApplicationDataMapper>();
            services.AddSingleton<IMapper, Mapper>();

            services.RegisterRequestHandlers();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors("AllowSpecificOrigin");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
