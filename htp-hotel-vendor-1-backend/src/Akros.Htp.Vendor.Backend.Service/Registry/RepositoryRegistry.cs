using Akros.Htp.Vendor.Backend.DataAccess.Contract.Repository;
using Akros.Htp.Vendor.Backend.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Akros.Htp.Vendor.Backend.Service.Registry
{
    public static class RepositoryRegistry
    {
        public static void SetupRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IRoomRepository, RoomRepository>();
        }
    }
}
