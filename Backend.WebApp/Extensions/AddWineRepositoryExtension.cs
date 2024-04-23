using Core.Actions.Abstractions.DataBaseConnector;
using DataBase.EF.ConnectionFroWine.Realizations;
using DataBase.EF.ConnectionFroWine.Repository;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширение для добавления репозиториев
    /// </summary>
    public static class AddWineRepositoryExtension
    {
        public static void AddRepository(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped(typeof(IBaseGenericRepository<>), typeof(BaseWineRepository<>));
            applicationBuilder.Services.AddScoped<IProjectPageServiceRepository, ProjectPageServiceRepository>();
        }
    }
}
