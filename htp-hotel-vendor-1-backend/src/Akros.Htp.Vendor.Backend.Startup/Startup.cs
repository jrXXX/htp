using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using Akros.Htp.Vendor.Backend.Common;
using Akros.Htp.Vendor.Backend.Domain.Model.Configuration;
using Akros.Htp.Vendor.Backend.Domain.Service;
using Akros.Htp.Vendor.Backend.Service.Registry;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

namespace Akros.Htp.Vendor.Backend.Startup
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();

            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHtpDomainService, BackendService>();

            var provider = services.BuildServiceProvider();
            var dependency = provider.GetRequiredService<IHtpDomainService>();
            dependency.ConfigureServices(services, Configuration);
            
            services.AddSwaggerGenNewtonsoftSupport();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Vendor.Backend.Startup", Version = "v1" });
                c.EnableAnnotations();
                c.CustomSchemaIds(x => x.GetCustomAttributes<DisplayNameAttribute>().SingleOrDefault()?.DisplayName ?? x.Name);
            });

            // Add config object so it can be injected
            services.Configure<BackendConfiguration>(Configuration.GetSection("BackendConfiguration"));
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptionsMonitor<BackendConfiguration>>().CurrentValue);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            logger.LogInformation("Startup.Configure");

            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vendor.Backend.Startup v1"));

            app.UseBackendService(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            BackendConfigurationHelper.Services = app.ApplicationServices;
        }
    }
}
