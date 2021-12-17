using Akros.Htp.Vendor.Backend.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Akros.Htp.Vendor.Backend.Service.Registry
{
    public class BackendService : IHtpDomainService
    {
        private readonly ILogger<BackendService> _logger;

        public BackendService(ILogger<BackendService> logger)
        {
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.SetupDbContext(configuration);
            services.SetupRepositories(configuration);
            services.SetupDomainServices(configuration);
        }
    }
}
