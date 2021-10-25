namespace Lesson_03.Commands
{
	/// <summary>
	/// Интерфейс исполнителя команд
	/// </summary>
	public interface IInvoker
	{

		/// <summary>Количество выполненных команд</summary>
		public int Count { get; }

		/// <summary>Выполнить комманду и поместить ее в стек выполненных команд</summary>
		public void Execute(ICommand command);

		/// <summary>Отменить последнюю выполненную команду</summary>
		public void Undo();

		/// <summary>Очистка списка выполненных команд</summary>
		public void Reset();
	}
}
