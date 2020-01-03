using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Boddooh
{
	/// <summary>
	/// Summary description for MessageForm.
	/// </summary>
	public class FormMessage : System.Windows.Forms.Form
	{			
		private string message = string.Empty;
		public string Message
		{
			get
			{
				return message;
			}
			set
			{
				message = value;
				this.MessageLabel.Text = message;
			}
		}

		private string caption = string.Empty;
		private System.Windows.Forms.Label MessageLabel;
		private System.Windows.Forms.Button Button1;
	
		public string Caption
		{
			get
			{
				return caption;
			}
			set
			{
				caption = value;
				this.Text = caption;
			}
		}

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormMessage()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.MessageLabel = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MessageLabel
            // 
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MessageLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MessageLabel.Location = new System.Drawing.Point(0, 0);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(416, 80);
            this.MessageLabel.TabIndex = 0;
            this.MessageLabel.Text = "label1";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MessageLabel.Click += new System.EventHandler(this.MessageLabel_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(168, 80);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "OK";
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // FormMessage
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(416, 118);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.MessageLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMessage";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Load += new System.EventHandler(this.FormMessage_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void FormMessage_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

        private void MessageLabel_Click(object sender, EventArgs e)
        {

        }
	}
}
