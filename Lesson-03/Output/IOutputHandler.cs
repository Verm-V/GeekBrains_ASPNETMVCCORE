using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Lesson_03.Output
{
	/// <summary>
	/// Хэндлер отвечающий за вывод на экран
	/// Система координат: 
	///  Y(R - row) сверху-вниз
	///  X(C - column) слева-направо
	/// </summary>
	public interface IOutputHandler
	{
		/// <summary>Ширина экранной области</summary>
		public int Width {get; }

		/// <summary>Высота экранной области</summary>
		public int Height { get; }

		/// <summary>Максимально значене яркости</summary>
		public int MaxBright { get; }

		/// <summary>
		/// Вывод содержимого буфера в консоль
		/// </summary>
		public void RenderOutput();

		/// <summary>
		/// Вывод сообщения на экран
		/// </summary>
		/// <param name="row">Координата Y</param>
		/// <param name="col">Координата X</param>
		/// <param name="message">Сообщение для вывода</param>
		public void PrintMessage(int row, int col, string message);

		/// <summary>
		/// Вывод точки на экране
		/// </summary>
		/// <param name="row">Координата Y</param>
		/// <param name="col">Координата X</param>
		/// <param name="bright">Значение яркости точки, 
		/// значения выходящие за пределы будут приводится к ближайшему краю диапазона яркости</param>
		public void DrawPoint(int row, int col, int bright);

		/// <summary>
		/// Рисует на экране рамку
		/// </summary>
		/// <param name="row">Координата Y начала рамки</param>
		/// <param name="col">Координата X начала рамки</param>
		/// <param name="height">Высота рамки</param>
		/// <param name="width">Ширина рамки</param>
		public void DrawFrame(int row, int col, int height, int width);
	}
}
