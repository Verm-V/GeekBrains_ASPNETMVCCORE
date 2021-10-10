
namespace Lesson_01
{
	partial class Form1
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			ThreadsStop();

			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.FibonachiLabel = new System.Windows.Forms.Label();
			this.FibonachDelay = new System.Windows.Forms.Label();
			this.FibonachiValue = new System.Windows.Forms.Label();
			this.DelayValue = new System.Windows.Forms.Label();
			this.Start = new System.Windows.Forms.Button();
			this.CpuMetric = new System.Windows.Forms.Label();
			this.MetricsValue = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// FibonachiLabel
			// 
			this.FibonachiLabel.AutoSize = true;
			this.FibonachiLabel.Dock = System.Windows.Forms.DockStyle.Left;
			this.FibonachiLabel.Location = new System.Drawing.Point(4, 1);
			this.FibonachiLabel.Name = "FibonachiLabel";
			this.FibonachiLabel.Size = new System.Drawing.Size(143, 40);
			this.FibonachiLabel.TabIndex = 0;
			this.FibonachiLabel.Text = "Число Фибоначчи: ";
			this.FibonachiLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FibonachDelay
			// 
			this.FibonachDelay.AutoSize = true;
			this.FibonachDelay.Dock = System.Windows.Forms.DockStyle.Left;
			this.FibonachDelay.Location = new System.Drawing.Point(4, 83);
			this.FibonachDelay.Name = "FibonachDelay";
			this.FibonachDelay.Size = new System.Drawing.Size(157, 42);
			this.FibonachDelay.TabIndex = 0;
			this.FibonachDelay.Text = "Счетчик обновления:";
			this.FibonachDelay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FibonachiValue
			// 
			this.FibonachiValue.AutoSize = true;
			this.FibonachiValue.Dock = System.Windows.Forms.DockStyle.Left;
			this.FibonachiValue.Location = new System.Drawing.Point(277, 1);
			this.FibonachiValue.Name = "FibonachiValue";
			this.FibonachiValue.Size = new System.Drawing.Size(17, 40);
			this.FibonachiValue.TabIndex = 0;
			this.FibonachiValue.Text = "1";
			this.FibonachiValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// DelayValue
			// 
			this.DelayValue.AutoSize = true;
			this.DelayValue.Dock = System.Windows.Forms.DockStyle.Left;
			this.DelayValue.Location = new System.Drawing.Point(277, 83);
			this.DelayValue.Name = "DelayValue";
			this.DelayValue.Size = new System.Drawing.Size(17, 42);
			this.DelayValue.TabIndex = 0;
			this.DelayValue.Text = "0";
			this.DelayValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Start
			// 
			this.Start.Dock = System.Windows.Forms.DockStyle.Fill;
			this.Start.Location = new System.Drawing.Point(535, 86);
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(310, 36);
			this.Start.TabIndex = 1;
			this.Start.Text = "Start";
			this.Start.UseVisualStyleBackColor = true;
			this.Start.Click += new System.EventHandler(this.button1_Click);
			// 
			// CpuMetric
			// 
			this.CpuMetric.AutoSize = true;
			this.CpuMetric.Dock = System.Windows.Forms.DockStyle.Left;
			this.CpuMetric.Location = new System.Drawing.Point(4, 42);
			this.CpuMetric.Name = "CpuMetric";
			this.CpuMetric.Size = new System.Drawing.Size(249, 40);
			this.CpuMetric.TabIndex = 0;
			this.CpuMetric.Text = "Загрузка CPU удаленного сервера:";
			this.CpuMetric.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// MetricsValue
			// 
			this.MetricsValue.AutoSize = true;
			this.MetricsValue.Dock = System.Windows.Forms.DockStyle.Left;
			this.MetricsValue.Location = new System.Drawing.Point(277, 42);
			this.MetricsValue.Name = "MetricsValue";
			this.MetricsValue.Size = new System.Drawing.Size(17, 40);
			this.MetricsValue.TabIndex = 0;
			this.MetricsValue.Text = "0";
			this.MetricsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label1.Location = new System.Drawing.Point(535, 1);
			this.label1.Name = "label1";
			this.tableLayoutPanel1.SetRowSpan(this.label1, 2);
			this.label1.Size = new System.Drawing.Size(310, 81);
			this.label1.TabIndex = 0;
			this.label1.Text = "обновляются по истечении счетчика\r\nв отдельном потоке";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 257F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 315F));
			this.tableLayoutPanel1.Controls.Add(this.label1, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.Start, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.FibonachiLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.DelayValue, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.MetricsValue, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.FibonachDelay, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.FibonachiValue, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.CpuMetric, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 24);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 126);
			this.tableLayoutPanel1.TabIndex = 2;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(882, 181);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "Form1";
			this.Text = "Start";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label FibonachiLabel;
		private System.Windows.Forms.Label FibonachDelay;
		private System.Windows.Forms.Label FibonachiValue;
		private System.Windows.Forms.Label DelayValue;
		private System.Windows.Forms.Button Start;
		private System.Windows.Forms.Label CpuMetric;
		private System.Windows.Forms.Label MetricsValue;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
	}
}

