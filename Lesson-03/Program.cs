using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Lesson_03.Application;
using Lesson_03.Output;
using Lesson_03.Fractals;

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
			// Основоной сервис приложения
			services.AddTransient<App>();

			// Сервис отвечающий за вывод на экран
			services.AddSingleton<IOutputHandler, OutputHandler>();

			// Сервис рассчета фрактала
			services.AddSingleton<IFractal, Mandelbrot>();

			services.AddLogging(builder =>
			{
				builder.AddNLog("nlog.config");
			});
		}

	}
}
