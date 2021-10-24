using Lesson_03.Fractals;

namespace Lesson_03.Commands
{
	class CommandReset : ICommand
	{
		/// <summary>Получатель команды</summary>
		private readonly IFractal _fractal;

		public CommandReset(IFractal fractal)
		{
			_fractal = fractal;
		}

		public void Execute()
		{
			_fractal.ResetState();
		}

		public void Undo()
		{
			// Не делать ничего.
		}
	}
}
