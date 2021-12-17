using Akros.Htp.Vendor.Backend.DataAccess.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Akros.Htp.Vendor.Backend.Service.Registry
{
    public static class DbContextRegistry
    {
        public static void SetupDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<HotelDbContext>(options =>
            {
                options.UseNpgsql(configuration["Server:DbConnection"]);
            });
        }
    }
}
