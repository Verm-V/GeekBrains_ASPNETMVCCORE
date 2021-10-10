using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;


namespace Lesson_01.Elements
{
	public class Fibonachi
	{
		/// <summary> максимальное количество членов последовательности 
		/// больше 93 ставить не стоит, т.к. используется тип ulong и 
		/// на 94-м члене последовательности произойдет переполнение</summary>
		private const int SequenceMax = 93;

		/// <summary>Тред для счетчика</summary>
		private Thread _thread;
		/// <summary>Событие смены числа фибоначи</summary>
		private ManualResetEvent _event;
		/// <summary>Токен отмены</summary>
		private CancellationTokenSource _tokenSource;

		/// <summary>Метка содержащая значение счетчика</summary>
		private Label _label;

		//массив для хранения рассчитанных чисел Фибоначчи
		private List<ulong> memory = new List<ulong>();

		public Fibonachi(CancellationTokenSource tokenSource, ManualResetEvent resetEvent, Label label, string name)
		{
			_event = resetEvent;
			_tokenSource = tokenSource;
			_label = label;
			MemoryInit();

			_thread = new Thread(Run);
			_thread.Name = name;
			_thread.Start();
		}

		/// <summary>
		/// Вечный цикл счетчика
		/// </summary>
		private void Run()
		{
			try
			{
				while (true)
				{
					_event.WaitOne();
					if (!_tokenSource.IsCancellationRequested)
					{
						ulong nextNumber = GetNextNumber(memory.Count);
						_label.Invoke(new Action(() => { _label.Text = nextNumber.ToString(); }));
						if (memory.Count > SequenceMax) { MemoryInit(); }
						_event.Reset();
					}
					else
					{
						break;
					}
				}
			}
			catch
			{
				//Ничего не делаем
			}
		}

		/// <summary>
		/// Рекурсивно рассчитывает члены последовательноси Фибоначчи до заданного номера
		/// используя массив для хранения ранее рассчитанных значений
		/// </summary>
		/// <param name="n">номер члена последовательности до которого считать</param>
		/// <param name="memory">массив элементов хранящий ранее рассчитанные члены последовательности</param>
		/// <returns>значение члена последовательности</returns>
		private ulong GetNextNumber(int n)
		{
			if (n <= 1) return (ulong)n; // Первые два значения

			// Если в массиве памяти данный элемент уже вычислен, то вернем его, иначе пойдем по рекурсии
			if (memory.Count > n)
				return memory[n];
			else
			{
				memory.Add(GetNextNumber(n - 1) + GetNextNumber(n - 2));
				return memory[n];
			}
		}

		private void MemoryInit()
		{
			memory.Clear();
			memory.Add(1);
			memory.Add(1);
		}
	}
}
