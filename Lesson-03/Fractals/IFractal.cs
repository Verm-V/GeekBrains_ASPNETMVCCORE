namespace Lesson_03.Fractals
{
	/// <summary>
	/// Отвечает за рассчет и вывод фрактала на экран
	/// Рендер будет идти отсюда же для скорости
	/// </summary>
	public interface IFractal
	{
		/// <summary>
		/// Сброс координат и увеличения в изначальное состояние
		/// </summary>
		public void ResetState();

		/// <summary>
		/// Сдвиг отображения фрактала
		/// Учитывается только знак параметров
		/// </summary>
		/// <param name="dx">Направление сдвига по X</param>
		/// <param name="dy">Направление сдвига по Y</param>
		public void Move(int dx, int dy);

		/// <summary>
		/// Изменени масштаба
		/// Учитывается только знак параметра
		/// </summary>
		/// <param name="dz">Направление изменения масштаба</param>
		public void ChangeZoom(int dz);

		/// <summary>
		/// Изменение детализации отрисовки
		/// Учитывается только знак параметра
		/// </summary>
		/// <param name="delta">Направление изменения детализации</param>
		public void ChangeDetails(int delta);
	}
}
