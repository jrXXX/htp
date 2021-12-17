using System;
using System.Linq;
using Akros.Htp.Vendor.Backend.DataAccess.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Akros.Htp.Vendor.Backend.Service.Registry
{
    public static class BackendServiceExtensions
    { 
        public static async void UseBackendService(this IApplicationBuilder builder, ILogger logger)
        {
            using (var scope = builder.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<HotelDbContext>();
                try
                {
                    var pendingMigrations = await context.Database.GetPendingMigrationsAsync();

                    if (pendingMigrations.Any())
                    {
                        logger.LogWarning($"You have {pendingMigrations.Count()} pending migrations to apply.");
                        logger.LogWarning("Applying pending migrations now");
                        await context.Database.MigrateAsync();
                    }

                    var lastAppliedMigration = (await context.Database.GetAppliedMigrationsAsync()).Last();

                    logger.LogInformation($"You're on schema version: {lastAppliedMigration}");
                }
                catch (Exception ex)
                {
                    logger.LogError($"Could not setup dbContext: <{ex.Message}>", ex);
                }
            }
        }
    }
}