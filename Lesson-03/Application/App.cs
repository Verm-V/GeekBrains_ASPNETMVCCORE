using Lesson_03.Commands;
using Lesson_03.Fractals;
using Lesson_03.Output;
using NLog;
using System;
using System.Numerics;

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
		/// <summary>Выполнятель комманд</summary>
		private readonly IInvoker _invoker;

		public App(IOutputHandler outputHandler, IFractal fractal, IInvoker invoker)
		{
			_output = outputHandler;
			_fractal = fractal;
			_invoker = invoker;
			_logger = LogManager.GetCurrentClassLogger();
			_logger.Debug("App service constructed");
		}

		public void Run()
		{
			_logger.Info("App start");

			// Инициализация
			PrepareConsoleWindow();
			PrepareInterface();
			Console.CursorVisible = false;

			// Основной рабочий цикл
			bool isExit = false;
			while (!isExit)
			{
				isExit = InputHandler();
			}

			// Завершение работы
			Console.Clear();
			Console.CursorVisible = true;
			Console.SetCursorPosition(0, 0);

			_logger.Info("App ends");
		}


		/// <summary>
		/// Установка размеров окна программы по необхохдимости
		/// </summary>
		private void PrepareConsoleWindow()
		{
			int width = Console.WindowWidth > _output.Width ? Console.WindowWidth : _output.Width + 1;
			int height = Console.WindowHeight > _output.Height ? Console.WindowHeight : _output.Height + 1;

			Console.SetWindowSize(width, height);
			Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);

		}

		/// <summary>
		/// Подготовка к работе программы
		/// Вывод интерфейса на экран
		/// </summary>
		private void PrepareInterface()
		{
			_output.DrawBox(0, 0, _output.Height - 6, _output.Width);
			_output.DrawBox(_output.Height - 6, 0, 6, _output.Width);
			_output.PrintMessage(_output.Height - 5, 1, "Курсорные клавиши - передвижение. K/L - изменение масштаба.");
			_output.PrintMessage(_output.Height - 4, 1, "I/O - изменение детализации. R - возврат к начальному положению. ");
			_output.PrintMessage(_output.Height - 3, 1, "Пробел - отмена последней комманды. ESQ/Q - выход.");

			_invoker.Execute(new CommandReset(_fractal));
			_invoker.Reset();
			_output.RenderOutput();
		}

		/// <summary>
		/// Обработчик ввода использующий паттерн ICommand
		/// В отдельный класс не стал выносить, т.к. не критично для задачи.
		/// </summary>
		private bool InputHandler()
		{
			bool isExit = false;

			Console.SetCursorPosition(0, _output.Height);
			ConsoleKeyInfo key = Console.ReadKey();

			bool isRefresh = false;//Обновлять ли экран

			switch (key.Key)
			{
				case ConsoleKey.RightArrow:
					_invoker.Execute(new CommandMove(_fractal, new Vector2(1, 0)));
					isRefresh = true;
					break;
				case ConsoleKey.LeftArrow:
					_invoker.Execute(new CommandMove(_fractal, new Vector2(-1, 0)));
					isRefresh = true;
					break;
				case ConsoleKey.UpArrow:
					_invoker.Execute(new CommandMove(_fractal, new Vector2(0, 1)));
					isRefresh = true;
					break;
				case ConsoleKey.DownArrow:
					_invoker.Execute(new CommandMove(_fractal, new Vector2(0, -1)));
					isRefresh = true;
					break;

				case ConsoleKey.K:
					_invoker.Execute(new CommandZoom(_fractal, 1));
					isRefresh = true;
					break;
				case ConsoleKey.L:
					_invoker.Execute(new CommandZoom(_fractal, -1));
					isRefresh = true;
					break;

				case ConsoleKey.I:
					_invoker.Execute(new CommandDetails(_fractal, -1));
					isRefresh = true;
					break;
				case ConsoleKey.O:
					_invoker.Execute(new CommandDetails(_fractal, 1));
					isRefresh = true;
					break;

				case ConsoleKey.Spacebar:
					_invoker.Undo();
					isRefresh = true;
					break;
				case ConsoleKey.R:
					_invoker.Execute(new CommandReset(_fractal));
					_invoker.Reset();
					isRefresh = true;
					break;

				case ConsoleKey.Q:
				case ConsoleKey.Escape:
					isExit = true;
					break;
			}

			if (isRefresh)
			{
				_output.PrintMessage(_output.Height - 2, 1, $"Выполнено комманд: {_invoker.Count}       ");
				_output.RenderOutput();
				isRefresh = false;
			}

			return isExit;
		}
	}
}
