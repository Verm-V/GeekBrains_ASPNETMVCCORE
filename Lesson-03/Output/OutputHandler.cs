using System;
using System.Text;

namespace Lesson_03.Output
{
	public class OutputHandler : IOutputHandler
	{
		/// <summary>Символьное представление дял яркости отдельных точек кадра</summary>
		private string _bright = ".,'~=+:;[/<&?oxOX# ";
		/// <summary>Ширина кадра</summary>
		private readonly int _w = 80;
		/// <summary>Высота кадра</summary>
		private readonly int _h = 40;
		/// <summary>Массив содержащий данные кадра для вывода на экран</summary>
		private readonly char[,] _innerBuffer;
		/// <summary>Буфер выводимый на экран</summary>
		private StringBuilder _outputBuffer = new StringBuilder();

		public OutputHandler()
		{
			_innerBuffer = new char[_h, _w];
		}
		public int Width { get => _w; }
		public int Height { get => _h; }
		public int MaxBright { get => _bright.Length - 1; }

		public void RenderOutput()
		{
			Flush();
			Console.SetCursorPosition(0, 0);
			var sss = _outputBuffer.ToString();
			Console.Write(_outputBuffer);
		}

		public void PrintMessage(int r, int c, string message)
		{
			if (CheckCoordinates(r, c))
			{
				int length = (_w - c > message.Length) ? message.Length : _w - c;
				for (int i = 0; i < length; i++)
				{
					_innerBuffer[r, c + i] = message[i];
				}
			}
		}

		public void DrawPoint(int r, int c, int bright)
		{
			if (CheckCoordinates(r, c))
			{
				_innerBuffer[r, c] = _bright[NormalizeBright(bright)];
			}
		}

		public void DrawBox(int row, int col, int height, int width)
		{
			if (CheckCoordinates(row, col) && CheckCoordinates(row + height - 1, col + width - 1))
			{
				//└─┘┌│┐
				for (int c = 1; c < width - 1; c++)
				{
					_innerBuffer[row, c + col] = '─';
					_innerBuffer[row + height - 1, c + col] = '─';
				}
				for (int r = 1; r < height - 1; r++)
				{
					_innerBuffer[r + row, col] = '│';
					_innerBuffer[r + row, col + width - 1] = '│';
				}
				_innerBuffer[row, col] = '┌';
				_innerBuffer[row, col + width - 1] = '┐';
				_innerBuffer[row + height - 1, col] = '└';
				_innerBuffer[row + height - 1, col + width - 1] = '┘';
			}
		}

		/// <summary>
		/// Сброс кадра в буфер вывода
		/// </summary>
		private void Flush()
		{
			_outputBuffer.Clear();
			for (int r = 0; r < _h; r++)
			{
				for (int c = 0; c < _w; c++)
				{
					_outputBuffer.Append(_innerBuffer[r, c] == '\0' ? ' ' : _innerBuffer[r, c]);
				}
				_outputBuffer.AppendLine();
			}
		}

		/// <summary>
		/// Проверка входят ли координаты в поле для вывода на экран
		/// </summary>
		/// <param name="row">Координата Y</param>
		/// <param name="col">Координата X</param>
		/// <returns>true если координаты попадают в поле для вывода на экран, иначе false</returns>
		private bool CheckCoordinates(int row, int col)
		{
			return (0 <= row && row < _w && 0 <= row && row < _h);
		}

		/// <summary>
		/// Нормализует значение яркости, чтобы оно попадало в нужный диапазон
		/// </summary>
		/// <param name="bright">Значение яркости для нормализации</param>
		/// <returns>Нормальизованное значение яркости</returns>
		private int NormalizeBright(int bright)
		{
			int normalBright = bright < 0 ? 0 : bright;
			normalBright = bright >= _bright.Length ? _bright.Length - 1 : bright;
			return normalBright;
		}
	}
}
