using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.Projects;
using WebApp.UseCases.Projects.Abstract;
using WebApp.UseCases.TImeLine;
using WebApp.UseCases.TImeLine.Abstract;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширения для регистрации в DI сервисов контроллеров
    /// </summary>
    public static class AddWineUseCaseExtensions
    {
        public static void ConfigureWineUseCases(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddScoped<ITimeLineService, TimeLineService>();
            applicationBuilder.Services.AddScoped<BaseWineService>();
            applicationBuilder.Services.AddScoped<IProjectsService, ProjectsService>();
        }
    }
}
