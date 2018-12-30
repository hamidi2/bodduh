namespace Boddooh
{
    partial class FormInputList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputList));
            this.groupBoxInputText = new System.Windows.Forms.GroupBox();
            this.lblRankWODFBSTM = new System.Windows.Forms.Label();
            this.lblRankWODFRTL = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMinorASWODFBSTM = new System.Windows.Forms.Label();
            this.lblLengthWODFBSTM = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblRankWD = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMinorASWD = new System.Windows.Forms.Label();
            this.lblMinorASWODFRTL = new System.Windows.Forms.Label();
            this.lblLengthWD = new System.Windows.Forms.Label();
            this.lblLengthWODFRTL = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputText = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxInputList = new System.Windows.Forms.GroupBox();
            this.dataGridViewInputList = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InputText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtoView = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSelect = new System.Windows.Forms.ToolStripButton();
            this.con = new System.Data.OleDb.OleDbConnection();
            this.da = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.da2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.da3 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect = new System.Windows.Forms.CheckBox();
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect = new System.Windows.Forms.CheckBox();
            this.groupBoxInputText.SuspendLayout();
            this.groupBoxInputList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputList)).BeginInit();
            this.toolStripMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxInputText
            // 
            this.groupBoxInputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInputText.Controls.Add(this.lblRankWODFBSTM);
            this.groupBoxInputText.Controls.Add(this.lblRankWODFRTL);
            this.groupBoxInputText.Controls.Add(this.label12);
            this.groupBoxInputText.Controls.Add(this.label11);
            this.groupBoxInputText.Controls.Add(this.lblMinorASWODFBSTM);
            this.groupBoxInputText.Controls.Add(this.lblLengthWODFBSTM);
            this.groupBoxInputText.Controls.Add(this.label9);
            this.groupBoxInputText.Controls.Add(this.label10);
            this.groupBoxInputText.Controls.Add(this.lblRankWD);
            this.groupBoxInputText.Controls.Add(this.label7);
            this.groupBoxInputText.Controls.Add(this.lblMinorASWD);
            this.groupBoxInputText.Controls.Add(this.lblMinorASWODFRTL);
            this.groupBoxInputText.Controls.Add(this.lblLengthWD);
            this.groupBoxInputText.Controls.Add(this.lblLengthWODFRTL);
            this.groupBoxInputText.Controls.Add(this.label4);
            this.groupBoxInputText.Controls.Add(this.label5);
            this.groupBoxInputText.Controls.Add(this.label3);
            this.groupBoxInputText.Controls.Add(this.label2);
            this.groupBoxInputText.Controls.Add(this.txtInputText);
            this.groupBoxInputText.Controls.Add(this.buttonOk);
            this.groupBoxInputText.Controls.Add(this.buttonCancel);
            this.groupBoxInputText.Controls.Add(this.label1);
            this.groupBoxInputText.Enabled = false;
            this.groupBoxInputText.Location = new System.Drawing.Point(0, 290);
            this.groupBoxInputText.Name = "groupBoxInputText";
            this.groupBoxInputText.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBoxInputText.Size = new System.Drawing.Size(898, 204);
            this.groupBoxInputText.TabIndex = 1;
            this.groupBoxInputText.TabStop = false;
            // 
            // lblRankWODFBSTM
            // 
            this.lblRankWODFBSTM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRankWODFBSTM.Location = new System.Drawing.Point(124, 168);
            this.lblRankWODFBSTM.Name = "lblRankWODFBSTM";
            this.lblRankWODFBSTM.Size = new System.Drawing.Size(41, 19);
            this.lblRankWODFBSTM.TabIndex = 24;
            this.lblRankWODFBSTM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblRankWODFRTL
            // 
            this.lblRankWODFRTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRankWODFRTL.Location = new System.Drawing.Point(124, 137);
            this.lblRankWODFRTL.Name = "lblRankWODFRTL";
            this.lblRankWODFRTL.Size = new System.Drawing.Size(41, 19);
            this.lblRankWODFRTL.TabIndex = 23;
            this.lblRankWODFRTL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(166, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 19);
            this.label12.TabIndex = 22;
            this.label12.Text = "امتیاز:";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(166, 137);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 19);
            this.label11.TabIndex = 21;
            this.label11.Text = "امتیاز:";
            // 
            // lblMinorASWODFBSTM
            // 
            this.lblMinorASWODFBSTM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinorASWODFBSTM.Location = new System.Drawing.Point(195, 168);
            this.lblMinorASWODFBSTM.Name = "lblMinorASWODFBSTM";
            this.lblMinorASWODFBSTM.Size = new System.Drawing.Size(172, 19);
            this.lblMinorASWODFBSTM.TabIndex = 20;
            this.lblMinorASWODFBSTM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLengthWODFBSTM
            // 
            this.lblLengthWODFBSTM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLengthWODFBSTM.Location = new System.Drawing.Point(513, 168);
            this.lblLengthWODFBSTM.Name = "lblLengthWODFBSTM";
            this.lblLengthWODFBSTM.Size = new System.Drawing.Size(35, 19);
            this.lblLengthWODFBSTM.TabIndex = 19;
            this.lblLengthWODFBSTM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(348, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "جمع ابجد کوچک:";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(548, 168);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(344, 19);
            this.label10.TabIndex = 17;
            this.label10.Text = "با حذف حروف تکراری از طرفین - تعداد حروف:";
            // 
            // lblRankWD
            // 
            this.lblRankWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRankWD.Location = new System.Drawing.Point(124, 106);
            this.lblRankWD.Name = "lblRankWD";
            this.lblRankWD.Size = new System.Drawing.Size(41, 19);
            this.lblRankWD.TabIndex = 16;
            this.lblRankWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(166, 106);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "امتیاز:";
            // 
            // lblMinorASWD
            // 
            this.lblMinorASWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinorASWD.Location = new System.Drawing.Point(195, 106);
            this.lblMinorASWD.Name = "lblMinorASWD";
            this.lblMinorASWD.Size = new System.Drawing.Size(172, 19);
            this.lblMinorASWD.TabIndex = 14;
            this.lblMinorASWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMinorASWODFRTL
            // 
            this.lblMinorASWODFRTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinorASWODFRTL.Location = new System.Drawing.Point(195, 137);
            this.lblMinorASWODFRTL.Name = "lblMinorASWODFRTL";
            this.lblMinorASWODFRTL.Size = new System.Drawing.Size(172, 19);
            this.lblMinorASWODFRTL.TabIndex = 13;
            this.lblMinorASWODFRTL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLengthWD
            // 
            this.lblLengthWD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLengthWD.Location = new System.Drawing.Point(490, 106);
            this.lblLengthWD.Name = "lblLengthWD";
            this.lblLengthWD.Size = new System.Drawing.Size(58, 19);
            this.lblLengthWD.TabIndex = 12;
            this.lblLengthWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLengthWODFRTL
            // 
            this.lblLengthWODFRTL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLengthWODFRTL.Location = new System.Drawing.Point(513, 137);
            this.lblLengthWODFRTL.Name = "lblLengthWODFRTL";
            this.lblLengthWODFRTL.Size = new System.Drawing.Size(35, 19);
            this.lblLengthWODFRTL.TabIndex = 11;
            this.lblLengthWODFRTL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(348, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "جمع ابجد کوچک:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(548, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "با حذف حروف تکراری از راست - تعداد حروف:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "جمع ابجد کوچک:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(548, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "بدون حذف حروف تکراری - تعداد حروف:";
            // 
            // txtInputText
            // 
            this.txtInputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputText.Location = new System.Drawing.Point(6, 26);
            this.txtInputText.Multiline = true;
            this.txtInputText.Name = "txtInputText";
            this.txtInputText.Size = new System.Drawing.Size(776, 67);
            this.txtInputText.TabIndex = 0;
            this.txtInputText.TextChanged += new System.EventHandler(this.txtInputText_TextChanged);
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonOk.Location = new System.Drawing.Point(6, 106);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(107, 35);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "تایید";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(6, 152);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(107, 35);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "انصراف";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(788, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "متن ورودی:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(6, 503);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 32);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "بستن";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBoxInputList
            // 
            this.groupBoxInputList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxInputList.Controls.Add(this.dataGridViewInputList);
            this.groupBoxInputList.Controls.Add(this.toolStripMainMenu);
            this.groupBoxInputList.Location = new System.Drawing.Point(0, -23);
            this.groupBoxInputList.Name = "groupBoxInputList";
            this.groupBoxInputList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBoxInputList.Size = new System.Drawing.Size(898, 310);
            this.groupBoxInputList.TabIndex = 0;
            this.groupBoxInputList.TabStop = false;
            // 
            // dataGridViewInputList
            // 
            this.dataGridViewInputList.AllowUserToAddRows = false;
            this.dataGridViewInputList.AllowUserToDeleteRows = false;
            this.dataGridViewInputList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInputList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInputList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.InputText,
            this.wd,
            this.wod});
            this.dataGridViewInputList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewInputList.Location = new System.Drawing.Point(3, 70);
            this.dataGridViewInputList.MultiSelect = false;
            this.dataGridViewInputList.Name = "dataGridViewInputList";
            this.dataGridViewInputList.ReadOnly = true;
            this.dataGridViewInputList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridViewInputList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInputList.ShowEditingIcon = false;
            this.dataGridViewInputList.Size = new System.Drawing.Size(892, 237);
            this.dataGridViewInputList.TabIndex = 0;
            this.dataGridViewInputList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInputList_CellContentClick);
            this.dataGridViewInputList.DoubleClick += new System.EventHandler(this.dataGridViewInputList_DoubleClick);
            this.dataGridViewInputList.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewInputList_KeyPress);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "شناسه";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 5;
            // 
            // InputText
            // 
            this.InputText.DataPropertyName = "inputtext";
            this.InputText.FillWeight = 400F;
            this.InputText.HeaderText = "متن ورودی";
            this.InputText.Name = "InputText";
            this.InputText.ReadOnly = true;
            this.InputText.Width = 600;
            // 
            // wd
            // 
            this.wd.DataPropertyName = "WD";
            this.wd.HeaderText = "بدون حذف تکراری";
            this.wd.Name = "wd";
            this.wd.ReadOnly = true;
            this.wd.Width = 275;
            // 
            // wod
            // 
            this.wod.DataPropertyName = "wod";
            this.wod.HeaderText = "با حذف تکراری ها";
            this.wod.Name = "wod";
            this.wod.ReadOnly = true;
            this.wod.Width = 500;
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMainMenu.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonNew,
            this.toolStripButtoView,
            this.toolStripButtonEdit,
            this.toolStripButtonDelete,
            this.toolStripButtonSelect});
            this.toolStripMainMenu.Location = new System.Drawing.Point(3, 23);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMainMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripMainMenu.Size = new System.Drawing.Size(892, 47);
            this.toolStripMainMenu.TabIndex = 1;
            this.toolStripMainMenu.TabStop = true;
            this.toolStripMainMenu.Text = "toolStripMainMenu";
            // 
            // toolStripButtonNew
            // 
            this.toolStripButtonNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripButtonNew.Image = global::Boddooh.Properties.Resources.Add;
            this.toolStripButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonNew.Name = "toolStripButtonNew";
            this.toolStripButtonNew.Size = new System.Drawing.Size(141, 44);
            this.toolStripButtonNew.Text = "ورودی جدید";
            this.toolStripButtonNew.Click += new System.EventHandler(this.toolStripButtonNew_Click);
            // 
            // toolStripButtoView
            // 
            this.toolStripButtoView.Image = global::Boddooh.Properties.Resources.View;
            this.toolStripButtoView.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtoView.Name = "toolStripButtoView";
            this.toolStripButtoView.Size = new System.Drawing.Size(169, 44);
            this.toolStripButtoView.Text = "مشاهده ورودی";
            this.toolStripButtoView.Click += new System.EventHandler(this.toolStripButtonView_Click);
            // 
            // toolStripButtonEdit
            // 
            this.toolStripButtonEdit.Image = global::Boddooh.Properties.Resources.Edit;
            this.toolStripButtonEdit.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonEdit.Name = "toolStripButtonEdit";
            this.toolStripButtonEdit.Size = new System.Drawing.Size(159, 44);
            this.toolStripButtonEdit.Text = "ویرایش ورودی";
            this.toolStripButtonEdit.Click += new System.EventHandler(this.toolStripButtonEdit_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::Boddooh.Properties.Resources.Delete;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(143, 44);
            this.toolStripButtonDelete.Text = "حذف ورودی";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripButtonSelect
            // 
            this.toolStripButtonSelect.Image = global::Boddooh.Properties.Resources.Select;
            this.toolStripButtonSelect.ImageTransparentColor = System.Drawing.Color.White;
            this.toolStripButtonSelect.Name = "toolStripButtonSelect";
            this.toolStripButtonSelect.Size = new System.Drawing.Size(153, 44);
            this.toolStripButtonSelect.Text = "انتخاب ورودی";
            this.toolStripButtonSelect.Click += new System.EventHandler(this.toolStripButtonSelect_Click);
            // 
            // con
            // 
            this.con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=InputList.mdb";
            // 
            // da
            // 
            this.da.DeleteCommand = this.oleDbCommand1;
            this.da.InsertCommand = this.oleDbCommand2;
            this.da.SelectCommand = this.oleDbCommand3;
            this.da.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.da.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand1.Connection = this.con;
            this.oleDbCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = resources.GetString("oleDbCommand2.CommandText");
            this.oleDbCommand2.Connection = this.con;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, "id"),
            new System.Data.OleDb.OleDbParameter("wd", System.Data.OleDb.OleDbType.WChar, 255, "wd"),
            new System.Data.OleDb.OleDbParameter("wod", System.Data.OleDb.OleDbType.WChar, 255, "wod"),
            new System.Data.OleDb.OleDbParameter("inputtext1", System.Data.OleDb.OleDbType.WChar, 255, "inputtext1"),
            new System.Data.OleDb.OleDbParameter("inputtext2", System.Data.OleDb.OleDbType.WChar, 255, "inputtext2"),
            new System.Data.OleDb.OleDbParameter("inputtext3", System.Data.OleDb.OleDbType.WChar, 255, "inputtext3"),
            new System.Data.OleDb.OleDbParameter("inputtext4", System.Data.OleDb.OleDbType.WChar, 255, "inputtext4"),
            new System.Data.OleDb.OleDbParameter("inputtext5", System.Data.OleDb.OleDbType.WChar, 255, "inputtext5"),
            new System.Data.OleDb.OleDbParameter("inputtext6", System.Data.OleDb.OleDbType.WChar, 255, "inputtext6"),
            new System.Data.OleDb.OleDbParameter("inputtext7", System.Data.OleDb.OleDbType.WChar, 255, "inputtext7"),
            new System.Data.OleDb.OleDbParameter("inputtext8", System.Data.OleDb.OleDbType.WChar, 255, "inputtext8"),
            new System.Data.OleDb.OleDbParameter("inputtext9", System.Data.OleDb.OleDbType.WChar, 255, "inputtext9"),
            new System.Data.OleDb.OleDbParameter("inputtext10", System.Data.OleDb.OleDbType.WChar, 255, "inputtext10"),
            new System.Data.OleDb.OleDbParameter("inputtext11", System.Data.OleDb.OleDbType.WChar, 255, "inputtext11"),
            new System.Data.OleDb.OleDbParameter("inputtext12", System.Data.OleDb.OleDbType.WChar, 255, "inputtext12"),
            new System.Data.OleDb.OleDbParameter("inputtext13", System.Data.OleDb.OleDbType.WChar, 255, "inputtext13"),
            new System.Data.OleDb.OleDbParameter("inputtext14", System.Data.OleDb.OleDbType.WChar, 255, "inputtext14"),
            new System.Data.OleDb.OleDbParameter("inputtext15", System.Data.OleDb.OleDbType.WChar, 255, "inputtext15"),
            new System.Data.OleDb.OleDbParameter("inputtext16", System.Data.OleDb.OleDbType.WChar, 255, "inputtext16"),
            new System.Data.OleDb.OleDbParameter("inputtext17", System.Data.OleDb.OleDbType.WChar, 255, "inputtext17"),
            new System.Data.OleDb.OleDbParameter("inputtext18", System.Data.OleDb.OleDbType.WChar, 255, "inputtext18"),
            new System.Data.OleDb.OleDbParameter("inputtext19", System.Data.OleDb.OleDbType.WChar, 255, "inputtext19"),
            new System.Data.OleDb.OleDbParameter("inputtext20", System.Data.OleDb.OleDbType.WChar, 255, "inputtext20")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.con;
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = resources.GetString("oleDbCommand4.CommandText");
            this.oleDbCommand4.Connection = this.con;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("wd", System.Data.OleDb.OleDbType.WChar, 255, "wd"),
            new System.Data.OleDb.OleDbParameter("wod", System.Data.OleDb.OleDbType.WChar, 255, "wod"),
            new System.Data.OleDb.OleDbParameter("inputtext1", System.Data.OleDb.OleDbType.WChar, 255, "inputtext1"),
            new System.Data.OleDb.OleDbParameter("inputtext2", System.Data.OleDb.OleDbType.WChar, 255, "inputtext2"),
            new System.Data.OleDb.OleDbParameter("inputtext3", System.Data.OleDb.OleDbType.WChar, 255, "inputtext3"),
            new System.Data.OleDb.OleDbParameter("inputtext4", System.Data.OleDb.OleDbType.WChar, 255, "inputtext4"),
            new System.Data.OleDb.OleDbParameter("inputtext5", System.Data.OleDb.OleDbType.WChar, 255, "inputtext5"),
            new System.Data.OleDb.OleDbParameter("inputtext6", System.Data.OleDb.OleDbType.WChar, 255, "inputtext6"),
            new System.Data.OleDb.OleDbParameter("inputtext7", System.Data.OleDb.OleDbType.WChar, 255, "inputtext7"),
            new System.Data.OleDb.OleDbParameter("inputtext8", System.Data.OleDb.OleDbType.WChar, 255, "inputtext8"),
            new System.Data.OleDb.OleDbParameter("inputtext9", System.Data.OleDb.OleDbType.WChar, 255, "inputtext9"),
            new System.Data.OleDb.OleDbParameter("inputtext10", System.Data.OleDb.OleDbType.WChar, 255, "inputtext10"),
            new System.Data.OleDb.OleDbParameter("inputtext11", System.Data.OleDb.OleDbType.WChar, 255, "inputtext11"),
            new System.Data.OleDb.OleDbParameter("inputtext12", System.Data.OleDb.OleDbType.WChar, 255, "inputtext12"),
            new System.Data.OleDb.OleDbParameter("inputtext13", System.Data.OleDb.OleDbType.WChar, 255, "inputtext13"),
            new System.Data.OleDb.OleDbParameter("inputtext14", System.Data.OleDb.OleDbType.WChar, 255, "inputtext14"),
            new System.Data.OleDb.OleDbParameter("inputtext15", System.Data.OleDb.OleDbType.WChar, 255, "inputtext15"),
            new System.Data.OleDb.OleDbParameter("inputtext16", System.Data.OleDb.OleDbType.WChar, 255, "inputtext16"),
            new System.Data.OleDb.OleDbParameter("inputtext17", System.Data.OleDb.OleDbType.WChar, 255, "inputtext17"),
            new System.Data.OleDb.OleDbParameter("inputtext18", System.Data.OleDb.OleDbType.WChar, 255, "inputtext18"),
            new System.Data.OleDb.OleDbParameter("inputtext19", System.Data.OleDb.OleDbType.WChar, 255, "inputtext19"),
            new System.Data.OleDb.OleDbParameter("inputtext20", System.Data.OleDb.OleDbType.WChar, 255, "inputtext20"),
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // da2
            // 
            this.da2.DeleteCommand = this.oleDbCommand5;
            this.da2.InsertCommand = this.oleDbCommand6;
            this.da2.SelectCommand = this.oleDbCommand7;
            this.da2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.da2.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand5.Connection = this.con;
            this.oleDbCommand5.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO Inputs\r\n                      (id, wod, wd, inputtext)\r\nVALUES     (?" +
                ", ?, ?, ?)";
            this.oleDbCommand6.Connection = this.con;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, "id"),
            new System.Data.OleDb.OleDbParameter("wod", System.Data.OleDb.OleDbType.WChar, 255, "wod"),
            new System.Data.OleDb.OleDbParameter("wd", System.Data.OleDb.OleDbType.WChar, 255, "wd"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT     MAX(id) AS maxid\r\nFROM         Inputs";
            this.oleDbCommand7.Connection = this.con;
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = "UPDATE    Inputs\r\nSET              wod = ?, wd = ?, inputtext = ?\r\nWHERE     (id " +
                "= ?)";
            this.oleDbCommand8.Connection = this.con;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("wod", System.Data.OleDb.OleDbType.WChar, 255, "wod"),
            new System.Data.OleDb.OleDbParameter("wd", System.Data.OleDb.OleDbType.WChar, 255, "wd"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext"),
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // da3
            // 
            this.da3.DeleteCommand = this.oleDbCommand9;
            this.da3.InsertCommand = this.oleDbCommand10;
            this.da3.SelectCommand = this.oleDbCommand11;
            this.da3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.da3.UpdateCommand = this.oleDbCommand12;
            // 
            // oleDbCommand9
            // 
            this.oleDbCommand9.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand9.Connection = this.con;
            this.oleDbCommand9.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand10
            // 
            this.oleDbCommand10.CommandText = "INSERT INTO Inputs\r\n                      (id, wod, wd, inputtext)\r\nVALUES     (?" +
                ", ?, ?, ?)";
            this.oleDbCommand10.Connection = this.con;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, "id"),
            new System.Data.OleDb.OleDbParameter("wod", System.Data.OleDb.OleDbType.WChar, 255, "wod"),
            new System.Data.OleDb.OleDbParameter("wd", System.Data.OleDb.OleDbType.WChar, 255, "wd"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext")});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = resources.GetString("oleDbCommand11.CommandText");
            this.oleDbCommand11.Connection = this.con;
            this.oleDbCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, "id")});
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = "UPDATE    Inputs\r\nSET              wod = ?, wd = ?, inputtext = ?\r\nWHERE     (id " +
                "= ?)";
            this.oleDbCommand12.Connection = this.con;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("wod", System.Data.OleDb.OleDbType.WChar, 255, "wod"),
            new System.Data.OleDb.OleDbParameter("wd", System.Data.OleDb.OleDbType.WChar, 255, "wd"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext"),
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect
            // 
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.AutoSize = true;
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Location = new System.Drawing.Point(586, 509);
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Name = "chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect";
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Size = new System.Drawing.Size(309, 23);
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.TabIndex = 2;
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Text = "حذف تکراری ها از راست قبل از انتخاب";
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.UseVisualStyleBackColor = true;
            this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.CheckedChanged += new System.EventHandler(this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect_CheckedChanged);
            // 
            // chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect
            // 
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.AutoSize = true;
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Location = new System.Drawing.Point(271, 509);
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Name = "chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect";
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Size = new System.Drawing.Size(314, 23);
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.TabIndex = 3;
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Text = "حذف تکراری ها از طرفین قبل از انتخاب";
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.UseVisualStyleBackColor = true;
            this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.CheckedChanged += new System.EventHandler(this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect_CheckedChanged);
            // 
            // FormInputList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 547);
            this.Controls.Add(this.chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect);
            this.Controls.Add(this.chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect);
            this.Controls.Add(this.groupBoxInputList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBoxInputText);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormInputList";
            this.Text = " :: لیست ورودیها :: ";
            this.Load += new System.EventHandler(this.FormInputList_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormInputList_KeyPress);
            this.groupBoxInputText.ResumeLayout(false);
            this.groupBoxInputText.PerformLayout();
            this.groupBoxInputList.ResumeLayout(false);
            this.groupBoxInputList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInputList)).EndInit();
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxInputText;
        private System.Windows.Forms.TextBox txtInputText;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxInputList;
        private System.Windows.Forms.DataGridView dataGridViewInputList;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private System.Windows.Forms.ToolStripButton toolStripButtonNew;
        private System.Windows.Forms.ToolStripButton toolStripButtonEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelect;
        private System.Windows.Forms.Label lblMinorASWODFRTL;
        private System.Windows.Forms.Label lblLengthWD;
        private System.Windows.Forms.Label lblLengthWODFRTL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMinorASWD;
        private System.Windows.Forms.ToolStripButton toolStripButtoView;
        private InputListDataSet inputListDataSet;
        private System.Data.OleDb.OleDbConnection con;
        private System.Data.OleDb.OleDbDataAdapter da;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbDataAdapter da2;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbCommand6;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
        private System.Data.OleDb.OleDbDataAdapter da3;
        private System.Data.OleDb.OleDbCommand oleDbCommand9;
        private System.Data.OleDb.OleDbCommand oleDbCommand10;
        private System.Data.OleDb.OleDbCommand oleDbCommand11;
        private System.Data.OleDb.OleDbCommand oleDbCommand12;
        private System.Windows.Forms.CheckBox chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect;
        private System.Windows.Forms.CheckBox chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect;
        private System.Windows.Forms.Label lblRankWD;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMinorASWODFBSTM;
        private System.Windows.Forms.Label lblLengthWODFBSTM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblRankWODFBSTM;
        private System.Windows.Forms.Label lblRankWODFRTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn InputText;
        private System.Windows.Forms.DataGridViewTextBoxColumn wd;
        private System.Windows.Forms.DataGridViewTextBoxColumn wod;
    }
}