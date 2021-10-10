using System;
using System.Threading;
using System.Windows.Forms;

namespace Lesson_01.Elements
{
	public class Counter
	{
		/// <summary>Дефолтное значение для таймера</summary>
		private const int CounterDefault = 5;

		/// <summary>Тред для счетчика</summary>
		private Thread _thread;
		/// <summary>Событие смены числа фибоначи</summary>
		private ManualResetEvent _event;
		/// <summary>Токен отмены</summary>
		private CancellationTokenSource _tokenSource;

		/// <summary>Метка содержащая значение счетчика</summary>
		private Label _label;

		public Counter(CancellationTokenSource tokenSource, ManualResetEvent resetEvent, Label label, string name)
		{
			_event = resetEvent;
			_tokenSource = tokenSource;
			_label = label;

			_thread = new Thread(Run);
			_thread.Name = name;
			_thread.Start();
		}

		/// <summary>
		/// Вечный цикл счетчика
		/// </summary>
		private void Run()
		{
			int value;
			int.TryParse(_label.Text, out value);

			try
			{
				while (!_tokenSource.IsCancellationRequested)
				{
					Thread.Sleep(100);
					value = value == 0 ? CounterDefault : value - 1;
					_label.Invoke(new Action(() => { _label.Text = value.ToString(); }));
					if (value == 0) { _event.Set(); }
				}
			}
			catch
			{
				//Ничего не делаем
			}
		}
	}
}
