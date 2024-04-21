namespace WebApp.Models.Response.ProjectsPage
{
    /// <summary>
    /// Строка списка проектов при запросе на получение содержания таблицы
    /// </summary>
    public class ProjectResponse
    {
        /// <summary>
        /// Id проекта
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование проекта
        /// </summary>
        public string ProjectName { get; set; } = string.Empty;

        /// <summary>
        /// Количество мероприятий на сегодня
        /// </summary>
        public int EventCount { get; set; }
    }
}
