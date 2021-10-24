using Lesson_03.Fractals;
using System;
using System.Numerics;

namespace Lesson_03.Commands
{
	public class CommandMove : ICommand
	{
		/// <summary>Получатель команды</summary>
		private readonly IFractal _fractal;
		/// <summary>Направление движения</summary>
		private readonly Vector2 _direction;

		public CommandMove(IFractal fractal, Vector2 direction)
		{
			_fractal = fractal;
			_direction = direction;
		}

		public void Execute()
		{
			_fractal.Move(Math.Sign(_direction.X), Math.Sign(_direction.Y));
		}

		public void Undo()
		{
			_fractal.Move(-Math.Sign(_direction.X), -Math.Sign(_direction.Y));
		}
	}
}
