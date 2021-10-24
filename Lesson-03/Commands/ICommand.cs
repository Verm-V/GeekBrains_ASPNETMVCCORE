namespace Lesson_03.Commands
{
	/// <summary>
	/// Интерфейс комманды
	/// </summary>
	public interface ICommand
	{
		/// <summary>Выполнить комманду</summary>
		public void Execute();

		/// <summary>Отменить выполнение комманды</summary>
		public void Undo();
	}
}
