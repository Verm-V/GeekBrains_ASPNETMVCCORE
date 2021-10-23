using NLog;
using System;

namespace Lesson_03.Application
{
	public class App
	{
		private readonly ILogger _logger;

		public App()
		{
			_logger = LogManager.GetCurrentClassLogger();
			_logger.Debug("App service constructed");
		}

		public void Run()
		{
			_logger.Info("App start");

			//Do something

			_logger.Info("App ends");

			Console.WriteLine("Press any key to exit");
			Console.ReadKey();

		}

	}
}
