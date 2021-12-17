using Akros.Htp.Vendor.Backend.Domain.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Akros.Htp.Vendor.Backend.Service.Registry
{
    public static class DomainServiceRegistry
    {
        public static void SetupDomainServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddScoped<IHotelService, HotelService>();
        }
    }
}
