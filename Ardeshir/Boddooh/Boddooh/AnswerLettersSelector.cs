using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace BoddoohControl
{
	/// <summary>
	/// Summary description for AnswerLettersSelector.
	/// </summary>
	public class AnswerLettersSelector : System.Windows.Forms.UserControl
	{
		bool Loaded = false;
        public static int Length=40;
        public static int LetterButtonWidth = 30;
		
		public System.Windows.Forms.RadioButton[,] RadioButtons;
		
		private System.Windows.Forms.Panel[] Panels;
		private System.Windows.Forms.Panel MainPanel;

		#region Properties

		private Color selectedLetterButtonBackColor = System.Drawing.SystemColors.Highlight;
		public Color SelectedLetterButtonBackColor
		{
			get
			{
				return selectedLetterButtonBackColor;
			}
			set
			{
				selectedLetterButtonBackColor=value;
				Refresh();
			}
		}

		private Color selectedLetterButtonForeColor = System.Drawing.SystemColors.HighlightText;
		public Color SelectedLetterButtonForeColor
		{
			get
			{
				return selectedLetterButtonForeColor;
			}
			set
			{
				selectedLetterButtonForeColor=value;
				Refresh();
			}
		}


		private Color unselectedLetterButtonBackColor = System.Drawing.SystemColors.Control;
		public Color UnselectedLetterButtonBackColor
		{
			get
			{
				return unselectedLetterButtonBackColor;
			}
			set
			{
				unselectedLetterButtonBackColor=value;
				Refresh();
			}
		}

		private Color unselectedLetterButtonForeColor = System.Drawing.SystemColors.ControlText;
		public Color UnselectedLetterButtonForeColor
		{
			get
			{
				return unselectedLetterButtonForeColor;
			}
			set
			{
				unselectedLetterButtonForeColor=value;
				Refresh();
			}
		}

		
		public delegate void SelectedAnswerChangedDelegate();
		private SelectedAnswerChangedDelegate selectedAnswerChanged;
		public SelectedAnswerChangedDelegate SelectedAnswerChanged
		{
			get
			{
				return selectedAnswerChanged;
			}
			set
			{
				selectedAnswerChanged=value;
			}
		}

		private String  selectedAnswer = "________________________";
		public String SelectedAnswer
		{
			get
			{
				return selectedAnswer;
			}
			set
			{
				selectedAnswer=value;
                for (int i = 0; i < Length; i++)
                {
                    char SelectedLetter = ' ';
                    if (i<selectedAnswer.Length)
                     SelectedLetter = Convert.ToChar(selectedAnswer.Substring(i, 1));
                    for (int j = 1; j >= 0; j--)
                        if (this.RadioButtons[i, j].Text == Convert.ToString(SelectedLetter))
                            this.RadioButtons[i, j].Checked = true;
                        else
                            this.RadioButtons[i, j].Checked = false;

                }
			}

		}
		
		#endregion Properties


		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public AnswerLettersSelector()
		{
			// This call is required by the Windows.Forms Form Designer.

            InitializeComponent();
			ComponentInitialization();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing)
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.MainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(104, 152);
            this.MainPanel.TabIndex = 0;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // AnswerLettersSelector
            // 
            this.Controls.Add(this.MainPanel);
            this.Name = "AnswerLettersSelector";
            this.Size = new System.Drawing.Size(104, 152);
            this.Load += new System.EventHandler(this.AnswerLettersSelector_Load);
            this.ResumeLayout(false);

		}
		#endregion

		private void ComponentInitialization()
		{		
			this.SuspendLayout();

			this.RadioButtons = new System.Windows.Forms.RadioButton[Length, 2];
            this.Panels = new System.Windows.Forms.Panel[Length];
			int TabIndex = 0;
            for (int i = 0; i < Length; i++)
			{
				this.Panels[i] = new Panel();
                this.Panels[i].Location = new System.Drawing.Point(LetterButtonWidth * (Length - 1 - i), 0);
                this.Panels[i].Size = new System.Drawing.Size(LetterButtonWidth, Length * LetterButtonWidth);

				for (int j=0;j<2;j++)
				{
					this.RadioButtons[i, j] = new RadioButton();
					this.RadioButtons[i, j].Appearance = System.Windows.Forms.Appearance.Button;
					this.RadioButtons[i, j].TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
					this.RadioButtons[i, j].Location = new System.Drawing.Point(0, LetterButtonWidth*j);
					this.RadioButtons[i, j].Size = new System.Drawing.Size(LetterButtonWidth, LetterButtonWidth);
					this.RadioButtons[i, j].TabIndex = TabIndex++;
					this.RadioButtons[i, j].Text = " ";
					this.RadioButtons[i, j].Tag = i.ToString()+", "+j.ToString();
					this.RadioButtons[i, j].CheckedChanged += new System.EventHandler(this.RadioButtons_CheckedChanged);
					this.Panels[i].Controls.Add(this.RadioButtons[i, j]);
				}				
				
				this.MainPanel.Controls.Add(this.Panels[i]);
				Loaded = true;
			}			
			this.ResumeLayout(false);
			
		}

		
		private void AnswerLettersSelector_Load(object sender, System.EventArgs e)
		{
			
		}

		private void RadioButtons_CheckedChanged(object sender, System.EventArgs e)
		{
			String TagString = (String)((System.Windows.Forms.RadioButton) sender).Tag;
			int CommaIndex = TagString.IndexOf(",");
			int i = Convert.ToInt16(TagString.Substring(0,CommaIndex));
			int j = Convert.ToInt16(TagString.Substring(CommaIndex+1,TagString.Length-CommaIndex-1));
			Refresh();			
		}

		private void Refresh()
		{
			if (! Loaded) return;
			String TempSelectedAnswer = String.Empty;
			char SelectedLetter = '_';
			for (int i=0;i<Length;i++)
			{
				SelectedLetter = '_';
				for (int j=0;j<2;j++)
					if (this.RadioButtons[i, j].Checked)
					{
						this.RadioButtons[i, j].BackColor = this.SelectedLetterButtonBackColor;
						this.RadioButtons[i, j].ForeColor = this.SelectedLetterButtonForeColor;
						SelectedLetter = Convert.ToChar(this.RadioButtons[i, j].Text.Substring(0,1));
						if (SelectedLetter == ' ') 
							SelectedLetter = '_';
					}
					else
					{
						this.RadioButtons[i, j].BackColor = this.UnselectedLetterButtonBackColor;						
						this.RadioButtons[i, j].ForeColor = this.UnselectedLetterButtonForeColor;						
					}
				TempSelectedAnswer += SelectedLetter;
			}
			this.selectedAnswer = TempSelectedAnswer;
			if (this.selectedAnswerChanged != null)
			{
				SelectedAnswerChangedDelegate handler = new SelectedAnswerChangedDelegate(this.selectedAnswerChanged);
				handler();

			}

					
		}

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

		
	}
}
