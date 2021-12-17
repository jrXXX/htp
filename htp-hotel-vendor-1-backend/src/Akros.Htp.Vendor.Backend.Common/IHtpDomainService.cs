using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Akros.Htp.Vendor.Backend.Common
{
    public interface IHtpDomainService
    {
        void ConfigureServices(IServiceCollection services, IConfiguration configuration);
    }
}
