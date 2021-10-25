using Lesson_03.Fractals;
using System;

namespace Lesson_03.Commands
{
	class CommandDetails : ICommand
	{
		/// <summary>Получатель команды</summary>
		private readonly IFractal _fractal;
		/// <summary>Направление изменения</summary>
		private readonly int _direction;

		public CommandDetails(IFractal fractal, int direction)
		{
			_fractal = fractal;
			_direction = direction;
		}

		public void Execute()
		{
			_fractal.ChangeDetails(Math.Sign(_direction));
		}

		public void Undo()
		{
			_fractal.ChangeDetails(-Math.Sign(_direction));
		}
	}
}
