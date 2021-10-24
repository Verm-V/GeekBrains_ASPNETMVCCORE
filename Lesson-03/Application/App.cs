using Lesson_03.Fractals;
using Lesson_03.Output;
using NLog;
using System;

namespace Lesson_03.Application
{
	public class App
	{
		/// <summary>Логгер</summary>
		private readonly ILogger _logger;
		/// <summary>Хэндлер отвечающий за вывод на экран</summary>
		private readonly IOutputHandler _output;
		/// <summary>Сервис считающий фрактал</summary>
		private readonly IFractal _fractal;

		public App(IOutputHandler outputHandler, IFractal fractal)
		{
			_output = outputHandler;
			_fractal = fractal;
			_logger = LogManager.GetCurrentClassLogger();
			_logger.Debug("App service constructed");
		}

		public void Run()
		{
			_logger.Info("App start");

			//Do something
			Console.SetWindowSize(_output.Width + 1, _output.Height + 1);
			Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

			_output.DrawFrame(_output.Height - 5, 0, 5, _output.Width);
			_output.DrawFrame(0, 0, _output.Height - 4, _output.Width);
			_output.PrintMessage(_output.Height - 4, 1, "Курсорные клавиши - передвижение.");
			_output.PrintMessage(_output.Height - 3, 1, "K/L - изменение масштаба. I/O - изменение детализации.");
			_output.PrintMessage(_output.Height - 2, 1, "Пробел - возврат к начальному положению. ESQ/Q - выход.");

			_fractal.CalculateAndRenderFrame();

			bool isExit = false;
			while (!isExit)
			{
				bool isRefresh = false;//Обновлять ли экран

				Console.CursorVisible = false;
				Console.SetCursorPosition(0, _output.Height);
				ConsoleKeyInfo key = Console.ReadKey();


				switch (key.Key)
				{
					case ConsoleKey.RightArrow:
						_fractal.Move(1, 0);
						isRefresh = true;
						break;
					case ConsoleKey.LeftArrow:
						_fractal.Move(-1, 0);
						isRefresh = true;
						break;
					case ConsoleKey.UpArrow:
						_fractal.Move(0, 1);
						isRefresh = true;
						break;
					case ConsoleKey.DownArrow:
						_fractal.Move(0, -1);
						isRefresh = true;
						break;
					case ConsoleKey.Spacebar:
						_fractal.ResetState();
						isRefresh = true;
						break;

					case ConsoleKey.I:
						_fractal.ChangeDetails(-1);
						isRefresh = true;
						break;
					case ConsoleKey.O:
						_fractal.ChangeDetails(1);
						isRefresh = true;
						break;

					case ConsoleKey.K:
						_fractal.ChangeZoom(1);
						isRefresh = true;
						break;
					case ConsoleKey.L:
						_fractal.ChangeZoom(-1);
						isRefresh = true;
						break;

					case ConsoleKey.Q:
					case ConsoleKey.Escape:
						Console.Clear();
						Console.SetCursorPosition(0, 0);
						isExit = true;
						break;
				}

				if (isRefresh)
				{
					_fractal.CalculateAndRenderFrame();
					_output.RenderOutput();
					isRefresh = false;
				}
			}

			_logger.Info("App ends");

		}

	}
}
