namespace Lesson_03.Commands
{
	/// <summary>
	/// Интерфейс исполнителя комманд
	/// </summary>
	public interface IInvoker
	{

		/// <summary>Количество выполненных комманд</summary>
		public int Count { get; }

		/// <summary>Выполнить комманду и поместить ее в стек выполненных комманд</summary>
		public void Execute(ICommand command);

		/// <summary>Отменить последнюю выполненную комманду</summary>
		public void Undo();

		/// <summary>Очистка списка выполненных комманд</summary>
		public void Reset();
	}
}
