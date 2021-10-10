﻿using System;
using System.Threading;
using System.Windows.Forms;
using Lesson_01.Elements;

namespace Lesson_01
{
	public partial class Form1 : Form
	{
		/// <summary>Событие смены числа фибоначи</summary>
		private readonly ManualResetEvent _resetEvent;
		/// <summary>Токен отмены</summary>
		private readonly CancellationTokenSource _tokenSource; 
		
		/// <summary>Флаг того, что треды были запущены</summary>
		private bool processStarted = false;

		Counter counter;
		Fibonachi fibonachi;


		public Form1()
		{
			InitializeComponent();
			_resetEvent = new ManualResetEvent(false);
			_tokenSource = new CancellationTokenSource();
		}

		private void label1_Click(object sender, EventArgs e)
		{
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (!processStarted)
			{
				counter = new Counter(_tokenSource, _resetEvent, DelayValue, "counterThread");
				fibonachi = new Fibonachi(_tokenSource, _resetEvent, FibonachiValue, "fibonachiThread");
				processStarted = true;
			}
		}

		private void ThreadsStop()
		{
			_tokenSource.Cancel();
			_resetEvent.Set();
		}

	}
}
