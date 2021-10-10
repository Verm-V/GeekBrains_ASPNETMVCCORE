
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
			this.SuspendLayout();
			// 
			// FibonachiLabel
			// 
			this.FibonachiLabel.AutoSize = true;
			this.FibonachiLabel.Location = new System.Drawing.Point(68, 38);
			this.FibonachiLabel.Name = "FibonachiLabel";
			this.FibonachiLabel.Size = new System.Drawing.Size(143, 20);
			this.FibonachiLabel.TabIndex = 0;
			this.FibonachiLabel.Text = "Число Фибоначчи: ";
			// 
			// FibonachDelay
			// 
			this.FibonachDelay.AutoSize = true;
			this.FibonachDelay.Location = new System.Drawing.Point(68, 80);
			this.FibonachDelay.Name = "FibonachDelay";
			this.FibonachDelay.Size = new System.Drawing.Size(79, 20);
			this.FibonachDelay.TabIndex = 0;
			this.FibonachDelay.Text = "Задержка:";
			// 
			// FibonachiValue
			// 
			this.FibonachiValue.AutoSize = true;
			this.FibonachiValue.Location = new System.Drawing.Point(247, 38);
			this.FibonachiValue.Name = "FibonachiValue";
			this.FibonachiValue.Size = new System.Drawing.Size(17, 20);
			this.FibonachiValue.TabIndex = 0;
			this.FibonachiValue.Text = "1";
			// 
			// DelayValue
			// 
			this.DelayValue.AutoSize = true;
			this.DelayValue.Location = new System.Drawing.Point(247, 80);
			this.DelayValue.Name = "DelayValue";
			this.DelayValue.Size = new System.Drawing.Size(17, 20);
			this.DelayValue.TabIndex = 0;
			this.DelayValue.Text = "5";
			// 
			// Start
			// 
			this.Start.Location = new System.Drawing.Point(68, 122);
			this.Start.Name = "Start";
			this.Start.Size = new System.Drawing.Size(94, 29);
			this.Start.TabIndex = 1;
			this.Start.Text = "Start";
			this.Start.UseVisualStyleBackColor = true;
			this.Start.Click += new System.EventHandler(this.button1_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.Start);
			this.Controls.Add(this.DelayValue);
			this.Controls.Add(this.FibonachDelay);
			this.Controls.Add(this.FibonachiValue);
			this.Controls.Add(this.FibonachiLabel);
			this.Name = "Form1";
			this.Text = "Start";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label FibonachiLabel;
		private System.Windows.Forms.Label FibonachDelay;
		private System.Windows.Forms.Label FibonachiValue;
		private System.Windows.Forms.Label DelayValue;
		private System.Windows.Forms.Button Start;
	}
}

