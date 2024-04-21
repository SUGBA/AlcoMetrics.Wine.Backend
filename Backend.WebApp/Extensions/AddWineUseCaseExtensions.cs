using WebApp.UseCases.Base.Abstract;
using WebApp.UseCases.ProjectsPage;
using WebApp.UseCases.ProjectsPage.Abstract;

namespace WebApp.Extensions
{
    /// <summary>
    /// Расширения для регистрации в DI сервисов контроллеров
    /// </summary>
    public static class AddWineUseCaseExtensions
    {
        public static void ConfigureWineUseCases(this WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddTransient<BaseWineService>();
            applicationBuilder.Services.AddTransient<IProjectsPageService, ProjectsPageService>();
        }
    }
}
