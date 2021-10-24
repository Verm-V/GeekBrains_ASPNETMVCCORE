namespace Lesson_03.Commands
{
	/// <summary>
	/// Интерфейс команды
	/// </summary>
	public interface ICommand
	{
		/// <summary>Выполнить команду</summary>
		public void Execute();

		/// <summary>Отменить выполнение команды</summary>
		public void Undo();
	}
}
