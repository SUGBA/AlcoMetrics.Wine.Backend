using Core.Actions.Abstractions.DataBaseConnector;
using DataBase.EF.ConnectionForWine.Realizations;
using DataBase.EF.ConnectionForWine.Repository;

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
            applicationBuilder.Services.AddScoped<ITimeLineServiceRepository, TimeLineServiceRepository>();
            applicationBuilder.Services.AddScoped<IProjectServiceRepository, ProjectServiceRepository>();
            applicationBuilder.Services.AddScoped<ITimeLineDayServiceRepository, TimeLineDayServiceRepository>();
        }
    }
}
