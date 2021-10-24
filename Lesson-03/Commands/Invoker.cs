using NLog;
using System.Collections.Generic;

namespace Lesson_03.Commands
{
	public class Invoker : IInvoker
	{
		/// <summary>Стек для хранения выполненных комманд</summary>
		private readonly Stack<ICommand> _commands;
		/// <summary>Логгер</summary>
		private readonly ILogger _logger;

		public Invoker()
		{
			_commands = new Stack<ICommand>();
			_logger = LogManager.GetCurrentClassLogger();
		}

		public int Count { get => _commands.Count; }

		public void Execute(ICommand command)
		{
			_commands.Push(command);
			_commands.Peek().Execute();
			_logger.Debug($"Executed commnd: {command.ToString()}");
		}

		public void Undo()
		{
			if (_commands.Count > 0)
			{
				_commands.Peek().Undo();
				_commands.Pop();
			}
		}

		public void Reset()
		{
			_commands.Clear();
		}
	}
}
