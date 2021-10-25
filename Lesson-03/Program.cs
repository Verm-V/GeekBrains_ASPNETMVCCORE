using Lesson_03.Application;
using Lesson_03.Commands;
using Lesson_03.Fractals;
using Lesson_03.Output;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

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
			services.AddScoped<IOutputHandler, OutputHandler>();

			// Сервис рассчета фрактала
			services.AddScoped<IFractal, Mandelbrot>();

			// Выполнятель комманд
			services.AddScoped<IInvoker, Invoker>();

			// Логгирование
			services.AddLogging(builder =>
			{
				builder.AddNLog("nlog.config");
			});
		}
	}
}
