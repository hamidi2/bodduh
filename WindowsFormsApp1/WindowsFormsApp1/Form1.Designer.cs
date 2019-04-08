namespace WindowsFormsApp1
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbInput = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.tbOutput1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tbOutput2 = new System.Windows.Forms.TextBox();
			this.tbOutput3 = new System.Windows.Forms.TextBox();
			this.tbOutput4 = new System.Windows.Forms.TextBox();
			this.tbOutput5 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(500, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(39, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "ورودی";
			// 
			// tbInput
			// 
			this.tbInput.Location = new System.Drawing.Point(12, 6);
			this.tbInput.Name = "tbInput";
			this.tbInput.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbInput.Size = new System.Drawing.Size(478, 20);
			this.tbInput.TabIndex = 1;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(214, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "آغاز عملیات";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tbOutput1
			// 
			this.tbOutput1.Location = new System.Drawing.Point(12, 61);
			this.tbOutput1.Name = "tbOutput1";
			this.tbOutput1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbOutput1.Size = new System.Drawing.Size(478, 20);
			this.tbOutput1.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(496, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "خروجیها";
			// 
			// tbOutput2
			// 
			this.tbOutput2.Location = new System.Drawing.Point(12, 87);
			this.tbOutput2.Name = "tbOutput2";
			this.tbOutput2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbOutput2.Size = new System.Drawing.Size(478, 20);
			this.tbOutput2.TabIndex = 5;
			// 
			// tbOutput3
			// 
			this.tbOutput3.Location = new System.Drawing.Point(12, 113);
			this.tbOutput3.Name = "tbOutput3";
			this.tbOutput3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbOutput3.Size = new System.Drawing.Size(478, 20);
			this.tbOutput3.TabIndex = 6;
			// 
			// tbOutput4
			// 
			this.tbOutput4.Location = new System.Drawing.Point(12, 139);
			this.tbOutput4.Name = "tbOutput4";
			this.tbOutput4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbOutput4.Size = new System.Drawing.Size(478, 20);
			this.tbOutput4.TabIndex = 7;
			// 
			// tbOutput5
			// 
			this.tbOutput5.Location = new System.Drawing.Point(12, 178);
			this.tbOutput5.Name = "tbOutput5";
			this.tbOutput5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.tbOutput5.Size = new System.Drawing.Size(478, 20);
			this.tbOutput5.TabIndex = 8;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(499, 181);
			this.label3.Name = "label3";
			this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.label3.Size = new System.Drawing.Size(46, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "روش دوم";
			// 
			// Form1
			// 
			this.AcceptButton = this.button1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(547, 210);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.tbOutput5);
			this.Controls.Add(this.tbOutput4);
			this.Controls.Add(this.tbOutput3);
			this.Controls.Add(this.tbOutput2);
			this.Controls.Add(this.tbOutput1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.tbInput);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox tbInput;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tbOutput1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbOutput2;
		private System.Windows.Forms.TextBox tbOutput3;
		private System.Windows.Forms.TextBox tbOutput4;
		private System.Windows.Forms.TextBox tbOutput5;
		private System.Windows.Forms.Label label3;
	}
}

