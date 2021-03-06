using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Boddooh;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using BoddoohControl;
using System.Data.OleDb;

namespace Boddooh
{
	/// <summary>
	/// Summary description for FormPartII.
	/// </summary>
	public class FormMain : System.Windows.Forms.Form
	{
        public static int MinimumRank = 0;

        public static int FinalProcessingTimes = 0;

        public static List<string> ItemsIndgvAnswers = new List<string>();
        public static List<string> ItemsIndgvSelectedAnswer = new List<string>();
        public static List<string> ItemsIndgvInputs = new List<string>();
        public static List<string> ItemsIndgvSavedAnswers = new List<string>();
        
        public static int HeaderSize = 150;
        public AnswerLettersSelector[] AnswerLettersSelectors;
        public Label[] AnswerLettersSelectorLabels;
        public int AnswerLettersSelectorsCount;

        private static int DoneCount;
        private Mutex MyMutex = new Mutex(); 
        private Mutex mutex1 = new Mutex(); 
        private static long ProgressCount;
        private static long MaxProgressCount;

        private int ComputingJobsCount = 2;
        private Thread[] ComputingJobs;
        public IntTuple[] AllStartAndEnds;

        public static bool TheCountingProblemInitialzed = false;
        public static long[,] TheCountingProblemTable;
        public static ArrayList UnfilteredAnswersList;
        public static ListBox IMListBox;
        public static AnswerArrayAndTagTuple[] AnswersAndTheirRank;
        public static ArrayList AllOptionsForTheFirstAndLastLetters;
        public static string FinishedString = "محاسبه جوابها تمام شد.";

        public DataGridView SelectedDataGridViewForPrint;
        public int SelectedIndexInDataGridViewForPrint;
        private static int ItemsPrintedCount;
        private static int PageNumber;
        private ArrayList OptionsForTheFirstAnswerLetters;
        private ArrayList OptionsForTheLastAnswerLetters; 
		private int tabPage0Index = 0;
        private int tabPage2Index = 1;
        private System.Windows.Forms.OpenFileDialog LoadFromFileDialog;
        private System.Windows.Forms.SaveFileDialog SaveToFileDialog;
        private Button btnSelectFirstLetters;
        private PrintDialog PrintDialog;
        private System.Drawing.Printing.PrintDocument PrintDocument;
        private AnswerLettersSelector answerLettersSelector1;
        private System.Windows.Forms.Timer timer1;
        private TabControl tabctrlResults;
        private TabPage tabInput;
        private GroupBox groupBox1;
        private Label label21;
        private ComboBox ddlLast12;
        private ComboBox ddlFirst12;
        private ComboBox ddlLast10;
        private ComboBox ddlLast11;
        private ComboBox ddlFirst11;
        private ComboBox ddlFirst10;
        private ComboBox ddlFirst9;
        private ComboBox ddlFirst8;
        private ComboBox ddlFirst7;
        private ComboBox ddlFirst6;
        private ComboBox ddlLast6;
        private ComboBox ddlLast7;
        private ComboBox ddlLast8;
        private ComboBox ddlLast9;
        private ComboBox ddlLast2;
        private ComboBox ddlLast3;
        private ComboBox ddlLast4;
        private ComboBox ddlLast5;
        private ComboBox ddlFirst5;
        private ComboBox ddlFirst4;
        private ComboBox ddlFirst3;
        private ComboBox ddlFirst2;
        private Label label19;
        private TextBox txtCount;
        private Label label6;
        private Label label7;
        private NumericUpDown nudMinRank;
        private Label label10;
        private Button btnFindAnswers;
        private TextBox txtLast1;
        private ListBox listLastLettersOptions;
        private NumericUpDown nudMinorASFA;
        private TextBox txtLast0;
        private ListBox listFirstLettersOptions;
        private CheckBox chkOnlySpecialAnswers;
        private Label label4;
        private Label label3;
        private TextBox txtFirst0;
        private TextBox txtFirst1;
        private Label label5;
        private Label label17;
        private GroupBox groupBox3;
        private Button btnDeleteBaseInput;
        private Label lblRank;
        private Label label23;
        private Label lblMinorASFQ3;
        private Label lblMinorASFQ2;
        private TextBox txtMinusMinorASFQ;
        private Label label22;
        private RadioButton radioDoOmitDuplicateLettersFromBothSidesToMiddle;
        private Label lblBaseInput;
        private Label label18;
        private Button btnInputManagement;
        private Label lblLengthQ;
        private Label label16;
        private Panel panel3;
        private RadioButton radioFromMtoTB;
        private RadioButton radioFromTBtoM;
        private Label label8;
        private Panel pnlOddLength;
        private Label label14;
        private RadioButton radioMiddleElementFromBottom;
        private RadioButton radioMiddleElementFromTop;
        private Panel pnlMoreThan64;
        private Label label11;
        private RadioButton radioNonModular;
        private RadioButton radioModular;
        private Button btnSelectFromDB;
        public TextBox txtInput;
        private Label label1;
        private RadioButton radioDoNotOmitDuplicateLetters;
        private RadioButton radioDoOmitDuplicateLettersFromRightToLeft;
        private Label lblMinorASFQ;
        private Button btnConfirmInput;
        private Label label9;
        private TabPage tabResults;
        private ProgressBar progressBar;
        private Label label20;
        private Button btnStop;
        private Button btnPrint;
        private Button btnTakeToInputPanel;
        private DataGridView dgvAnswers;
        private Label label13;
        private NumericUpDown nudFinalProcessingTimes;
        private Button btnDoFinalProcessingSelected;
        private TextBox txtGivenNumber;
        private Label label12;
        private Button btnDoFinalProcessing;
        public ListBox listAnswers;
        private TabPage tabResultsAfterProcessing;
        private ListBox listSelectedAnswer;
        private Button btnPrintOneSelected;
        private Button btnPrintAllLeft;
        private TabPage tabResultsAfterUltimateProcessing;
        private Label label24;
        private Label lblStatus;
        private Button btnDoTheUltimateProcessing;
        private Label label2;
        private Panel pnlUltimateSelection;
        private VScrollBar vScrollBar1;
        private Button btnSaveUltimateResult;
        private Button btnSaveResults;
        private DataGridView dgvSelectedAnswer;
        private TabPage tabQs;
        private SplitContainer splitContainer1;
        private Button btnViewRawResults;
        private Button btnViewInputs;
        private System.Data.OleDb.OleDbConnection con;
        private System.Data.OleDb.OleDbDataAdapter daQs;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbCommand oleDbCommand2;
        private System.Data.OleDb.OleDbCommand oleDbCommand3;
        private System.Data.OleDb.OleDbCommand oleDbCommand4;
        private System.Data.OleDb.OleDbDataAdapter daQs2;
        private System.Data.OleDb.OleDbCommand oleDbCommand5;
        private System.Data.OleDb.OleDbCommand oleDbCommand6;
        private System.Data.OleDb.OleDbCommand oleDbCommand7;
        private System.Data.OleDb.OleDbCommand oleDbCommand8;
        private Label label28;
        private Label label26;
        private TextBox txtSelectedAnswer;
        private TextBox txtSelectedSelectedAnswer;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn rank;
        private DataGridViewTextBoxColumn inputtext;
        private TextBox txtUltimateResult;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private OleDbDataAdapter daRAs;
        private OleDbCommand oleDbCommand9;
        private OleDbCommand oleDbCommand10;
        private OleDbCommand oleDbCommand11;
        private OleDbCommand oleDbCommand12;
        private OleDbDataAdapter oleDbDataAdapter1;
        private OleDbCommand oleDbCommand13;
        private OleDbCommand oleDbCommand14;
        private OleDbCommand oleDbCommand15;
        private OleDbCommand oleDbCommand16;
        private OleDbDataAdapter daUAs;
        private OleDbCommand oleDbCommand17;
        private OleDbCommand oleDbCommand18;
        private OleDbCommand oleDbCommand19;
        private OleDbCommand oleDbCommand20;
        private OleDbDataAdapter daRAs2;
        private OleDbCommand oleDbCommand21;
        private OleDbCommand oleDbCommand22;
        private OleDbCommand oleDbCommand23;
        private OleDbCommand oleDbCommand24;
        private OleDbDataAdapter daUAs2;
        private OleDbCommand oleDbCommand25;
        private OleDbCommand oleDbCommand26;
        private OleDbCommand oleDbCommand27;
        private OleDbCommand oleDbCommand28;
        private OleDbDataAdapter daQs3;
        private OleDbCommand oleDbCommand29;
        private OleDbCommand oleDbCommand30;
        private OleDbCommand oleDbCommand31;
        private OleDbCommand oleDbCommand32;
        private OleDbDataAdapter daUAs3;
        private OleDbCommand oleDbCommand33;
        private OleDbCommand oleDbCommand34;
        private OleDbCommand oleDbCommand35;
        private OleDbCommand oleDbCommand36;
        private OleDbDataAdapter daRAs3;
        private OleDbCommand oleDbCommand37;
        private OleDbCommand oleDbCommand38;
        private OleDbCommand oleDbCommand39;
        private OleDbCommand oleDbCommand40;
        private Button btnViewUltimateResults;
        private OleDbDataAdapter daRAs4;
        private OleDbCommand oleDbCommand41;
        private OleDbCommand oleDbCommand42;
        private OleDbCommand oleDbCommand43;
        private OleDbCommand oleDbCommand44;
        private OleDbDataAdapter daUAs4;
        private OleDbCommand oleDbCommand45;
        private OleDbCommand oleDbCommand46;
        private OleDbCommand oleDbCommand47;
        private OleDbCommand oleDbCommand48;
        private TabPage tabAs;
        private TextBox txtSelectedInput;
        private Label label25;
        private DataGridView dgvSavedAnswers;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private Label label27;
        private TextBox txtSelectedSavedAnswer;
        private DataGridView dgvInputs;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private Button btnProcessRawAnswers;
        private OleDbDataAdapter daQs4;
        private OleDbCommand oleDbCommand49;
        private OleDbCommand oleDbCommand50;
        private OleDbCommand oleDbCommand51;
        private OleDbCommand oleDbCommand52;
        private Label lblRankFinal;
        private Label label29;
        private Label label30;
        private TextBox txtThreadsCount;
        private Label labelCount;
        private TextBox txtOperationResult;
        private Label label15;
        private IContainer components;

