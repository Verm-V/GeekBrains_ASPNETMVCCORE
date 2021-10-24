using Lesson_03.Output;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_03.Fractals
{
	/// <summary>
	/// Логику рассчетов содрал со старых программ для рассчета фракталов на ZX-Spectrum и БК
	/// </summary>
	public class Mandelbrot : IFractal
	{
		private readonly IOutputHandler _output;

		private readonly double coordStep = 0.01;//Шаг для сдвига координат
		private readonly double zoomStep = 0.01;//Шаг для зума
		private readonly double detailsStep = 10;//Шаг для детализации

		/// <summary>Константа для корректировки яркости точек</summary>
		private readonly int _so = 1;
		/// <summary>Дефолтное оложение по X</summary>
		private readonly double _defaultCoordX = -2.0;
		/// <summary>Дефолтное оложение по Y</summary>
		private readonly double _defaultCoordY = 1.25;
		/// <summary>Дефолтный масштаб по X</summary>
		private readonly double _defaultZoomX = 2.5;
		/// <summary>Дефолтный масштаб по Y</summary>
		private readonly double _defaultZoomY = -2.5;
		/// <summary>Дефолтная детализация</summary>
		private readonly double _defaultDetails = 4;

		/// <summary>Ограничитель для яркости точек</summary>
		private readonly int _mi;
		/// <summary>Координата Y области в которой рисуется фрактал</summary>
		private readonly int _startRow = 1;
		/// <summary>Координата X области в которой рисуется фрактал</summary>
		private readonly int _startColumn = 1;
		/// <summary>Ширина области в которой рисуется фрактал</summary>
		private readonly int _width;
		/// <summary>Высота области в которой рисуется фрактал</summary>
		private readonly int _height;

		/// <summary>Текущая координата X</summary>
		private double coordX;
		/// <summary>Текущая координата Y</summary>
		private double coordY;
		/// <summary>Текущий масштаб по X</summary>
		private double zoomX;
		/// <summary>Текущий масштаб по Y</summary>
		private double zoomY;
		/// <summary>Текущая детализация</summary>
		private double details;


		public Mandelbrot(IOutputHandler outputHandler)
		{
			_output = outputHandler;
			_mi = _output.MaxBright + 1;
			_width = _output.Width - 2;
			_height = _output.Height - 6;
			ResetState();
		}

		public void ResetState()
		{
			coordX = _defaultCoordX;
			coordY = _defaultCoordY;
			zoomX = _defaultZoomX;
			zoomY = _defaultZoomY;
			details = _defaultDetails;
		}

		public void Move(int dx, int dy)
		{
			coordX += coordStep * Math.Sign(dx);
			coordY += coordStep * Math.Sign(dy);
		}

		public void ChangeZoom(int dz)
		{
			zoomX += zoomStep * Math.Sign(dz);
			zoomY -= zoomStep * Math.Sign(dz);
			coordX -= zoomStep * Math.Sign(dz) / 2;
			coordY += zoomStep * Math.Sign(dz) / 2;
		}

		public void ChangeDetails(int delta)
		{
			switch(Math.Sign(delta))
			{
				case 1:
					details *= detailsStep;
					break;
				case -1:
					details /= detailsStep;
					break;
			}
		}

		public void CalculateAndRenderFrame()
		{
			CalculateNextFrame();
			_output.RenderOutput();
		}

		/// <summary>
		/// Рассчет очередного кадра
		/// </summary>
		private void CalculateNextFrame()
		{
			double sx = zoomX / _width;
			double sy = zoomY / _height;

			double cx = 0;
			double zx = 0;
			double zy = 0;
			double cc = 0;
			double x2 = 0;
			double y2 = 0;
			double t = 0;
			for (int y = 0; y < _height; y++)
			{
				double cy = y * sy + coordY;
				for (int x = 0; x < _width; x++)
				{
					cx = x * sx + coordX;
					zx = 0;
					zy = 0;
					cc = _so;
					x2 = zx * zx;
					y2 = zy * zy;
					while (cc < _mi && (x2 + y2) <= details)
					{
						t = x2 - y2 + cx;
						zy = 2 * zx * zy + cy;
						zx = t;
						cc++;
						x2 = zx * zx;
						y2 = zy * zy;
					}
					_output.DrawPoint(_startRow + y, _startColumn + x, (int)(cc - _so));
				}
			}
		}
	}
}
