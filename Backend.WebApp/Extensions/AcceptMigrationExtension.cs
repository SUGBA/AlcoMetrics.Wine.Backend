using DataBase.EF.ConnectionForWine.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширение для принятия миграций
    /// </summary>
    public static class AcceptMigrationExtension
    {
        /// <summary>
        /// Принять миграции
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public static void AcceptMigration(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var dbService = scope.ServiceProvider.GetRequiredService<WineDbContext>();

                if (dbService.Database.GetPendingMigrations().Any())
                    dbService.Database.Migrate();
            }
        }
    }
}