		public FormMain()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.LoadFromFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveToFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.PrintDialog = new System.Windows.Forms.PrintDialog();
            this.PrintDocument = new System.Drawing.Printing.PrintDocument();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabctrlResults = new System.Windows.Forms.TabControl();
            this.tabInput = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.txtThreadsCount = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ddlLast12 = new System.Windows.Forms.ComboBox();
            this.ddlFirst12 = new System.Windows.Forms.ComboBox();
            this.ddlLast10 = new System.Windows.Forms.ComboBox();
            this.ddlLast11 = new System.Windows.Forms.ComboBox();
            this.ddlFirst11 = new System.Windows.Forms.ComboBox();
            this.ddlFirst10 = new System.Windows.Forms.ComboBox();
            this.ddlFirst9 = new System.Windows.Forms.ComboBox();
            this.ddlFirst8 = new System.Windows.Forms.ComboBox();
            this.ddlFirst7 = new System.Windows.Forms.ComboBox();
            this.ddlFirst6 = new System.Windows.Forms.ComboBox();
            this.ddlLast6 = new System.Windows.Forms.ComboBox();
            this.ddlLast7 = new System.Windows.Forms.ComboBox();
            this.ddlLast8 = new System.Windows.Forms.ComboBox();
            this.ddlLast9 = new System.Windows.Forms.ComboBox();
            this.ddlLast2 = new System.Windows.Forms.ComboBox();
            this.ddlLast3 = new System.Windows.Forms.ComboBox();
            this.ddlLast4 = new System.Windows.Forms.ComboBox();
            this.ddlLast5 = new System.Windows.Forms.ComboBox();
            this.ddlFirst5 = new System.Windows.Forms.ComboBox();
            this.ddlFirst4 = new System.Windows.Forms.ComboBox();
            this.ddlFirst3 = new System.Windows.Forms.ComboBox();
            this.ddlFirst2 = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.nudMinRank = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.btnFindAnswers = new System.Windows.Forms.Button();
            this.txtLast1 = new System.Windows.Forms.TextBox();
            this.listLastLettersOptions = new System.Windows.Forms.ListBox();
            this.nudMinorASFA = new System.Windows.Forms.NumericUpDown();
            this.txtLast0 = new System.Windows.Forms.TextBox();
            this.listFirstLettersOptions = new System.Windows.Forms.ListBox();
            this.chkOnlySpecialAnswers = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFirst0 = new System.Windows.Forms.TextBox();
            this.txtFirst1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnDeleteBaseInput = new System.Windows.Forms.Button();
            this.lblRank = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.lblMinorASFQ3 = new System.Windows.Forms.Label();
            this.lblMinorASFQ2 = new System.Windows.Forms.Label();
            this.txtMinusMinorASFQ = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle = new System.Windows.Forms.RadioButton();
            this.lblBaseInput = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnInputManagement = new System.Windows.Forms.Button();
            this.lblLengthQ = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioFromMtoTB = new System.Windows.Forms.RadioButton();
            this.radioFromTBtoM = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.pnlOddLength = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.radioMiddleElementFromBottom = new System.Windows.Forms.RadioButton();
            this.radioMiddleElementFromTop = new System.Windows.Forms.RadioButton();
            this.pnlMoreThan64 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.radioNonModular = new System.Windows.Forms.RadioButton();
            this.radioModular = new System.Windows.Forms.RadioButton();
            this.btnSelectFromDB = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioDoNotOmitDuplicateLetters = new System.Windows.Forms.RadioButton();
            this.radioDoOmitDuplicateLettersFromRightToLeft = new System.Windows.Forms.RadioButton();
            this.lblMinorASFQ = new System.Windows.Forms.Label();
            this.btnConfirmInput = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabResults = new System.Windows.Forms.TabPage();
            this.labelCount = new System.Windows.Forms.Label();
            this.txtSelectedAnswer = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label20 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnTakeToInputPanel = new System.Windows.Forms.Button();
            this.dgvAnswers = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inputtext = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label13 = new System.Windows.Forms.Label();
            this.nudFinalProcessingTimes = new System.Windows.Forms.NumericUpDown();
            this.btnDoFinalProcessingSelected = new System.Windows.Forms.Button();
            this.txtGivenNumber = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnDoFinalProcessing = new System.Windows.Forms.Button();
            this.listAnswers = new System.Windows.Forms.ListBox();
            this.tabResultsAfterProcessing = new System.Windows.Forms.TabPage();
            this.txtSelectedSelectedAnswer = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.btnDoTheUltimateProcessing = new System.Windows.Forms.Button();
            this.dgvSelectedAnswer = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.listSelectedAnswer = new System.Windows.Forms.ListBox();
            this.btnPrintOneSelected = new System.Windows.Forms.Button();
            this.btnPrintAllLeft = new System.Windows.Forms.Button();
            this.tabResultsAfterUltimateProcessing = new System.Windows.Forms.TabPage();
            this.lblRankFinal = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.txtUltimateResult = new System.Windows.Forms.TextBox();
            this.btnSaveUltimateResult = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.pnlUltimateSelection = new System.Windows.Forms.Panel();
            this.tabQs = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvInputs = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnViewInputs = new System.Windows.Forms.Button();
            this.btnProcessRawAnswers = new System.Windows.Forms.Button();
            this.txtSelectedInput = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnViewUltimateResults = new System.Windows.Forms.Button();
            this.btnViewRawResults = new System.Windows.Forms.Button();
            this.tabAs = new System.Windows.Forms.TabPage();
            this.label27 = new System.Windows.Forms.Label();
            this.txtSelectedSavedAnswer = new System.Windows.Forms.TextBox();
            this.dgvSavedAnswers = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.con = new System.Data.OleDb.OleDbConnection();
            this.daQs = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand2 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand3 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand4 = new System.Data.OleDb.OleDbCommand();
            this.daQs2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand5 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand6 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand7 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand8 = new System.Data.OleDb.OleDbCommand();
            this.daRAs = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand9 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand10 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand11 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand12 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand13 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand14 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand15 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand16 = new System.Data.OleDb.OleDbCommand();
            this.daUAs = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand17 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand18 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand19 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand20 = new System.Data.OleDb.OleDbCommand();
            this.daRAs2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand21 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand22 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand23 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand24 = new System.Data.OleDb.OleDbCommand();
            this.daUAs2 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand25 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand26 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand27 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand28 = new System.Data.OleDb.OleDbCommand();
            this.daQs3 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand29 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand30 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand31 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand32 = new System.Data.OleDb.OleDbCommand();
            this.daUAs3 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand33 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand34 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand35 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand36 = new System.Data.OleDb.OleDbCommand();
            this.daRAs3 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand37 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand38 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand39 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand40 = new System.Data.OleDb.OleDbCommand();
            this.daRAs4 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand41 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand42 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand43 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand44 = new System.Data.OleDb.OleDbCommand();
            this.daUAs4 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand45 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand46 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand47 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand48 = new System.Data.OleDb.OleDbCommand();
            this.daQs4 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand49 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand50 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand51 = new System.Data.OleDb.OleDbCommand();
            this.oleDbCommand52 = new System.Data.OleDb.OleDbCommand();
            this.txtOperationResult = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tabctrlResults.SuspendLayout();
            this.tabInput.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinorASFA)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pnlOddLength.SuspendLayout();
            this.pnlMoreThan64.SuspendLayout();
            this.tabResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinalProcessingTimes)).BeginInit();
            this.tabResultsAfterProcessing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedAnswer)).BeginInit();
            this.tabResultsAfterUltimateProcessing.SuspendLayout();
            this.tabQs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputs)).BeginInit();
            this.tabAs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavedAnswers)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadFromFileDialog
            // 
            this.LoadFromFileDialog.Filter = "Boddooh Files (*.Bod) | *.Bod";
            this.LoadFromFileDialog.Title = "بارکردن از فايل";
            this.LoadFromFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.LoadFromFileDialog_FileOk);
            // 
            // SaveToFileDialog
            // 
            this.SaveToFileDialog.Filter = "Boddooh Files (*.Bod) | *.Bod";
            this.SaveToFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveToFileDialog_FileOk);
            // 
            // PrintDialog
            // 
            this.PrintDialog.Document = this.PrintDocument;
            // 
            // PrintDocument
            // 
            this.PrintDocument.DocumentName = "Answers";
            this.PrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabctrlResults
            // 
            this.tabctrlResults.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.tabctrlResults.Controls.Add(this.tabInput);
            this.tabctrlResults.Controls.Add(this.tabResults);
            this.tabctrlResults.Controls.Add(this.tabResultsAfterProcessing);
            this.tabctrlResults.Controls.Add(this.tabResultsAfterUltimateProcessing);
            this.tabctrlResults.Controls.Add(this.tabQs);
            this.tabctrlResults.Controls.Add(this.tabAs);
            this.tabctrlResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlResults.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabctrlResults.Location = new System.Drawing.Point(0, 0);
            this.tabctrlResults.Name = "tabctrlResults";
            this.tabctrlResults.RightToLeftLayout = true;
            this.tabctrlResults.SelectedIndex = 0;
            this.tabctrlResults.Size = new System.Drawing.Size(1194, 741);
            this.tabctrlResults.TabIndex = 88;
            // 
            // tabInput
            // 
            this.tabInput.Controls.Add(this.groupBox1);
            this.tabInput.Controls.Add(this.groupBox3);
            this.tabInput.Location = new System.Drawing.Point(4, 31);
            this.tabInput.Name = "tabInput";
            this.tabInput.Size = new System.Drawing.Size(1186, 706);
            this.tabInput.TabIndex = 3;
            this.tabInput.Text = "   ورودی   ";
            this.tabInput.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOperationResult);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.txtThreadsCount);
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.ddlLast12);
            this.groupBox1.Controls.Add(this.ddlFirst12);
            this.groupBox1.Controls.Add(this.ddlLast10);
            this.groupBox1.Controls.Add(this.ddlLast11);
            this.groupBox1.Controls.Add(this.ddlFirst11);
            this.groupBox1.Controls.Add(this.ddlFirst10);
            this.groupBox1.Controls.Add(this.ddlFirst9);
            this.groupBox1.Controls.Add(this.ddlFirst8);
            this.groupBox1.Controls.Add(this.ddlFirst7);
            this.groupBox1.Controls.Add(this.ddlFirst6);
            this.groupBox1.Controls.Add(this.ddlLast6);
            this.groupBox1.Controls.Add(this.ddlLast7);
            this.groupBox1.Controls.Add(this.ddlLast8);
            this.groupBox1.Controls.Add(this.ddlLast9);
            this.groupBox1.Controls.Add(this.ddlLast2);
            this.groupBox1.Controls.Add(this.ddlLast3);
            this.groupBox1.Controls.Add(this.ddlLast4);
            this.groupBox1.Controls.Add(this.ddlLast5);
            this.groupBox1.Controls.Add(this.ddlFirst5);
            this.groupBox1.Controls.Add(this.ddlFirst4);
            this.groupBox1.Controls.Add(this.ddlFirst3);
            this.groupBox1.Controls.Add(this.ddlFirst2);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.txtCount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.nudMinRank);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnFindAnswers);
            this.groupBox1.Controls.Add(this.txtLast1);
            this.groupBox1.Controls.Add(this.listLastLettersOptions);
            this.groupBox1.Controls.Add(this.nudMinorASFA);
            this.groupBox1.Controls.Add(this.txtLast0);
            this.groupBox1.Controls.Add(this.listFirstLettersOptions);
            this.groupBox1.Controls.Add(this.chkOnlySpecialAnswers);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFirst0);
            this.groupBox1.Controls.Add(this.txtFirst1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 345);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1186, 361);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label30
            // 
            this.label30.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label30.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label30.Location = new System.Drawing.Point(210, 308);
            this.label30.Margin = new System.Windows.Forms.Padding(0);
            this.label30.Name = "label30";
            this.label30.Padding = new System.Windows.Forms.Padding(1);
            this.label30.Size = new System.Drawing.Size(159, 41);
            this.label30.TabIndex = 151;
            this.label30.Text = "تعداد نخهای اجرا:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtThreadsCount
            // 
            this.txtThreadsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtThreadsCount.Location = new System.Drawing.Point(151, 317);
            this.txtThreadsCount.Name = "txtThreadsCount";
            this.txtThreadsCount.Size = new System.Drawing.Size(50, 27);
            this.txtThreadsCount.TabIndex = 150;
            this.txtThreadsCount.Text = "2";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label21.Location = new System.Drawing.Point(333, 215);
            this.label21.Margin = new System.Windows.Forms.Padding(0);
            this.label21.Name = "label21";
            this.label21.Padding = new System.Windows.Forms.Padding(1);
            this.label21.Size = new System.Drawing.Size(40, 41);
            this.label21.TabIndex = 149;
            this.label21.Text = "...";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddlLast12
            // 
            this.ddlLast12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast12.FormattingEnabled = true;
            this.ddlLast12.Location = new System.Drawing.Point(769, 263);
            this.ddlLast12.Name = "ddlLast12";
            this.ddlLast12.Size = new System.Drawing.Size(50, 27);
            this.ddlLast12.TabIndex = 148;
            // 
            // ddlFirst12
            // 
            this.ddlFirst12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst12.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst12.FormattingEnabled = true;
            this.ddlFirst12.Location = new System.Drawing.Point(375, 223);
            this.ddlFirst12.Name = "ddlFirst12";
            this.ddlFirst12.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst12.TabIndex = 147;
            // 
            // ddlLast10
            // 
            this.ddlLast10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast10.FormattingEnabled = true;
            this.ddlLast10.Location = new System.Drawing.Point(656, 263);
            this.ddlLast10.Name = "ddlLast10";
            this.ddlLast10.Size = new System.Drawing.Size(50, 27);
            this.ddlLast10.TabIndex = 146;
            // 
            // ddlLast11
            // 
            this.ddlLast11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast11.FormattingEnabled = true;
            this.ddlLast11.Location = new System.Drawing.Point(713, 263);
            this.ddlLast11.Name = "ddlLast11";
            this.ddlLast11.Size = new System.Drawing.Size(50, 27);
            this.ddlLast11.TabIndex = 145;
            // 
            // ddlFirst11
            // 
            this.ddlFirst11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst11.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst11.FormattingEnabled = true;
            this.ddlFirst11.Location = new System.Drawing.Point(431, 223);
            this.ddlFirst11.Name = "ddlFirst11";
            this.ddlFirst11.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst11.TabIndex = 144;
            // 
            // ddlFirst10
            // 
            this.ddlFirst10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst10.FormattingEnabled = true;
            this.ddlFirst10.Location = new System.Drawing.Point(487, 223);
            this.ddlFirst10.Name = "ddlFirst10";
            this.ddlFirst10.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst10.TabIndex = 143;
            // 
            // ddlFirst9
            // 
            this.ddlFirst9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst9.FormattingEnabled = true;
            this.ddlFirst9.Location = new System.Drawing.Point(545, 223);
            this.ddlFirst9.Name = "ddlFirst9";
            this.ddlFirst9.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst9.TabIndex = 142;
            // 
            // ddlFirst8
            // 
            this.ddlFirst8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst8.FormattingEnabled = true;
            this.ddlFirst8.Location = new System.Drawing.Point(601, 223);
            this.ddlFirst8.Name = "ddlFirst8";
            this.ddlFirst8.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst8.TabIndex = 141;
            // 
            // ddlFirst7
            // 
            this.ddlFirst7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst7.FormattingEnabled = true;
            this.ddlFirst7.Location = new System.Drawing.Point(657, 223);
            this.ddlFirst7.Name = "ddlFirst7";
            this.ddlFirst7.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst7.TabIndex = 140;
            // 
            // ddlFirst6
            // 
            this.ddlFirst6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst6.FormattingEnabled = true;
            this.ddlFirst6.Location = new System.Drawing.Point(714, 223);
            this.ddlFirst6.Name = "ddlFirst6";
            this.ddlFirst6.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst6.TabIndex = 139;
            // 
            // ddlLast6
            // 
            this.ddlLast6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast6.FormattingEnabled = true;
            this.ddlLast6.Location = new System.Drawing.Point(431, 263);
            this.ddlLast6.Name = "ddlLast6";
            this.ddlLast6.Size = new System.Drawing.Size(50, 27);
            this.ddlLast6.TabIndex = 138;
            // 
            // ddlLast7
            // 
            this.ddlLast7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast7.FormattingEnabled = true;
            this.ddlLast7.Location = new System.Drawing.Point(487, 263);
            this.ddlLast7.Name = "ddlLast7";
            this.ddlLast7.Size = new System.Drawing.Size(50, 27);
            this.ddlLast7.TabIndex = 137;
            // 
            // ddlLast8
            // 
            this.ddlLast8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast8.FormattingEnabled = true;
            this.ddlLast8.Location = new System.Drawing.Point(543, 263);
            this.ddlLast8.Name = "ddlLast8";
            this.ddlLast8.Size = new System.Drawing.Size(50, 27);
            this.ddlLast8.TabIndex = 136;
            // 
            // ddlLast9
            // 
            this.ddlLast9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast9.FormattingEnabled = true;
            this.ddlLast9.Location = new System.Drawing.Point(600, 263);
            this.ddlLast9.Name = "ddlLast9";
            this.ddlLast9.Size = new System.Drawing.Size(50, 27);
            this.ddlLast9.TabIndex = 135;
            // 
            // ddlLast2
            // 
            this.ddlLast2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast2.FormattingEnabled = true;
            this.ddlLast2.Location = new System.Drawing.Point(206, 263);
            this.ddlLast2.Name = "ddlLast2";
            this.ddlLast2.Size = new System.Drawing.Size(50, 27);
            this.ddlLast2.TabIndex = 134;
            // 
            // ddlLast3
            // 
            this.ddlLast3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast3.FormattingEnabled = true;
            this.ddlLast3.Location = new System.Drawing.Point(262, 263);
            this.ddlLast3.Name = "ddlLast3";
            this.ddlLast3.Size = new System.Drawing.Size(50, 27);
            this.ddlLast3.TabIndex = 133;
            // 
            // ddlLast4
            // 
            this.ddlLast4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast4.FormattingEnabled = true;
            this.ddlLast4.Location = new System.Drawing.Point(318, 263);
            this.ddlLast4.Name = "ddlLast4";
            this.ddlLast4.Size = new System.Drawing.Size(50, 27);
            this.ddlLast4.TabIndex = 132;
            // 
            // ddlLast5
            // 
            this.ddlLast5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ddlLast5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlLast5.FormattingEnabled = true;
            this.ddlLast5.Location = new System.Drawing.Point(375, 263);
            this.ddlLast5.Name = "ddlLast5";
            this.ddlLast5.Size = new System.Drawing.Size(50, 27);
            this.ddlLast5.TabIndex = 131;
            // 
            // ddlFirst5
            // 
            this.ddlFirst5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst5.FormattingEnabled = true;
            this.ddlFirst5.Location = new System.Drawing.Point(770, 223);
            this.ddlFirst5.Name = "ddlFirst5";
            this.ddlFirst5.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst5.TabIndex = 130;
            // 
            // ddlFirst4
            // 
            this.ddlFirst4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst4.FormattingEnabled = true;
            this.ddlFirst4.Location = new System.Drawing.Point(826, 223);
            this.ddlFirst4.Name = "ddlFirst4";
            this.ddlFirst4.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst4.TabIndex = 129;
            // 
            // ddlFirst3
            // 
            this.ddlFirst3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst3.FormattingEnabled = true;
            this.ddlFirst3.Location = new System.Drawing.Point(879, 223);
            this.ddlFirst3.Name = "ddlFirst3";
            this.ddlFirst3.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst3.TabIndex = 128;
            // 
            // ddlFirst2
            // 
            this.ddlFirst2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ddlFirst2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlFirst2.FormattingEnabled = true;
            this.ddlFirst2.Location = new System.Drawing.Point(932, 223);
            this.ddlFirst2.Name = "ddlFirst2";
            this.ddlFirst2.Size = new System.Drawing.Size(50, 27);
            this.ddlFirst2.TabIndex = 127;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label19.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Location = new System.Drawing.Point(834, 255);
            this.label19.Margin = new System.Windows.Forms.Padding(0);
            this.label19.Name = "label19";
            this.label19.Padding = new System.Windows.Forms.Padding(1);
            this.label19.Size = new System.Drawing.Size(40, 41);
            this.label19.TabIndex = 126;
            this.label19.Text = "...";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCount
            // 
            this.txtCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCount.Location = new System.Drawing.Point(543, 65);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(60, 27);
            this.txtCount.TabIndex = 100;
            // 
            // label6
            // 
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(401, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 41);
            this.label6.TabIndex = 79;
            this.label6.Text = "دو حرف اول:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label7.Location = new System.Drawing.Point(151, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 41);
            this.label7.TabIndex = 80;
            this.label7.Text = "دو حرف آخر:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nudMinRank
            // 
            this.nudMinRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinRank.Location = new System.Drawing.Point(876, 75);
            this.nudMinRank.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudMinRank.Name = "nudMinRank";
            this.nudMinRank.Size = new System.Drawing.Size(87, 27);
            this.nudMinRank.TabIndex = 1;
            this.nudMinRank.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nudMinRank.ValueChanged += new System.EventHandler(this.nudMinRank_ValueChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Location = new System.Drawing.Point(960, 66);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(209, 41);
            this.label10.TabIndex = 77;
            this.label10.Text = "جوابهایی با حداقل امتیاز:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnFindAnswers
            // 
            this.btnFindAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFindAnswers.Location = new System.Drawing.Point(19, 312);
            this.btnFindAnswers.Name = "btnFindAnswers";
            this.btnFindAnswers.Size = new System.Drawing.Size(126, 32);
            this.btnFindAnswers.TabIndex = 3;
            this.btnFindAnswers.Text = "محاسبه جواب ها";
            this.btnFindAnswers.Click += new System.EventHandler(this.btnFindAnswers_Click);
            // 
            // txtLast1
            // 
            this.txtLast1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLast1.Location = new System.Drawing.Point(150, 263);
            this.txtLast1.Name = "txtLast1";
            this.txtLast1.Size = new System.Drawing.Size(50, 27);
            this.txtLast1.TabIndex = 8;
            // 
            // listLastLettersOptions
            // 
            this.listLastLettersOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listLastLettersOptions.FormattingEnabled = true;
            this.listLastLettersOptions.ItemHeight = 19;
            this.listLastLettersOptions.Location = new System.Drawing.Point(19, 23);
            this.listLastLettersOptions.Name = "listLastLettersOptions";
            this.listLastLettersOptions.Size = new System.Drawing.Size(126, 156);
            this.listLastLettersOptions.TabIndex = 5;
            this.listLastLettersOptions.SelectedIndexChanged += new System.EventHandler(this.listLastLettersOptions_SelectedIndexChanged);
            // 
            // nudMinorASFA
            // 
            this.nudMinorASFA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudMinorASFA.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nudMinorASFA.Location = new System.Drawing.Point(876, 23);
            this.nudMinorASFA.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudMinorASFA.Name = "nudMinorASFA";
            this.nudMinorASFA.Size = new System.Drawing.Size(87, 27);
            this.nudMinorASFA.TabIndex = 0;
            // 
            // txtLast0
            // 
            this.txtLast0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLast0.Location = new System.Drawing.Point(98, 263);
            this.txtLast0.Name = "txtLast0";
            this.txtLast0.Size = new System.Drawing.Size(50, 27);
            this.txtLast0.TabIndex = 9;
            // 
            // listFirstLettersOptions
            // 
            this.listFirstLettersOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listFirstLettersOptions.FormattingEnabled = true;
            this.listFirstLettersOptions.ItemHeight = 19;
            this.listFirstLettersOptions.Location = new System.Drawing.Point(271, 23);
            this.listFirstLettersOptions.Name = "listFirstLettersOptions";
            this.listFirstLettersOptions.Size = new System.Drawing.Size(124, 156);
            this.listFirstLettersOptions.TabIndex = 4;
            this.listFirstLettersOptions.SelectedIndexChanged += new System.EventHandler(this.listFirstLettersOptions_SelectedIndexChanged);
            // 
            // chkOnlySpecialAnswers
            // 
            this.chkOnlySpecialAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOnlySpecialAnswers.AutoSize = true;
            this.chkOnlySpecialAnswers.Checked = true;
            this.chkOnlySpecialAnswers.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOnlySpecialAnswers.Location = new System.Drawing.Point(995, 122);
            this.chkOnlySpecialAnswers.Name = "chkOnlySpecialAnswers";
            this.chkOnlySpecialAnswers.Size = new System.Drawing.Size(170, 23);
            this.chkOnlySpecialAnswers.TabIndex = 2;
            this.chkOnlySpecialAnswers.Text = "فقط جوابهای خاص";
            this.chkOnlySpecialAnswers.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(1095, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(1);
            this.label4.Size = new System.Drawing.Size(94, 41);
            this.label4.TabIndex = 65;
            this.label4.Text = "حروف اول:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(956, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 23);
            this.label3.TabIndex = 59;
            this.label3.Text = "جمع ابجد کوچک جواب ها:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFirst0
            // 
            this.txtFirst0.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirst0.Location = new System.Drawing.Point(1044, 223);
            this.txtFirst0.Name = "txtFirst0";
            this.txtFirst0.Size = new System.Drawing.Size(50, 27);
            this.txtFirst0.TabIndex = 6;
            // 
            // txtFirst1
            // 
            this.txtFirst1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirst1.Location = new System.Drawing.Point(988, 223);
            this.txtFirst1.Name = "txtFirst1";
            this.txtFirst1.Size = new System.Drawing.Size(50, 27);
            this.txtFirst1.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(2, 255);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(1);
            this.label5.Size = new System.Drawing.Size(106, 41);
            this.label5.TabIndex = 68;
            this.label5.Text = ": حروف آخر";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label17.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Location = new System.Drawing.Point(610, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 23);
            this.label17.TabIndex = 99;
            this.label17.Text = " تعداد:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnDeleteBaseInput);
            this.groupBox3.Controls.Add(this.lblRank);
            this.groupBox3.Controls.Add(this.label23);
            this.groupBox3.Controls.Add(this.lblMinorASFQ3);
            this.groupBox3.Controls.Add(this.lblMinorASFQ2);
            this.groupBox3.Controls.Add(this.txtMinusMinorASFQ);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.radioDoOmitDuplicateLettersFromBothSidesToMiddle);
            this.groupBox3.Controls.Add(this.lblBaseInput);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.btnInputManagement);
            this.groupBox3.Controls.Add(this.lblLengthQ);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.pnlOddLength);
            this.groupBox3.Controls.Add(this.pnlMoreThan64);
            this.groupBox3.Controls.Add(this.btnSelectFromDB);
            this.groupBox3.Controls.Add(this.txtInput);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.radioDoNotOmitDuplicateLetters);
            this.groupBox3.Controls.Add(this.radioDoOmitDuplicateLettersFromRightToLeft);
            this.groupBox3.Controls.Add(this.lblMinorASFQ);
            this.groupBox3.Controls.Add(this.btnConfirmInput);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1186, 324);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // btnDeleteBaseInput
            // 
            this.btnDeleteBaseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteBaseInput.Location = new System.Drawing.Point(1015, 62);
            this.btnDeleteBaseInput.Name = "btnDeleteBaseInput";
            this.btnDeleteBaseInput.Size = new System.Drawing.Size(156, 30);
            this.btnDeleteBaseInput.TabIndex = 106;
            this.btnDeleteBaseInput.Text = "حذف ورودی پایه";
            this.btnDeleteBaseInput.Click += new System.EventHandler(this.btnDeleteBaseInput_Click);
            // 
            // lblRank
            // 
            this.lblRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRank.Location = new System.Drawing.Point(658, 291);
            this.lblRank.Name = "lblRank";
            this.lblRank.Size = new System.Drawing.Size(41, 19);
            this.lblRank.TabIndex = 105;
            this.lblRank.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(694, 291);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(53, 19);
            this.label23.TabIndex = 104;
            this.label23.Text = "امتیاز:";
            // 
            // lblMinorASFQ3
            // 
            this.lblMinorASFQ3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinorASFQ3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinorASFQ3.Location = new System.Drawing.Point(343, 287);
            this.lblMinorASFQ3.Name = "lblMinorASFQ3";
            this.lblMinorASFQ3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMinorASFQ3.Size = new System.Drawing.Size(303, 23);
            this.lblMinorASFQ3.TabIndex = 103;
            this.lblMinorASFQ3.Text = "= ";
            this.lblMinorASFQ3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblMinorASFQ2
            // 
            this.lblMinorASFQ2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMinorASFQ2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinorASFQ2.Location = new System.Drawing.Point(191, 286);
            this.lblMinorASFQ2.Name = "lblMinorASFQ2";
            this.lblMinorASFQ2.Size = new System.Drawing.Size(62, 23);
            this.lblMinorASFQ2.TabIndex = 102;
            this.lblMinorASFQ2.Text = "   ";
            this.lblMinorASFQ2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtMinusMinorASFQ
            // 
            this.txtMinusMinorASFQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMinusMinorASFQ.Location = new System.Drawing.Point(277, 286);
            this.txtMinusMinorASFQ.Name = "txtMinusMinorASFQ";
            this.txtMinusMinorASFQ.Size = new System.Drawing.Size(60, 27);
            this.txtMinusMinorASFQ.TabIndex = 101;
            this.txtMinusMinorASFQ.TextChanged += new System.EventHandler(this.txtMinusMinorASFQ_TextChanged);
            // 
            // label22
            // 
            this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label22.Location = new System.Drawing.Point(246, 286);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(32, 23);
            this.label22.TabIndex = 99;
            this.label22.Text = " - ";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // radioDoOmitDuplicateLettersFromBothSidesToMiddle
            // 
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.AutoSize = true;
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.Location = new System.Drawing.Point(19, 30);
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.Name = "radioDoOmitDuplicateLettersFromBothSidesToMiddle";
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.Size = new System.Drawing.Size(227, 23);
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.TabIndex = 98;
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.Text = "با حذف تکراری ها از طرفین";
            this.radioDoOmitDuplicateLettersFromBothSidesToMiddle.UseVisualStyleBackColor = true;
            // 
            // lblBaseInput
            // 
            this.lblBaseInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBaseInput.Location = new System.Drawing.Point(192, 67);
            this.lblBaseInput.Name = "lblBaseInput";
            this.lblBaseInput.Size = new System.Drawing.Size(713, 25);
            this.lblBaseInput.TabIndex = 97;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(911, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(98, 25);
            this.label18.TabIndex = 96;
            this.label18.Text = "ورودی پایه:";
            // 
            // btnInputManagement
            // 
            this.btnInputManagement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInputManagement.Location = new System.Drawing.Point(24, 62);
            this.btnInputManagement.Name = "btnInputManagement";
            this.btnInputManagement.Size = new System.Drawing.Size(142, 30);
            this.btnInputManagement.TabIndex = 95;
            this.btnInputManagement.Text = "مدیریت ورودی";
            this.btnInputManagement.Click += new System.EventHandler(this.btnInputManagement_Click);
            // 
            // lblLengthQ
            // 
            this.lblLengthQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLengthQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLengthQ.Location = new System.Drawing.Point(1006, 287);
            this.lblLengthQ.Name = "lblLengthQ";
            this.lblLengthQ.Size = new System.Drawing.Size(65, 23);
            this.lblLengthQ.TabIndex = 94;
            this.lblLengthQ.Text = " ";
            this.lblLengthQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label16.Location = new System.Drawing.Point(1057, 286);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(118, 23);
            this.label16.TabIndex = 93;
            this.label16.Text = "تعداد حروف:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.radioFromMtoTB);
            this.panel3.Controls.Add(this.radioFromTBtoM);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(871, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 100);
            this.panel3.TabIndex = 91;
            // 
            // radioFromMtoTB
            // 
            this.radioFromMtoTB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioFromMtoTB.AutoSize = true;
            this.radioFromMtoTB.Location = new System.Drawing.Point(144, 67);
            this.radioFromMtoTB.Name = "radioFromMtoTB";
            this.radioFromMtoTB.Size = new System.Drawing.Size(138, 23);
            this.radioFromMtoTB.TabIndex = 1;
            this.radioFromMtoTB.Text = "شروع از وسط ";
            this.radioFromMtoTB.UseVisualStyleBackColor = true;
            // 
            // radioFromTBtoM
            // 
            this.radioFromTBtoM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioFromTBtoM.AutoSize = true;
            this.radioFromTBtoM.Checked = true;
            this.radioFromTBtoM.Location = new System.Drawing.Point(116, 38);
            this.radioFromTBtoM.Name = "radioFromTBtoM";
            this.radioFromTBtoM.Size = new System.Drawing.Size(167, 23);
            this.radioFromTBtoM.TabIndex = 0;
            this.radioFromTBtoM.TabStop = true;
            this.radioFromTBtoM.Text = "شروع از بالا و پایین";
            this.radioFromTBtoM.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Location = new System.Drawing.Point(37, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 23);
            this.label8.TabIndex = 89;
            this.label8.Text = "شروع تکثیر الگوی مادر";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlOddLength
            // 
            this.pnlOddLength.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOddLength.Controls.Add(this.label14);
            this.pnlOddLength.Controls.Add(this.radioMiddleElementFromBottom);
            this.pnlOddLength.Controls.Add(this.radioMiddleElementFromTop);
            this.pnlOddLength.Location = new System.Drawing.Point(259, 175);
            this.pnlOddLength.Name = "pnlOddLength";
            this.pnlOddLength.Size = new System.Drawing.Size(300, 100);
            this.pnlOddLength.TabIndex = 92;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label14.Location = new System.Drawing.Point(12, 9);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(278, 23);
            this.label14.TabIndex = 89;
            this.label14.Text = "انتخاب عنصر وسط (طول فرد)";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioMiddleElementFromBottom
            // 
            this.radioMiddleElementFromBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioMiddleElementFromBottom.AutoSize = true;
            this.radioMiddleElementFromBottom.Location = new System.Drawing.Point(152, 67);
            this.radioMiddleElementFromBottom.Name = "radioMiddleElementFromBottom";
            this.radioMiddleElementFromBottom.Size = new System.Drawing.Size(126, 23);
            this.radioMiddleElementFromBottom.TabIndex = 1;
            this.radioMiddleElementFromBottom.Text = "از نیمه پایینی";
            this.radioMiddleElementFromBottom.UseVisualStyleBackColor = true;
            // 
            // radioMiddleElementFromTop
            // 
            this.radioMiddleElementFromTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioMiddleElementFromTop.AutoSize = true;
            this.radioMiddleElementFromTop.Checked = true;
            this.radioMiddleElementFromTop.Location = new System.Drawing.Point(153, 38);
            this.radioMiddleElementFromTop.Name = "radioMiddleElementFromTop";
            this.radioMiddleElementFromTop.Size = new System.Drawing.Size(125, 23);
            this.radioMiddleElementFromTop.TabIndex = 0;
            this.radioMiddleElementFromTop.TabStop = true;
            this.radioMiddleElementFromTop.Text = "از نیمه بالایی";
            this.radioMiddleElementFromTop.UseVisualStyleBackColor = true;
            // 
            // pnlMoreThan64
            // 
            this.pnlMoreThan64.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMoreThan64.Controls.Add(this.label11);
            this.pnlMoreThan64.Controls.Add(this.radioNonModular);
            this.pnlMoreThan64.Controls.Add(this.radioModular);
            this.pnlMoreThan64.Location = new System.Drawing.Point(565, 176);
            this.pnlMoreThan64.Name = "pnlMoreThan64";
            this.pnlMoreThan64.Size = new System.Drawing.Size(300, 100);
            this.pnlMoreThan64.TabIndex = 90;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label11.Location = new System.Drawing.Point(3, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(291, 23);
            this.label11.TabIndex = 74;
            this.label11.Text = "نحوه تکثیر (طول بیش از 64 حرف) ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioNonModular
            // 
            this.radioNonModular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioNonModular.AutoSize = true;
            this.radioNonModular.Location = new System.Drawing.Point(186, 67);
            this.radioNonModular.Name = "radioNonModular";
            this.radioNonModular.Size = new System.Drawing.Size(91, 23);
            this.radioNonModular.TabIndex = 1;
            this.radioNonModular.Text = "برگشتی";
            this.radioNonModular.UseVisualStyleBackColor = true;
            // 
            // radioModular
            // 
            this.radioModular.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioModular.AutoSize = true;
            this.radioModular.Checked = true;
            this.radioModular.Location = new System.Drawing.Point(182, 38);
            this.radioModular.Name = "radioModular";
            this.radioModular.Size = new System.Drawing.Size(95, 23);
            this.radioModular.TabIndex = 0;
            this.radioModular.TabStop = true;
            this.radioModular.Text = "چرخشی";
            this.radioModular.UseVisualStyleBackColor = true;
            // 
            // btnSelectFromDB
            // 
            this.btnSelectFromDB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFromDB.Location = new System.Drawing.Point(724, 26);
            this.btnSelectFromDB.Name = "btnSelectFromDB";
            this.btnSelectFromDB.Size = new System.Drawing.Size(212, 30);
            this.btnSelectFromDB.TabIndex = 0;
            this.btnSelectFromDB.Text = "انتخاب از لیست ورودیها ...";
            this.btnSelectFromDB.Click += new System.EventHandler(this.btnSelectFromDB_Click);
            // 
            // txtInput
            // 
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Location = new System.Drawing.Point(24, 95);
            this.txtInput.MaxLength = 3000;
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(1147, 74);
            this.txtInput.TabIndex = 1;
            this.txtInput.TextChanged += new System.EventHandler(this.txtInput_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(849, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 36);
            this.label1.TabIndex = 7;
            this.label1.Text = "لطفا ورودي برنامه را وارد کنيد";
            // 
            // radioDoNotOmitDuplicateLetters
            // 
            this.radioDoNotOmitDuplicateLetters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioDoNotOmitDuplicateLetters.AutoSize = true;
            this.radioDoNotOmitDuplicateLetters.Checked = true;
            this.radioDoNotOmitDuplicateLetters.Location = new System.Drawing.Point(473, 31);
            this.radioDoNotOmitDuplicateLetters.Name = "radioDoNotOmitDuplicateLetters";
            this.radioDoNotOmitDuplicateLetters.Size = new System.Drawing.Size(245, 23);
            this.radioDoNotOmitDuplicateLetters.TabIndex = 2;
            this.radioDoNotOmitDuplicateLetters.TabStop = true;
            this.radioDoNotOmitDuplicateLetters.Text = "با در نظر گرفتن حروف تکراری";
            this.radioDoNotOmitDuplicateLetters.UseVisualStyleBackColor = true;
            this.radioDoNotOmitDuplicateLetters.CheckedChanged += new System.EventHandler(this.radioDoNotOmitDuplicateLetters_CheckedChanged);
            // 
            // radioDoOmitDuplicateLettersFromRightToLeft
            // 
            this.radioDoOmitDuplicateLettersFromRightToLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.radioDoOmitDuplicateLettersFromRightToLeft.AutoSize = true;
            this.radioDoOmitDuplicateLettersFromRightToLeft.Location = new System.Drawing.Point(245, 31);
            this.radioDoOmitDuplicateLettersFromRightToLeft.Name = "radioDoOmitDuplicateLettersFromRightToLeft";
            this.radioDoOmitDuplicateLettersFromRightToLeft.Size = new System.Drawing.Size(222, 23);
            this.radioDoOmitDuplicateLettersFromRightToLeft.TabIndex = 3;
            this.radioDoOmitDuplicateLettersFromRightToLeft.Text = "با حذف تکراری ها از راست";
            this.radioDoOmitDuplicateLettersFromRightToLeft.UseVisualStyleBackColor = true;
            this.radioDoOmitDuplicateLettersFromRightToLeft.CheckedChanged += new System.EventHandler(this.radioDoOmitDuplicateLetters_CheckedChanged);
            // 
            // lblMinorASFQ
            // 
            this.lblMinorASFQ.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMinorASFQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMinorASFQ.Location = new System.Drawing.Point(753, 287);
            this.lblMinorASFQ.Name = "lblMinorASFQ";
            this.lblMinorASFQ.Size = new System.Drawing.Size(63, 23);
            this.lblMinorASFQ.TabIndex = 75;
            this.lblMinorASFQ.Text = " ";
            this.lblMinorASFQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnConfirmInput
            // 
            this.btnConfirmInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirmInput.Location = new System.Drawing.Point(24, 283);
            this.btnConfirmInput.Name = "btnConfirmInput";
            this.btnConfirmInput.Size = new System.Drawing.Size(142, 30);
            this.btnConfirmInput.TabIndex = 4;
            this.btnConfirmInput.Text = "تاييد";
            this.btnConfirmInput.Click += new System.EventHandler(this.btnConfirmInput_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.Location = new System.Drawing.Point(813, 286);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(199, 23);
            this.label9.TabIndex = 74;
            this.label9.Text = "جمع ابجد کوچک ورودی:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // tabResults
            // 
            this.tabResults.Controls.Add(this.labelCount);
            this.tabResults.Controls.Add(this.txtSelectedAnswer);
            this.tabResults.Controls.Add(this.label28);
            this.tabResults.Controls.Add(this.btnSaveResults);
            this.tabResults.Controls.Add(this.lblStatus);
            this.tabResults.Controls.Add(this.progressBar);
            this.tabResults.Controls.Add(this.label20);
            this.tabResults.Controls.Add(this.btnStop);
            this.tabResults.Controls.Add(this.btnPrint);
            this.tabResults.Controls.Add(this.btnTakeToInputPanel);
            this.tabResults.Controls.Add(this.dgvAnswers);
            this.tabResults.Controls.Add(this.label13);
            this.tabResults.Controls.Add(this.nudFinalProcessingTimes);
            this.tabResults.Controls.Add(this.btnDoFinalProcessingSelected);
            this.tabResults.Controls.Add(this.txtGivenNumber);
            this.tabResults.Controls.Add(this.label12);
            this.tabResults.Controls.Add(this.btnDoFinalProcessing);
            this.tabResults.Controls.Add(this.listAnswers);
            this.tabResults.Location = new System.Drawing.Point(4, 31);
            this.tabResults.Name = "tabResults";
            this.tabResults.Padding = new System.Windows.Forms.Padding(3);
            this.tabResults.Size = new System.Drawing.Size(1186, 706);
            this.tabResults.TabIndex = 1;
            this.tabResults.Text = "   خروجی ها   ";
            this.tabResults.UseVisualStyleBackColor = true;
            // 
            // labelCount
            // 
            this.labelCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(700, 618);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(57, 19);
            this.labelCount.TabIndex = 111;
            this.labelCount.Text = "Count";
            // 
            // txtSelectedAnswer
            // 
            this.txtSelectedAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedAnswer.Location = new System.Drawing.Point(3, 434);
            this.txtSelectedAnswer.Multiline = true;
            this.txtSelectedAnswer.Name = "txtSelectedAnswer";
            this.txtSelectedAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedAnswer.Size = new System.Drawing.Size(1177, 171);
            this.txtSelectedAnswer.TabIndex = 110;
            // 
            // label28
            // 
            this.label28.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label28.Location = new System.Drawing.Point(994, 408);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(189, 23);
            this.label28.TabIndex = 108;
            this.label28.Text = "خروجی انتخاب شده:";
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveResults.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSaveResults.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSaveResults.Location = new System.Drawing.Point(313, 663);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(266, 31);
            this.btnSaveResults.TabIndex = 107;
            this.btnSaveResults.Text = "ذخیره سازی جوابهای تولید شده";
            this.btnSaveResults.UseVisualStyleBackColor = true;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(924, 611);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(254, 23);
            this.lblStatus.TabIndex = 96;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.Location = new System.Drawing.Point(103, 611);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(220, 32);
            this.progressBar.TabIndex = 95;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.Location = new System.Drawing.Point(313, 618);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(190, 23);
            this.label20.TabIndex = 94;
            this.label20.Text = "میزان پیشرفت تقریبی:";
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnStop.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnStop.Location = new System.Drawing.Point(8, 611);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(89, 32);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "توقف";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrint.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrint.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPrint.Location = new System.Drawing.Point(232, 663);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 31);
            this.btnPrint.TabIndex = 91;
            this.btnPrint.Text = "چاپ";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnTakeToInputPanel
            // 
            this.btnTakeToInputPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTakeToInputPanel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnTakeToInputPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnTakeToInputPanel.Location = new System.Drawing.Point(6, 663);
            this.btnTakeToInputPanel.Name = "btnTakeToInputPanel";
            this.btnTakeToInputPanel.Size = new System.Drawing.Size(220, 31);
            this.btnTakeToInputPanel.TabIndex = 92;
            this.btnTakeToInputPanel.Text = "انتقال به صفحه قبل";
            this.btnTakeToInputPanel.UseVisualStyleBackColor = true;
            this.btnTakeToInputPanel.Click += new System.EventHandler(this.btnTakeToInputPanel_Click);
            // 
            // dgvAnswers
            // 
            this.dgvAnswers.AllowUserToAddRows = false;
            this.dgvAnswers.AllowUserToDeleteRows = false;
            this.dgvAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnswers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.rank,
            this.inputtext});
            this.dgvAnswers.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAnswers.Location = new System.Drawing.Point(3, 3);
            this.dgvAnswers.MultiSelect = false;
            this.dgvAnswers.Name = "dgvAnswers";
            this.dgvAnswers.ReadOnly = true;
            this.dgvAnswers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAnswers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAnswers.ShowEditingIcon = false;
            this.dgvAnswers.Size = new System.Drawing.Size(1180, 402);
            this.dgvAnswers.TabIndex = 85;
            this.dgvAnswers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnswers_CellContentClick);
            this.dgvAnswers.SelectionChanged += new System.EventHandler(this.dgvAnswers_SelectionChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ش";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 40;
            // 
            // rank
            // 
            this.rank.DataPropertyName = "rank";
            this.rank.HeaderText = "امتیاز";
            this.rank.Name = "rank";
            this.rank.ReadOnly = true;
            this.rank.Width = 50;
            // 
            // inputtext
            // 
            this.inputtext.FillWeight = 400F;
            this.inputtext.HeaderText = "متن خروجی";
            this.inputtext.Name = "inputtext";
            this.inputtext.ReadOnly = true;
            this.inputtext.Width = 1250;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Location = new System.Drawing.Point(999, 666);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(27, 23);
            this.label13.TabIndex = 87;
            this.label13.Text = "بار";
            // 
            // nudFinalProcessingTimes
            // 
            this.nudFinalProcessingTimes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nudFinalProcessingTimes.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.nudFinalProcessingTimes.Location = new System.Drawing.Point(1032, 664);
            this.nudFinalProcessingTimes.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudFinalProcessingTimes.Name = "nudFinalProcessingTimes";
            this.nudFinalProcessingTimes.Size = new System.Drawing.Size(59, 27);
            this.nudFinalProcessingTimes.TabIndex = 88;
            this.nudFinalProcessingTimes.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // btnDoFinalProcessingSelected
            // 
            this.btnDoFinalProcessingSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoFinalProcessingSelected.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDoFinalProcessingSelected.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDoFinalProcessingSelected.Location = new System.Drawing.Point(794, 663);
            this.btnDoFinalProcessingSelected.Name = "btnDoFinalProcessingSelected";
            this.btnDoFinalProcessingSelected.Size = new System.Drawing.Size(143, 31);
            this.btnDoFinalProcessingSelected.TabIndex = 89;
            this.btnDoFinalProcessingSelected.Text = "جواب انتخاب شده";
            this.btnDoFinalProcessingSelected.UseVisualStyleBackColor = true;
            this.btnDoFinalProcessingSelected.Click += new System.EventHandler(this.btnDoFinalProcessingSelected_Click);
            // 
            // txtGivenNumber
            // 
            this.txtGivenNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGivenNumber.Location = new System.Drawing.Point(943, 663);
            this.txtGivenNumber.Name = "txtGivenNumber";
            this.txtGivenNumber.Size = new System.Drawing.Size(50, 27);
            this.txtGivenNumber.TabIndex = 90;
            this.txtGivenNumber.Text = "0";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(1000, 666);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(180, 23);
            this.label12.TabIndex = 86;
            this.label12.Text = "صدر موخر:";
            // 
            // btnDoFinalProcessing
            // 
            this.btnDoFinalProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoFinalProcessing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDoFinalProcessing.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDoFinalProcessing.Location = new System.Drawing.Point(681, 663);
            this.btnDoFinalProcessing.Name = "btnDoFinalProcessing";
            this.btnDoFinalProcessing.Size = new System.Drawing.Size(107, 31);
            this.btnDoFinalProcessing.TabIndex = 84;
            this.btnDoFinalProcessing.Text = "همه جوابها";
            this.btnDoFinalProcessing.UseVisualStyleBackColor = true;
            this.btnDoFinalProcessing.Click += new System.EventHandler(this.btnDoFinalProcessing_Click);
            // 
            // listAnswers
            // 
            this.listAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listAnswers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listAnswers.ItemHeight = 19;
            this.listAnswers.Location = new System.Drawing.Point(373, 451);
            this.listAnswers.Name = "listAnswers";
            this.listAnswers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listAnswers.Size = new System.Drawing.Size(267, 61);
            this.listAnswers.TabIndex = 93;
            // 
            // tabResultsAfterProcessing
            // 
            this.tabResultsAfterProcessing.Controls.Add(this.txtSelectedSelectedAnswer);
            this.tabResultsAfterProcessing.Controls.Add(this.label26);
            this.tabResultsAfterProcessing.Controls.Add(this.btnDoTheUltimateProcessing);
            this.tabResultsAfterProcessing.Controls.Add(this.dgvSelectedAnswer);
            this.tabResultsAfterProcessing.Controls.Add(this.listSelectedAnswer);
            this.tabResultsAfterProcessing.Controls.Add(this.btnPrintOneSelected);
            this.tabResultsAfterProcessing.Controls.Add(this.btnPrintAllLeft);
            this.tabResultsAfterProcessing.Location = new System.Drawing.Point(4, 31);
            this.tabResultsAfterProcessing.Name = "tabResultsAfterProcessing";
            this.tabResultsAfterProcessing.Padding = new System.Windows.Forms.Padding(3);
            this.tabResultsAfterProcessing.Size = new System.Drawing.Size(1186, 706);
            this.tabResultsAfterProcessing.TabIndex = 0;
            this.tabResultsAfterProcessing.Text = "   خروجی ها بعد از صدر موخر   ";
            this.tabResultsAfterProcessing.UseVisualStyleBackColor = true;
            // 
            // txtSelectedSelectedAnswer
            // 
            this.txtSelectedSelectedAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedSelectedAnswer.Location = new System.Drawing.Point(3, 475);
            this.txtSelectedSelectedAnswer.Multiline = true;
            this.txtSelectedSelectedAnswer.Name = "txtSelectedSelectedAnswer";
            this.txtSelectedSelectedAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedSelectedAnswer.Size = new System.Drawing.Size(1177, 189);
            this.txtSelectedSelectedAnswer.TabIndex = 111;
            // 
            // label26
            // 
            this.label26.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label26.Location = new System.Drawing.Point(994, 449);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(189, 23);
            this.label26.TabIndex = 106;
            this.label26.Text = "خروجی انتخاب شده:";
            // 
            // btnDoTheUltimateProcessing
            // 
            this.btnDoTheUltimateProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDoTheUltimateProcessing.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnDoTheUltimateProcessing.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnDoTheUltimateProcessing.Location = new System.Drawing.Point(979, 670);
            this.btnDoTheUltimateProcessing.Name = "btnDoTheUltimateProcessing";
            this.btnDoTheUltimateProcessing.Size = new System.Drawing.Size(199, 28);
            this.btnDoTheUltimateProcessing.TabIndex = 91;
            this.btnDoTheUltimateProcessing.Text = "نمایش و انتخاب حروف";
            this.btnDoTheUltimateProcessing.UseVisualStyleBackColor = true;
            this.btnDoTheUltimateProcessing.Click += new System.EventHandler(this.btnDoTheUltimateProcessing_Click);
            // 
            // dgvSelectedAnswer
            // 
            this.dgvSelectedAnswer.AllowUserToAddRows = false;
            this.dgvSelectedAnswer.AllowUserToDeleteRows = false;
            this.dgvSelectedAnswer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSelectedAnswer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn2});
            this.dgvSelectedAnswer.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvSelectedAnswer.Location = new System.Drawing.Point(3, 3);
            this.dgvSelectedAnswer.MultiSelect = false;
            this.dgvSelectedAnswer.Name = "dgvSelectedAnswer";
            this.dgvSelectedAnswer.ReadOnly = true;
            this.dgvSelectedAnswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSelectedAnswer.RowTemplate.Height = 55;
            this.dgvSelectedAnswer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSelectedAnswer.ShowEditingIcon = false;
            this.dgvSelectedAnswer.Size = new System.Drawing.Size(1180, 443);
            this.dgvSelectedAnswer.TabIndex = 88;
            this.dgvSelectedAnswer.SelectionChanged += new System.EventHandler(this.dgvSelectedAnswer_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ش";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 40;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "rank";
            this.dataGridViewTextBoxColumn3.HeaderText = "امتیاز";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 50;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "inputtext";
            this.dataGridViewTextBoxColumn2.FillWeight = 400F;
            this.dataGridViewTextBoxColumn2.HeaderText = "متن خروجی بعد از صدر موخر";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 1500;
            // 
            // listSelectedAnswer
            // 
            this.listSelectedAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listSelectedAnswer.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.listSelectedAnswer.ItemHeight = 19;
            this.listSelectedAnswer.Location = new System.Drawing.Point(58, 194);
            this.listSelectedAnswer.Name = "listSelectedAnswer";
            this.listSelectedAnswer.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.listSelectedAnswer.Size = new System.Drawing.Size(460, 61);
            this.listSelectedAnswer.TabIndex = 90;
            // 
            // btnPrintOneSelected
            // 
            this.btnPrintOneSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintOneSelected.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrintOneSelected.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPrintOneSelected.Location = new System.Drawing.Point(115, 670);
            this.btnPrintOneSelected.Name = "btnPrintOneSelected";
            this.btnPrintOneSelected.Size = new System.Drawing.Size(199, 28);
            this.btnPrintOneSelected.TabIndex = 87;
            this.btnPrintOneSelected.Text = "چاپ جواب انتخاب شده";
            this.btnPrintOneSelected.UseVisualStyleBackColor = true;
            // 
            // btnPrintAllLeft
            // 
            this.btnPrintAllLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPrintAllLeft.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnPrintAllLeft.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnPrintAllLeft.Location = new System.Drawing.Point(8, 670);
            this.btnPrintAllLeft.Name = "btnPrintAllLeft";
            this.btnPrintAllLeft.Size = new System.Drawing.Size(101, 28);
            this.btnPrintAllLeft.TabIndex = 86;
            this.btnPrintAllLeft.Text = "چاپ همه";
            this.btnPrintAllLeft.UseVisualStyleBackColor = true;
            // 
            // tabResultsAfterUltimateProcessing
            // 
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.lblRankFinal);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.label29);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.vScrollBar1);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.txtUltimateResult);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.btnSaveUltimateResult);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.label2);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.label24);
            this.tabResultsAfterUltimateProcessing.Controls.Add(this.pnlUltimateSelection);
            this.tabResultsAfterUltimateProcessing.Location = new System.Drawing.Point(4, 31);
            this.tabResultsAfterUltimateProcessing.Name = "tabResultsAfterUltimateProcessing";
            this.tabResultsAfterUltimateProcessing.Size = new System.Drawing.Size(1186, 706);
            this.tabResultsAfterUltimateProcessing.TabIndex = 2;
            this.tabResultsAfterUltimateProcessing.Text = "   خروجی نهایی   ";
            this.tabResultsAfterUltimateProcessing.UseVisualStyleBackColor = true;
            this.tabResultsAfterUltimateProcessing.Click += new System.EventHandler(this.tabResultsAfterUltimateProcessing_Click);
            // 
            // lblRankFinal
            // 
            this.lblRankFinal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRankFinal.Location = new System.Drawing.Point(801, 510);
            this.lblRankFinal.Name = "lblRankFinal";
            this.lblRankFinal.Size = new System.Drawing.Size(53, 19);
            this.lblRankFinal.TabIndex = 114;
            this.lblRankFinal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(855, 510);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 19);
            this.label29.TabIndex = 113;
            this.label29.Text = "امتیاز:";
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar1.Location = new System.Drawing.Point(1160, 13);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(19, 498);
            this.vScrollBar1.TabIndex = 101;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // txtUltimateResult
            // 
            this.txtUltimateResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUltimateResult.Location = new System.Drawing.Point(5, 548);
            this.txtUltimateResult.Multiline = true;
            this.txtUltimateResult.Name = "txtUltimateResult";
            this.txtUltimateResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtUltimateResult.Size = new System.Drawing.Size(1177, 150);
            this.txtUltimateResult.TabIndex = 112;
            // 
            // btnSaveUltimateResult
            // 
            this.btnSaveUltimateResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveUltimateResult.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnSaveUltimateResult.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnSaveUltimateResult.Location = new System.Drawing.Point(928, 514);
            this.btnSaveUltimateResult.Name = "btnSaveUltimateResult";
            this.btnSaveUltimateResult.Size = new System.Drawing.Size(128, 28);
            this.btnSaveUltimateResult.TabIndex = 106;
            this.btnSaveUltimateResult.Text = "ذخیره سازی";
            this.btnSaveUltimateResult.UseVisualStyleBackColor = true;
            this.btnSaveUltimateResult.Click += new System.EventHandler(this.btnSaveUltimateResult_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(314, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(713, 25);
            this.label2.TabIndex = 101;
            this.label2.Visible = false;
            // 
            // label24
            // 
            this.label24.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label24.Location = new System.Drawing.Point(994, 519);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(189, 23);
            this.label24.TabIndex = 91;
            this.label24.Text = "خروجی نهایی:";
            // 
            // pnlUltimateSelection
            // 
            this.pnlUltimateSelection.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlUltimateSelection.Location = new System.Drawing.Point(8, 13);
            this.pnlUltimateSelection.Name = "pnlUltimateSelection";
            this.pnlUltimateSelection.Size = new System.Drawing.Size(1149, 489);
            this.pnlUltimateSelection.TabIndex = 104;
            // 
            // tabQs
            // 
            this.tabQs.Controls.Add(this.splitContainer1);
            this.tabQs.Location = new System.Drawing.Point(4, 31);
            this.tabQs.Name = "tabQs";
            this.tabQs.Size = new System.Drawing.Size(1186, 706);
            this.tabQs.TabIndex = 4;
            this.tabQs.Text = "   ورودی های ذخیره شده   ";
            this.tabQs.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvInputs);
            this.splitContainer1.Panel1.Controls.Add(this.btnViewInputs);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnProcessRawAnswers);
            this.splitContainer1.Panel2.Controls.Add(this.txtSelectedInput);
            this.splitContainer1.Panel2.Controls.Add(this.label25);
            this.splitContainer1.Panel2.Controls.Add(this.btnViewUltimateResults);
            this.splitContainer1.Panel2.Controls.Add(this.btnViewRawResults);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1186, 706);
            this.splitContainer1.SplitterDistance = 459;
            this.splitContainer1.TabIndex = 91;
            // 
            // dgvInputs
            // 
            this.dgvInputs.AllowUserToAddRows = false;
            this.dgvInputs.AllowUserToDeleteRows = false;
            this.dgvInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn8});
            this.dgvInputs.Location = new System.Drawing.Point(3, 37);
            this.dgvInputs.MultiSelect = false;
            this.dgvInputs.Name = "dgvInputs";
            this.dgvInputs.ReadOnly = true;
            this.dgvInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvInputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInputs.ShowEditingIcon = false;
            this.dgvInputs.Size = new System.Drawing.Size(1186, 422);
            this.dgvInputs.TabIndex = 109;
            this.dgvInputs.SelectionChanged += new System.EventHandler(this.dgvInputs_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "شناسه";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            this.dataGridViewTextBoxColumn5.Width = 5;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.FillWeight = 400F;
            this.dataGridViewTextBoxColumn8.HeaderText = "متن ورودی";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 2500;
            // 
            // btnViewInputs
            // 
            this.btnViewInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewInputs.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnViewInputs.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnViewInputs.Location = new System.Drawing.Point(1015, -3);
            this.btnViewInputs.Name = "btnViewInputs";
            this.btnViewInputs.Size = new System.Drawing.Size(165, 28);
            this.btnViewInputs.TabIndex = 108;
            this.btnViewInputs.Text = "مشاهده ورودی ها";
            this.btnViewInputs.UseVisualStyleBackColor = true;
            this.btnViewInputs.Click += new System.EventHandler(this.btnViewInputs_Click);
            // 
            // btnProcessRawAnswers
            // 
            this.btnProcessRawAnswers.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnProcessRawAnswers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnProcessRawAnswers.Location = new System.Drawing.Point(477, 2);
            this.btnProcessRawAnswers.Name = "btnProcessRawAnswers";
            this.btnProcessRawAnswers.Size = new System.Drawing.Size(232, 28);
            this.btnProcessRawAnswers.TabIndex = 113;
            this.btnProcessRawAnswers.Text = "نمایش در صفحه خروجی ها";
            this.btnProcessRawAnswers.UseVisualStyleBackColor = true;
            this.btnProcessRawAnswers.Click += new System.EventHandler(this.btnProcessRawAnswers_Click);
            // 
            // txtSelectedInput
            // 
            this.txtSelectedInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedInput.Location = new System.Drawing.Point(3, 36);
            this.txtSelectedInput.Multiline = true;
            this.txtSelectedInput.Name = "txtSelectedInput";
            this.txtSelectedInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedInput.Size = new System.Drawing.Size(1177, 241);
            this.txtSelectedInput.TabIndex = 112;
            // 
            // label25
            // 
            this.label25.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label25.Location = new System.Drawing.Point(993, 7);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(189, 23);
            this.label25.TabIndex = 111;
            this.label25.Text = "ورودی انتخاب شده:";
            // 
            // btnViewUltimateResults
            // 
            this.btnViewUltimateResults.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnViewUltimateResults.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnViewUltimateResults.Location = new System.Drawing.Point(8, 2);
            this.btnViewUltimateResults.Name = "btnViewUltimateResults";
            this.btnViewUltimateResults.Size = new System.Drawing.Size(232, 28);
            this.btnViewUltimateResults.TabIndex = 110;
            this.btnViewUltimateResults.Text = "مشاهده خروجی های نهایی";
            this.btnViewUltimateResults.UseVisualStyleBackColor = true;
            this.btnViewUltimateResults.Click += new System.EventHandler(this.btnViewUltimateResults_Click);
            // 
            // btnViewRawResults
            // 
            this.btnViewRawResults.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.btnViewRawResults.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnViewRawResults.Location = new System.Drawing.Point(246, 2);
            this.btnViewRawResults.Name = "btnViewRawResults";
            this.btnViewRawResults.Size = new System.Drawing.Size(225, 28);
            this.btnViewRawResults.TabIndex = 109;
            this.btnViewRawResults.Text = "مشاهده خروجی های اولیه";
            this.btnViewRawResults.UseVisualStyleBackColor = true;
            this.btnViewRawResults.Click += new System.EventHandler(this.btnViewRawResults_Click);
            // 
            // tabAs
            // 
            this.tabAs.Controls.Add(this.label27);
            this.tabAs.Controls.Add(this.txtSelectedSavedAnswer);
            this.tabAs.Controls.Add(this.dgvSavedAnswers);
            this.tabAs.Location = new System.Drawing.Point(4, 31);
            this.tabAs.Name = "tabAs";
            this.tabAs.Size = new System.Drawing.Size(1186, 706);
            this.tabAs.TabIndex = 5;
            this.tabAs.Text = "   خروجی های ذخیره شده   ";
            this.tabAs.UseVisualStyleBackColor = true;
            // 
            // label27
            // 
            this.label27.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label27.Location = new System.Drawing.Point(989, 496);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(189, 23);
            this.label27.TabIndex = 113;
            this.label27.Text = "خروجی انتخاب شده:";
            // 
            // txtSelectedSavedAnswer
            // 
            this.txtSelectedSavedAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectedSavedAnswer.Location = new System.Drawing.Point(3, 520);
            this.txtSelectedSavedAnswer.Multiline = true;
            this.txtSelectedSavedAnswer.Name = "txtSelectedSavedAnswer";
            this.txtSelectedSavedAnswer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSelectedSavedAnswer.Size = new System.Drawing.Size(1177, 180);
            this.txtSelectedSavedAnswer.TabIndex = 112;
            // 
            // dgvSavedAnswers
            // 
            this.dgvSavedAnswers.AllowUserToAddRows = false;
            this.dgvSavedAnswers.AllowUserToDeleteRows = false;
            this.dgvSavedAnswers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSavedAnswers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSavedAnswers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn9});
            this.dgvSavedAnswers.Location = new System.Drawing.Point(0, 2);
            this.dgvSavedAnswers.MultiSelect = false;
            this.dgvSavedAnswers.Name = "dgvSavedAnswers";
            this.dgvSavedAnswers.ReadOnly = true;
            this.dgvSavedAnswers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvSavedAnswers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSavedAnswers.ShowEditingIcon = false;
            this.dgvSavedAnswers.Size = new System.Drawing.Size(1186, 493);
            this.dgvSavedAnswers.TabIndex = 92;
            this.dgvSavedAnswers.SelectionChanged += new System.EventHandler(this.dgvSavedAnswers_SelectionChanged);
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "شناسه";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            this.dataGridViewTextBoxColumn7.Width = 5;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.FillWeight = 400F;
            this.dataGridViewTextBoxColumn9.HeaderText = "متن خروجی";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 2500;
            // 
            // con
            // 
            this.con.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=\"D:\\Boddooh 91102\\Boddooh\\InputList." +
                "mdb\";Persist Security Info=True";
            // 
            // daQs
            // 
            this.daQs.DeleteCommand = this.oleDbCommand1;
            this.daQs.InsertCommand = this.oleDbCommand2;
            this.daQs.SelectCommand = this.oleDbCommand3;
            this.daQs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daQs.UpdateCommand = this.oleDbCommand4;
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
            this.oleDbCommand2.CommandText = "INSERT INTO Qs\r\n                      (qid, input1, input2, input3, input4, input" +
                "5, input6, input7, input8)\r\nVALUES     (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand2.Connection = this.con;
            this.oleDbCommand2.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("input1", System.Data.OleDb.OleDbType.WChar, 255, "input1"),
            new System.Data.OleDb.OleDbParameter("input2", System.Data.OleDb.OleDbType.WChar, 255, "input2"),
            new System.Data.OleDb.OleDbParameter("input3", System.Data.OleDb.OleDbType.WChar, 255, "input3"),
            new System.Data.OleDb.OleDbParameter("input4", System.Data.OleDb.OleDbType.WChar, 255, "input4"),
            new System.Data.OleDb.OleDbParameter("input5", System.Data.OleDb.OleDbType.WChar, 255, "input5"),
            new System.Data.OleDb.OleDbParameter("input6", System.Data.OleDb.OleDbType.WChar, 255, "input6"),
            new System.Data.OleDb.OleDbParameter("input7", System.Data.OleDb.OleDbType.WChar, 255, "input7"),
            new System.Data.OleDb.OleDbParameter("input8", System.Data.OleDb.OleDbType.WChar, 255, "input8")});
            // 
            // oleDbCommand3
            // 
            this.oleDbCommand3.CommandText = resources.GetString("oleDbCommand3.CommandText");
            this.oleDbCommand3.Connection = this.con;
            this.oleDbCommand3.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("input1", System.Data.OleDb.OleDbType.WChar, 255, "input1"),
            new System.Data.OleDb.OleDbParameter("input2", System.Data.OleDb.OleDbType.WChar, 255, "input2"),
            new System.Data.OleDb.OleDbParameter("input3", System.Data.OleDb.OleDbType.WChar, 255, "input3"),
            new System.Data.OleDb.OleDbParameter("input4", System.Data.OleDb.OleDbType.WChar, 255, "input4"),
            new System.Data.OleDb.OleDbParameter("input5", System.Data.OleDb.OleDbType.WChar, 255, "input5"),
            new System.Data.OleDb.OleDbParameter("input6", System.Data.OleDb.OleDbType.WChar, 255, "input6"),
            new System.Data.OleDb.OleDbParameter("input7", System.Data.OleDb.OleDbType.WChar, 255, "input7"),
            new System.Data.OleDb.OleDbParameter("input8", System.Data.OleDb.OleDbType.WChar, 255, "input8"),
            new System.Data.OleDb.OleDbParameter("input9", System.Data.OleDb.OleDbType.WChar, 255, "input9"),
            new System.Data.OleDb.OleDbParameter("input10", System.Data.OleDb.OleDbType.WChar, 255, "input10"),
            new System.Data.OleDb.OleDbParameter("input11", System.Data.OleDb.OleDbType.WChar, 255, "input11"),
            new System.Data.OleDb.OleDbParameter("input12", System.Data.OleDb.OleDbType.WChar, 255, "input12"),
            new System.Data.OleDb.OleDbParameter("input13", System.Data.OleDb.OleDbType.WChar, 255, "input13"),
            new System.Data.OleDb.OleDbParameter("input14", System.Data.OleDb.OleDbType.WChar, 255, "input14"),
            new System.Data.OleDb.OleDbParameter("input15", System.Data.OleDb.OleDbType.WChar, 255, "input15"),
            new System.Data.OleDb.OleDbParameter("input16", System.Data.OleDb.OleDbType.WChar, 255, "input16"),
            new System.Data.OleDb.OleDbParameter("input17", System.Data.OleDb.OleDbType.WChar, 255, "input17"),
            new System.Data.OleDb.OleDbParameter("input18", System.Data.OleDb.OleDbType.WChar, 255, "input18"),
            new System.Data.OleDb.OleDbParameter("input19", System.Data.OleDb.OleDbType.WChar, 255, "input19"),
            new System.Data.OleDb.OleDbParameter("input20", System.Data.OleDb.OleDbType.WChar, 255, "input20")});
            // 
            // oleDbCommand4
            // 
            this.oleDbCommand4.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daQs2
            // 
            this.daQs2.DeleteCommand = this.oleDbCommand5;
            this.daQs2.InsertCommand = this.oleDbCommand6;
            this.daQs2.SelectCommand = this.oleDbCommand7;
            this.daQs2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daQs2.UpdateCommand = this.oleDbCommand8;
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
            this.oleDbCommand6.CommandText = "INSERT INTO Inputs\r\n                      (id, wd, wod, inputtext1, inputtext2, i" +
                "nputtext3, inputtext4, inputtext5, inputtext6, inputtext7, inputtext8)\r\nVALUES  " +
                "   (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand6.Connection = this.con;
            this.oleDbCommand6.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("inputtext8", System.Data.OleDb.OleDbType.WChar, 255, "inputtext8")});
            // 
            // oleDbCommand7
            // 
            this.oleDbCommand7.CommandText = "SELECT     MAX(qid) AS maxqid\r\nFROM         Qs";
            this.oleDbCommand7.Connection = this.con;
            // 
            // oleDbCommand8
            // 
            this.oleDbCommand8.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand8.Connection = this.con;
            this.oleDbCommand8.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daRAs
            // 
            this.daRAs.DeleteCommand = this.oleDbCommand9;
            this.daRAs.InsertCommand = this.oleDbCommand10;
            this.daRAs.SelectCommand = this.oleDbCommand11;
            this.daRAs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daRAs.UpdateCommand = this.oleDbCommand12;
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
            this.oleDbCommand10.CommandText = "INSERT INTO RAs\r\n                      (qid, raid, ranswer1, ranswer2, ranswer3, " +
                "ranswer4, ranswer5, ranswer6, ranswer7, ranswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand10.Connection = this.con;
            this.oleDbCommand10.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("raid", System.Data.OleDb.OleDbType.Integer, 0, "raid"),
            new System.Data.OleDb.OleDbParameter("ranswer1", System.Data.OleDb.OleDbType.WChar, 255, "ranswer1"),
            new System.Data.OleDb.OleDbParameter("ranswer2", System.Data.OleDb.OleDbType.WChar, 255, "ranswer2"),
            new System.Data.OleDb.OleDbParameter("ranswer3", System.Data.OleDb.OleDbType.WChar, 255, "ranswer3"),
            new System.Data.OleDb.OleDbParameter("ranswer4", System.Data.OleDb.OleDbType.WChar, 255, "ranswer4"),
            new System.Data.OleDb.OleDbParameter("ranswer5", System.Data.OleDb.OleDbType.WChar, 255, "ranswer5"),
            new System.Data.OleDb.OleDbParameter("ranswer6", System.Data.OleDb.OleDbType.WChar, 255, "ranswer6"),
            new System.Data.OleDb.OleDbParameter("ranswer7", System.Data.OleDb.OleDbType.WChar, 255, "ranswer7"),
            new System.Data.OleDb.OleDbParameter("ranswer8", System.Data.OleDb.OleDbType.WChar, 255, "ranswer8")});
            // 
            // oleDbCommand11
            // 
            this.oleDbCommand11.CommandText = "SELECT     raid, ranswer1, ranswer2, ranswer3, ranswer4, ranswer5, ranswer6, rans" +
                "wer7, ranswer8\r\nFROM         RAs\r\nWHERE     (qid = ?)";
            this.oleDbCommand11.Connection = this.con;
            this.oleDbCommand11.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid")});
            // 
            // oleDbCommand12
            // 
            this.oleDbCommand12.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand12.Connection = this.con;
            this.oleDbCommand12.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.DeleteCommand = this.oleDbCommand13;
            this.oleDbDataAdapter1.InsertCommand = this.oleDbCommand14;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbCommand15;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.oleDbDataAdapter1.UpdateCommand = this.oleDbCommand16;
            // 
            // oleDbCommand13
            // 
            this.oleDbCommand13.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand13.Connection = this.con;
            this.oleDbCommand13.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand14
            // 
            this.oleDbCommand14.CommandText = "INSERT INTO Qs\r\n                      (qid, input1, input2, input3, input4, input" +
                "5, input6, input7, input8)\r\nVALUES     (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand14.Connection = this.con;
            this.oleDbCommand14.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("input1", System.Data.OleDb.OleDbType.WChar, 255, "input1"),
            new System.Data.OleDb.OleDbParameter("input2", System.Data.OleDb.OleDbType.WChar, 255, "input2"),
            new System.Data.OleDb.OleDbParameter("input3", System.Data.OleDb.OleDbType.WChar, 255, "input3"),
            new System.Data.OleDb.OleDbParameter("input4", System.Data.OleDb.OleDbType.WChar, 255, "input4"),
            new System.Data.OleDb.OleDbParameter("input5", System.Data.OleDb.OleDbType.WChar, 255, "input5"),
            new System.Data.OleDb.OleDbParameter("input6", System.Data.OleDb.OleDbType.WChar, 255, "input6"),
            new System.Data.OleDb.OleDbParameter("input7", System.Data.OleDb.OleDbType.WChar, 255, "input7"),
            new System.Data.OleDb.OleDbParameter("input8", System.Data.OleDb.OleDbType.WChar, 255, "input8")});
            // 
            // oleDbCommand15
            // 
            this.oleDbCommand15.CommandText = "SELECT     qid\r\nFROM         Qs\r\nWHERE     (input1 = ?) AND (input2 = ?) AND (inp" +
                "ut3 = ?) AND (input4 = ?) AND (input5 = ?) AND (input6 = ?) AND (input7 = ?) AND" +
                " (input8 = ?)";
            this.oleDbCommand15.Connection = this.con;
            this.oleDbCommand15.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("input1", System.Data.OleDb.OleDbType.WChar, 255, "input1"),
            new System.Data.OleDb.OleDbParameter("input2", System.Data.OleDb.OleDbType.WChar, 255, "input2"),
            new System.Data.OleDb.OleDbParameter("input3", System.Data.OleDb.OleDbType.WChar, 255, "input3"),
            new System.Data.OleDb.OleDbParameter("input4", System.Data.OleDb.OleDbType.WChar, 255, "input4"),
            new System.Data.OleDb.OleDbParameter("input5", System.Data.OleDb.OleDbType.WChar, 255, "input5"),
            new System.Data.OleDb.OleDbParameter("input6", System.Data.OleDb.OleDbType.WChar, 255, "input6"),
            new System.Data.OleDb.OleDbParameter("input7", System.Data.OleDb.OleDbType.WChar, 255, "input7"),
            new System.Data.OleDb.OleDbParameter("input8", System.Data.OleDb.OleDbType.WChar, 255, "input8")});
            // 
            // oleDbCommand16
            // 
            this.oleDbCommand16.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand16.Connection = this.con;
            this.oleDbCommand16.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daUAs
            // 
            this.daUAs.DeleteCommand = this.oleDbCommand17;
            this.daUAs.InsertCommand = this.oleDbCommand18;
            this.daUAs.SelectCommand = this.oleDbCommand19;
            this.daUAs.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daUAs.UpdateCommand = this.oleDbCommand20;
            // 
            // oleDbCommand17
            // 
            this.oleDbCommand17.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand17.Connection = this.con;
            this.oleDbCommand17.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand18
            // 
            this.oleDbCommand18.CommandText = "INSERT INTO UAs\r\n                      (qid, uaid, uanswer1, uanswer2, uanswer3, " +
                "uanswer4, uanswer5, uanswer6, uanswer7, uanswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand18.Connection = this.con;
            this.oleDbCommand18.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uaid", System.Data.OleDb.OleDbType.Integer, 0, "uaid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand19
            // 
            this.oleDbCommand19.CommandText = "SELECT     raid, ranswer1, ranswer2, ranswer3, ranswer4, ranswer5, ranswer6, rans" +
                "wer7, ranswer8\r\nFROM         RAs\r\nWHERE     (qid = ?)";
            this.oleDbCommand19.Connection = this.con;
            this.oleDbCommand19.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid")});
            // 
            // oleDbCommand20
            // 
            this.oleDbCommand20.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand20.Connection = this.con;
            this.oleDbCommand20.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daRAs2
            // 
            this.daRAs2.DeleteCommand = this.oleDbCommand21;
            this.daRAs2.InsertCommand = this.oleDbCommand22;
            this.daRAs2.SelectCommand = this.oleDbCommand23;
            this.daRAs2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daRAs2.UpdateCommand = this.oleDbCommand24;
            // 
            // oleDbCommand21
            // 
            this.oleDbCommand21.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand21.Connection = this.con;
            this.oleDbCommand21.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand22
            // 
            this.oleDbCommand22.CommandText = "INSERT INTO RAs\r\n                      (qid, raid, ranswer1, ranswer2, ranswer3, " +
                "ranswer4, ranswer5, ranswer6, ranswer7, ranswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand22.Connection = this.con;
            this.oleDbCommand22.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("raid", System.Data.OleDb.OleDbType.Integer, 0, "raid"),
            new System.Data.OleDb.OleDbParameter("ranswer1", System.Data.OleDb.OleDbType.WChar, 255, "ranswer1"),
            new System.Data.OleDb.OleDbParameter("ranswer2", System.Data.OleDb.OleDbType.WChar, 255, "ranswer2"),
            new System.Data.OleDb.OleDbParameter("ranswer3", System.Data.OleDb.OleDbType.WChar, 255, "ranswer3"),
            new System.Data.OleDb.OleDbParameter("ranswer4", System.Data.OleDb.OleDbType.WChar, 255, "ranswer4"),
            new System.Data.OleDb.OleDbParameter("ranswer5", System.Data.OleDb.OleDbType.WChar, 255, "ranswer5"),
            new System.Data.OleDb.OleDbParameter("ranswer6", System.Data.OleDb.OleDbType.WChar, 255, "ranswer6"),
            new System.Data.OleDb.OleDbParameter("ranswer7", System.Data.OleDb.OleDbType.WChar, 255, "ranswer7"),
            new System.Data.OleDb.OleDbParameter("ranswer8", System.Data.OleDb.OleDbType.WChar, 255, "ranswer8")});
            // 
            // oleDbCommand23
            // 
            this.oleDbCommand23.CommandText = "SELECT     MAX(raid) AS maxraid\r\nFROM         RAs";
            this.oleDbCommand23.Connection = this.con;
            // 
            // oleDbCommand24
            // 
            this.oleDbCommand24.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand24.Connection = this.con;
            this.oleDbCommand24.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daUAs2
            // 
            this.daUAs2.DeleteCommand = this.oleDbCommand25;
            this.daUAs2.InsertCommand = this.oleDbCommand26;
            this.daUAs2.SelectCommand = this.oleDbCommand27;
            this.daUAs2.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daUAs2.UpdateCommand = this.oleDbCommand28;
            // 
            // oleDbCommand25
            // 
            this.oleDbCommand25.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand25.Connection = this.con;
            this.oleDbCommand25.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand26
            // 
            this.oleDbCommand26.CommandText = "INSERT INTO UAs\r\n                      (qid, uaid, uanswer1, uanswer2, uanswer3, " +
                "uanswer4, uanswer5, uanswer6, uanswer7, uanswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand26.Connection = this.con;
            this.oleDbCommand26.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uaid", System.Data.OleDb.OleDbType.Integer, 0, "uaid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand27
            // 
            this.oleDbCommand27.CommandText = "SELECT     MAX(uaid) AS maxuaid\r\nFROM         UAs";
            this.oleDbCommand27.Connection = this.con;
            // 
            // oleDbCommand28
            // 
            this.oleDbCommand28.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand28.Connection = this.con;
            this.oleDbCommand28.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daQs3
            // 
            this.daQs3.DeleteCommand = this.oleDbCommand29;
            this.daQs3.InsertCommand = this.oleDbCommand30;
            this.daQs3.SelectCommand = this.oleDbCommand31;
            this.daQs3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daQs3.UpdateCommand = this.oleDbCommand32;
            // 
            // oleDbCommand29
            // 
            this.oleDbCommand29.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand29.Connection = this.con;
            this.oleDbCommand29.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand30
            // 
            this.oleDbCommand30.CommandText = "INSERT INTO Qs\r\n                      (qid, input1, input2, input3, input4, input" +
                "5, input6, input7, input8)\r\nVALUES     (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand30.Connection = this.con;
            this.oleDbCommand30.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("input1", System.Data.OleDb.OleDbType.WChar, 255, "input1"),
            new System.Data.OleDb.OleDbParameter("input2", System.Data.OleDb.OleDbType.WChar, 255, "input2"),
            new System.Data.OleDb.OleDbParameter("input3", System.Data.OleDb.OleDbType.WChar, 255, "input3"),
            new System.Data.OleDb.OleDbParameter("input4", System.Data.OleDb.OleDbType.WChar, 255, "input4"),
            new System.Data.OleDb.OleDbParameter("input5", System.Data.OleDb.OleDbType.WChar, 255, "input5"),
            new System.Data.OleDb.OleDbParameter("input6", System.Data.OleDb.OleDbType.WChar, 255, "input6"),
            new System.Data.OleDb.OleDbParameter("input7", System.Data.OleDb.OleDbType.WChar, 255, "input7"),
            new System.Data.OleDb.OleDbParameter("input8", System.Data.OleDb.OleDbType.WChar, 255, "input8")});
            // 
            // oleDbCommand31
            // 
            this.oleDbCommand31.CommandText = "SELECT     qid, input1, input2, input3, input4, input5, input6, input7, input8\r\nF" +
                "ROM         Qs";
            this.oleDbCommand31.Connection = this.con;
            // 
            // oleDbCommand32
            // 
            this.oleDbCommand32.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand32.Connection = this.con;
            this.oleDbCommand32.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daUAs3
            // 
            this.daUAs3.DeleteCommand = this.oleDbCommand33;
            this.daUAs3.InsertCommand = this.oleDbCommand34;
            this.daUAs3.SelectCommand = this.oleDbCommand35;
            this.daUAs3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daUAs3.UpdateCommand = this.oleDbCommand36;
            // 
            // oleDbCommand33
            // 
            this.oleDbCommand33.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand33.Connection = this.con;
            this.oleDbCommand33.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand34
            // 
            this.oleDbCommand34.CommandText = "INSERT INTO UAs\r\n                      (qid, uaid, uanswer1, uanswer2, uanswer3, " +
                "uanswer4, uanswer5, uanswer6, uanswer7, uanswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand34.Connection = this.con;
            this.oleDbCommand34.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uaid", System.Data.OleDb.OleDbType.Integer, 0, "uaid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand35
            // 
            this.oleDbCommand35.CommandText = "SELECT     uaid, uanswer1, uanswer2, uanswer3, uanswer4, uanswer5, uanswer6, uans" +
                "wer7, uanswer8\r\nFROM         UAs\r\nWHERE     (qid = ?)";
            this.oleDbCommand35.Connection = this.con;
            this.oleDbCommand35.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid")});
            // 
            // oleDbCommand36
            // 
            this.oleDbCommand36.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand36.Connection = this.con;
            this.oleDbCommand36.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daRAs3
            // 
            this.daRAs3.DeleteCommand = this.oleDbCommand37;
            this.daRAs3.InsertCommand = this.oleDbCommand38;
            this.daRAs3.SelectCommand = this.oleDbCommand39;
            this.daRAs3.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daRAs3.UpdateCommand = this.oleDbCommand40;
            // 
            // oleDbCommand37
            // 
            this.oleDbCommand37.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand37.Connection = this.con;
            this.oleDbCommand37.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand38
            // 
            this.oleDbCommand38.CommandText = "INSERT INTO UAs\r\n                      (qid, uaid, uanswer1, uanswer2, uanswer3, " +
                "uanswer4, uanswer5, uanswer6, uanswer7, uanswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand38.Connection = this.con;
            this.oleDbCommand38.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uaid", System.Data.OleDb.OleDbType.Integer, 0, "uaid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand39
            // 
            this.oleDbCommand39.CommandText = "SELECT     raid, ranswer1, ranswer2, ranswer3, ranswer4, ranswer5, ranswer6, rans" +
                "wer7, ranswer8\r\nFROM         RAs\r\nWHERE     (qid = ?)";
            this.oleDbCommand39.Connection = this.con;
            this.oleDbCommand39.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid")});
            // 
            // oleDbCommand40
            // 
            this.oleDbCommand40.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand40.Connection = this.con;
            this.oleDbCommand40.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daRAs4
            // 
            this.daRAs4.DeleteCommand = this.oleDbCommand41;
            this.daRAs4.InsertCommand = this.oleDbCommand42;
            this.daRAs4.SelectCommand = this.oleDbCommand43;
            this.daRAs4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daRAs4.UpdateCommand = this.oleDbCommand44;
            // 
            // oleDbCommand41
            // 
            this.oleDbCommand41.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand41.Connection = this.con;
            this.oleDbCommand41.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand42
            // 
            this.oleDbCommand42.CommandText = "INSERT INTO UAs\r\n                      (qid, uaid, uanswer1, uanswer2, uanswer3, " +
                "uanswer4, uanswer5, uanswer6, uanswer7, uanswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand42.Connection = this.con;
            this.oleDbCommand42.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uaid", System.Data.OleDb.OleDbType.Integer, 0, "uaid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand43
            // 
            this.oleDbCommand43.CommandText = resources.GetString("oleDbCommand43.CommandText");
            this.oleDbCommand43.Connection = this.con;
            this.oleDbCommand43.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("ranswer1", System.Data.OleDb.OleDbType.WChar, 255, "ranswer1"),
            new System.Data.OleDb.OleDbParameter("ranswer2", System.Data.OleDb.OleDbType.WChar, 255, "ranswer2"),
            new System.Data.OleDb.OleDbParameter("ranswer3", System.Data.OleDb.OleDbType.WChar, 255, "ranswer3"),
            new System.Data.OleDb.OleDbParameter("ranswer4", System.Data.OleDb.OleDbType.WChar, 255, "ranswer4"),
            new System.Data.OleDb.OleDbParameter("ranswer5", System.Data.OleDb.OleDbType.WChar, 255, "ranswer5"),
            new System.Data.OleDb.OleDbParameter("ranswer6", System.Data.OleDb.OleDbType.WChar, 255, "ranswer6"),
            new System.Data.OleDb.OleDbParameter("ranswer7", System.Data.OleDb.OleDbType.WChar, 255, "ranswer7"),
            new System.Data.OleDb.OleDbParameter("ranswer8", System.Data.OleDb.OleDbType.WChar, 255, "ranswer8")});
            // 
            // oleDbCommand44
            // 
            this.oleDbCommand44.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand44.Connection = this.con;
            this.oleDbCommand44.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daUAs4
            // 
            this.daUAs4.DeleteCommand = this.oleDbCommand45;
            this.daUAs4.InsertCommand = this.oleDbCommand46;
            this.daUAs4.SelectCommand = this.oleDbCommand47;
            this.daUAs4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daUAs4.UpdateCommand = this.oleDbCommand48;
            // 
            // oleDbCommand45
            // 
            this.oleDbCommand45.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand45.Connection = this.con;
            this.oleDbCommand45.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand46
            // 
            this.oleDbCommand46.CommandText = "INSERT INTO UAs\r\n                      (qid, uaid, uanswer1, uanswer2, uanswer3, " +
                "uanswer4, uanswer5, uanswer6, uanswer7, uanswer8)\r\nVALUES     (?, ?, ?, ?, ?, ?," +
                " ?, ?, ?, ?)";
            this.oleDbCommand46.Connection = this.con;
            this.oleDbCommand46.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uaid", System.Data.OleDb.OleDbType.Integer, 0, "uaid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand47
            // 
            this.oleDbCommand47.CommandText = resources.GetString("oleDbCommand47.CommandText");
            this.oleDbCommand47.Connection = this.con;
            this.oleDbCommand47.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("uanswer1", System.Data.OleDb.OleDbType.WChar, 255, "uanswer1"),
            new System.Data.OleDb.OleDbParameter("uanswer2", System.Data.OleDb.OleDbType.WChar, 255, "uanswer2"),
            new System.Data.OleDb.OleDbParameter("uanswer3", System.Data.OleDb.OleDbType.WChar, 255, "uanswer3"),
            new System.Data.OleDb.OleDbParameter("uanswer4", System.Data.OleDb.OleDbType.WChar, 255, "uanswer4"),
            new System.Data.OleDb.OleDbParameter("uanswer5", System.Data.OleDb.OleDbType.WChar, 255, "uanswer5"),
            new System.Data.OleDb.OleDbParameter("uanswer6", System.Data.OleDb.OleDbType.WChar, 255, "uanswer6"),
            new System.Data.OleDb.OleDbParameter("uanswer7", System.Data.OleDb.OleDbType.WChar, 255, "uanswer7"),
            new System.Data.OleDb.OleDbParameter("uanswer8", System.Data.OleDb.OleDbType.WChar, 255, "uanswer8")});
            // 
            // oleDbCommand48
            // 
            this.oleDbCommand48.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand48.Connection = this.con;
            this.oleDbCommand48.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // daQs4
            // 
            this.daQs4.DeleteCommand = this.oleDbCommand49;
            this.daQs4.InsertCommand = this.oleDbCommand50;
            this.daQs4.SelectCommand = this.oleDbCommand51;
            this.daQs4.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "personel", new System.Data.Common.DataColumnMapping[] {
                        new System.Data.Common.DataColumnMapping("id", "id"),
                        new System.Data.Common.DataColumnMapping("name", "name"),
                        new System.Data.Common.DataColumnMapping("type", "type"),
                        new System.Data.Common.DataColumnMapping("kod", "kod")})});
            this.daQs4.UpdateCommand = this.oleDbCommand52;
            // 
            // oleDbCommand49
            // 
            this.oleDbCommand49.CommandText = "DELETE FROM Inputs\r\nWHERE     (id = ?)";
            this.oleDbCommand49.Connection = this.con;
            this.oleDbCommand49.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // oleDbCommand50
            // 
            this.oleDbCommand50.CommandText = "INSERT INTO Qs\r\n                      (qid, input1, input2, input3, input4, input" +
                "5, input6, input7, input8)\r\nVALUES     (?, ?, ?, ?, ?, ?, ?, ?, ?)";
            this.oleDbCommand50.Connection = this.con;
            this.oleDbCommand50.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid"),
            new System.Data.OleDb.OleDbParameter("input1", System.Data.OleDb.OleDbType.WChar, 255, "input1"),
            new System.Data.OleDb.OleDbParameter("input2", System.Data.OleDb.OleDbType.WChar, 255, "input2"),
            new System.Data.OleDb.OleDbParameter("input3", System.Data.OleDb.OleDbType.WChar, 255, "input3"),
            new System.Data.OleDb.OleDbParameter("input4", System.Data.OleDb.OleDbType.WChar, 255, "input4"),
            new System.Data.OleDb.OleDbParameter("input5", System.Data.OleDb.OleDbType.WChar, 255, "input5"),
            new System.Data.OleDb.OleDbParameter("input6", System.Data.OleDb.OleDbType.WChar, 255, "input6"),
            new System.Data.OleDb.OleDbParameter("input7", System.Data.OleDb.OleDbType.WChar, 255, "input7"),
            new System.Data.OleDb.OleDbParameter("input8", System.Data.OleDb.OleDbType.WChar, 255, "input8")});
            // 
            // oleDbCommand51
            // 
            this.oleDbCommand51.CommandText = "SELECT     input1, input2, input3, input4, input5, input6, input7, input8\r\nFROM  " +
                "       Qs\r\nWHERE     (qid = ?)";
            this.oleDbCommand51.Connection = this.con;
            this.oleDbCommand51.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
            new System.Data.OleDb.OleDbParameter("qid", System.Data.OleDb.OleDbType.Integer, 0, "qid")});
            // 
            // oleDbCommand52
            // 
            this.oleDbCommand52.CommandText = "UPDATE    Inputs\r\nSET              wd = ?, wod = ?, inputtext1 = ?, inputtext2 = " +
                "?, inputtext3 = ?, inputtext4 = ?, inputtext5 = ?, inputtext6 = ?, inputtext7 = " +
                "?, inputtext8 = ?\r\nWHERE     (id = ?)";
            this.oleDbCommand52.Connection = this.con;
            this.oleDbCommand52.Parameters.AddRange(new System.Data.OleDb.OleDbParameter[] {
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
            new System.Data.OleDb.OleDbParameter("Original_id", System.Data.OleDb.OleDbType.Integer, 0, System.Data.ParameterDirection.Input, false, ((byte)(0)), ((byte)(0)), "id", System.Data.DataRowVersion.Original, null)});
            // 
            // txtOperationResult
            // 
            this.txtOperationResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtOperationResult.Location = new System.Drawing.Point(538, 11);
            this.txtOperationResult.Name = "txtOperationResult";
            this.txtOperationResult.Size = new System.Drawing.Size(103, 27);
            this.txtOperationResult.TabIndex = 153;
            this.txtOperationResult.TextChanged += new System.EventHandler(this.txtOperationResult_TextChanged);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label15.Location = new System.Drawing.Point(648, 6);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 41);
            this.label15.TabIndex = 152;
            this.label15.Text = "حاصل عملیات:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(11, 23);
            this.ClientSize = new System.Drawing.Size(1194, 741);
            this.Controls.Add(this.tabctrlResults);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MinimumSize = new System.Drawing.Size(1200, 726);
            this.Name = "FormMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "   :: بدوح ::   ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPartII_Load);
            this.tabctrlResults.ResumeLayout(false);
            this.tabInput.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinorASFA)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pnlOddLength.ResumeLayout(false);
            this.pnlOddLength.PerformLayout();
            this.pnlMoreThan64.ResumeLayout(false);
            this.pnlMoreThan64.PerformLayout();
            this.tabResults.ResumeLayout(false);
            this.tabResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnswers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFinalProcessingTimes)).EndInit();
            this.tabResultsAfterProcessing.ResumeLayout(false);
            this.tabResultsAfterProcessing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSelectedAnswer)).EndInit();
            this.tabResultsAfterUltimateProcessing.ResumeLayout(false);
            this.tabResultsAfterUltimateProcessing.PerformLayout();
            this.tabQs.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputs)).EndInit();
            this.tabAs.ResumeLayout(false);
            this.tabAs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSavedAnswers)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void chkDuplicateLettersMustBeOmitted_CheckedChanged(object sender, System.EventArgs e)
		{
			/*BoddoohPartIII.DuplicateLettersMustBeOmitted = chkDuplicateLettersMustBeOmitted.Checked;
			if (chkDuplicateLettersMustBeOmitted.Checked)
			{				
				InputLettersCountWarning.Text = "تعداد حروف متمايز عبارت ورودي بايد مضربي از دوازده باشد.";
				InputLettersCountText.Text = "تعداد حروف متمايز عبارت ورودي:";				
			}
			else
			{
                InputLettersCountWarning.Text = "تعداد حروف عبارت ورودي بايد مضربي از دوازده باشد.";
				InputLettersCountText.Text = "تعداد حروف عبارت ورودي:";
			}
			RefreshForm();*/
		}
        private void Process(byte first, byte second, byte prelast, byte last, int masfa, int OneTwoEightPatternNumber, bool onlyspecial, ListBox listAnswers)
		{           
                                           
                 
		}

        
        // تعداد جوابهای
        // x1+...+x^n = k such that 0 <= xi <=6
        private static void InitTheCountingProblemTable(int Length)
		{
            int MaxLength = Length;
            int MaxSum = 28 * Length;
            TheCountingProblemTable = new long[MaxSum, MaxLength];
            for (int s = 0; s < MaxSum; s++)
            {
                for (int L = 0; L < MaxLength; L++)
                {
                    TheCountingProblemTable[s, L] = 0;
                }
            }

            for (int s = 0; s < MaxSum; s++)
            {
                if (s <= 6)
                    TheCountingProblemTable[s, 1] = 1;
                else
                    break;

            }
            for (int L = 2; L < MaxLength; L++)
            {
                for (int s = 0; s < MaxSum; s++)
                {
                    TheCountingProblemTable[s, L] = 0;
                    if (s>=0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s, L-1];
                    if (s-1>=0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s-1, L-1];
                    if (s-2>=0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s-2, L-1];
                    if (s-3>=0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s-3, L-1];
                    if (s-4>=0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s-4, L-1];
                    if (s-5>=0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s-5, L-1];
                    if (s - 6 >= 0) TheCountingProblemTable[s, L] = TheCountingProblemTable[s, L] + TheCountingProblemTable[s - 6, L - 1];
                }
            }



		}

        private static long GetSolutionOfTheCountingProblem(int k, int n)
        {
           
            return TheCountingProblemTable[k, n];
        }

        
        public void FindAllAnswersForTheCase(bool NoDuplicateLetters, int masfa, int OneTwoEightPatternNumber, bool onlyspecial, ListBox listAnswers)
        {
            //ArrayList result = new ArrayList();
            //String QuestionString = Boddooh.LetterSequence;
            //if (NoDuplicateLetters)
            //    QuestionString = Boddooh.OmitDuplicateLetters(QuestionString);
            //FindAllAnswers(QuestionString, first, second, prelast, last, masfa, OneTwoEightPatternNumber, onlyspecial, listAnswers);
        }
        public void FindAllAnswers(String QuestionString, int[] GivenLetters, int masfa, int OneTwoEightPatternNumber, bool onlyspecial, ListBox listAnswers, int IndexOfThread)
        {
            int Length = QuestionString.Length;

            FindAnswers(QuestionString, masfa, OneTwoEightPatternNumber, onlyspecial,  listAnswers, IndexOfThread);

            //int[] QuestionLetters = new int[Length];    byte[] AnswerLetters = new byte[Length];
            //byte[] FirstLetters = new byte[Length];FirstLetters[0] = first;FirstLetters[1] = second;
            //for (int i = 0; i < Length; i++)
            //{
            //    QuestionLetters[i] = Abjad.MinorAbjadNumber(QuestionString[i]);
            //    AnswerLetters[i] = 0;
            //}           
            //Boddooh.SortAnswers(AllAnswers, QuestionLetters, OutputLettersElements, 0, AllAnswers.Count - 1, FirstLetters, 2);
            //return AllAnswers;
        }
        //private void ProcessTest()
        //{
        //    string InitialInputText = MiscMethods.NormalizePersianString(txtInput.Text.Trim());
        //    Boddooh.Question = MiscMethods.RemoveDelimiters(InitialInputText);

        //    Boddooh.Errors InputError = Boddooh.Errors.None;
        //    if (!Boddooh.CheckInput(ref InputError))
        //    {
        //        Boddooh.ShowRecommendedErrorMessage(InputError);
        //        txtInput.Select();
        //        return;
        //    }
        //    int first = Convert.ToInt32(txtFirst.Text);
        //    int second = Convert.ToInt32(txtSecond.Text);
        //    int prelast = Convert.ToInt32(txtPrelast.Text);
        //    int last = Convert.ToInt32(txtLast.Text);

        //    Goto(frame2);
        //    listAnswers.Items.Clear();
        //    if (radioDoOmitDuplicateLetters.Checked )
        //    {
        //        listAnswers.Items.Add("با حذف حروف تکراری:");
        //        listAnswers.Items.Add("");
        //        Boddooh.AnswersListForNoDuplicateLettersCase = Boddooh.FindAllAnswersForTheCaseTest(chkOnlySpecialAnswers.Checked, listAnswers, true, first, second, prelast, last, 0);
        //        for (int i = 0; i < Boddooh.AnswersListForNoDuplicateLettersCase.Count; i++)
        //            listAnswers.Items.Add(MiscMethods.PutOneSpaceBetweenAdjacentLetters((string)Boddooh.AnswersListForNoDuplicateLettersCase[i]));
        //        listAnswers.Items.Add("");
        //        listAnswers.Items.Add("");
        //    }
        //    if (radioDoNotOmitDuplicateLetters.Checked )
        //    {
        //        listAnswers.Items.Add("بدون حذف حروف تکراری:");
        //        listAnswers.Items.Add("");
        //        Boddooh.AnswersListForDuplicateLettersCase = Boddooh.FindAllAnswersForTheCaseTest(chkOnlySpecialAnswers.Checked, listAnswers, false, first, second, prelast, last, 0);
        //        for (int i = 0; i < Boddooh.AnswersListForDuplicateLettersCase.Count; i++)
        //            listAnswers.Items.Add(MiscMethods.PutOneSpaceBetweenAdjacentLetters((string)Boddooh.AnswersListForDuplicateLettersCase[i]));
        //        listAnswers.Items.Add("");
        //        listAnswers.Items.Add("");
        //    }
        //}


        private void SaveQuestionAndAllAnswersToFile(string Q)
        {
        }
        private void WriteToFile(string Q, int Type, int Ranking)
        {
            ArrayList AnswersList;
            string FileName = Q + " - ";            
            if (Type == 1)
            {
                
                FileName += "مناسب ترین جوابها";
               // AnswersList = BoddoohPartIII.AllAnswersOfType1OrderedByRanking[Ranking - 1];                
            }
            else
            {
                FileName += "سایر جوابها";
               // AnswersList = BoddoohPartIII.AllAnswersOfType2OrderedByRanking[Ranking - 1];
            }
            FileName += " - " + "اولویت" + " " + MiscMethods.OrderString(Ranking) + ".txt";

          //  if (AnswersList.Count == 0) return;
            OutputFile file = new OutputFile(FileName);
            file.Open();
            string TempString = Abjad.GetMinorAbjadSequence(Q);
            file.WriteLine(TempString);
            //for (int i = 0; i < AnswersList.Count; i++)
            //{
            //    TempString = Abjad.GetMinorAbjadSequence((string)AnswersList[i]);
            //    file.WriteLine(TempString);
            //}
            file.Close();
        }


        private static string ConvertToString(ArrayList l)
        {
            string s= "";
            for (int i = 0;i<l.Count/2;i++)
                s += l[i];

            if (l.Count % 2 != 0)
                s += l[l.Count / 2 + 1];

            for (int i = l.Count / 2-1; i >=0 ; i--)
                s +=l[l.Count-1-i];
            return s;
        }

        		


        private void btnConfirmInput_Click(object sender, System.EventArgs e)
		{
            ConfirmInput();
		}

		private void Goto(string s)
		{
			if (s == "Input")tabctrlResults.SelectedIndex = 0;
            if (s == "Results") tabctrlResults.SelectedIndex = 1;
            if (s == "ResultsAfterProcessing") tabctrlResults.SelectedIndex = 2;
            if (s == "ResultsAfterUltimateProcessing") tabctrlResults.SelectedIndex = 3;
            if (s == "SavedInputs") tabctrlResults.SelectedIndex = 4;
            if (s == "SavedOutputs") tabctrlResults.SelectedIndex = 5;
		}


        private delegate void stringDelegate(string s, int rank);
        public void AddAnswerToRightDGV(string s, int rank)
        {
            if (listAnswers.InvokeRequired)
            {
                stringDelegate sd = new stringDelegate(AddAnswerToRightDGV);
                this.Invoke(sd, new object[] { s, rank });
            }
            else
            {

                string RankString = MiscMethods.ToString(rank, 3);

                dgvAnswers.Rows.Add();
                ItemsIndgvAnswers.Add(s);
                int Count = dgvAnswers.Rows.Count;
                string CountString = MiscMethods.ToString(Count, 3);
                dgvAnswers.Rows[Count - 1].Cells[0].Value = CountString;
                dgvAnswers.Rows[Count - 1].Cells[1].Value = RankString;
                if (s.Length <= HeaderSize)
                    dgvAnswers.Rows[Count - 1].Cells[2].Value = s;
                else
                {
                    dgvAnswers.Rows[Count - 1].Cells[2].Value = s.Substring(0, HeaderSize) + " " + "...";
                }

                //listAnswers.Items.Add((listAnswers.Items.Count + 1).ToString() + "\t" + s);
            }
        }
        private delegate void stringDelegate3(int v);
        public void RefreshProgressBar(int v)
        {
            if (progressBar.InvokeRequired)
            {
                stringDelegate3 sd = new stringDelegate3(RefreshProgressBar);
                this.Invoke(sd, new object[] { v });
            }
            else
            {
                progressBar.Value=v;
            }
        }
        private delegate void stringDelegate2(string s);
        public void WriteLabal(string s)
        {
            if (lblStatus.InvokeRequired)
            {
                stringDelegate2 sd = new stringDelegate2(WriteLabal);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                lblStatus.Text =  s;
            }
        }

        private delegate void stringDelegateCounter(long value);
        public void refrershLabalCount(long value)
        {
            if (labelCount.InvokeRequired)
            {
                stringDelegateCounter sd = new stringDelegateCounter(refrershLabalCount);
                this.Invoke(sd, new object[] { value });
            }
            else
            {
                labelCount.Text = value.ToString(); ;
            }
        }

       

		private void FormPartII_Load(object sender, System.EventArgs e)
		{
            OptionsForTheFirstAnswerLetters = new ArrayList();
            OptionsForTheLastAnswerLetters = new ArrayList();

			Abjad.Initialize();
            Boddooh.Initialize();
			//BoddoohPartIII.Initialize();			
            string InitialInputText = "";
                //"کیف حال رض مع و ن";
            //InitialInputText = "کيف حال رضا مع المامون";
            //InitialInputText = "کیست مادر یاهو";
            //InitialInputText = "کیست مادر هو نماید جان آن";
			//InitialInputText = "کي جهان اه را بنما به مرات عيون";
			//InitialInputText = "کی جهان اه را بنما به مرات عیون";
			InitialInputText = MiscMethods.NormalizePersianString(InitialInputText);
            //txtFirst.Text = "13"; txtSecond.Text = "16";
            //txtLast.Text = "12"; txtPrelast.Text = "14";            
			//InitialInputText = "کيست مادر بر عيون";
			txtInput.Text = InitialInputText;
			Goto("Input");
			txtInput.Select();
		}


				

		private void ShowSelectedAnswer()
		{	
			/*string separator = " ";
			int index = BoddoohPartIII.SelectedAnswerIndex;
            if (0 <= index && index < BoddoohPartIII.AllAnswers.Count)
			{
				string Answer = (string) BoddoohPartIII.AllAnswers[index];
				string output = "پاسخ: ";
				
				for (int i=0;i<Answer.Length;i++)
				{
					output += (separator + Answer[i]);
				}
				lblOutput.Text = output;
			}	*/		
		}

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			//BoddoohPartIII.OPTION1 = checkBox1.Checked;
		}

		private void btnLoadFromFile_Click(object sender, System.EventArgs e)
		{
			LoadFromFileDialog.ShowDialog();			
		}

		private void btnSaveToFile_Click(object sender, System.EventArgs e)
        {
            SaveToFile("1.xls");
        }

        private void SaveToFile(string FileName)
        {
            //Microsoft.Office.Interop.Excel.Application xlApp;
            //Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            //Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
            //object misValue = System.Reflection.Missing.Value;

            //xlApp = new Microsoft.Office.Interop.Excel.Application();
            //xlWorkBook = xlApp.Workbooks.Add(misValue);

            //xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            //for (int i = 0; i < listAnswers.Items.Count; i++)
            //{
            //    xlWorkSheet.Cells[1 + i, 1] = listAnswers.Items[i].ToString();
            //}
                

            //xlWorkBook.SaveAs(FileName, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            //xlWorkBook.Close(true, misValue, misValue);
            //xlApp.Quit();

            //releaseObject(xlWorkSheet);
            //releaseObject(xlWorkBook);
            //releaseObject(xlApp);

            //MessageBox.Show("فایل مربوطه با موفقیت ایجاد شد.");
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }

            finally
            {
                GC.Collect();
            }
        }

		private void LoadFromFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{			
		}

		private void SaveToFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
            //SaveQuestionAndAllAnswersToFile(SaveToFileDialog.FileName);
		}

		private void listAnswers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void txtInput_TextChanged(object sender, System.EventArgs e)
		{
            RefreshInputPanel();
            CheckIfBasedOnTheBaseInput();
		}

        private void CheckIfBasedOnTheBaseInput()
        {
            string BaseInput = lblBaseInput.Text.Trim();
            if (BaseInput.Length > 0)
            {
              string GivenInput = MiscMethods.NormalizePersianString(txtInput.Text.Trim());
                GivenInput = MiscMethods.RemoveDelimiters(GivenInput);
                BaseInput = MiscMethods.NormalizePersianString(BaseInput);
                BaseInput = MiscMethods.RemoveDelimiters(BaseInput);

                if (radioDoOmitDuplicateLettersFromBothSidesToMiddle.Checked)
                {
                    GivenInput = Boddooh.OmitDuplicateLetters(GivenInput, true);
                    BaseInput = Boddooh.OmitDuplicateLetters(BaseInput, true);
                }
                if (radioDoOmitDuplicateLettersFromRightToLeft.Checked)
                {
                    GivenInput = Boddooh.OmitDuplicateLetters(GivenInput, false);
                    BaseInput = Boddooh.OmitDuplicateLetters(BaseInput, false);
                }

                
                if (string.Compare(BaseInput, GivenInput) != 0)
                {
                    if (!BaseInput.StartsWith(GivenInput))
                        txtInput.BackColor = Color.Wheat;
                    else
                        txtInput.BackColor = Color.White;

                }
                else
                    txtInput.BackColor = Color.White;
            }
        }

        private void RefreshInputPanel()
        {
            pnlOddLength.Enabled = pnlMoreThan64.Enabled = true;

            string InitialInputText = MiscMethods.NormalizePersianString(txtInput.Text.Trim());
            Boddooh.Question = MiscMethods.RemoveDelimiters(InitialInputText);

            Boddooh.Errors InputError = Boddooh.Errors.None;
            if (!Boddooh.CheckInput(ref InputError) && InputError != Boddooh.Errors.NoInput)
            {
                return;
            }

            Boddooh.QuestionString = Boddooh.LetterSequence;
            if (radioDoOmitDuplicateLettersFromRightToLeft.Checked)
            {
                Boddooh.QuestionString = Boddooh.OmitDuplicateLetters(Boddooh.QuestionString, false);
            }
            if (radioDoOmitDuplicateLettersFromBothSidesToMiddle.Checked)
            {
                Boddooh.QuestionString = Boddooh.OmitDuplicateLetters(Boddooh.QuestionString, true);

            }
            lblRank.Text = FormInputManagment.GetRank(Boddooh.QuestionString).ToString();

            int Length = Boddooh.QuestionString.Length;
            pnlOddLength.Enabled = (Length % 2 == 1);
            pnlMoreThan64.Enabled = (Length > 64);
            Boddooh.MinorAbjadSummationForTheQuestion = Abjad.MinorAbjadSummation(Boddooh.QuestionString);
            lblMinorASFQ.Text = Boddooh.MinorAbjadSummationForTheQuestion.ToString();
            lblMinorASFQ2.Text = lblMinorASFQ.Text;
            int Minus = 0;
            try { Minus = Convert.ToInt32(txtMinusMinorASFQ.Text); }
            catch { }
            int Temp = Boddooh.MinorAbjadSummationForTheQuestion - Minus;
            int factor = Temp / 28;
            int rem = Temp % 28;
            lblMinorASFQ3.Text = " = " + factor.ToString() + " * 28 + " + rem.ToString() + " = " + (factor + 1).ToString() + " * 28 - " + (28 - rem).ToString();
            lblLengthQ.Text = Convert.ToString(Length);
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IntQuadruple[] q = new IntQuadruple[4];

            //q[0]= new IntQuadruple(2,24,33,12);
            //q[1]= new IntQuadruple(12,4,24,12);
            //q[2]= new IntQuadruple(7,21,33,17);
            //q[3]= new IntQuadruple(6,14,3,2);
            
            //Boddooh.SortQuadruples(q);


            //int[] QuestionLetters = new int[] {11, 10, 17, 8,0,0,0,0,13,16,6,14 };
            //int[] AnswerLetters = new int[] {13,16,9,19,0,0,0,0,9,11,14,12 };
            //if (BoddoohStairwayLab.DoTheCheckingProcess(QuestionLetters, AnswerLetters, 4))
            //    MessageBox.Show("Yes");
            //else
            //    MessageBox.Show("No");


            //int[] a = {5,3,3,1,7,3};
           // bool b = BoddoohStairwayLab.CheckSummations(a);
          //  if  (b)
          //      MessageBox.Show("true");
         //   else
         //   MessageBox.Show("false");
            //int[] FourInts = { 60, 50, 40, 03 };
             //MessageBox.Show(Math.Sign(-1).ToString());
             //MessageBox.Show(Math.Sign(0).ToString());
//               MessageBox.Show(Math.Sign(5).ToString());
            

            //BoddoohLab BL = new BoddoohLab(7);
           // BL.TryToStartOrContinueWithTheDigits(0, 0, 1613);
            //BL.ShowTable("");
            // BL.TryToStartOrContinueWithTheDigits(4, 0, 191);
            //BL.ShowTable("");
            
           // bool f = BL.TryToStartOrContinueWithTheDigits(7, 0, 1015);
         

            

            //System.Random R = new Random(Convert.ToInt32 (txtInput.Text) );

            //int si = R.Next(7);int sj = R.Next(4);
            //    int di = R.Next(7);int dj = R.Next(4);
            //// BoddoohPartIII.Initialize();

//            MessageBox.Show("From: " + Abjad.GetLetterByMinorAbjadNumber(BoddoohPartIII.OrganizedLettersTable[si, sj]));
            //MessageBox.Show("To: " + Abjad.GetLetterByMinorAbjadNumber(BoddoohPartIII.OrganizedLettersTable[di, dj]));
           // BoddoohPartIII.CountCellsFromSourceToDestination(si, sj, di, dj, "DR");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectAll1_Click(object sender, EventArgs e)
        {
        }

        private void btnDeSelectAll1_Click(object sender, EventArgs e)
        {
        }

        private void btnDeSelectAll2_Click(object sender, EventArgs e)
        {
        }

        private void btnSelectAll2_Click(object sender, EventArgs e)
        {
        }

        private void frame0_Enter(object sender, EventArgs e)
        {

        }

        private void radioDoNotOmitDuplicateLetters_CheckedChanged(object sender, EventArgs e)
        {
            RefreshInputPanel();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            Boddooh.Initialize();
            //ProcessTest();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void nudMajorASFA_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectFirstLetters_Click(object sender, EventArgs e)
        {
            SelectFirstLetters(listFirstLettersOptions.SelectedIndex);
        }

        private void SelectFirstLetters(int index)
        {
            if (index == -1)
            {
                txtFirst0.Clear();
                txtFirst1.Clear();
                txtLast1.Clear();
                txtLast0.Clear();
            }
            else
            {                
                int Length = Boddooh.QuestionString.Length;
                IntTuple Option = (IntTuple)OptionsForTheFirstAnswerLetters[index];
                txtFirst0.Text = Option.First.ToString();
                txtFirst1.Text = Option.Second.ToString();
                Boddooh.OutputLettersElements = Boddooh.GenerateOutputLettersElements(Option.First, Option.Second, Boddooh.QuestionString.Length, radioFromTBtoM.Checked, radioModular.Checked, radioMiddleElementFromTop.Checked );
                FillWithAllLettersWithTheGivenElement(ddlFirst2, Boddooh.OutputLettersElements[2]);
                FillWithAllLettersWithTheGivenElement(ddlFirst3, Boddooh.OutputLettersElements[3]);
                if (Length>=10) FillWithAllLettersWithTheGivenElement(ddlFirst4, Boddooh.OutputLettersElements[4]);
                if (Length>=12) FillWithAllLettersWithTheGivenElement(ddlFirst5, Boddooh.OutputLettersElements[5]);
                if (Length >= 14) FillWithAllLettersWithTheGivenElement(ddlFirst6, Boddooh.OutputLettersElements[6]);
                if (Length >= 16) FillWithAllLettersWithTheGivenElement(ddlFirst7, Boddooh.OutputLettersElements[7]);
                if (Length >= 18) FillWithAllLettersWithTheGivenElement(ddlFirst8, Boddooh.OutputLettersElements[8]);
                if (Length >= 20) FillWithAllLettersWithTheGivenElement(ddlFirst9, Boddooh.OutputLettersElements[9]);
                if (Length >= 22) FillWithAllLettersWithTheGivenElement(ddlFirst10, Boddooh.OutputLettersElements[10]);
                if (Length >= 24) FillWithAllLettersWithTheGivenElement(ddlFirst11, Boddooh.OutputLettersElements[11]);
                if (Length >= 26) FillWithAllLettersWithTheGivenElement(ddlFirst12, Boddooh.OutputLettersElements[12]);

                if (Length >= 26) FillWithAllLettersWithTheGivenElement(ddlLast12, Boddooh.OutputLettersElements[Length - 13]);
                if (Length >= 24) FillWithAllLettersWithTheGivenElement(ddlLast11, Boddooh.OutputLettersElements[Length - 12]);
                if (Length >= 22) FillWithAllLettersWithTheGivenElement(ddlLast10, Boddooh.OutputLettersElements[Length - 11]);
                if (Length >= 20) FillWithAllLettersWithTheGivenElement(ddlLast9, Boddooh.OutputLettersElements[Length - 10]);
                if (Length >= 18) FillWithAllLettersWithTheGivenElement(ddlLast8, Boddooh.OutputLettersElements[Length - 9]);
                if (Length >= 16) FillWithAllLettersWithTheGivenElement(ddlLast7, Boddooh.OutputLettersElements[Length - 8]);
                if (Length >= 14) FillWithAllLettersWithTheGivenElement(ddlLast6, Boddooh.OutputLettersElements[Length - 7]);

                if (Length >= 12) FillWithAllLettersWithTheGivenElement(ddlLast5, Boddooh.OutputLettersElements[Length - 6]);
                if (Length >= 10) FillWithAllLettersWithTheGivenElement(ddlLast4, Boddooh.OutputLettersElements[Length - 5]);
                FillWithAllLettersWithTheGivenElement(ddlLast3, Boddooh.OutputLettersElements[Length - 4]);
                FillWithAllLettersWithTheGivenElement(ddlLast2, Boddooh.OutputLettersElements[Length - 3]);
                Boddooh.MinorAbjadSummationForTheAnswer = Boddooh.FindMinorAbjadSummationForTheAnswer(Boddooh.MinorAbjadSummationForTheQuestion, Boddooh.OutputLettersElements);

                int MinMinorAbjadSummationForTheAnswer = Boddooh.MinorAbjadSummationForTheAnswer;
                while (MinMinorAbjadSummationForTheAnswer - 36 >= Length)
                    MinMinorAbjadSummationForTheAnswer = MinMinorAbjadSummationForTheAnswer - 36;
                int MaxMinorAbjadSummationForTheAnswer = Boddooh.MinorAbjadSummationForTheAnswer;
                while (MaxMinorAbjadSummationForTheAnswer + 36 <= 28 * Length)
                    MaxMinorAbjadSummationForTheAnswer = MaxMinorAbjadSummationForTheAnswer + 36;

                nudMinorASFA.Minimum = (decimal)MinMinorAbjadSummationForTheAnswer;
                nudMinorASFA.Maximum = (decimal)MaxMinorAbjadSummationForTheAnswer;
                nudMinorASFA.Value = (decimal)Boddooh.MinorAbjadSummationForTheAnswer;
                
                OptionsForTheLastAnswerLetters.Clear();
                listLastLettersOptions.Items.Clear();
                for (int i = 0; i < AllOptionsForTheFirstAndLastLetters.Count; i++)
                {
                    IntQuadruple IQ = (IntQuadruple)AllOptionsForTheFirstAndLastLetters[i];
                    if (IQ.First == Option.First && IQ.Second == Option.Second)
                    {




                         int GivenResult = -1;
                         try { GivenResult = Convert.ToInt32(txtOperationResult.Text); }
                         catch { txtOperationResult.Text = ""; }

                        int MinorASFQ = Convert.ToInt32(lblMinorASFQ.Text);
                        int MinorASFA = (int)nudMinorASFA.Value;

                        int QFirst = Abjad.MinorAbjadNumber(Boddooh.QuestionString[0]);
                        int QLast = Abjad.MinorAbjadNumber(Boddooh.QuestionString[Boddooh.QuestionString.Length-1]);
                        int y2 = IQ.Third;
                        int y1 = IQ.Forth;

                        int ThisItemResult = CalculateResult(Length, IQ.First, QFirst, QLast, IQ.Forth, MinorASFQ, MinorASFA);
                        if (GivenResult == ThisItemResult || GivenResult == -1)
                        {                            
                            string OptionString = "  " + y2.ToString() + " , " + y1.ToString() + "  ";
                            listLastLettersOptions.Items.Add(OptionString);
                            OptionsForTheLastAnswerLetters.Add(new IntTuple(y1, y2));
                        }
                    }
                }
                if (listLastLettersOptions.Items.Count==0)
                    SelectLastLetters(-1);
                else
                    SelectLastLetters(0);
            }
        }
        private void SelectLastLetters(int index)
        {
            if (index == -1)
            {
                txtLast1.Clear();
                txtLast0.Clear();
            }
            else
            {
                IntTuple Option = (IntTuple)OptionsForTheLastAnswerLetters[index];
                txtLast0.Text = Option.First.ToString();
                txtLast1.Text = Option.Second.ToString();
            }
        }

        private void ShowOperationResult()
        {
            int AFirst = 0; int QFirst = 0;
            int QLast = 0; int ALast = 0;
            try
            {
                int QLength = Boddooh.QuestionString.Length;
                QFirst = Abjad.MinorAbjadNumber(Boddooh.QuestionString[0]);
                QLast = Abjad.MinorAbjadNumber(Boddooh.QuestionString[QLength - 1]);
                AFirst = Convert.ToInt32(txtFirst0.Text);
                ALast = Convert.ToInt32(txtLast0.Text);
                int MinorASFQ = Convert.ToInt32(lblMinorASFQ.Text);
                int MinorASFA = (int)nudMinorASFA.Value;
                int Temp = 2 * (MinorASFQ + MinorASFA);
                Temp = Temp - (QFirst + QLast + AFirst + ALast);
                int OperationResult = Temp % BoddoohNumbers.TwentyEight;
                //if (QFirst == 0 || QLast == 0 || AFirst == 0 || ALast  == 0)
                   // lblOperationResultCount.Text = "";
               // else                    
                   // lblOperationResultCount.Text = Convert.ToString(OperationResult);
            }
            catch 
            {
               // lblOperationResultCount.Text = "";
            }
            
        }

        private int CalculateResult(int QLength, int AFirst, int QFirst, int QLast, int ALast, int MinorASFQ, int MinorASFA)
        {            
            try
            {
                int Temp = 2 * (MinorASFQ + MinorASFA);
                Temp = Temp - (QFirst + QLast + AFirst + ALast);
                int OperationResult = Temp % BoddoohNumbers.TwentyEight;
                if (QFirst == 0 || QLast == 0 || AFirst == 0 || ALast == 0)
                    return -1;
                else
                    return OperationResult;
            }
            catch
            {
                return -1;
            }

        }
        

        private void listFirstLettersOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectFirstLetters(listFirstLettersOptions.SelectedIndex);
          
        }

        private void listLastLettersOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectLastLetters(listLastLettersOptions.SelectedIndex);
        }

        private void btnSelectLastLetters_Click(object sender, EventArgs e)
        {
            SelectLastLetters(listLastLettersOptions.SelectedIndex);
        }


        private void ConfirmInput()
        {
            string InitialInputText = MiscMethods.NormalizePersianString(txtInput.Text.Trim());

            Boddooh.Question = MiscMethods.RemoveDelimiters(InitialInputText);

            Boddooh.Errors InputError = Boddooh.Errors.None;
            if (!Boddooh.CheckInput(ref InputError) && InputError != Boddooh.Errors.NoInput)
            {
                Boddooh.ShowRecommendedErrorMessage(InputError);
                txtInput.Select();
                return;
            }

            Boddooh.QuestionString = Boddooh.LetterSequence;
            Boddooh.QuestionStringWithDots = Boddooh.LetterSequenceWithDots;
            if (radioDoOmitDuplicateLettersFromRightToLeft.Checked)
            {
                Boddooh.QuestionString = Boddooh.OmitDuplicateLetters(Boddooh.QuestionString, false);
                Boddooh.QuestionStringWithDots = Boddooh.OmitDuplicateLetters(Boddooh.LetterSequenceWithDots, false); 

            }
            if (radioDoOmitDuplicateLettersFromBothSidesToMiddle.Checked)
            {
                Boddooh.QuestionString = Boddooh.OmitDuplicateLetters(Boddooh.QuestionString, true);
                Boddooh.QuestionStringWithDots = Boddooh.OmitDuplicateLetters(Boddooh.LetterSequenceWithDots, true); 

            }

            
            int Length = Boddooh.QuestionString.Length;
            pnlOddLength.Enabled = (Length % 2 == 1);
            pnlMoreThan64.Enabled = (Length > 64);
            
            if (Length < 2)
            {
                listFirstLettersOptions.Items.Clear();
                listLastLettersOptions.Items.Clear();
                return;
            }

            int q1 = Abjad.MinorAbjadNumber(Boddooh.QuestionString[0]);
            int q2 = Abjad.MinorAbjadNumber(Boddooh.QuestionString[1]);
            IntQuadruple[] OptionsForFirstTwoOutoutLetters = Boddooh.OrderTuplesBasedOnTheirRanks(q1, q2, Elements.None, Elements.None);
            Boddooh.MinorAbjadSummationForTheQuestion = Abjad.MinorAbjadSummation(Boddooh.QuestionString);
            lblMinorASFQ.Text = Boddooh.MinorAbjadSummationForTheQuestion.ToString();
           
            

            listFirstLettersOptions.Items.Clear();
            OptionsForTheFirstAnswerLetters.Clear();
            AllOptionsForTheFirstAndLastLetters = new ArrayList();
            AllOptionsForTheFirstAndLastLetters.Clear();
            int Count = 0;
            for (int index = 0; index < OptionsForFirstTwoOutoutLetters.Length; index++)
            {
                IntQuadruple AnOptionForFirstTwoOutoutLetters = OptionsForFirstTwoOutoutLetters[index];
                int x1 = AnOptionForFirstTwoOutoutLetters.First;
                int x2 = AnOptionForFirstTwoOutoutLetters.Second;
                Boddooh.OutputLettersElements = Boddooh.GenerateOutputLettersElements(x1, x2, Boddooh.QuestionString.Length, radioFromTBtoM.Checked, radioModular.Checked, radioMiddleElementFromTop.Checked);
                string OptionString = "  " + x1.ToString() + " , " + x2.ToString() + "  ";
                listFirstLettersOptions.Items.Add(OptionString);
                OptionsForTheFirstAnswerLetters.Add(new IntTuple(x1, x2));
               // if (x1 == 17 && x2 == 20)
                 ///   MessageBox.Show("");
                ArrayList OptionsForLastAndPrelastLetters = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterparts(x1, x2, 0, 1);
                for (int i = 0; i < OptionsForLastAndPrelastLetters.Count; i++)
                {
                    IntTuple AnOptionForLastAndPrelastLetters = (IntTuple)OptionsForLastAndPrelastLetters[i];
                    int y1 = AnOptionForLastAndPrelastLetters.First;
                    int y2 = AnOptionForLastAndPrelastLetters.Second;
                    Count++;
                    AllOptionsForTheFirstAndLastLetters.Add(new IntQuadruple(x1, x2, y2, y1));
                }

            }
            txtCount.Text = Count.ToString();
            SelectFirstLetters(0);
        }

        private void FillWithAllLettersWithTheGivenElement(ComboBox Combo, Elements element)
        {
            Combo.Items.Clear();
            Combo.Items.Add("");
            for (int i = 0; i < 7; i++)
            {
                int v = Abjad.ElementalOrder(element) + i * BoddoohNumbers.Four;
                Combo.Items.Add(v);
            }
        }

        private void FindAnswers( int masfa, int OneTwoEightPatternNumber, bool onlyspecial,  ListBox listAnswers)
        {
            bool OmitDuplicateLetters = radioDoOmitDuplicateLettersFromRightToLeft.Checked;
            
            FindAllAnswersForTheCase(OmitDuplicateLetters, masfa, OneTwoEightPatternNumber, onlyspecial, listAnswers);  
        }

        private void button2_Click(object sender, EventArgs e)
        {

            for (int RightCounterpart = 1; RightCounterpart <= 28; RightCounterpart++)
            {
                ArrayList 
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Air, 1); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() +  "  a1");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Air, 2); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  a2");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Air, 8); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  a8");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Earth, 1); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  e1");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Earth, 2); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  e2");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Earth, 8); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  e8");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Water, 1); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  w1");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Water, 2); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  w2");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Water, 8); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  w8");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Fire, 1); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  f1");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Fire, 2); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  f2");
                r = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RightCounterpart, Elements.Fire, 8); if (r.Count == 0) MessageBox.Show(RightCounterpart.ToString() + "  f8");

            }
        }

        private void btnFindAnswers_Click(object sender, EventArgs e)
        {           
            Boddooh.Initialize();
            string InitialInputText = MiscMethods.NormalizePersianString(txtInput.Text.Trim());
            Boddooh.Question = MiscMethods.RemoveDelimiters(InitialInputText);

            Boddooh.Errors InputError = Boddooh.Errors.None;
            if (!Boddooh.CheckInput(ref InputError))
            {
                Boddooh.ShowRecommendedErrorMessage(InputError);
                txtInput.Select();
                return;
            }
            dgvAnswers.Rows.Clear();
            ItemsIndgvAnswers.Clear();
            WriteLabal("");
            Goto("Results");
           
            
            listAnswers.Items.Clear();
           listSelectedAnswer.Items.Clear();

           String QuestionString = Boddooh.LetterSequence;
           if (radioDoOmitDuplicateLettersFromRightToLeft.Checked)
           {
               QuestionString = Boddooh.OmitDuplicateLetters(QuestionString, false);
           }
           if (radioDoOmitDuplicateLettersFromBothSidesToMiddle.Checked)
           {
               QuestionString = Boddooh.OmitDuplicateLetters(QuestionString, true);
           }
           int Length = QuestionString.Length;

           int[] GivenLetters = new int[Length];
           GetGivenLetters();
           UnfilteredAnswersList = new ArrayList();
           this.Cursor = Cursors.WaitCursor;
           progressBar.Value = 0;
           labelCount.Text = "";

           ComputingJobs = new Thread[ComputingJobsCount];
           Boddooh.GivenLettersForComputingThreads = new List<int[]>();

           int FirstFreeIndex = 0;
           while (Boddooh.GivenLetters[FirstFreeIndex] != -1)
               FirstFreeIndex++;

           ProgressCount = 0;
           InitTheCountingProblemTable( Length);
            
            AllStartAndEnds = new IntTuple[49];
           for (int i = 0; i<49; i++)
           {
               Boddooh.GivenLettersForComputingThreads.Add(new int[Boddooh.GivenLetters.Length]);
               for (int j = 0; j < Boddooh.GivenLetters.Length; j++)
                    Boddooh.GivenLettersForComputingThreads[i][j] = Boddooh.GivenLetters[j];

               Boddooh.GivenLettersForComputingThreads[i][FirstFreeIndex] = Abjad.ElementalOrder(Boddooh.OutputLettersElements[FirstFreeIndex]) + 4 * (i / 7);
               Boddooh.GivenLettersForComputingThreads[i][Boddooh.GivenLetters.Length - FirstFreeIndex - 1] = Abjad.ElementalOrder(Boddooh.OutputLettersElements[Boddooh.GivenLetters.Length - FirstFreeIndex - 1]) + 4 * (i % 7);


               
           }







           ComputingJobsCount = 1;
           try
           {

               ComputingJobsCount = Convert.ToInt16(txtThreadsCount.Text);
           }
           catch
           {
           }

           txtThreadsCount.Text = ComputingJobsCount.ToString();
           ComputingJobs = new Thread[ComputingJobsCount];
           for (int i = 0; i < ComputingJobsCount; i++)
           {
               ParameterizedThreadStart start = new ParameterizedThreadStart(AnswerFindingProcess);
               ComputingJobs[i] = new Thread(start);
           }
            int TaskSize = 49 / ComputingJobsCount;
            if (49 %ComputingJobsCount>0)
                TaskSize++;

            MyMutex = new Mutex();
            MyMutex.WaitOne();
            DoneCount = 0;
            MyMutex.ReleaseMutex();
            for (int index = 0; index < ComputingJobsCount; index++)
           {
               int a = index * TaskSize;
               int b = Math.Min((index + 1) * TaskSize - 1, 48);
               IntTuple IT = new IntTuple(a, b);
               ComputingJobs[index].Start(IT);
           }

            timer1.Enabled = true;



              
           
           //bool Done = false;
           //while (!Done)
           //{
           //    Thread.Sleep(1000);
           //    Done = true;
           //    for (int i = 0; i < ComputingJobsCount; i++)
           //    {
           //        if (ComputingJobs[i].ThreadState != ThreadState.Stopped)
           //            Done = false;
           //    }
           //}

         

            //WriteLabal(FinishedString);
        }



        public void GetGivenLetters()
        {

            bool onlyspecial = chkOnlySpecialAnswers.Checked;

            int OneTwoEightPatternNumber = 1;
            ArrayList result = new ArrayList();
            String QuestionString = Boddooh.LetterSequence;
            if (radioDoOmitDuplicateLettersFromRightToLeft.Checked)
            {
                QuestionString = Boddooh.OmitDuplicateLetters(QuestionString, false);
            }
            if (radioDoOmitDuplicateLettersFromBothSidesToMiddle.Checked)
            {
                QuestionString = Boddooh.OmitDuplicateLetters(QuestionString, true);
            }
            int Length = QuestionString.Length;



            Boddooh.GivenLetters = new int[Length];
            for (int i = 0; i < Boddooh.GivenLetters.Length; i++)
                Boddooh.GivenLetters[i] = -1;
            Boddooh.GivenLetters[0] = Convert.ToInt32(txtFirst0.Text);
            Boddooh.GivenLetters[1] = Convert.ToInt32(txtFirst1.Text);

            try { if (ddlFirst2.SelectedIndex > 0)  Boddooh.GivenLetters[2] = Convert.ToInt32(ddlFirst2.Items[ddlFirst2.SelectedIndex].ToString()); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            try { if (ddlFirst3.SelectedIndex > 0) Boddooh.GivenLetters[3] = Convert.ToInt32(ddlFirst3.Items[ddlFirst3.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst4.SelectedIndex > 0)Boddooh.GivenLetters[4] = Convert.ToInt32(ddlFirst4.Items[ddlFirst4.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst5.SelectedIndex > 0)Boddooh.GivenLetters[5] = Convert.ToInt32(ddlFirst5.Items[ddlFirst5.SelectedIndex].ToString()); }
            catch { }

            try { if (ddlFirst6.SelectedIndex > 0)Boddooh.GivenLetters[6] = Convert.ToInt32(ddlFirst6.Items[ddlFirst6.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst7.SelectedIndex > 0)Boddooh.GivenLetters[7] = Convert.ToInt32(ddlFirst7.Items[ddlFirst7.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst8.SelectedIndex > 0)Boddooh.GivenLetters[8] = Convert.ToInt32(ddlFirst8.Items[ddlFirst8.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst9.SelectedIndex > 0)Boddooh.GivenLetters[9] = Convert.ToInt32(ddlFirst9.Items[ddlFirst9.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst10.SelectedIndex > 0)Boddooh.GivenLetters[10] = Convert.ToInt32(ddlFirst10.Items[ddlFirst10.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst11.SelectedIndex > 0)Boddooh.GivenLetters[11] = Convert.ToInt32(ddlFirst11.Items[ddlFirst11.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlFirst12.SelectedIndex > 0)Boddooh.GivenLetters[12] = Convert.ToInt32(ddlFirst12.Items[ddlFirst12.SelectedIndex].ToString()); }
            catch { }





            try { if (ddlLast12.SelectedIndex > 0) Boddooh.GivenLetters[Length - 13] = Convert.ToInt32(ddlLast12.Items[ddlLast12.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast11.SelectedIndex > 0) Boddooh.GivenLetters[Length - 12] = Convert.ToInt32(ddlLast11.Items[ddlLast11.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast10.SelectedIndex > 0) Boddooh.GivenLetters[Length - 11] = Convert.ToInt32(ddlLast10.Items[ddlLast10.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast9.SelectedIndex > 0) Boddooh.GivenLetters[Length - 10] = Convert.ToInt32(ddlLast9.Items[ddlLast9.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast8.SelectedIndex > 0) Boddooh.GivenLetters[Length - 9] = Convert.ToInt32(ddlLast8.Items[ddlLast8.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast7.SelectedIndex > 0) Boddooh.GivenLetters[Length - 8] = Convert.ToInt32(ddlLast7.Items[ddlLast7.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast6.SelectedIndex > 0) Boddooh.GivenLetters[Length - 7] = Convert.ToInt32(ddlLast6.Items[ddlLast6.SelectedIndex].ToString()); }
            catch { }

            
            
            try { if (ddlLast5.SelectedIndex > 0) Boddooh.GivenLetters[Length - 6] = Convert.ToInt32(ddlLast5.Items[ddlLast5.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast4.SelectedIndex > 0) Boddooh.GivenLetters[Length - 5] = Convert.ToInt32(ddlLast4.Items[ddlLast4.SelectedIndex].ToString()); }
            catch { }

            try { if (ddlLast3.SelectedIndex > 0)Boddooh.GivenLetters[Length - 4] = Convert.ToInt32(ddlLast3.Items[ddlLast3.SelectedIndex].ToString()); }
            catch { }
            try { if (ddlLast2.SelectedIndex > 0) Boddooh.GivenLetters[Length - 3] = Convert.ToInt32(ddlLast2.Items[ddlLast2.SelectedIndex].ToString()); }
            catch { }

            Boddooh.GivenLetters[Length - 2] = Convert.ToInt32(txtLast1.Text);
            Boddooh.GivenLetters[Length - 1] = Convert.ToInt32(txtLast0.Text);
        }

        public void FilterAndShowUnfilteredAnswersList()
        {
            ArrayList FinalAnswers = new ArrayList();
            int ConditionsCount = 19;
            int Max = MiscMethods.Power(2, ConditionsCount);
            ArrayList[] Subsets = new ArrayList[ConditionsCount + 1];
            for (int i = 0; i < Subsets.Length; i++)
                Subsets[i] = new ArrayList();
            for (int i = 0; i < Max; i++)
            {
                int ZeroesCount = ConditionsCount - MiscMethods.GetOnesCount(i);
                Subsets[ZeroesCount].Add(i);
            }
            int ZCount = 0;
            bool Done = false;
            while (!Done && ZCount <= ConditionsCount)
            {
                int Min = 1000000;
                int BestSubset = 0;
                for (int i = 0; i < Subsets[ZCount].Count; i++)
                {
                    int ASubset = (int)Subsets[ZCount][i];
                    int M = CountAnswersSatisfyingASubsetOfConditions(ConditionsCount, ASubset);
                    if (M < Min && M > 0)
                    {
                        Min = M;
                        BestSubset = ASubset;
                    }
                }
                if (Min < 1000000)
                {
                    ArrayList FinalAnswersIndices = AnswersSatisfyingASubsetOfConditions(ConditionsCount, BestSubset);
                    for (int i = 0; i < FinalAnswersIndices.Count; i++)
                    {
                        int index = (int)FinalAnswersIndices[i];
                        AnswerArrayAndTagTuple AAATT = (AnswerArrayAndTagTuple)UnfilteredAnswersList[index];
                        string AnswerString = Abjad.LettersArrayToString(AAATT.AnswerArray, "");
                        AddAnswerToRightDGV(AnswerString + "  ", 0);
                        
                    }
                    Done = true;
                }
                ZCount++;
            }

        }
        public int CountAnswersSatisfyingASubsetOfConditions(int ConditionsCount,int ASubset)
        {
            int Count = 0;
            for (int i = 0; i < UnfilteredAnswersList.Count; i++)
            {
                AnswerArrayAndTagTuple AAATT = (AnswerArrayAndTagTuple)UnfilteredAnswersList[i];
                int MetConditions = (int)AAATT.Tag;
                bool Satisfied = true;
                for (int j = 0; j < ConditionsCount; j++)
                {
                    if (MiscMethods.GetIthBitInN(ASubset, j)==1)
                        if (MiscMethods.GetIthBitInN(MetConditions, j)==0)
                        {
                            Satisfied = false;
                            break;
                        }
                }  
                if (Satisfied)
                    Count++;
            }
            return Count;
        }

        public ArrayList AnswersSatisfyingASubsetOfConditions(int ConditionsCount, int TheSubset)
        {
            ArrayList result = new ArrayList();
            for (int i = 0; i < UnfilteredAnswersList.Count; i++)
            {
                AnswerArrayAndTagTuple AAATT = (AnswerArrayAndTagTuple)UnfilteredAnswersList[i];
                int MetConditions = (int)AAATT.Tag;
                bool Satisfied = true;
                for (int j = 0; j < ConditionsCount; j++)
                {
                    if (MiscMethods.GetIthBitInN(TheSubset, j) == 1)
                        if (MiscMethods.GetIthBitInN(MetConditions, j) == 0)
                        {
                            Satisfied = false;
                            break;
                        }
                }
                if (Satisfied)
                    result.Add(i);
            }
            return result;
        }


        public void FindAnswers(String QuestionString, int masfa, int OneTwoEightPatternNumber, bool onlyspecial,ListBox listAnswers, int IndexOfThread)
        {
            int AllCount = 0; int AllSWPCount = 0; int AllSpecial = 0;
            ArrayList result = new ArrayList();

            int Length = QuestionString.Length;
            int first = Boddooh.GivenLetters[0]; int second = Boddooh.GivenLetters[1]; int prelast = Boddooh.GivenLetters[Length - 2]; int last = Boddooh.GivenLetters[Length - 1];

            Boddooh.OutputLettersElements = Boddooh.GenerateOutputLettersElements(first, second, Length, radioFromTBtoM.Checked, radioModular.Checked, radioMiddleElementFromTop.Checked);

            //int tt = 0;
            //for (int i = 0; i < Length; i++)
            //    tt += Abjad.ElementalOrder(Boddooh.OutputLettersElements[i]);
            //MessageBox.Show(tt.ToString ());
            int[] QuestionLetters = new int[Length]; byte[] AnswerLetters = new byte[Length];
            
            int FreeCount = Length;
            int RemainingPartOfmasfa = masfa;
            for (int i = 0; i < Length; i++)
            {
                QuestionLetters[i] = Abjad.MinorAbjadNumber(QuestionString[i]); AnswerLetters[i] = 0;
                if (Boddooh.GivenLetters[i] != -1)
                {
                    RemainingPartOfmasfa -= Boddooh.GivenLetters[i];
                    FreeCount--;
                }
                else
                {
                    RemainingPartOfmasfa -= Abjad.ElementalOrder(Boddooh.OutputLettersElements[i]);                    
                }
            }
            MaxProgressCount = GetSolutionOfTheCountingProblem(RemainingPartOfmasfa / 7, FreeCount);

            int ConsumedPartOfMASFA = first + second + prelast + last;

            AnswerLetters[0] = (byte)first; AnswerLetters[1] = (byte)second; AnswerLetters[Length - 2] = (byte)prelast; AnswerLetters[Length - 1] = (byte)last;
            int UnknownPartLength = Length - 4;
            int UnknownPairsCount = UnknownPartLength / 2;
            if (UnknownPartLength % 2 == 1)
                UnknownPairsCount++;
            ArrayList[] OptionsForAllPairs = new ArrayList[UnknownPairsCount];
            int[] MaxValues = new int[UnknownPairsCount]; int[] MinValues = new int[UnknownPairsCount];
            for (int index = 0; index < UnknownPairsCount; index++)
            {
                ArrayList OptionsForOnePair = new ArrayList();
                int LeftOne = Boddooh.GivenLettersForComputingThreads[IndexOfThread][Length - 3 - index]; 
                int RightOne = Boddooh.GivenLettersForComputingThreads[IndexOfThread][2 + index];

                if ((1 <= LeftOne && LeftOne <= 28) && (1 <= RightOne && RightOne <= 28))
                {
                    OptionsForOnePair.Add(new IntTuple(RightOne, LeftOne));
                }
                else
                {
                    int RIndex = 2 + index; Elements RElement = Boddooh.OutputLettersElements[RIndex];
                    for (int ro = 0; ro < BoddoohNumbers.Seven; ro++)
                    {
                        int RValue = Abjad.ElementalOrder(RElement) + ro * BoddoohNumbers.Four;
                        if (RIndex < Length / 2)
                        {
                            ArrayList LValueOptions = BoddoohLab.FindAllPossibleMatchesForTheLeftCounterpart(RIndex, RValue, OneTwoEightPatternNumber);
                            for (int OptionIndex = 0; OptionIndex < LValueOptions.Count; OptionIndex++)
                            {
                                int LValue = (int)LValueOptions[OptionIndex];
                                OptionsForOnePair.Add(new IntTuple(RValue, LValue));
                            }
                        }
                        else
                        {
                            OptionsForOnePair.Add(new IntTuple(RValue, 0));
                        }
                    }
                }


                Boddooh.SortOptionsForOnePairBasedOnTheirMinorAbjadSummation(OptionsForOnePair);
                if (OptionsForOnePair.Count == 0)
                {
                    MessageBox.Show("Error!");
                }
                else
                {
                    IntTuple ITMin = (IntTuple)OptionsForOnePair[0];
                    IntTuple ITMax = (IntTuple)OptionsForOnePair[OptionsForOnePair.Count - 1];
                    OptionsForAllPairs[index] = OptionsForOnePair;
                    MinValues[index] = ITMin.First + ITMin.Second;
                    MaxValues[index] = ITMax.First + ITMax.Second;
                }
            }

            for (int index = UnknownPairsCount - 2; index >= 0; index--)
            {
                MinValues[index] += MinValues[index + 1];
                MaxValues[index] += MaxValues[index + 1];
            }

            int Remaining = masfa - ConsumedPartOfMASFA;
            Stack OptionsStack = new Stack();
            ArrayList OptionsForTheFirstPair = OptionsForAllPairs[0];
            for (int i = 0; i < OptionsForTheFirstPair.Count; i++)
            {
                IntTuple IT = (IntTuple)OptionsForTheFirstPair[i];
                int CurrentRemaining = Remaining - (IT.First + IT.Second);
                IntQuadruple IQ = new IntQuadruple(IT.First, IT.Second, 0, CurrentRemaining);
                OptionsStack.Push(IQ);
            }
            //long Count = 0;
            while (OptionsStack.Count > 0)
            {
               
                mutex1.WaitOne();
                ProgressCount++;
                refrershLabalCount(ProgressCount);
                mutex1.ReleaseMutex();
                if (ProgressCount % 1000 < 25)
                {
                    int v = (int)Math.Round(((float)(ProgressCount * 100)) / ((float)MaxProgressCount));
                    if (0 <= v && v <= 100)
                    {
                        RefreshProgressBar(v);
                    }
                }
                
                IntQuadruple IQ = (IntQuadruple)OptionsStack.Pop(); int index = IQ.Third; int CurrentRemaining = IQ.Forth;
                AnswerLetters[2 + index] = (byte)IQ.First; 
                if ((2 + index) < Length / 2)                    
                    AnswerLetters[Length - 3 - index] = (byte)IQ.Second;
                if (index == UnknownPairsCount - 1)
                {
                    if (CurrentRemaining == 0)
                    {
                        AllCount++;
                       // MessageBox.Show("");

                        byte[] AnAcceptableAnswer = new byte[Length];
                        for (int i = 0; i < Length; i++)
                            AnAcceptableAnswer[i] = AnswerLetters[i];
                        int[] StairwayResultArray = new int[Length-1];
                        bool ok = BoddoohStairwayLab.DoTheCheckingProcess(QuestionLetters, AnswerLetters, StairwayResultArray);
                        if (ok)
                        {
                            AllSWPCount++;
                            if (Boddooh.IsASpecialAnswer(AnswerLetters))
                            {
                                AllSpecial++;
                                long Status = 0;
                                int Rank = Boddooh101Table.GetRank(QuestionLetters, AnAcceptableAnswer, StairwayResultArray);
                                if (Rank >= MinimumRank)
                                {
                                    AddAnswerToRightDGV(  
                                        Abjad.LettersArrayToString(AnAcceptableAnswer, Boddooh.QuestionStringWithDots)
                                        ,Rank);
                                }

                            }
                            else
                            {
                                if (!onlyspecial)
                                {
                                    
                                    int Rank = Boddooh101Table.GetRank(QuestionLetters, AnAcceptableAnswer, StairwayResultArray);
                                    if (Rank >= MinimumRank)
                                    {
                                        AddAnswerToRightDGV( 
                                            Abjad.LettersArrayToString(AnAcceptableAnswer, Boddooh.QuestionStringWithDots) 
                                           , Rank);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (MinValues[index +1] <= CurrentRemaining && CurrentRemaining <= MaxValues[index+1])
                    {
                        ArrayList OptionsForTheNextPair = OptionsForAllPairs[index+1];
                        for (int i = 0; i < OptionsForTheNextPair.Count; i++)
                        {
                            IntTuple IT = (IntTuple)OptionsForTheNextPair[i];
                            int NewCurrentRemaining = CurrentRemaining - (IT.First + IT.Second);
                            if (NewCurrentRemaining >= 0)
                            {
                                IQ = new IntQuadruple(IT.First, IT.Second, index + 1, NewCurrentRemaining);
                                OptionsStack.Push(IQ);
                            }
                        }
                    }
                }
            }
            //MessageBox.Show(Count.ToString());
            //MessageBox.Show(MaxCount.ToString());
            //MessageBox.Show("تعداد کل جوابهای  ممکن:" + AllCount.ToString());
            //MessageBox.Show("تعداد کل جوابهای  مورد تایید در آزمایشگاه پلکانی:" + AllSWPCount.ToString());
            //MessageBox.Show("تعداد کل جوابهای خاص مورد تایید در آزمایشگاه پلکانی:" + AllSpecial.ToString());
            //return result;
        }


        private void AnswerFindingProcess1()
        {
            AddAnswerToRightDGV("sd", 0);
            Goto("ResultsAfterProcessing");
           
        }


        private void AnswerFindingProcess(object IndexTupleObject)
        {
            IntTuple IndexTuple = (IntTuple)IndexTupleObject;
            int StartIndex = IndexTuple.First;
            int EndIndex = IndexTuple.Second;
            bool onlyspecial = chkOnlySpecialAnswers.Checked;      
           
            int OneTwoEightPatternNumber = 1;
            ArrayList result = new ArrayList();
            String QuestionString = Boddooh.LetterSequence;
            if (radioDoOmitDuplicateLettersFromRightToLeft.Checked)
            {
                QuestionString = Boddooh.OmitDuplicateLetters(QuestionString, false);
            }
            if (radioDoOmitDuplicateLettersFromBothSidesToMiddle.Checked)
            {
                QuestionString = Boddooh.OmitDuplicateLetters(QuestionString, true);
            }
            int Length = QuestionString.Length;

            int masfa = 0; 
            
            bool ValidData = ValidateForm( ref  masfa);
            if (!ValidData)
                return;
            for (int index = StartIndex; index <= EndIndex; index++)
                FindAnswers(QuestionString, masfa, OneTwoEightPatternNumber, onlyspecial, listAnswers, index);

            MyMutex.WaitOne();
            DoneCount++;
            MyMutex.ReleaseMutex();
                                
           
        }

        private bool ValidateForm( ref int masfa)
        {
            try
            {

                masfa = Convert.ToInt32(nudMinorASFA.Text);
                MinimumRank = Convert.ToInt32(nudMinRank.Value);
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int[] a = new int[2]; a[0] = 1; a[1] = 3;
            int[] b = new int[2]; b[0] = 2; b[1] = 2;
            int[] t = a; a = b; b = t;
            //MessageBox.Show(Abjad.MajorAbjadSummation("").ToString());


        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            byte[] AnswerLetters = { 13, 16, 1, 19, 15, 10, 12, 22, 2, 19, 14, 12 };
            decimal Sum = AnswerLetters[0] % BoddoohNumbers.Nine; decimal Join = AnswerLetters[0] % BoddoohNumbers.Nine;
            

            for (int i = 1; i < AnswerLetters.Length; i++)
            {
                Sum += (AnswerLetters[i] % BoddoohNumbers.Nine);
                Join = MiscMethods.JoinDigits(AnswerLetters[i] % BoddoohNumbers.Nine, Join);
            }

            decimal Temp = Sum + Join;
            if (Temp % BoddoohNumbers.TwentyEight != 0 && Temp % BoddoohNumbers.TwentyEight != 20 && Temp % BoddoohNumbers.TwentyEight != 8)
                MessageBox.Show("");
            Temp = Math.Abs(Sum - Join);
            if (Temp % BoddoohNumbers.TwentyEight != 0 && Temp % BoddoohNumbers.TwentyEight != 20 && Temp % BoddoohNumbers.TwentyEight != 8)
                MessageBox.Show("d");
            MessageBox.Show("dd");
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SelectedDataGridViewForPrint = dgvAnswers;
            SelectedIndexInDataGridViewForPrint = -1;
            ItemsPrintedCount = 0;
            PageNumber = 1;
            if (this.PrintDialog.ShowDialog() == DialogResult.OK)
            {
                this.PrintDocument.Print();
                
            }
        }


        private void Print(object sender, System.Drawing.Printing.PrintPageEventArgs e, String QuestionString, int MinorASFQ, int MinorASFA, ref int count, ref int PageNumber)
        {
             
            int Right = e.PageSettings.PaperSize.Width - e.PageSettings.Margins.Right;
            int Bottom = e.PageSettings.PaperSize.Height - e.PageSettings.Margins.Bottom;
            int Left = e.PageSettings.Margins.Left;
            Font Heading1Font = new Font("Times New Roman", 14f);
            Font Heading2Font = new Font("Times New Roman", 12f);
            Font TextFont = new Font("Times New Roman", 12f);
            Font PageNumberFont = new Font("Times New Roman", 10f);

            float Y = e.PageSettings.Margins.Top;
            float Height = Heading1Font.GetHeight(e.Graphics);
            float LineSpacing = Heading1Font.GetHeight(e.Graphics) * 1.25f;
           // float single4 = (e.MarginBounds.Height - Height) / Heading2Font.GetHeight(e.Graphics);
            String InputString = "ورودی   " + MiscMethods.PutOneSpaceBetweenAdjacentLetters(QuestionString);
            
            String HeaderStringPart1 = "جمع ابجد کوچک ورودی: " + MinorASFQ.ToString();
            String HeaderStringPart2 = "جمع ابجد کوچک پاسخ ها: " + MinorASFA.ToString();

            SizeF InputStringSF = e.Graphics.MeasureString(InputString, Heading1Font);
            e.Graphics.DrawString(InputString, Heading1Font, Brushes.Black, (float)(Right - InputStringSF.Width), Y);
            Y += (LineSpacing);

            LineSpacing = Heading2Font.GetHeight(e.Graphics) * 1.25f;
            String HeaderString = HeaderStringPart1 + "\t\t" + HeaderStringPart2;
            SizeF HeaderSF = e.Graphics.MeasureString(HeaderString, Heading2Font);
            e.Graphics.DrawString(HeaderString, Heading2Font, Brushes.Black, (float)(Right - HeaderSF.Width), Y);
            Y += (LineSpacing);

            LineSpacing = TextFont.GetHeight(e.Graphics) * 1.25f;
            if (SelectedIndexInDataGridViewForPrint == -1)
            {
                for (int i = ItemsPrintedCount; i < SelectedDataGridViewForPrint.Rows.Count && Y < Bottom; i++)
                {
                    String Text = SelectedDataGridViewForPrint.Rows[i].Cells[2].Value.ToString();
                    HeaderSF = e.Graphics.MeasureString(Text, TextFont);
                    e.Graphics.DrawString(Text, TextFont, Brushes.Black, (float)(Right - HeaderSF.Width), Y);
                    Y += (LineSpacing);
                    ItemsPrintedCount++;
                }
            }
            else
            {
                String Text = "جواب: " + SelectedDataGridViewForPrint.Rows[SelectedIndexInDataGridViewForPrint].Cells[2].Value.ToString();
                HeaderSF = e.Graphics.MeasureString(Text, TextFont);
                e.Graphics.DrawString(Text, TextFont, Brushes.Black, (float)(Right - HeaderSF.Width), Y);
              
                
            }
            String PageNumberText = "صفحه " + PageNumber.ToString();
            SizeF PageNumberSF = e.Graphics.MeasureString(PageNumberText, PageNumberFont);
            e.Graphics.DrawString(PageNumberText, PageNumberFont, Brushes.Black, (float)(Left), Bottom);
            PageNumber++;
           
        }

       


        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Print(sender, e, Boddooh.QuestionString, Boddooh.MinorAbjadSummationForTheQuestion, Boddooh.MinorAbjadSummationForTheAnswer, ref ItemsPrintedCount, ref PageNumber);
            if (ItemsPrintedCount == SelectedDataGridViewForPrint.Rows.Count || SelectedIndexInDataGridViewForPrint != -1)
                e.HasMorePages = false;
            else
                e.HasMorePages = true;
        }

        private void FinalProcessing(int[] AnswerLetters, int PhaseCount)
        {
            int Length = AnswerLetters.Length;
            int[] TempAnswerLetters = new int[Length];
            for (int times = 0; times < PhaseCount; times++)
            {
                for (int i = 0; i < Length / 2; i++)
                {
                    TempAnswerLetters[2 * i] = AnswerLetters[Length - 1 - i];
                    TempAnswerLetters[2 * i + 1] = AnswerLetters[i];
                }
                if (Length % 2 == 1)
                    TempAnswerLetters[Length - 1] = AnswerLetters[Length / 2];
                for (int i = 0; i < Length; i++)
                    AnswerLetters[i] = TempAnswerLetters[i];
            }
        }

        private void UndoFinalProcessing(int[] AnswerLetters, int PhaseCount)
        {
            int Length = AnswerLetters.Length;
            int[] TempAnswerLetters = new int[Length];
            for (int times = 0; times < PhaseCount; times++)
            {
                for (int i = 0; i < Length ; i++)
                {
                    if (i%2==0)
                        TempAnswerLetters[Length - 1 - i/2] = AnswerLetters[i];
                    else
                        TempAnswerLetters[i/2] = AnswerLetters[i];
                }

                for (int i = 0; i < Length; i++)
                    AnswerLetters[i] = TempAnswerLetters[i];
            }
        }

        private void UltimateProcessing(int[] AnswerLetters, int GivenNumber)
        {
            int Length = AnswerLetters.Length;
            int[] TempAnswerLetters = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                int t = AnswerLetters[i];
                if (t + GivenNumber <= 28)
                    t = t + GivenNumber;
                else
                    t = MiscMethods.EquivalentNumber(t);
                TempAnswerLetters[i] = (byte)t;
            }

            for (int i = 0; i < Length; i++)
                AnswerLetters[i] = TempAnswerLetters[i];


        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            int[] q = { 11, 10, 17, 8, 1, 12, 20, 26, 13, 16, 6, 14 };
            byte[] a = {13, 16, 1, 19, 15, 10, 12, 22, 2, 19, 14,12 };
            //Boddooh101Table.GetRank(q, a);

        }

        private void btnSelectAnswer_Click(object sender, EventArgs e)
        {
            
        }

       

        

        private void btnPrintAllLeft_Click(object sender, EventArgs e)
        {
            SelectedDataGridViewForPrint = dgvSelectedAnswer;
            SelectedIndexInDataGridViewForPrint = -1;
            ItemsPrintedCount = 0;
            PageNumber = 1;
            if (this.PrintDialog.ShowDialog() == DialogResult.OK)
            {
                this.PrintDocument.Print();

            }
        }

        private void btnPrintOneSelected_Click(object sender, EventArgs e)
        {
            if (dgvSelectedAnswer.SelectedRows.Count==0)
                return;
            SelectedDataGridViewForPrint =dgvSelectedAnswer;





            SelectedIndexInDataGridViewForPrint = dgvSelectedAnswer.SelectedRows[0].Index;
            ItemsPrintedCount = 0;
            PageNumber = 1;
            if (this.PrintDialog.ShowDialog() == DialogResult.OK)
            {
                this.PrintDocument.Print();

            }
        }

       

        private void btnStop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ComputingJobsCount; i++)
            {
                ComputingJobs[i].Abort();
            }
                
            this.Cursor = Cursors.Default;
        }

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            if (string.Compare(lblStatus.Text, FinishedString)==0)
                this.Cursor = Cursors.Default;
        }

        private void btnSelectFromDB_Click(object sender, EventArgs e)
        {
            FormInputList frm = new FormInputList();
            frm.OutputTextBox = txtInput;
            frm.ShowDialog();
        }

        private void radioDoOmitDuplicateLetters_CheckedChanged(object sender, EventArgs e)
        {
            RefreshInputPanel();
        }

        private void btnSaveInput_Click(object sender, EventArgs e)
        {
            FormInputList.InsertInput(txtInput.Text);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            //Boddooh.GenerateOutputLettersElements(1, 2, Convert.ToInt32(texx1 .Text), radioFromTBtoM.Checked , radioModular.Checked, radioMiddleElementFromTop.Checked);
        }

        private void txtFirst_TextChanged(object sender, EventArgs e)
        {
            ShowOperationResult();
        }

        private void txtLast_TextChanged(object sender, EventArgs e)
        {
            ShowOperationResult();
        }

        private void SortAllAnswersBasedOnTheirRankAndShowThemInSelectedAnswerList(AnswerArrayAndTagTuple[] answersAndTheirRank, int GivenNumber)
        {
            int N = answersAndTheirRank.Length;
            for (int i = N-1; i >=0 ; i--)
                for (int j = 0; j < i; j++)
                {
                    AnswerArrayAndTagTuple ART1 = answersAndTheirRank[j];
                    AnswerArrayAndTagTuple ART2 = answersAndTheirRank[j+1];
                    if (ART1.Tag < ART2.Tag)
                    {
                        AnswerArrayAndTagTuple ART = ART1; answersAndTheirRank[j] = ART2; answersAndTheirRank[j + 1] = ART;
                    }
                }

            listSelectedAnswer.Items.Clear();
            for (int i = 0; i < answersAndTheirRank.Length; i++)
            {
                AnswerArrayAndTagTuple ART = answersAndTheirRank[i];
                long Rank = ART.Tag;
                string RankString = "";
                if (Rank == 1) RankString = "*";
                if (Rank == 2) RankString = "**";
                if (Rank == 3) RankString = "***";
                if (Rank == 4) RankString = "****";
                string AnswerString = Abjad.LettersArrayToString(ART.AnswerArray, Boddooh.QuestionStringWithDots);
                listSelectedAnswer.Items.Add(AnswerString + " " + RankString);
                int[] TempArray = MiscMethods.CopyArray(ART.AnswerArray);
                UltimateProcessing(TempArray, GivenNumber);
                string TempAnswerString = Abjad.LettersArrayToString(TempArray, Boddooh.QuestionStringWithDots);
                listSelectedAnswer.Items.Add("("+TempAnswerString + ")");
            }
        }

        private void SortAnAnswersBasedOnTheirRankAndShowThemInSelectedAnswerList(AnswerArrayAndTagTuple ART, int GivenNumber)
        {
            

            int Rank = (int) ART.Tag;
            //string RankString = "";
            //if (Rank == 1) RankString = "*";
            //if (Rank == 2) RankString = "**";
            //if (Rank == 3) RankString = "***";
            //if (Rank == 4) RankString = "****";
            string AnswerString = Abjad.LettersArrayToString(ART.AnswerArray, "");
            
           // listSelectedAnswer.Items.Add(AnswerString + " " + RankString);
            int[] TempArray = MiscMethods.CopyArray(ART.AnswerArray);
            UltimateProcessing(TempArray, GivenNumber);
            string TempAnswerString = Abjad.LettersArrayToString(TempArray, "");
          //  listSelectedAnswer.Items.Add("(" + TempAnswerString + ")");
            AddAnswerToLeftDGV(AnswerString, TempAnswerString, Rank);
        }

        public void AddAnswerToLeftDGV(string s1, string s2, int rank)
        {
                dgvSelectedAnswer.Rows.Add();
            
                int Count = dgvSelectedAnswer.Rows.Count;
                dgvSelectedAnswer.Rows[Count - 1].Cells[0].Value = Count.ToString();

                dgvSelectedAnswer.Rows[Count - 1].Cells[1].Value = rank.ToString();

                dgvSelectedAnswer.Columns[2].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dgvSelectedAnswer.Rows.Add(s1 + Environment.NewLine + s2); // Environment.NewLine = "\r\n" in Windows
                if (s1.Length <= HeaderSize)
                    dgvSelectedAnswer.Rows[Count - 1].Cells[2].Value = s1 + Environment.NewLine + s2;
                else
                {
                    dgvSelectedAnswer.Rows[Count - 1].Cells[2].Value = (s1.Substring(0, HeaderSize) + " " + "...") + Environment.NewLine + (s2.Substring(0, HeaderSize) + " " + "...");
                }

                ItemsIndgvSelectedAnswer.Add(s1 + Environment.NewLine + s2);
                
        }

        private void btnDoFinalProcessingSelected_Click(object sender, EventArgs e)
        {
            
            

            FinalProcessingTimes = (int)nudFinalProcessingTimes.Value;
            if (dgvAnswers.SelectedRows.Count == 0) return;
            
            int GivenNumber = Convert.ToInt32(txtGivenNumber.Text);
            
           
                int ii = dgvAnswers.SelectedRows[0].Index ;
                dgvAnswers.Rows[ii].DefaultCellStyle.BackColor = Color.LightBlue;
                string s2 = ItemsIndgvAnswers[ii];
                s2 = MiscMethods.RemoveDots(s2);
                string s = "";
                for (int k = 0; k < s2.Length; k++)
                    if (s2[k] != '0' && s2[k] != '1' && s2[k] != '2' && s2[k] != '3' && s2[k] != '4' && s2[k] != '5' && s2[k] != '6' && s2[k] != '7' && s2[k] != '8' && s2[k] != '9')
                    s = s + s2[k];
                s = MiscMethods.RemoveDelimiters(s);
                int[] AnswerArrayBefore = Abjad.GetMinorAbjadSequenceArray(s);
                int[] AnswerArrayAfter = new int[AnswerArrayBefore.Length];
                for (int k = 0; k < AnswerArrayBefore.Length; k++)
                    AnswerArrayAfter[k] = AnswerArrayBefore[k];
                int times = 0;
                dgvSelectedAnswer.Rows.Clear();
                ItemsIndgvSelectedAnswer.Clear();
                while (times < FinalProcessingTimes)
                {
                    FinalProcessing(AnswerArrayAfter, 1);

                    int Rank = ComputeFinalRankAfterSadreMoakhar(AnswerArrayBefore, AnswerArrayAfter);
                    AnswerArrayAndTagTuple AnswersAndRank = new AnswerArrayAndTagTuple(AnswerArrayAfter, Rank);
                    //AnswersAndTheirRank[0] = new AnswerArrayAndTagTuple(AnswerArrayAfter, Rank);
                    SortAnAnswersBasedOnTheirRankAndShowThemInSelectedAnswerList(AnswersAndRank, GivenNumber);
                    times++;
                }
                //int Rank = ComputeFinalRankOutOfFour(AnswerArrayBefore, AnswerArrayAfter);
                //AnswersAndTheirRank[i] = new AnswerArrayAndTagTuple(AnswerArrayAfter, Rank); 

                Goto("ResultsAfterProcessing");
            
        }
        private void btnDoFinalProcessing_Click(object sender, EventArgs e)
        {
            FinalProcessingTimes = (int)nudFinalProcessingTimes.Value;
            AnswersAndTheirRank = new AnswerArrayAndTagTuple[listAnswers.Items.Count];
            int GivenNumber = Convert.ToInt32(txtGivenNumber.Text);
            for (int i = 0; i < listAnswers.Items.Count; i++)
            {
                string s2 = listAnswers.Items[i].ToString();
                s2 = MiscMethods.RemoveDots(s2);
                string s = "";
                for (int k = 0; k < s2.Length; k++)
                    if (s2[k] != '0' && s2[k] != '1' && s2[k] != '2' && s2[k] != '3' && s2[k] != '4' && s2[k] != '5' && s2[k] != '6' && s2[k] != '7' && s2[k] != '8' && s2[k] != '9')
                        s = s + s2[k];
                s = MiscMethods.RemoveDelimiters(s);                
                int[] AnswerArrayBefore = Abjad.GetMinorAbjadSequenceArray(s);
                int[] AnswerArrayAfter = new int[AnswerArrayBefore.Length];
                for (int k = 0; k < AnswerArrayBefore.Length; k++)
                    AnswerArrayAfter[k] = AnswerArrayBefore[k];
                int times = 0;
                while (times < FinalProcessingTimes)
                {
                    FinalProcessing(AnswerArrayAfter, 1);
                    times++;
                }
                int Rank = ComputeFinalRankAfterSadreMoakhar(AnswerArrayBefore, AnswerArrayAfter);
                AnswersAndTheirRank[i] = new AnswerArrayAndTagTuple(AnswerArrayAfter, Rank); 

            }
            SortAllAnswersBasedOnTheirRankAndShowThemInSelectedAnswerList(AnswersAndTheirRank, GivenNumber);

        }

        private static int ComputeFinalRankAfterSadreMoakhar(int[] AnswerArrayBefore, int[] AnswerArrayAfter)
        {            
            int Length = AnswerArrayBefore.Length;
            int[] DistanceArray = new int[Length];
            int[] DistanceArrayMod9 = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                DistanceArray[i] = Math.Abs(AnswerArrayBefore[i] - AnswerArrayAfter[i]);
                DistanceArrayMod9[i] = DistanceArray[i] % BoddoohNumbers.Nine;
            }

            // Condition 1
            int Temp1Length = Length / 2;
            if (Length % 2 == 1)
                Temp1Length++;
            ArrayList[] Temp1ArrayList = new ArrayList[Temp1Length];
            for (int i = 0; i < Temp1Length; i++)
                Temp1ArrayList[i] = new ArrayList();
            bool Condition1Done = false;
            if (Length % 2 == 1)
            {
                Temp1ArrayList[0].Add(DistanceArrayMod9[Length / 2]);
                for (int i = 0; i < Temp1Length-1; i++)
                {
                    int x = DistanceArrayMod9[Length-1-i];    int y = DistanceArrayMod9[i];
                    int t1 = Math.Abs(x-y); while (t1>9) t1 = MiscMethods.SummationOfDigits(t1);
                    int t2 = x+y;   while (t2>9) t2 = MiscMethods.SummationOfDigits(t2);
                    if (t1 == 1 || t1 == 2)
                        Temp1ArrayList[Temp1Length -1- i].Add(t1);
                    if ((t2 == 1 || t2 == 2) && (t1!=t2))
                        Temp1ArrayList[Temp1Length - 1 - i].Add(t2);
                    if (Temp1ArrayList[Temp1Length - 1 - i].Count == 0)
                        Condition1Done = true;
                    
                }

            }
            else
            {
                for (int i = 0; i < Temp1Length; i++)
                {
                    int x = DistanceArrayMod9[Length - 1 - i]; int y = DistanceArrayMod9[i];
                    int t1 = Math.Abs(x - y); while (t1 > 9) t1 = MiscMethods.SummationOfDigits(t1);
                    int t2 = x + y; while (t2 > 9) t2 = MiscMethods.SummationOfDigits(t2);
                    if (t1 == 1 || t1 == 2)
                        Temp1ArrayList[Temp1Length - 1 - i].Add(t1);
                    if ((t2 == 1 || t2 == 2) && (t1 != t2))
                        Temp1ArrayList[Temp1Length - 1 - i].Add(t2);
                    if (Temp1ArrayList[Temp1Length - 1 - i].Count == 0)
                        Condition1Done = true;


                }
            }

            bool Condition1 = false;
            if (!Condition1Done)
            {
                int[] MaxArray = new int[Temp1Length];
                for (int i = 0; i < Temp1Length; i++)
                    MaxArray[i] = Temp1ArrayList[i].Count - 1;
                Counter Counter = new Counter(Temp1Length, 0, MaxArray);
                Counter.Restart();
                int[] Items = new int[Temp1Length];
                while (!Counter.Done && !Condition1)
                {
                    for (int i = 0; i < Temp1Length; i++)   Items[i] = (int)Temp1ArrayList[i][Counter.CurrentValues[i]];
                    if (FSM11222211.Accepts(Items))
                    {
                        Condition1 = true;
                    }
                    Counter.Next();
                }
            }

            // Condition 2, 3 & 4

            int[] TempAArray = new int[Length];
            int[] TempBArray = new int[Length];
            int[] TempCArray = new int[Length];
            int[] TempDArray = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                TempAArray[i] = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(AnswerArrayBefore[Length - 1 - i]));
                TempBArray[i] = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(AnswerArrayBefore[i]));
                TempCArray[i] = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(AnswerArrayAfter[Length - 1 - i]));
                TempDArray[i] = Abjad.MajorAbjadNumber(Abjad.GetLetterByMinorAbjadNumber(AnswerArrayAfter[i]));

            }
            int TempA = MiscMethods.JoinItemsAndModN(TempAArray, BoddoohNumbers.TwentyEight);
            int TempB = MiscMethods.JoinItemsAndModN(TempBArray, BoddoohNumbers.TwentyEight);
            int TempC = MiscMethods.JoinItemsAndModN(TempCArray, BoddoohNumbers.TwentyEight);
            int TempD = MiscMethods.JoinItemsAndModN(TempDArray, BoddoohNumbers.TwentyEight);
            
            // Condition 2
            bool Condition2 = false;
            int Temp2AB = TempA + TempB;
            int Temp2CD = TempC + TempD;
            int Temp2E = Math.Abs(Temp2AB-Temp2CD);
            int Temp2F = Temp2AB + Temp2CD;
            if (Temp2E % BoddoohNumbers.TwentyEight == 20 || Temp2E % BoddoohNumbers.TwentyEight == 8 ||
                Temp2F % BoddoohNumbers.TwentyEight == 20 || Temp2F % BoddoohNumbers.TwentyEight == 8)
                Condition2 = true;

            // Condition 3
            bool Condition3 = false;
            int Temp3E = MiscMethods.JoinDigits(TempB, TempA);
            int Temp3F = MiscMethods.JoinDigits(TempD, TempC);
            if (Temp3E % BoddoohNumbers.TwentyEight == 0 && (Temp3F % BoddoohNumbers.TwentyEight == 20 || Temp3F % BoddoohNumbers.TwentyEight == 8))            
                Condition3 = true;
            if (Temp3F % BoddoohNumbers.TwentyEight == 0 && (Temp3E % BoddoohNumbers.TwentyEight == 20 || Temp3E % BoddoohNumbers.TwentyEight == 8))
                Condition3 = true;

            // Condition 4

            bool Condition4 = false;
            int Temp4E = MiscMethods.JoinDigits(TempA, TempB) % BoddoohNumbers.TwentyEight;
            int Temp4F = MiscMethods.JoinDigits(TempC, TempD) % BoddoohNumbers.TwentyEight;
            int Temp4G = Math.Abs(Temp4E - Temp4F);
            int Temp4H = Temp4E + Temp4F;
            if (Temp4G % BoddoohNumbers.TwentyEight == 20 || Temp4G % BoddoohNumbers.TwentyEight == 8 ||
                Temp4H % BoddoohNumbers.TwentyEight == 20 || Temp4H % BoddoohNumbers.TwentyEight == 8)
                Condition4 = true;

            int Rank = 0;
            if (Condition1) Rank++;
            if (Condition2) Rank++;
            if (Condition3) Rank++;
            if (Condition4) Rank++;

         

            // Condition 5

            //bool Condition4 = false;
            //AnswerArrayBefore, byte[] AnswerArrayAfter
            int C5_After = MiscMethods.JoinItemsAndModN(AnswerArrayAfter, 28);
            int C5_IAfter = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(AnswerArrayAfter), 28);
            int C5_Before = MiscMethods.JoinItemsAndModN(AnswerArrayBefore, 28);
            int C5_IBefore = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(AnswerArrayBefore), 28);

            int[] MajorArrayAfter = MiscMethods.MajorAbjadArray(AnswerArrayAfter);
            int[] MajorArrayBefore = MiscMethods.MajorAbjadArray(AnswerArrayBefore);

            int C5_MajorAfter = MiscMethods.JoinItemsAndModN(MajorArrayAfter, 28);
            int C5_MajorIAfter = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(MajorArrayAfter), 28);
            int C5_MajorBefore = MiscMethods.JoinItemsAndModN(MajorArrayBefore, 28);
            int C5_MajorIBefore = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(MajorArrayBefore), 28);

            int C5_A1 = Math.Abs(C5_IBefore - C5_After);
            int C5_A2 = Math.Abs(C5_IAfter - C5_After);

            int C5_B1 = Math.Abs(C5_IBefore - C5_After);
            int C5_B2 = Math.Abs(C5_MajorIBefore - C5_MajorBefore);

            if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(C5_A1, C5_A2))            
                Rank++;
            if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(C5_B1, C5_B2))
                Rank++;

            int C5_C1 = (C5_IBefore + C5_After);
            int C5_C2 = Math.Abs(C5_MajorIBefore - C5_MajorBefore);

            if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(C5_C1, C5_C2))
                Rank++;

            int C5_D1 = Math.Abs(C5_MajorIAfter - C5_MajorAfter);
            int C5_D2 = Math.Abs(C5_After - C5_IAfter);
            int C5_D3 = (C5_D1 + C5_D2);
            int C5_D4 = Math.Abs(C5_D1 - C5_D2);

            int C5_E1 = Math.Abs(C5_After - C5_MajorAfter);
            int C5_E2 = Math.Abs(C5_IBefore - C5_MajorIAfter);
            int C5_E3 = (C5_E1 + C5_E2);
            int C5_E4 = Math.Abs(C5_E1 - C5_E2);

            if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(C5_E4, C5_E3))
                Rank++;

            if (InputManagement.SummationOrDistanceIsAVerySpecialNumber(C5_E3, C5_D4))
                Rank++;

            int[] Temp1 = new int[Length];
            int[] Temp2 = new int[Length];

            for (int i = 0; i < Length; i++)
            {
                Temp1[i] = -1;
                Temp2[i] = -1;
            }
            int index = 0;
            for (int i = 4; i <= Length; i+=4)
            {
                Temp1[index] = AnswerArrayBefore[i - 1];
                Temp2[index] = AnswerArrayBefore[i - 1];
                index++;
            }
            int factor1 = Length / 2;
            int factor2 = Length / 2;
            if (Length % 2==1)
                factor2++;

            for (int i = 1; i <= Length; i ++)if ( i%4 != 0)
            {
                int index1 = factor1 * i -1;
                int index2 = factor2 * i - 1;

                bool done1= false;
                int offset = 0;
                while (!done1)
                {
                    if (Temp1[(index1 + offset) % Length] == -1)
                    {
                        Temp1[(index1 + offset) % Length] = AnswerArrayBefore[i-1];
                        done1 = true;
                    }
                    else
                    {
                        if (Temp1[(index1 - offset) % Length] == -1)
                        {
                            Temp1[(index1 - offset) % Length] = AnswerArrayBefore[i-1];
                            done1 = true;
                        }
                        else
                            offset++;
                    }                    
                }
                bool done2 = false;
                offset = 0;
                while (!done2)
                {
                    if (Temp2[(index2 + offset) % Length] == -1)
                    {
                        Temp2[(index2 + offset) % Length] = AnswerArrayBefore[i-1];
                        done2 = true;
                    }
                    else
                    {
                        if (Temp2[(index2 - offset) % Length] == -1)
                        {
                            Temp2[(index2 - offset) % Length] = AnswerArrayBefore[i-1];
                            done2 = true;
                        }
                        else
                            offset++;
                    }
                }

                //Temp1[index] = AnswerArrayBefore[i - 1];
                //Temp2[index] = AnswerArrayBefore[i - 1];
               
            }
            if (MiscMethods.ArraysAreTheSame(AnswerArrayAfter, Temp1))
            {
                Rank++;
            }
            else
            {
                if (MiscMethods.ArraysAreTheSame(AnswerArrayAfter, Temp2))
                {
                    Rank++;
                }
            }


            return Rank;
        }

        //private void SortAllAnswersBasedOnTheirRankOutOfFour(Tuple[] QuestionArray, byte[] AnswerArray)
        //{
        //}

        private void OnlyOptionsForTheFirstAndLastLettersWithAGivenResult(int GivenResult)
        {
            int QLength = Boddooh.QuestionString.Length;
            int MinorASFQ = Convert.ToInt32(lblMinorASFQ.Text);
            int MinorASFA = (int)nudMinorASFA.Value;

            int QFirst = Abjad.MinorAbjadNumber(Boddooh.QuestionString[0]);
            int QLast = Abjad.MinorAbjadNumber(Boddooh.QuestionString[Boddooh.QuestionString.Length-1]);

            listFirstLettersOptions.Items.Clear();
            OptionsForTheFirstAnswerLetters.Clear();
            int Count = 0;
            
            for (int i = 0; i < AllOptionsForTheFirstAndLastLetters.Count; i++)
            {
                IntQuadruple IQ = (IntQuadruple)AllOptionsForTheFirstAndLastLetters[i];
                Boddooh.OutputLettersElements = Boddooh.GenerateOutputLettersElements(IQ.First, IQ.Second, Boddooh.QuestionString.Length, radioFromTBtoM.Checked, radioModular.Checked, radioMiddleElementFromTop.Checked);
                Boddooh.MinorAbjadSummationForTheAnswer = Boddooh.FindMinorAbjadSummationForTheAnswer(Boddooh.MinorAbjadSummationForTheQuestion, Boddooh.OutputLettersElements);
                //if (IQ.First == 16 && IQ.Second == 17)
                //    MessageBox.Show("");
                //if (IQ.First == 17 && IQ.Second == 16)
                //    MessageBox.Show("");
                int ThisItemResult = CalculateResult(QLength, IQ.First, QFirst, QLast, IQ.Forth, MinorASFQ, Boddooh.MinorAbjadSummationForTheAnswer);
                if (GivenResult == -1 || (GivenResult == ThisItemResult))
                {
                    int x1 = IQ.First;
                    int x2 = IQ.Second;
                    
                    Count ++;
                    string OptionString = "  " + x1.ToString() + " , " + x2.ToString() + "  ";
                    if (!listFirstLettersOptions.Items.Contains(OptionString))
                    {
                        listFirstLettersOptions.Items.Add(OptionString);
                        OptionsForTheFirstAnswerLetters.Add(new IntTuple(x1, x2));
                    }
                }
            }
            txtCount.Text = Count.ToString();

            if (listFirstLettersOptions.Items.Count == 0)
                SelectFirstLetters(-1);
            else
                SelectFirstLetters(0);

            if (listLastLettersOptions.Items.Count == 0)
                SelectLastLetters(-1);
            else
                SelectLastLetters(0);

            
        }

        private void button1_Click_5(object sender, EventArgs e)
        {
            //Boddooh101Table.FinalConditionsMet();
        }

        private void txtOperationResult_TextChanged(object sender, EventArgs e)
        {
            int GivenResult = -1;
            try { GivenResult = Convert.ToInt32(txtOperationResult.Text); }
            catch { txtOperationResult.Text = ""; }
            OnlyOptionsForTheFirstAndLastLettersWithAGivenResult(GivenResult);
               
        }

        private void button1_Click_6(object sender, EventArgs e)
        {
            //int[] Ans = new int[] { 13, 16, 1, 19, 15, 10, 12, 22, 2, 19, 14, 12 };
           // int[] Que = new int[] { 11, 10, 17, 8, 1, 12, 20, 26, 13, 16, 6, 14 };
            //string s= MiscMethods.ArrayToCSVString(Que);
            //IntQuadruple Iq = new IntQuadruple(1,2,3,-1);
            //IntQuadruple Iq1 = new IntQuadruple(11, 12, 13, -1);
            //Stack stk = new Stack();
            //stk.Push(Iq);
            //stk.Push(Iq1);
           // string ss = MiscMethods.StackToString(stk,);
            //Stack stk2 = MiscMethods.StringToStack(ss);
            //int[] sa = MiscMethods.CSVStringToArray(s);
           // Boddooh101Table.Conditions_InputManagment(Que);
            AllBoddooh4By4Tables.Initialize();
            //int Rank = Boddooh101Table.Conditions_ABCDEFG(Que, Ans);
            //int Rank = Computer(Bef, Aft);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            //int[] q = { 11, 10, 17, 8, 1, 12, 20, 26, 13, 16, 6, 14 };
            ////byte[] a = { 13, 16, 1, 19, 15, 10, 12, 22, 2, 19, 14, 12 };
            int[] q = { 176, 216, 244, 212, 184, 192, 264, 248, 236, 228 , 180 };
            int[] a = { 176,404, 408,608, 584, 728, 984,1072, 1076, 1136,1196};
            //long S = Boddooh101Table.FinalConditionsMet(a ,q);

            //Boddooh101Table.GetRank(q, a);

            //long i = 0;
            //i= MiscMethods.SetIthBitInNToB(i, 2, true);
            //MessageBox.Show(MiscMethods.GetBinaryString(i));
        }

              

        private void btnInputManagement_Click(object sender, EventArgs e)
        {
            FormInputManagment frm = new FormInputManagment();
            frm.OutputLabel = lblBaseInput;
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AllBoddooh4By4Tables.Initialize();
            //InputManagement.Initialize();
          //  List<int[]> A = InputManagment.GetB4B4TablesSummationArray(12, 11, 10, 17, 8, RemainingLetters, AllPossibleTuplesOfRemainingLetters);
            
            int[] S= new int[]{176,188,244,240,184,248,264,248, 208,256,124,224};
            //int[] A = new int 
            InputManagement.IsAValidB4B4TablesSummationArray(12, S, true);
           // MessageBox.Show(A.Count.ToString());

            // InputManagment.GetAllPosibleQuadrapleSummations(12, 11, 10, 17, 8);
            //int[] S= new int[]{176,188,244,240,184,248,264,208,256,124,224};
            //List<int[]> SS =InputManagment.GenerateAllClause14ArraysWithAGivenB4B4TablesSummationArray(12, 11, 10, 17, 8, S);
            //MessageBox.Show(1.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IntSet L = new IntSet();
            for (int i=1;i<=28;i++)
                L.Add(i);
            List<int[]> T5 = InputManagement.GetAllPermutations(5, L);
            IntSet P_B = new IntSet();
            IntSet P_D = new IntSet();
            IntSet P_BD = new IntSet();
            //textBox1.Clear();
            for (int i = 0; i < T5.Count; i++)
            {
                int[] APermutation = T5[i];
                Boddooh4By4Table B4B4T0 = new Boddooh4By4Table(APermutation[0], APermutation[1], APermutation[2], APermutation[3]);
                Boddooh4By4Table B4B4T1 = new Boddooh4By4Table(APermutation[1], APermutation[2], APermutation[3], APermutation[4]);
                int D0 = AllBoddooh4By4Tables.Get_D(B4B4T0);
                int B0 = AllBoddooh4By4Tables.Get_B(B4B4T0);
                int D1 = AllBoddooh4By4Tables.Get_D(B4B4T1);
                int B1 = AllBoddooh4By4Tables.Get_B(B4B4T1);
                //textBox1.Text += (B0.ToString() + ", " + B1.ToString() + ", " + D0.ToString() + ", " + D1.ToString());
                int B = Convert.ToInt32(B0.ToString() + "0" + B1.ToString());
                int D = Convert.ToInt32(D0.ToString() + "0" + D1.ToString());
                int BD = Convert.ToInt32(B.ToString() + "0" + D.ToString());
                P_B.Add(B);
                P_D.Add(D);
                P_BD.Add(BD);

            }
            int m = 0;
            for (int i = 0; i < P_BD.Members.Count; i++)
            {
                MessageBox.Show(P_BD.Members[i].ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           // InputManagement.Initialize();
            List<int[]> All = new List<int[]>();

            for (int iii = 1; iii <= 1; iii++)
            {
                List<int[]> L = InputManagement.GenerateAllInputs(12, 11);
                if (L.Count > 0)
                    All.AddRange(L);
                //
            }
            for (int i = 0; i < All.Count; i++)
              MessageBox.Show(FormInputManagment.GetInputText(All[i]));


        }
        public void PPP()
        {
            //int L1 = 0; int L2 = 0; int L3 = 0; int L4 = 0;
            //try
            //{
            //    L1 = Convert.ToInt32(txtL1.Text); L2 = Convert.ToInt32(txtL2.Text); L3 = Convert.ToInt32(txtL3.Text); L4 = Convert.ToInt32(txtL4.Text);
            //}
            //catch { }
            //listIM.Items.Clear();

            //if (1 <= L1 && L1 <= 28)
            //{
            //    InputManagment.Initialize();
            //    InputManagment.LB = listIM;
            //    if ((1 <= L2 && L2 <= 28) && (1 <= L3 && L3 <= 28) && (1 <= L4 && L4 <= 28))
            //    {
            //        List<int[]> I = InputManagment.GenerateAllInputs(12, L1, L2, L3, L4);
            //        for (int i = 0; i < I.Count; i++)
            //        {
            //            int S = MiscMethods.ArrayItemsSummation(I[i]);
            //            //if (S == 154)
            //            //{
            //                listIM.Items.Add(
            //                    FormInputManagment.GetInputText(I[i])
            //                    );
            //                listIM.Items.Add(S.ToString());

            //            //}


            //        }
            //    }
            //    else
            //        InputManagment.GenerateAllInputs(12, L1);
            //}
            ////listIM.Items.Add("پایان");
            //MessageBox.Show(listIM.Items.Count.ToString());
        }
        private void btnIM_Click(object sender, EventArgs e)
        {
            //listIM.Items.Clear();
            //this.Cursor = Cursors.WaitCursor;
            //BackgroundThread = new Thread(new ThreadStart(PPP));
            //BackgroundThread.Start();

            All12();
        }
        public void All12()
        {
            //int L1 = 0; int L2 = 0; int L3 = 0; int L4 = 0;
            //InputManagment.Initialize();
            //    InputManagment.LB = listIM;
           
            //listIM.Items.Clear();

            //for (int i=3;i<=28;i++)
            //{
            //    int Last = InputManagment.GetLastLetter(i);
            //    for (int j = 1; j <= 28; j++)if (j!=i && j!=Last)
            //    {
            //        for (int k = 1; k <= 28; k++) if (k != i && k != Last && k!= j)
            //        {
            //            for (int l = 1; l <= 28; l++) if (l != i && l != Last && l != j && l != k)
            //            {
            //                List<int[]> I = InputManagment.GenerateAllInputs(12, i, j, k, l);

            //                for (int ii = 0; ii < I.Count; ii++)
            //                {
            //                    int S = MiscMethods.ArrayItemsSummation(I[ii]);
            //                    //if (S == 154)
            //                    //{
            //                    listIM.Items.Add(
            //                        FormInputManagment.GetInputText(I[ii])
            //                        );
            //                    listIM.Items.Add(S.ToString());

            //                    //}


            //                }
            //                if (I.Count>0)
            //                    MessageBox.Show(I.Count.ToString());
            //            }
            //        }
            //    }

               
            //}
            //listIM.Items.Add("پایان");
            
        }


        public void AddTextTolistIM(string s, int rank)
        {
            if (IMListBox.InvokeRequired)
            {
                stringDelegate sd = new stringDelegate(AddTextTolistIM);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                IMListBox.Items.Add(s);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            int[] a = new int[] { 11,13, 20,24,2,1,4,5,7,6,21,14};
            int[] b = new int[12];
            int[] d = new int[12] ;
            for (int i = 0; i < 12; i++)
            {
                Boddooh4By4Table B4B4T = new Boddooh4By4Table(a[i], a[(i + 1) % 12], a[(i + 2) % 12], a[(i + 3) % 12]);
                int D = AllBoddooh4By4Tables.Get_D(B4B4T);
                int B = AllBoddooh4By4Tables.Get_B(B4B4T);
                b[i] = B;
                d[i] = D;
            }

            int t = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int[] Pattern = ComplementaryInputManagement.GetPattern(12);
            //List<int[]> Ins = ComplementaryInputManagement.FindInputs(12,11,10,17,8,Pattern);
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void btnTakeToInputPanel_Click(object sender, EventArgs e)
        {





            if (dgvAnswers.SelectedRows.Count == 0) return;



            int ii = dgvAnswers.SelectedRows[0].Index;
            ///string s2 = dgvAnswers.Rows[ii].Cells[2].Value.ToString();
            string s2 = ItemsIndgvAnswers[ii];

            s2 = MiscMethods.RemoveDots(s2);

            string s = "";
            for (int k = 0; k < s2.Length; k++)
                if (s2[k] != '0' && s2[k] != '1' && s2[k] != '2' && s2[k] != '3' && s2[k] != '4' && s2[k] != '5' && s2[k] != '6' && s2[k] != '7' && s2[k] != '8' && s2[k] != '9')
                    s = s + s2[k];
            s = MiscMethods.RemoveDelimiters(s);
            int[] AnswerArray = Abjad.GetMinorAbjadSequenceArray(s);

            txtFirst0.Text = AnswerArray[0].ToString();txtFirst1.Text = AnswerArray[1].ToString();
            txtLast0.Text = AnswerArray[AnswerArray.Length - 1 - 0].ToString();txtLast1.Text = AnswerArray[AnswerArray.Length - 1 - 1].ToString();

            int HalfLength = AnswerArray.Length;
            if (HalfLength>2)
            {
                SelectTextFromComboBox(ddlFirst2, AnswerArray[2].ToString());
                SelectTextFromComboBox(ddlLast2, AnswerArray[AnswerArray.Length - 1 - 2].ToString());
            }

            if (HalfLength > 3)
            {
                SelectTextFromComboBox(ddlFirst3, AnswerArray[3].ToString());
                SelectTextFromComboBox(ddlLast3, AnswerArray[AnswerArray.Length - 1 - 3].ToString());
            }
            if (HalfLength > 4)
            {
                SelectTextFromComboBox(ddlFirst4, AnswerArray[4].ToString());
                SelectTextFromComboBox(ddlLast4, AnswerArray[AnswerArray.Length - 1 - 4].ToString());
            }
            if (HalfLength > 5)
            {
                SelectTextFromComboBox(ddlFirst5, AnswerArray[5].ToString());
                SelectTextFromComboBox(ddlLast5, AnswerArray[AnswerArray.Length - 1 - 5].ToString());
            }
            if (HalfLength > 6)
            {
                SelectTextFromComboBox(ddlFirst6, AnswerArray[6].ToString());
                SelectTextFromComboBox(ddlLast6, AnswerArray[AnswerArray.Length - 1 - 6].ToString());
            }
            if (HalfLength > 7)
            {
                SelectTextFromComboBox(ddlFirst7, AnswerArray[7].ToString());
                SelectTextFromComboBox(ddlLast7, AnswerArray[AnswerArray.Length - 1 - 7].ToString());
            }
            if (HalfLength > 8)
            {
                SelectTextFromComboBox(ddlFirst8, AnswerArray[8].ToString());
                SelectTextFromComboBox(ddlLast8, AnswerArray[AnswerArray.Length - 1 - 8].ToString());
            }
            if (HalfLength > 9)
            {
                SelectTextFromComboBox(ddlFirst9, AnswerArray[9].ToString());
                SelectTextFromComboBox(ddlLast9, AnswerArray[AnswerArray.Length - 1 - 9].ToString());
            }
            if (HalfLength > 10)
            {
                SelectTextFromComboBox(ddlFirst10, AnswerArray[10].ToString());
                SelectTextFromComboBox(ddlLast10, AnswerArray[AnswerArray.Length - 1 - 10].ToString());
            }

            if (HalfLength > 11)
            {
                SelectTextFromComboBox(ddlFirst11, AnswerArray[11].ToString());
                SelectTextFromComboBox(ddlLast11, AnswerArray[AnswerArray.Length - 1 - 11].ToString());
            }
            if (HalfLength > 12)
            {
                SelectTextFromComboBox(ddlFirst12, AnswerArray[12].ToString());
                SelectTextFromComboBox(ddlLast12, AnswerArray[AnswerArray.Length - 1 - 12].ToString());
            }

            Goto("Input");
        }

        private void SelectTextFromComboBox(ComboBox DDL, string s)
        {
            for (int i = 0; i < DDL.Items.Count; i++)
            {
                if (DDL.Items[i].ToString() == s)
                {
                    DDL.SelectedIndex = i;
                    return;
                }
            }
        }

        private void listAnswers_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void txtMinusMinorASFQ_TextChanged(object sender, EventArgs e)
        {
            RefreshInputPanel();
        }

        private void button1_Click_7(object sender, EventArgs e)
        {
            //int[] a = new int[] { 176,404, 408,608,584,728,984,1072,1076,1136,1196};
            //int ss = Boddooh101Table.Conditions_Unknown(a);
            //    MessageBox.Show(ss.ToString());
             int[] a = new int[] { 11, 10, 17,8,1,12,20,26, 13, 16,6,14};
             int ss = Boddooh101Table.Conditions_InputManagment(a);
                MessageBox.Show(ss.ToString());

            
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            int[] a = new int[] { 19,22,12,2,15,13,1,12,14,19,10,16 };
            int[] b = new int[] { 13,16,1,19,15,10,12,22,2,19,14,12 };
            //int[] b = MiscMethods.MajorAbjadArray(a);

            //int ss = MiscMethods.JoinItemsAndModN(a, 28);
            //int ss2 = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray(a), 28);
            int ss = ComputeFinalRankAfterSadreMoakhar(b, a);

            //int ss = MiscMethods.JoinItemsAndModN(a, 28);
            //int ss2 = MiscMethods.JoinItemsAndModN(MiscMethods.InverseArray( a), 28);
            //int ss = ComputeFinalRankAfterSadreMoakhar(a, b);

            //MessageBox.Show(ss.ToString()); //MessageBox.Show(ss2.ToString());
        }

        private void btnDeleteBaseInput_Click(object sender, EventArgs e)
        {
            lblBaseInput.Text = "";
        }

        private void lblBaseInput_TextChanged(object sender, EventArgs e)
        {
            if (lblBaseInput.Text.Trim().Length > 0)
                txtInput.Text = lblBaseInput.Text.Trim();
        }

        private void lblBaseInput_Click(object sender, EventArgs e)
        {

        }

        private void dgvSelectedAnswer_DoubleClick(object sender, EventArgs e)
        {
            string InputText = "";
            if (dgvSelectedAnswer.SelectedRows.Count > 0)
            {
                //InputText = dgvSelectedAnswer.SelectedRows[0].Cells[2].Value.ToString();
                int index = dgvSelectedAnswer.SelectedRows[0].Index;
                InputText = ItemsIndgvSelectedAnswer[index];
            }

            InputText = MiscMethods.RemoveDelimiters(InputText);
            string line1 = InputText.Substring(0, InputText.Length / 2);
            string line2 = InputText.Substring(InputText.Length / 2, InputText.Length / 2);
            //answerLettersSelector1 = new AnswerLettersSelector();
            ShowSelectedAnswer(line1, line2);
            //answerLettersSelector2.Refresh();



           
        }

        private void ShowSelectedAnswer(string line1, string line2)
        {
           // char[,] Answer = (char[,])BoddoohPartI.Answers[index];
            for (int i = 0; i < line1.Length; i++)
            {
                //char SelectedLetter = Convert.ToChar(((String)BoddoohPartI.OutputSentence[index]).Substring(i, 1));
                //for (int j = 1; j >= 0; j--)
                //{
                    //answerLettersSelector2.RadioButtons[i, 0].Text = Convert.ToString(line1.Substring(i, 1));
                    //answerLettersSelector2.RadioButtons[i, 1].Text = Convert.ToString(line2.Substring(i, 1));
                   // if (Answer[i, j] == SelectedLetter)
                    //answerLettersSelector2.RadioButtons[i, 0].Checked = false;
                   // else
                        //answerLettersSelector2.RadioButtons[i, 1].Checked = false;
                //}
            }
            Refresh();
        }

        private void dgvSelectedAnswer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //answerLettersSelector2.Width = answerLettersSelector2.Length * answerLettersSelector2.LetterButtonWidth;
             
            //int Right = hScrollBar1.Left + hScrollBar1.Width;
            //answerLettersSelector2.Left = Right - answerLettersSelector2.Width;
            //int i = hScrollBar1.Value;
            //int delta = answerLettersSelector2.Width - hScrollBar1.Width;
            //int Right2 = Right + i*delta/90;
            //answerLettersSelector2.Left = Right2 - answerLettersSelector2.Width;
            //label24.Text = i.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (DoneCount == ComputingJobsCount)
            {
                WriteLabal(FinishedString);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnDoTheUltimateProcessing_Click(object sender, EventArgs e)
        {
            if (dgvSelectedAnswer.SelectedRows.Count == 0)
                return;

            int ii = dgvSelectedAnswer.SelectedRows[0].Index;


            //string s = dgvSelectedAnswer.Rows[ii].Cells[2].Value.ToString();
            string s = ItemsIndgvSelectedAnswer[ii];
            s = MiscMethods.RemoveDots(s);
            s = MiscMethods.RemoveDelimiters(s);
            string s1 = s.Substring(0, s.Length / 2);
            string s2 = s.Substring(s.Length / 2, s.Length / 2);
            //s1 = Repeat("ابجدهوزحطی", 100);
            //s2 = Repeat("ابجدهوزحطس", 100);
            ShowInResultAfterUltimateProcessingPanel(s1, s2);
            Goto("ResultsAfterUltimateProcessing");
        }

        private string Repeat(string d, int count)
        {
            string s = "";
            for (int i = 0; i < count; i++)
                s += d;
            return s;

        }
        private void ShowInResultAfterUltimateProcessingPanel(string s1, string s2)
        {
            string SO1 = MiscMethods.RemoveDelimiters(s1);
            string SO2 = MiscMethods.RemoveDelimiters(s2);
            int Length = SO1.Length;
            int MaxAnswerLettersSelectorsCount = 1001 / AnswerLettersSelector.Length;
            MaxAnswerLettersSelectorsCount++;
            if (AnswerLettersSelectors == null)
            {

                AnswerLettersSelectors = new AnswerLettersSelector[MaxAnswerLettersSelectorsCount];
                AnswerLettersSelectorLabels = new Label[MaxAnswerLettersSelectorsCount];
            }
            else
            {
                for (int i = 0; i < MaxAnswerLettersSelectorsCount; i++)
                {
                    if (AnswerLettersSelectors[i] != null)
                    {

                        AnswerLettersSelectors[i].Visible = false;
                        AnswerLettersSelectorLabels[i].Visible = false;
                    }
                }
            }
            int Left = 10;
            int Top = 20;
            int H = AnswerLettersSelector.LetterButtonWidth * 4;
            int H1 = AnswerLettersSelector.LetterButtonWidth;
            int W = AnswerLettersSelector.LetterButtonWidth * AnswerLettersSelector.Length;
            AnswerLettersSelectorsCount = Length / AnswerLettersSelector.Length ;
            if (Length % AnswerLettersSelector.Length > 0)
                AnswerLettersSelectorsCount++;
            string SU = SO1;
            string SD = SO2;
            for (int i = 0; i < AnswerLettersSelectorsCount; i++)
            {
                if (AnswerLettersSelectors[i] == null)
                {

                    AnswerLettersSelectors[i] = new AnswerLettersSelector();
                    AnswerLettersSelectorLabels[i] = new Label();
                }
                AnswerLettersSelectors[i].Location = new System.Drawing.Point(Left, Top + i * H);
                AnswerLettersSelectors[i].Name = "ALS_" + i.ToString();
                AnswerLettersSelectors[i].SelectedAnswer = Repeat(" ", AnswerLettersSelector.Length);
                AnswerLettersSelectors[i].SelectedAnswerChanged = null;
                AnswerLettersSelectors[i].SelectedLetterButtonBackColor = System.Drawing.SystemColors.Highlight;
                AnswerLettersSelectors[i].SelectedLetterButtonForeColor = System.Drawing.SystemColors.HighlightText;
                AnswerLettersSelectors[i].Size = new System.Drawing.Size(W, 2*H1);
                AnswerLettersSelectors[i].Tag = i;
               // AnswerLettersSelectors[i].TabIndex = 92 + i;
                AnswerLettersSelectors[i].UnselectedLetterButtonBackColor = System.Drawing.SystemColors.Control;
                AnswerLettersSelectors[i].UnselectedLetterButtonForeColor = System.Drawing.SystemColors.ControlText;
                AnswerLettersSelectors[i].Visible = true;

                AnswerLettersSelectors[i].SelectedAnswerChanged =
                    new AnswerLettersSelector.SelectedAnswerChangedDelegate(SelectedAnswerChangedHandler);

                //AnswerLettersSelectors[i].SelectedAnswerChanged =
                //     new Boddooh.AnswerLettersSelector.SelectedAnswerChangedDelegate(SelectedAnswerChangedHandler);

                AnswerLettersSelectorLabels[i].Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                AnswerLettersSelectorLabels[i].Location = new System.Drawing.Point(Left, Top + i * H + 2 * AnswerLettersSelector.LetterButtonWidth);
                AnswerLettersSelectorLabels[i].Name = "label_" + i.ToString();
                AnswerLettersSelectorLabels[i].Size = new System.Drawing.Size(W, H1);

                AnswerLettersSelectorLabels[i].Tag = i;
               // AnswerLettersSelectorLabels[i].TabIndex = 101 + i;
                AnswerLettersSelectorLabels[i].Visible = true;


                for (int j=0;j< AnswerLettersSelector.Length;j++)
                {
                    if (j< Math.Min(AnswerLettersSelector.Length, SU.Length))
                    {
                        AnswerLettersSelectors[i].RadioButtons[j, 0].Text = (SU.Substring(j, 1));                    
                        AnswerLettersSelectors[i].RadioButtons[j, 1].Text = (SD.Substring(j, 1));

                    }
                    else
                    {
                        AnswerLettersSelectors[i].RadioButtons[j, 0].Text = " ";
                        AnswerLettersSelectors[i].RadioButtons[j, 1].Text = " ";

                    }
                }
                if (SU.Length - AnswerLettersSelector.Length>0) SU = SU.Substring(AnswerLettersSelector.Length, SU.Length - AnswerLettersSelector.Length);
                if (SD.Length - AnswerLettersSelector.Length > 0) SD = SD.Substring(AnswerLettersSelector.Length, SD.Length - AnswerLettersSelector.Length);
                this.pnlUltimateSelection.Controls.Add(AnswerLettersSelectors[i]);
                this.pnlUltimateSelection.Controls.Add(AnswerLettersSelectorLabels[i]);

            }
            vScrollBar1.Visible = (AnswerLettersSelectorsCount > 4);
            this.pnlUltimateSelection.Refresh();

            //           // char[,] Answer = (char[,])BoddoohPartI.Answers[index];
            //for (int i = 0; i < line1.Length; i++)
            //{
            //    //char SelectedLetter = Convert.ToChar(((String)BoddoohPartI.OutputSentence[index]).Substring(i, 1));
            //    //for (int j = 1; j >= 0; j--)
            //    //{
            //    //answerLettersSelector2.RadioButtons[i, 0].Text = Convert.ToString(line1.Substring(i, 1));
            //    //answerLettersSelector2.RadioButtons[i, 1].Text = Convert.ToString(line2.Substring(i, 1));
            //    // if (Answer[i, j] == SelectedLetter)
            //    //answerLettersSelector2.RadioButtons[i, 0].Checked = false;
            //    // else
            //    //answerLettersSelector2.RadioButtons[i, 1].Checked = false;
            //    //}
            //}
        }

       
        private void button1_Click_8(object sender, EventArgs e)
        {
            //int C = Convert.ToInt32(textBox2.Text);
            //string s1 = Repeat("1234567890", C);
            //string s2 = Repeat("0123456789", C);
            //ShowInResultAfterUltimateProcessingPanel(s1, s2);
            //AnswerLettersSelector SLA = new AnswerLettersSelector();

            //this.tabResultsAfterUltimateProcessing.Refresh();
            //SLA.Refresh();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int v = vScrollBar1.Value;
            int Top = 20;
            int H = AnswerLettersSelector.LetterButtonWidth * 4;
            int f = (AnswerLettersSelectorsCount - 3) * H;
            
            for (int i = 0; i < AnswerLettersSelectorsCount; i++)
            {
                AnswerLettersSelectors[i].Top = Top + i * H - v * (f/90);
                AnswerLettersSelectorLabels[i].Top = Top + i * H - v * (f / 90) + 2 * AnswerLettersSelector.LetterButtonWidth;
            }
        }

        private void tabResultsAfterUltimateProcessing_Click(object sender, EventArgs e)
        {

        }

        private void grpUltimateSelection_Enter(object sender, EventArgs e)
        {

        }


        //private void listAnswers_SelectedIndexChanged(object sender, System.EventArgs e)
        //{
        //    if (0 <= listAnswers.SelectedIndex && listAnswers.SelectedIndex <= listAnswers.Items.Count)
        //    {
        //        if (BoddoohPartI.SelectedAnswerIndex >= 0)
        //            BoddoohPartI.OutputSentence[BoddoohPartI.SelectedAnswerIndex] = answerLettersSelector1.SelectedAnswer;
        //        BoddoohPartI.SelectedAnswerIndex = listAnswers.SelectedIndex;
        //        ShowSelectedAnswer();
        //    }
        //}
        private void SelectedAnswerChangedHandler()
        {
            string s = "";
            int Length = Boddooh.QuestionString.Length;
            int MaxAnswerLettersSelectorsCount = 1001 / AnswerLettersSelector.Length;
            MaxAnswerLettersSelectorsCount++;
            for (int i = 0; i < MaxAnswerLettersSelectorsCount; i++)
            {
                if (AnswerLettersSelectors[i] != null && AnswerLettersSelectors[i].Visible)
                {
                    string temp = AnswerLettersSelectors[i].SelectedAnswer;
                    if (Length<AnswerLettersSelector.Length)
                        temp = temp.Substring(0, Length);
                    AnswerLettersSelectorLabels[i].Text  = MiscMethods.PutOneSpaceBetweenAdjacentLetters(temp);

                    s += AnswerLettersSelectorLabels[i].Text;

                    if (Length > AnswerLettersSelector.Length)
                        Length -= AnswerLettersSelector.Length;
                    else
                        Length = 0;
                }
            }
            txtUltimateResult.Text = s;
            if (s.IndexOf("_") == -1)
            {
                s = MiscMethods.RemoveDelimiters(s);
                int[] AnswerArray = MiscMethods.StringToMinorAbjadSequence(s);
                UndoFinalProcessing(AnswerArray, FinalProcessingTimes);
                string OS = "";
                for (int index = 0; index < AnswerArray.Length; index++)
                    OS += Abjad.GetLetterByMinorAbjadNumber(AnswerArray[index]);

                int Rank = GetRank(Boddooh.QuestionStringWithDots, OS);
                lblRankFinal.Text = Rank.ToString(); 

            }

            //MessageBox.Show(s);
            //string Ans = answerLettersSelector1.SelectedAnswer.Substring(0, 1);
            //for (int i = 1; i < TwentyFour; i++)
            //    Ans += " " + answerLettersSelector1.SelectedAnswer.Substring(i, 1);
            //SelectedAnswerLabel.Text = Ans;
        }

        private void btnSaveUltimateResult_Click(object sender, EventArgs e)
        {
            try
            {
                
                string qs = Boddooh.QuestionString;
                qs = MiscMethods.PutOneSpaceBetweenAdjacentLetters(qs);
                string uas = txtUltimateResult.Text.Trim();
                long qid = SaveQAndOrGetItsId(qs);
                SaveUAAndGetItsId(qid, uas);
                Goto("SavedInputs");
                MessageBox.Show("عملیات ذخیره سازی با موفقیت انجام شد.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void RefreshQuestions()
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                daQs3.Fill(dt);
                con.Close();
                dgvInputs.Rows.Clear();
                ItemsIndgvInputs.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvInputs.Rows.Add();
                    dgvInputs.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();

                    string s = dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString() + dt.Rows[i][3].ToString() + dt.Rows[i][4].ToString() + dt.Rows[i][5].ToString() +
                        dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString();

                    ItemsIndgvInputs.Add(s);
                    if (s.Length <= HeaderSize)
                        dgvInputs.Rows[i].Cells[1].Value = s;
                    else
                    {
                        dgvInputs.Rows[i].Cells[1].Value = s.Substring(0, HeaderSize) + " " + "...";
                    }
                }
                dgvInputs.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                if (ItemsIndgvInputs.Count > 0)
                    txtSelectedInput.Text = ItemsIndgvInputs[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void RefreshUltimateAnswers(long qid)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                daUAs3.SelectCommand.Parameters[0].Value = qid.ToString();
                daUAs3.Fill(dt);
                con.Close();
                dgvSavedAnswers.Rows.Clear();
                ItemsIndgvSavedAnswers.Clear ();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvSavedAnswers.Rows.Add();
                    dgvSavedAnswers.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();

                    string s = dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString() + dt.Rows[i][3].ToString() + dt.Rows[i][4].ToString() + dt.Rows[i][5].ToString() +
                        dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString();
                    ItemsIndgvSavedAnswers.Add(s);
                    if (s.Length <= HeaderSize)
                        dgvSavedAnswers.Rows[i].Cells[1].Value = s;
                    else
                    {
                        dgvSavedAnswers.Rows[i].Cells[1].Value = s.Substring(0, HeaderSize) + " " + "...";
                    }

                }
                dgvSavedAnswers.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
        private void RefreshRawAnswers(long qid)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                daRAs3.SelectCommand.Parameters[0].Value = qid.ToString();
                daRAs3.Fill(dt);
                con.Close();
                dgvSavedAnswers.Rows.Clear();
                ItemsIndgvSavedAnswers.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvSavedAnswers.Rows.Add();
                    dgvSavedAnswers.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();

                    string s = dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString() + dt.Rows[i][3].ToString() + dt.Rows[i][4].ToString() + dt.Rows[i][5].ToString() +
                        dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString();
                    ItemsIndgvSavedAnswers.Add(s);
                    if (s.Length <= HeaderSize)
                        dgvSavedAnswers.Rows[i].Cells[1].Value = s;
                    else
                    {
                        dgvSavedAnswers.Rows[i].Cells[1].Value = s.Substring(0, HeaderSize) + " " + "...";
                    }
                }
                dgvSavedAnswers.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void ShowIndgvAnswers(long qid)
        {
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                daRAs3.SelectCommand.Parameters[0].Value = qid.ToString();
                daRAs3.Fill(dt);
                con.Close();
                dgvAnswers.Rows.Clear();
                ItemsIndgvAnswers.Clear();
                string qs = GetQ(qid);
                Boddooh.QuestionString = qs;
                txtInput.Text = MiscMethods.PutOneSpaceBetweenAdjacentLetters(qs);
                radioDoNotOmitDuplicateLetters.Checked = true;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvAnswers.Rows.Add();
                    dgvAnswers.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();

                    string s = dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString() + dt.Rows[i][3].ToString() + dt.Rows[i][4].ToString() + dt.Rows[i][5].ToString() +
                        dt.Rows[i][6].ToString() + dt.Rows[i][7].ToString() + dt.Rows[i][8].ToString();
                    ItemsIndgvAnswers.Add(s);
                    
                        
                    int Rank = GetRank(qs, s);
                    //string s = Abjad.LettersArrayToString(s, qs ,Rank);
                    dgvAnswers.Rows[i].Cells[0].Value = (i + 1).ToString();
                    dgvAnswers.Rows[i].Cells[1].Value = Rank.ToString();
                    if (s.Length <= HeaderSize)
                        dgvAnswers.Rows[i].Cells[2].Value = s;
                    else
                    {
                        dgvAnswers.Rows[i].Cells[2].Value = s.Substring(0, HeaderSize) + " " + "...";
                    }
                }
                dgvAnswers.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnViewInputs_Click(object sender, EventArgs e)
        {
            RefreshQuestions();
        }

        private void dgvAnswers_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            if ( dgvAnswers.SelectedRows.Count >0)
            {
                int index = dgvAnswers.SelectedRows[0].Index ;
                if (index < ItemsIndgvAnswers.Count )
                s = ItemsIndgvAnswers[index];
            }
            txtSelectedAnswer.Text = s;

        }

        private void dgvAnswers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvSelectedAnswer_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            if (dgvSelectedAnswer.SelectedRows.Count > 0)
            {
                int index = dgvSelectedAnswer.SelectedRows[0].Index;
                if (index < ItemsIndgvSelectedAnswer .Count)
                    s = ItemsIndgvSelectedAnswer[index];
            }
            txtSelectedSelectedAnswer.Text = s;
            
        }

       
      

        private long new_qid()
        {
            long qid = 0;
            OleDbDataReader dr;
            try
            {
                con.Open();

                dr = daQs2.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        qid = Convert.ToInt32(dr["maxqid"]) + 1;
                    else qid = 1;
                }
                catch (Exception ex)
                {
                    qid = 1;
                }

                dr.Close();
                con.Close();
                return qid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }

        private long new_raid()
        {
            long raid = -1;
            OleDbDataReader dr;
            try
            {
                con.Open();

                dr = daRAs2.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        raid = Convert.ToInt32(dr["maxraid"]) + 1;
                    else raid = 1;
                }
                catch (Exception ex)
                {
                    raid = 1;
                }

                dr.Close();
                con.Close();
                return raid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }
        private long new_uaid()
        {
            long uaid = -1;
            OleDbDataReader dr;
            try
            {
                con.Open();

                dr = daUAs2.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        uaid = Convert.ToInt32(dr["maxuaid"]) + 1;
                    else uaid = 1;
                }
                catch (Exception ex)
                {
                    uaid = 1;
                }

                dr.Close();
                con.Close();
                return uaid;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }
        public  long GetQId(string qs)
        {
            long result = -1;
            string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string s = qs.Trim();
            string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s, 20);

            OleDbDataReader dr;
            try
            {
                con.Open();
                for (int i = 0; i < S_Array.Length; i++)
                    daQs.SelectCommand.Parameters[0 + i].Value = S_Array[i];

                dr = daQs.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        result = Convert.ToInt64(dr["qid"]);
                }
                catch (Exception ex)
                {
                    result = -1;
                }

                dr.Close();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }
        public string GetQ(long qid)
        {
            string result = "";

            OleDbDataReader dr;
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                daQs4.SelectCommand.Parameters[0].Value = qid.ToString();
                daQs4.Fill(dt);
                con.Close();
                
  
                if (dt.Rows.Count>0)
                {
                    result = dt.Rows[0][0].ToString() + dt.Rows[0][1].ToString() + dt.Rows[0][2].ToString() + dt.Rows[0][3].ToString() + dt.Rows[0][4].ToString() 
                        + dt.Rows[0][5].ToString() +   dt.Rows[0][6].ToString() + dt.Rows[0][7].ToString();
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            return result;
        }

        public long GetRAId(long qid, string ras)
        {
            long result = -1;
            string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string s = ras.Trim();
            string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s,8);

            OleDbDataReader dr;
            try
            {
                con.Open();
                daRAs4.SelectCommand.Parameters[0].Value = qid.ToString ();

                for (int i = 0; i < S_Array.Length; i++)
                    daRAs4.SelectCommand.Parameters[1 + i].Value = S_Array[i];

                dr = daRAs4.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        result = Convert.ToInt64(dr["raid"]);
                }
                catch (Exception ex)
                {
                    result = -1;
                }

                dr.Close();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }
        public long GetUAId(long qid, string uas)
        {
            long result = -1;
            string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string s = uas.Trim();
            string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s,8);

            OleDbDataReader dr;
            try
            {
                con.Open();
                daUAs4.SelectCommand.Parameters[0].Value = qid.ToString();

                for (int i = 0; i < S_Array.Length; i++)
                    daUAs4.SelectCommand.Parameters[1 + i].Value = S_Array[i];

                dr = daUAs4.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        result = Convert.ToInt64(dr["uaid"]);
                }
                catch (Exception ex)
                {
                    result = -1;
                }

                dr.Close();
                con.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }
        public long SaveQAndGetItsId(string qs)
        {
            string s = qs.Trim();
            string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s,20);

            long qid = new_qid();
            daQs.InsertCommand.Parameters[0].Value = qid.ToString();

            for (int i = 0; i < S_Array.Length; i++)
                daQs.InsertCommand.Parameters[1 + i].Value = S_Array[i];

            try
            {
                con.Open();
                daQs.InsertCommand.ExecuteNonQuery();
                con.Close();
                return qid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long SaveRAAndGetItsId(long qid, string ras)
        {
            string s = ras.Trim();
            string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s,8);

            long raid = new_raid();
            daRAs.InsertCommand.Parameters[0].Value = qid.ToString();
            daRAs.InsertCommand.Parameters[1].Value = raid.ToString();

            for (int i = 0; i < S_Array.Length; i++)
                daRAs.InsertCommand.Parameters[2 + i].Value = S_Array[i];
           

            try
            {
                con.Open();
                daRAs.InsertCommand.ExecuteNonQuery();
                con.Close();
                return raid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void SaveRAs(long qid, List<string> ras)
        {
            if (ras.Count == 0)
                return;
            long raid = new_raid();
            for (int i = 0; i < ras.Count; i++)
            {
                string s = ras[i].Trim();
                string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
                string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s,8);

                daRAs.InsertCommand.Parameters[0].Value = qid.ToString();
                daRAs.InsertCommand.Parameters[1].Value = raid.ToString();

                for (int ii = 0; ii < S_Array.Length; ii++)
                    daRAs.InsertCommand.Parameters[2 + ii].Value = S_Array[ii];

                try
                {
                    con.Open();
                    daRAs.InsertCommand.ExecuteNonQuery();
                    con.Close();
                    raid++;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }

        }
        public long SaveUAAndGetItsId(long qid, string uas)
        {
            string s = uas.Trim();
            string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string[] S_Array = MiscMethods.TrimAndSplitStringIntoParts(s,8);

            long uaid = new_uaid();
            daUAs.InsertCommand.Parameters[0].Value = qid.ToString();
            daUAs.InsertCommand.Parameters[1].Value = uaid.ToString();
            for (int i = 0; i < S_Array.Length; i++)
                daUAs.InsertCommand.Parameters[2 + i].Value = S_Array[i];
            

            try
            {
                con.Open();
                daUAs.InsertCommand.ExecuteNonQuery();
                con.Close();
                return uaid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long SaveQAndOrGetItsId(string qs)
        {
            long qid = GetQId(qs);
            if (qid == -1)
                qid = SaveQAndGetItsId(qs);
            return qid;
        }
        public long SaveRAAndOrGetItsId(long qid, string ras)
        {
            long raid = GetRAId(qid, ras);
            if (raid == -1)
                raid = SaveRAAndGetItsId(qid, ras);
            return raid;
        }
        public long SaveUAAndOrGetItsId(long qid, string uas)
        {
            long uaid = GetRAId(qid, uas);
            if (uaid == -1)
                uaid = SaveRAAndGetItsId(qid, uas);
            return uaid;
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            

            try
            {

                string qs = Boddooh.QuestionString;
                qs = MiscMethods.PutOneSpaceBetweenAdjacentLetters(qs);
                long qid = SaveQAndOrGetItsId(qs);
                List<string> Answers = new List<string>();
                for (int i = 0; i < dgvAnswers.Rows.Count; i++)
                {
                    string s = ItemsIndgvAnswers[i].Trim();
                    s = MiscMethods.RemoveDots(s);
                    Answers.Add(s);
                }

                SaveRAs(qid, Answers);
                MessageBox.Show("عملیات ذخیره سازی با موفقیت انجام شد.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void btnViewRawResults_Click(object sender, EventArgs e)
        {
            if (dgvInputs.SelectedRows.Count == 0) return;
            int index = dgvInputs.SelectedRows[0].Index;
            string s = ItemsIndgvInputs[index];
            s = MiscMethods.RemoveDots(s);

            long qid = GetQId(s);

            RefreshRawAnswers(qid);
            if (ItemsIndgvSavedAnswers.Count>0)
            txtSelectedSavedAnswer.Text = ItemsIndgvSavedAnswers[0];
            Goto("SavedOutputs");
        }

        private void btnViewUltimateResults_Click(object sender, EventArgs e)
        {
            if (dgvInputs.SelectedRows.Count == 0) return;
            int index = dgvInputs.SelectedRows[0].Index;
            string s = ItemsIndgvInputs[index];
            s = MiscMethods.RemoveDots(s);

            long qid = GetQId(s);

            RefreshUltimateAnswers(qid);
            if (ItemsIndgvSavedAnswers.Count > 0)
                txtSelectedSavedAnswer.Text = ItemsIndgvSavedAnswers[0];
            Goto("SavedOutputs");
        }

        private void dgvInputs_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            if (dgvInputs.SelectedRows.Count > 0)
            {
                int index = dgvInputs.SelectedRows[0].Index;
                if (index < ItemsIndgvInputs.Count)
                    s = ItemsIndgvInputs[index];
            }
            txtSelectedInput.Text = s;
        }

        private void dgvSavedAnswers_SelectionChanged(object sender, EventArgs e)
        {
            string s = "";
            if (dgvSavedAnswers.SelectedRows.Count > 0)
            {
                int index = dgvSavedAnswers.SelectedRows[0].Index;
                if (index < ItemsIndgvSavedAnswers.Count)
                    s = ItemsIndgvSavedAnswers[index];
            }
            txtSelectedSavedAnswer.Text = s;
        }

        private void btnProcessRawAnswers_Click(object sender, EventArgs e)
        {
            if (dgvInputs.SelectedRows.Count == 0) return;
            int index = dgvInputs.SelectedRows[0].Index;
            string s = ItemsIndgvInputs[index];
            s = MiscMethods.RemoveDots(s);
            
            long qid = GetQId(s);

            ShowIndgvAnswers(qid);
            Goto("Results");
        }
        private int GetRank(string qs, string os)
        {
            qs = MiscMethods.RemoveDelimiters(qs);
            os = MiscMethods.RemoveDelimiters(os);
            int Length = qs.Length;
          
            int[] QuestionLetters = MiscMethods.StringToMinorAbjadSequence(qs);
            byte[] AnAcceptableAnswer = MiscMethods.StringToMinorAbjadSequenceByteArray(os);
             
                  int[] StairwayResultArray = new int[Length-1];
                       



                            int Rank = Boddooh101Table.GetRank(QuestionLetters, AnAcceptableAnswer, StairwayResultArray);

                            return Rank;

                        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void nudMinRank_ValueChanged(object sender, EventArgs e)
        {
            MinimumRank =  Convert.ToInt32(nudMinRank.Value);
        }


       
        //private void ShowSelectedAnswer()
        //{
        //    int index = SelectedAnswerIndex;
        //    if (0 <= index && index < BoddoohPartI.Answers.Count)
        //    {
        //        char[,] Answer = (char[,])BoddoohPartI.Answers[index];
        //        for (int i = 0; i < BoddoohNumbers.TwentyFour; i++)
        //        {
        //            char SelectedLetter = Convert.ToChar(((String)BoddoohPartI.OutputSentence[index]).Substring(i, 1));
        //            for (int j = BoddoohNumbers.Four - 1; j >= 0; j--)
        //            {
        //                answerLettersSelector1.RadioButtons[i, j].Text = Convert.ToString(Answer[i, j]);
        //                if (Answer[i, j] == SelectedLetter)
        //                    answerLettersSelector1.RadioButtons[i, j].Checked = true;
        //                else
        //                    answerLettersSelector1.RadioButtons[i, j].Checked = false;
        //            }
        //        }
        //        Refresh();
        //    }
        //}
      
     

       

       
       
	}
}
