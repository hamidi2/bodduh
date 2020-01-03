namespace Boddooh
{
    partial class FormInputManagment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInputManagment));
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBoxInputList = new System.Windows.Forms.GroupBox();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripMainMenu = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsddlLength = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnView = new System.Windows.Forms.ToolStripButton();
            this.con = new System.Data.OleDb.OleDbConnection();
            this.DA_Transactions = new System.Data.OleDb.OleDbDataAdapter();
            this.DeleteComTransactions = new System.Data.OleDb.OleDbCommand();
            this.InsertComTransactions = new System.Data.OleDb.OleDbCommand();
            this.SelectCommand = new System.Data.OleDb.OleDbCommand();
            this.UpdateCom1 = new System.Data.OleDb.OleDbCommand();
            this.btnInitialize = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvGeneratedInputs = new System.Windows.Forms.DataGridView();
            this.inputtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isselected = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtLengthG = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtStartG = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tstxtMinRankG = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnViewG = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tstxtMaxRankG = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnGenerateG = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsBtnGenerateG1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnGenerateG2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsBtnStopGeneration = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSelectInput = new System.Windows.Forms.ToolStripButton();
            this.tsBtnProcessInput = new System.Windows.Forms.ToolStripButton();
            this.DA_GeneratedInputs = new System.Data.OleDb.OleDbDataAdapter();
            this.DeleteComGeneratedInputs = new System.Data.OleDb.OleDbCommand();
            this.InsetComGeneratedInputs = new System.Data.OleDb.OleDbCommand();
            this.SelectComGeneratedInputs = new System.Data.OleDb.OleDbCommand();
            this.UpdateComGeneratedInputs = new System.Data.OleDb.OleDbCommand();
            this.SaveTimer = new System.Windows.Forms.Timer(this.components);
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DA_Transactions2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.lblStatus = new System.Windows.Forms.Label();
            this.DA_GeneratedInputs2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBoxInputList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.toolStripMainMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneratedInputs)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(6, 353);
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
            this.groupBoxInputList.Controls.Add(this.dgvTransactions);
            this.groupBoxInputList.Controls.Add(this.toolStripMainMenu);
            this.groupBoxInputList.Location = new System.Drawing.Point(965, -23);
            this.groupBoxInputList.Name = "groupBoxInputList";
            this.groupBoxInputList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBoxInputList.Size = new System.Drawing.Size(253, 370);
            this.groupBoxInputList.TabIndex = 0;
            this.groupBoxInputList.TabStop = false;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.length,
            this.start,
            this.state});
            this.dgvTransactions.Location = new System.Drawing.Point(6, 73);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.ShowEditingIcon = false;
            this.dgvTransactions.Size = new System.Drawing.Size(244, 291);
            this.dgvTransactions.TabIndex = 0;
            this.dgvTransactions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransactions_CellContentClick);
            this.dgvTransactions.SelectionChanged += new System.EventHandler(this.dataGridViewInputList_SelectionChanged);
            this.dgvTransactions.DoubleClick += new System.EventHandler(this.dataGridViewInputList_DoubleClick);
            this.dgvTransactions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewInputList_KeyPress);
            // 
            // length
            // 
            this.length.DataPropertyName = "length";
            this.length.FillWeight = 400F;
            this.length.HeaderText = "طول";
            this.length.Name = "length";
            this.length.ReadOnly = true;
            this.length.Width = 50;
            // 
            // start
            // 
            this.start.DataPropertyName = "start";
            this.start.HeaderText = "شروع";
            this.start.Name = "start";
            this.start.ReadOnly = true;
            this.start.Width = 60;
            // 
            // state
            // 
            this.state.DataPropertyName = "state";
            this.state.HeaderText = "وضعیت";
            this.state.Name = "state";
            this.state.ReadOnly = true;
            this.state.Width = 150;
            // 
            // toolStripMainMenu
            // 
            this.toolStripMainMenu.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMainMenu.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStripMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsddlLength,
            this.toolStripSeparator2,
            this.tsBtnView});
            this.toolStripMainMenu.Location = new System.Drawing.Point(3, 23);
            this.toolStripMainMenu.Name = "toolStripMainMenu";
            this.toolStripMainMenu.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStripMainMenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStripMainMenu.Size = new System.Drawing.Size(247, 32);
            this.toolStripMainMenu.TabIndex = 1;
            this.toolStripMainMenu.TabStop = true;
            this.toolStripMainMenu.Text = "toolStripMainMenu";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(70, 29);
            this.toolStripLabel1.Text = "طول ورودی:";
            // 
            // tsddlLength
            // 
            this.tsddlLength.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsddlLength.Name = "tsddlLength";
            this.tsddlLength.Size = new System.Drawing.Size(75, 32);
            this.tsddlLength.SelectedIndexChanged += new System.EventHandler(this.tsddlLength_SelectedIndexChanged);
            this.tsddlLength.Click += new System.EventHandler(this.tsddlLength_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // tsBtnView
            // 
            this.tsBtnView.Image = global::Boddooh.Properties.Resources.View;
            this.tsBtnView.ImageTransparentColor = System.Drawing.Color.White;
            this.tsBtnView.Name = "tsBtnView";
            this.tsBtnView.Size = new System.Drawing.Size(84, 29);
            this.tsBtnView.Text = "مشاهده ";
            this.tsBtnView.Click += new System.EventHandler(this.tsBtnView_Click);
            // 
            // con
            // 
            this.con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=InputList.mdb";
            // 
            // DA_Transactions
            // 
            this.DA_Transactions.DeleteCommand = this.DeleteComTransactions;
            this.DA_Transactions.InsertCommand = this.InsertComTransactions;
            this.DA_Transactions.SelectCommand = this.SelectCommand;
            this.DA_Transactions.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.DA_Transactions.UpdateCommand = this.UpdateCom1;
            // 
            // DeleteComTransactions
            // 
            this.DeleteComTransactions.CommandText = "DELETE FROM Transactions";
            this.DeleteComTransactions.Connection = this.con;
            // 
            // InsertComTransactions
            // 
            this.InsertComTransactions.CommandText = "INSERT INTO Transactions\r\n                      (length, [first], [second], third" +
                ", forth, method)\r\nVALUES     (?, ?, ?, ?, ?, ?)";
            this.InsertComTransactions.Connection = this.con;
            this.InsertComTransactions.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("second", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("third", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("forth", System.Data.OleDb.OleDbType.Integer, 0, "forth"),
            new System.Data.OleDb.OleDbParameter("method", System.Data.OleDb.OleDbType.Integer, 0, "method")});
            // 
            // SelectCommand
            // 
            this.SelectCommand.CommandText = resources.GetString("SelectCommand.CommandText");
            this.SelectCommand.Connection = this.con;
            this.SelectCommand.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("length1", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("method", System.Data.OleDb.OleDbType.Integer, 0, "method"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("first1", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("second", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("second1", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("third", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("third1", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("forth", System.Data.OleDb.OleDbType.Integer, 0, "forth"),
            new System.Data.OleDb.OleDbParameter("forth1", System.Data.OleDb.OleDbType.Integer, 0, "forth")});
            // 
            // UpdateCom1
            // 
            this.UpdateCom1.CommandText = "UPDATE    Transactions\r\nSET              state = ?\r\nWHERE     (length = ?) AND ([" +
                "first] = ?) AND ([second] = ?) AND (third = ?) AND (forth = ?)";
            this.UpdateCom1.Connection = this.con;
            this.UpdateCom1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("state", System.Data.OleDb.OleDbType.WChar, 50, "state"),
            new System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param3", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param4", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param5", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param6", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null)});
            // 
            // btnInitialize
            // 
            this.btnInitialize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInitialize.Location = new System.Drawing.Point(1014, 353);
            this.btnInitialize.Name = "btnInitialize";
            this.btnInitialize.Size = new System.Drawing.Size(201, 32);
            this.btnInitialize.TabIndex = 15;
            this.btnInitialize.Text = "پاک کردن همه اطلاعات";
            this.btnInitialize.UseVisualStyleBackColor = true;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvGeneratedInputs);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Location = new System.Drawing.Point(-3, -23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(968, 370);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dgvGeneratedInputs
            // 
            this.dgvGeneratedInputs.AllowUserToAddRows = false;
            this.dgvGeneratedInputs.AllowUserToDeleteRows = false;
            this.dgvGeneratedInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvGeneratedInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneratedInputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inputtext,
            this.rank,
            this.isselected});
            this.dgvGeneratedInputs.Location = new System.Drawing.Point(6, 73);
            this.dgvGeneratedInputs.MultiSelect = false;
            this.dgvGeneratedInputs.Name = "dgvGeneratedInputs";
            this.dgvGeneratedInputs.ReadOnly = true;
            this.dgvGeneratedInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvGeneratedInputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGeneratedInputs.ShowEditingIcon = false;
            this.dgvGeneratedInputs.Size = new System.Drawing.Size(956, 291);
            this.dgvGeneratedInputs.TabIndex = 0;
            // 
            // inputtext
            // 
            this.inputtext.DataPropertyName = "inputtext";
            this.inputtext.FillWeight = 400F;
            this.inputtext.HeaderText = "متن ورودی";
            this.inputtext.Name = "inputtext";
            this.inputtext.ReadOnly = true;
            this.inputtext.Width = 500;
            // 
            // rank
            // 
            this.rank.DataPropertyName = "rank";
            this.rank.HeaderText = "امتیاز";
            this.rank.Name = "rank";
            this.rank.ReadOnly = true;
            this.rank.Width = 80;
            // 
            // isselected
            // 
            this.isselected.DataPropertyName = "isselected";
            this.isselected.HeaderText = "حالت";
            this.isselected.Name = "isselected";
            this.isselected.ReadOnly = true;
            this.isselected.Width = 200;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.tstxtLengthG,
            this.toolStripLabel4,
            this.tstxtStartG,
            this.toolStripLabel3,
            this.tstxtMinRankG,
            this.toolStripSeparator1,
            this.tsBtnViewG,
            this.toolStripSeparator5,
            this.tsBtnDelete,
            this.tstxtMaxRankG,
            this.toolStripSeparator3,
            this.tsBtnGenerateG,
            this.tsBtnStopGeneration,
            this.toolStripSeparator4,
            this.tsBtnSelectInput,
            this.tsBtnProcessInput});
            this.toolStrip1.Location = new System.Drawing.Point(3, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.toolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.toolStrip1.Size = new System.Drawing.Size(962, 32);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.TabStop = true;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 29);
            this.toolStripLabel2.Text = "طول :";
            // 
            // tstxtLengthG
            // 
            this.tstxtLengthG.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstxtLengthG.Name = "tstxtLengthG";
            this.tstxtLengthG.Size = new System.Drawing.Size(40, 32);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(45, 29);
            this.toolStripLabel4.Text = " شروع:";
            // 
            // tstxtStartG
            // 
            this.tstxtStartG.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstxtStartG.Name = "tstxtStartG";
            this.tstxtStartG.Size = new System.Drawing.Size(60, 32);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(74, 29);
            this.toolStripLabel3.Text = "حداقل امتیاز:";
            // 
            // tstxtMinRankG
            // 
            this.tstxtMinRankG.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstxtMinRankG.Name = "tstxtMinRankG";
            this.tstxtMinRankG.Size = new System.Drawing.Size(40, 32);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // tsBtnViewG
            // 
            this.tsBtnViewG.Image = global::Boddooh.Properties.Resources.View;
            this.tsBtnViewG.ImageTransparentColor = System.Drawing.Color.White;
            this.tsBtnViewG.Name = "tsBtnViewG";
            this.tsBtnViewG.Size = new System.Drawing.Size(84, 29);
            this.tsBtnViewG.Text = "مشاهده ";
            this.tsBtnViewG.Click += new System.EventHandler(this.tsBtnViewG_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 32);
            // 
            // tsBtnDelete
            // 
            this.tsBtnDelete.Image = global::Boddooh.Properties.Resources.Delete;
            this.tsBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnDelete.Name = "tsBtnDelete";
            this.tsBtnDelete.Size = new System.Drawing.Size(208, 29);
            this.tsBtnDelete.Text = "حذف ورودی های با امتیاز کمتر از:";
            this.tsBtnDelete.ToolTipText = "حذف ورودی های با امتیاز کمتر از:";
            this.tsBtnDelete.Click += new System.EventHandler(this.tsBtnDelete_Click);
            // 
            // tstxtMaxRankG
            // 
            this.tstxtMaxRankG.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tstxtMaxRankG.Name = "tstxtMaxRankG";
            this.tstxtMaxRankG.Size = new System.Drawing.Size(40, 32);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 32);
            // 
            // tsBtnGenerateG
            // 
            this.tsBtnGenerateG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGenerateG1,
            this.tsBtnGenerateG2});
            this.tsBtnGenerateG.Image = global::Boddooh.Properties.Resources.b;
            this.tsBtnGenerateG.ImageTransparentColor = System.Drawing.Color.White;
            this.tsBtnGenerateG.Name = "tsBtnGenerateG";
            this.tsBtnGenerateG.Size = new System.Drawing.Size(69, 29);
            this.tsBtnGenerateG.Text = "تولید";
            this.tsBtnGenerateG.ToolTipText = "تولید ورودی";
            // 
            // tsBtnGenerateG1
            // 
            this.tsBtnGenerateG1.Name = "tsBtnGenerateG1";
            this.tsBtnGenerateG1.Size = new System.Drawing.Size(173, 22);
            this.tsBtnGenerateG1.Text = "بر اساس روش اول";
            this.tsBtnGenerateG1.Click += new System.EventHandler(this.tsBtnGenerateG1_Click);
            // 
            // tsBtnGenerateG2
            // 
            this.tsBtnGenerateG2.Name = "tsBtnGenerateG2";
            this.tsBtnGenerateG2.Size = new System.Drawing.Size(173, 22);
            this.tsBtnGenerateG2.Text = "بر اساس روش دوم";
            this.tsBtnGenerateG2.Click += new System.EventHandler(this.tsBtnGenerateG2_Click);
            // 
            // tsBtnStopGeneration
            // 
            this.tsBtnStopGeneration.Image = global::Boddooh.Properties.Resources.Stop;
            this.tsBtnStopGeneration.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsBtnStopGeneration.Name = "tsBtnStopGeneration";
            this.tsBtnStopGeneration.Size = new System.Drawing.Size(64, 29);
            this.tsBtnStopGeneration.Text = "توقف";
            this.tsBtnStopGeneration.ToolTipText = "توقف ساخت ورودی";
            this.tsBtnStopGeneration.Click += new System.EventHandler(this.tsBtnStopGeneration_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 32);
            // 
            // tsBtnSelectInput
            // 
            this.tsBtnSelectInput.Image = global::Boddooh.Properties.Resources.Select;
            this.tsBtnSelectInput.ImageTransparentColor = System.Drawing.Color.White;
            this.tsBtnSelectInput.Name = "tsBtnSelectInput";
            this.tsBtnSelectInput.Size = new System.Drawing.Size(139, 29);
            this.tsBtnSelectInput.Text = "انتخاب / عدم انتخاب";
            this.tsBtnSelectInput.ToolTipText = "انتخاب / عدم انتخاب ورودی";
            this.tsBtnSelectInput.Click += new System.EventHandler(this.tsBtnSelectInput_Click);
            // 
            // tsBtnProcessInput
            // 
            this.tsBtnProcessInput.Image = global::Boddooh.Properties.Resources.Arrow_Back;
            this.tsBtnProcessInput.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnProcessInput.Name = "tsBtnProcessInput";
            this.tsBtnProcessInput.Size = new System.Drawing.Size(76, 29);
            this.tsBtnProcessInput.Text = "پردازش";
            this.tsBtnProcessInput.ToolTipText = "پردازش ورودی";
            this.tsBtnProcessInput.Click += new System.EventHandler(this.tsBtnProcessInput_Click);
            // 
            // DA_GeneratedInputs
            // 
            this.DA_GeneratedInputs.DeleteCommand = this.DeleteComGeneratedInputs;
            this.DA_GeneratedInputs.InsertCommand = this.InsetComGeneratedInputs;
            this.DA_GeneratedInputs.SelectCommand = this.SelectComGeneratedInputs;
            this.DA_GeneratedInputs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.DA_GeneratedInputs.UpdateCommand = this.UpdateComGeneratedInputs;
            // 
            // DeleteComGeneratedInputs
            // 
            this.DeleteComGeneratedInputs.CommandText = "DELETE FROM GeneratedInputs\r\nWHERE     (length = ?) AND (start >= ?) AND (start <" +
                "= ?) AND (rank < ?)";
            this.DeleteComGeneratedInputs.Connection = this.con;
            this.DeleteComGeneratedInputs.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("start", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("start1", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "start", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("rank", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "rank", System.Data.DataRowVersion.Original, null)});
            // 
            // InsetComGeneratedInputs
            // 
            this.InsetComGeneratedInputs.CommandText = "INSERT INTO GeneratedInputs\r\n                      (length, inputtext, rank, isse" +
                "lected, method, [first], [second], third, forth)\r\nVALUES     (?, ?, ?, ?, ?, ?, " +
                "?, ?, ?)";
            this.InsetComGeneratedInputs.Connection = this.con;
            this.InsetComGeneratedInputs.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext"),
            new System.Data.OleDb.OleDbParameter("rank", System.Data.OleDb.OleDbType.Integer, 0, "rank"),
            new System.Data.OleDb.OleDbParameter("isselected", System.Data.OleDb.OleDbType.WChar, 255, "isselected"),
            new System.Data.OleDb.OleDbParameter("method", System.Data.OleDb.OleDbType.Integer, 0, "method"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("second", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("third", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("forth", System.Data.OleDb.OleDbType.Integer, 0, "forth")});
            // 
            // SelectComGeneratedInputs
            // 
            this.SelectComGeneratedInputs.CommandText = resources.GetString("SelectComGeneratedInputs.CommandText");
            this.SelectComGeneratedInputs.Connection = this.con;
            this.SelectComGeneratedInputs.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("rank", System.Data.OleDb.OleDbType.Integer, 0, "rank"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("first1", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("second", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("second1", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("third", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("third1", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("forth", System.Data.OleDb.OleDbType.Integer, 0, "forth"),
            new System.Data.OleDb.OleDbParameter("forth1", System.Data.OleDb.OleDbType.Integer, 0, "forth")});
            // 
            // UpdateComGeneratedInputs
            // 
            this.UpdateComGeneratedInputs.CommandText = "UPDATE    GeneratedInputs\r\nSET              isselected = ?\r\nWHERE     (inputtext " +
                "= ?)";
            this.UpdateComGeneratedInputs.Connection = this.con;
            this.UpdateComGeneratedInputs.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("isselected", System.Data.OleDb.OleDbType.WChar, 255, "isselected"),
            new System.Data.OleDb.OleDbParameter("Original_inputtext", System.Data.OleDb.OleDbType.WChar, 255, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "inputtext", System.Data.DataRowVersion.Original, null)});
            // 
            // SaveTimer
            // 
            this.SaveTimer.Interval = 60000;
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
            this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // oleDbDeleteCommand1
            // 
            this.oleDbDeleteCommand1.CommandText = "DELETE FROM personel\r\nWHERE        (id = ?)";
            this.oleDbDeleteCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.WChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbInsertCommand1
            // 
            this.oleDbInsertCommand1.CommandText = "INSERT INTO personel\r\n                         (id, name, type, kod)\r\nVALUES     " +
                "   (?, ?, ?, ?)";
            this.oleDbInsertCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.WChar, 50, "id"),
            new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.WChar, 50, "name"),
            new System.Data.OleDb.OleDbParameter("type", System.Data.OleDb.OleDbType.WChar, 50, "type"),
            new System.Data.OleDb.OleDbParameter("kod", System.Data.OleDb.OleDbType.WChar, 50, "kod")});
            // 
            // oleDbSelectCommand1
            // 
            this.oleDbSelectCommand1.CommandText = "SELECT        id, name, type, kod\r\nFROM            personel";
            // 
            // oleDbUpdateCommand1
            // 
            this.oleDbUpdateCommand1.CommandText = "UPDATE       personel\r\nSET                name = ?, type = ?, kod = ?\r\nWHERE     " +
                "   (id = ?)";
            this.oleDbUpdateCommand1.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("name", System.Data.OleDb.OleDbType.WChar, 50, "name"),
            new System.Data.OleDb.OleDbParameter("type", System.Data.OleDb.OleDbType.WChar, 50, "type"),
            new System.Data.OleDb.OleDbParameter("kod", System.Data.OleDb.OleDbType.WChar, 50, "kod"),
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.WChar, 50, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(978, 353);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 32);
            this.button1.TabIndex = 17;
            this.button1.Text = "پاک کردن همه اطلاعات";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(946, 353);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(26, 32);
            this.button2.TabIndex = 18;
            this.button2.Text = "پاک کردن همه اطلاعات";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DA_Transactions2
            // 
            this.DA_Transactions2.DeleteCommand = this.oleDbCommand5;
            this.DA_Transactions2.InsertCommand = this.oleDbCommand6;
            this.DA_Transactions2.SelectCommand = this.oleDbCommand7;
            this.DA_Transactions2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.DA_Transactions2.UpdateCommand = this.oleDbCommand8;
            // 
            // oleDbCommand5
            // 
            this.oleDbCommand5.CommandText = "DELETE FROM Transactions";
            this.oleDbCommand5.Connection = this.con;
            // 
            // oleDbCommand6
            // 
            this.oleDbCommand6.CommandText = "INSERT INTO Transactions\r\n                      (length, [first], [second], third" +
                ", forth)\r\nVALUES     (?, ?, ?, ?, ?)";
            this.oleDbCommand6.Connection = this.con;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("second", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("third", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("forth", System.Data.OleDb.OleDbType.Integer, 0, "forth")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = resources.GetString("oleDbCommand7.CommandText");
            this.oleDbCommand7.Connection = this.con;
            this.oleDbCommand7.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("length1", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("first1", System.Data.OleDb.OleDbType.Integer, 0, "first")});
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = "UPDATE    Transactions\r\nSET              state = ?\r\nWHERE     (length = ?) AND ([" +
                "first] = ?) AND ([second] = ?) AND (third = ?) AND (forth = ?)";
            this.oleDbCommand8.Connection = this.con;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("state", System.Data.OleDb.OleDbType.WChar, 50, "state"),
            new System.Data.OleDb.OleDbParameter("Original_length", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "length", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param3", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param4", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param5", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null),
            new System.Data.OleDb.OleDbParameter("Original_Param6", System.Data.OleDb.OleDbType.Variant, 1024, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "", System.Data.DataRowVersion.Original, null)});
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblStatus.Location = new System.Drawing.Point(412, 362);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblStatus.Size = new System.Drawing.Size(471, 23);
            this.lblStatus.TabIndex = 83;
            this.lblStatus.TextChanged += new System.EventHandler(this.lblStatus_TextChanged);
            // 
            // DA_GeneratedInputs2
            // 
            this.DA_GeneratedInputs2.DeleteCommand = this.oleDbCommand1;
            this.DA_GeneratedInputs2.InsertCommand = this.oleDbCommand2;
            this.DA_GeneratedInputs2.SelectCommand = this.oleDbCommand3;
            this.DA_GeneratedInputs2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.DA_GeneratedInputs2.UpdateCommand = this.oleDbCommand4;
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "DELETE FROM GeneratedInputs";
            this.oleDbCommand1.Connection = this.con;
            // 
            // oleDbCommand2
            // 
            this.oleDbCommand2.CommandText = "INSERT INTO GeneratedInputs\r\n                      (length, start, inputtext, ran" +
                "k, isselected)\r\nVALUES     (?, ?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.con;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("start", System.Data.OleDb.OleDbType.Integer, 0, "start"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext"),
            new System.Data.OleDb.OleDbParameter("rank", System.Data.OleDb.OleDbType.Integer, 0, "rank"),
            new System.Data.OleDb.OleDbParameter("isselected", System.Data.OleDb.OleDbType.WChar, 255, "isselected")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.con;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("length", System.Data.OleDb.OleDbType.Integer, 0, "length"),
            new System.Data.OleDb.OleDbParameter("inputtext", System.Data.OleDb.OleDbType.WChar, 255, "inputtext"),
            new System.Data.OleDb.OleDbParameter("method", System.Data.OleDb.OleDbType.Integer, 0, "method"),
            new System.Data.OleDb.OleDbParameter("first", System.Data.OleDb.OleDbType.Integer, 0, "first"),
            new System.Data.OleDb.OleDbParameter("second", System.Data.OleDb.OleDbType.Integer, 0, "second"),
            new System.Data.OleDb.OleDbParameter("third", System.Data.OleDb.OleDbType.Integer, 0, "third"),
            new System.Data.OleDb.OleDbParameter("forth", System.Data.OleDb.OleDbType.Integer, 0, "forth")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE    GeneratedInputs\r\nSET              isselected = ?\r\nWHERE     (inputtext " +
                "= ?)";
            this.oleDbCommand4.Connection = this.con;
            this.oleDbCommand4.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("isselected", System.Data.OleDb.OleDbType.WChar, 255, "isselected"),
            new System.Data.OleDb.OleDbParameter("Original_inputtext", System.Data.OleDb.OleDbType.WChar, 255, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "inputtext", System.Data.DataRowVersion.Original, null)});
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(122, 353);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(302, 32);
            this.progressBar.TabIndex = 85;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(412, 360);
            this.label20.Name = "label20";
            this.label20.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label20.Size = new System.Drawing.Size(189, 23);
            this.label20.TabIndex = 84;
            this.label20.Text = "میزان پیشرفت تقریبی:";
            // 
            // FormInputManagment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 397);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnInitialize);
            this.Controls.Add(this.groupBoxInputList);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FormInputManagment";
            this.Text = " :: لیست ورودیها :: ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInputManagment_FormClosing);
            this.Load += new System.EventHandler(this.FormInputManagment_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FormInputList_KeyPress);
            this.groupBoxInputList.ResumeLayout(false);
            this.groupBoxInputList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.toolStripMainMenu.ResumeLayout(false);
            this.toolStripMainMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneratedInputs)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBoxInputList;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.ToolStrip toolStripMainMenu;
        private InputListDataSet inputListDataSet;
        private System.Data.OleDb.OleDbConnection con;
        private System.Data.OleDb.OleDbDataAdapter DA_Transactions;
        private System.Data.OleDb.OleDbCommand DeleteComTransactions;
        private System.Data.OleDb.OleDbCommand InsertComTransactions;
        private System.Data.OleDb.OleDbCommand SelectCommand;
        private System.Data.OleDb.OleDbCommand UpdateCom1;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvGeneratedInputs;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Data.OleDb.OleDbDataAdapter DA_GeneratedInputs;
        private System.Data.OleDb.OleDbCommand DeleteComGeneratedInputs;
        private System.Data.OleDb.OleDbCommand InsetComGeneratedInputs;
        private System.Data.OleDb.OleDbCommand SelectComGeneratedInputs;
        private System.Data.OleDb.OleDbCommand UpdateComGeneratedInputs;
        private System.Windows.Forms.Timer SaveTimer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnView;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox tstxtLengthG;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tstxtStartG;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsBtnViewG;
        private System.Windows.Forms.ToolStripButton tsBtnSelectInput;
        private System.Windows.Forms.DataGridViewTextBoxColumn inputtext;
        private System.Windows.Forms.DataGridViewTextBoxColumn rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn isselected;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Data.OleDb.OleDbDataAdapter DA_Transactions2;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbCommand6;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolStripButton tsBtnStopGeneration;
        private System.Windows.Forms.ToolStripDropDownButton tsBtnGenerateG;
        private System.Windows.Forms.ToolStripMenuItem tsBtnGenerateG1;
        private System.Windows.Forms.ToolStripMenuItem tsBtnGenerateG2;
        private System.Windows.Forms.ToolStripButton tsBtnProcessInput;
        private System.Windows.Forms.ToolStripComboBox tsddlLength;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripTextBox tstxtMinRankG;
        private System.Windows.Forms.ToolStripButton tsBtnDelete;
        private System.Data.OleDb.OleDbDataAdapter DA_GeneratedInputs2;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripTextBox tstxtMaxRankG;
        private System.Windows.Forms.DataGridViewTextBoxColumn length;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label20;
    }
}