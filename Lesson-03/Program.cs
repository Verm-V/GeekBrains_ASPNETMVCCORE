using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Lesson_03.Application;

namespace Lesson_03
{
	class Program
	{
		static void Main(string[] args)
		{
			{
				// Создаем сервисы и конфигурируем их
				var services = new ServiceCollection();
				ConfigureServices(services);

				// Запуск приложения
				using (ServiceProvider serviceProvider = services.BuildServiceProvider())
				{
					App app = serviceProvider.GetService<App>();
					app.Run();
				}

			}
		}

		/// <summary>
		/// Конфигурирует сервисы
		/// </summary>
		/// <param name="services">ServiceCollection</param>
		private static void ConfigureServices(ServiceCollection services)
		{
			services.AddTransient<App>();

			// Клиенты для запросов к Агентам метрик

			services.AddLogging(builder =>
			{
				builder.AddNLog("nlog.config");
			});
		}

	}
}
