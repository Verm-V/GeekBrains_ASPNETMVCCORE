using Lesson_03.Fractals;
using System;

namespace Lesson_03.Commands
{
	class CommandZoom : ICommand
	{
		/// <summary>Получатель команды</summary>
		private readonly IFractal _fractal;
		/// <summary>Направление движения</summary>
		private readonly int _direction;

		public CommandZoom(IFractal fractal, int direction)
		{
			_fractal = fractal;
			_direction = direction;
		}

		public void Execute()
		{
			_fractal.ChangeZoom(Math.Sign(_direction));
		}

		public void Undo()
		{
			_fractal.ChangeZoom(-Math.Sign(_direction));
		}
	}
}
