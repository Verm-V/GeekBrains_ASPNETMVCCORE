using Lesson_01.Client;
using Lesson_01.Models;
using Lesson_01.Requests;
using Lesson_01.Responses.FromManager;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace Lesson_01.Elements
{
	public class Metrics
	{
		/// <summary>Тред для счетчика</summary>
		private Thread _thread;
		/// <summary>Событие смены числа фибоначи</summary>
		private ManualResetEvent _event;
		/// <summary>Токен отмены</summary>
		private CancellationTokenSource _tokenSource;

		/// <summary>Клиент менеджера метрик</summary>
		private IMetricsClient _client;

		/// <summary>Элемент содержащий данные о метриках</summary>
		private Label _label;

		public Metrics(CancellationTokenSource tokenSource, ManualResetEvent resetEvent, Label label, string name)
		{
			_event = resetEvent;
			_tokenSource = tokenSource;
			_label = label;
			_client = new MetricsClient();

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
						string metric = GetNextMetric();
						if(metric.Length != 0)
						{
							_label.Invoke(new Action(() => { _label.Text = metric; }));
						}
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
		/// Забирает последнюю метрику с сервера
		/// </summary>
		/// <returns>Значение загрузки CPU</returns>
		private string GetNextMetric()
		{
			var request = new CpuMetricGetByIntervalRequestByClient()
			{
				AgentId = 1,
				ToTime = DateTimeOffset.UtcNow,
				FromTime = DateTimeOffset.UtcNow - TimeSpan.FromSeconds(20),
			};

			var result = string.Empty;

			try
			{
				var response = _client.GetMetrics<CpuMetricDto>(request, ApiNames.Cpu);

				if (response != null && response.Metrics.Count != 0)
				{
					result = $"{response.Metrics[^1].Value}%  -  {response.Metrics[^1].Time.ToString("G")}";
				}
			}
			catch
			{
				// Обработка ошибки
			}

			return result.ToString();
		}

	}
}
