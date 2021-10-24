using Lesson_03.Fractals;

namespace Lesson_03.Commands
{
	class CommandReset : ICommand
	{
		/// <summary>Получатель комманды</summary>
		private readonly IFractal _fractal;
		/// <summary>Направление движения</summary>
		private readonly int _direction;

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
