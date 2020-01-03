using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Collections;
using System.Threading;

namespace Boddooh
{

    public partial class FormInputManagment : Form
    {
        private static long ProgressCount;
        private static long MaxProgressCount;
        private Mutex ProgressCountMutex = new Mutex();

        public int MinRank;
        public List<int[]> AllStarts;
        private Mutex InputProcessMutex = new Mutex();
        private Mutex mutex1 = new Mutex(); 
        private int ComputingJobsCount = 2;
        //Semaphore VirtualCores;
        private Thread[] ComputingJobs;
       // List<int[]> ComputingJobsInformation;

        //private int NotInitialized = 0;
       // private int NotStarted = 1;
        private int Started = 2;
       // private int Stopped = 3;
        private int BackgroundThreadsState = 0;

        private Thread BackgroundThread;

        public Label OutputLabel;

        public static int GroupItemsCount = 2*27*26*25;
        public static int MinLength = 8;
        public static int MaxLength = 28;
        //public static int[] InputLengthArray = new int[] { 9, 11, 12, 14, 18, 20, 26, 28 };
        public static string TransactionNotStarted = "شروع نشده";

        public static string TransactionStarted = "نیمه تمام";
        public static string TransactionFinished = "تمام شده";
        public static string InputSelected = "انتخاب شده";

        public static string FinishedString = "محاسبه ورودی ها تمام شد.";
        public static int MaxRank = 10;
        public static ArrayList[] Inputs;
        
        //static string ConnectionString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA Source=InputList.mdb";


        private bool AlreadyInserted(int Length, int A, int B, int C, int D, string InputText, int Method)
        {
            try
            {
                bool result = false;
                con.Open();
                DA_GeneratedInputs2.SelectCommand.Parameters[0].Value = Length.ToString();
                DA_GeneratedInputs2.SelectCommand.Parameters[1].Value = InputText;
                DA_GeneratedInputs2.SelectCommand.Parameters[2].Value = Method.ToString();
                DA_GeneratedInputs2.SelectCommand.Parameters[3].Value = A.ToString();
                DA_GeneratedInputs2.SelectCommand.Parameters[4].Value = B.ToString();
                DA_GeneratedInputs2.SelectCommand.Parameters[5].Value = C.ToString();
                DA_GeneratedInputs2.SelectCommand.Parameters[6].Value = D.ToString();
                DataTable dt = new DataTable();
                DA_GeneratedInputs2.Fill(dt);
                result = (dt.Rows.Count > 0);
                con.Close();
                return result;
            }
            catch
            {
                return false;
            }
        }

        private bool InsertIfNotAlreadyInserted(int Length, int A, int B, int C, int D, string InputText, int Rank, int Method)
        {
            if (AlreadyInserted(Length, A,  B,  C,  D, InputText, Method))
            {
                return false;
            }
            else
            {
                InsertIntoGeneratedInputsAnyway(Length,  A,  B,  C,  D, InputText, Rank, Method);
                return true;
            }
        }

        private void InsertIntoGeneratedInputsAnyway(int Length, int A, int B, int C, int D, string InputText, int Rank, int Method)
        {
            con.Open();
            DA_GeneratedInputs.InsertCommand.Parameters[0].Value = Length.ToString();            
            DA_GeneratedInputs.InsertCommand.Parameters[1].Value = InputText;
            DA_GeneratedInputs.InsertCommand.Parameters[2].Value = Rank.ToString();
            DA_GeneratedInputs.InsertCommand.Parameters[3].Value = "";
            DA_GeneratedInputs.InsertCommand.Parameters[4].Value = Method.ToString();
            DA_GeneratedInputs.InsertCommand.Parameters[5].Value = A.ToString();
            DA_GeneratedInputs.InsertCommand.Parameters[6].Value = B.ToString();
            DA_GeneratedInputs.InsertCommand.Parameters[7].Value = C.ToString();
            DA_GeneratedInputs.InsertCommand.Parameters[8].Value = D.ToString();
            DA_GeneratedInputs.InsertCommand.ExecuteNonQuery();
            con.Close();
        }

        //private void InsertIntoGeneratedInputs(int Length, int StartLetter, List<int[]> Inputs, int Method)
        //{
        //    for (int i = 0; i < Inputs.Count; i++)
        //    {
        //        int[] AnInput = Inputs[i];
        //        int Rank = GetRank(AnInput);
        //        string InputText = GetInputText(AnInput);
        //        InsertIfNotAlreadyInserted(Length, StartLetter, InputText, Rank, Method); 
        //    }            
        //}

        private string GetTransactionState(int Length, int FirstLetter)
        {
            string result = TransactionStarted;
            DataTable dt = new DataTable();
            con.Open();
            DA_Transactions.SelectCommand.Parameters[0].Value = Length.ToString();
            DA_Transactions.SelectCommand.Parameters[1].Value = Length.ToString();
            DA_Transactions.SelectCommand.Parameters[2].Value = FirstLetter.ToString();
            DA_Transactions.SelectCommand.Parameters[3].Value = FirstLetter.ToString();
            
            DA_Transactions.Fill(dt);
            if (dt.Rows.Count == GroupItemsCount)
                result = TransactionFinished ;
            if (dt.Rows.Count == 0)
                result = TransactionNotStarted;
            con.Close();
            return result;
        }
        private string GetTransactionState(DataTable dt, ref int StartIndex, int Length, int FirstLetter)
        {
            if (dt.Rows.Count == 0 || StartIndex >= dt.Rows.Count)
                return TransactionNotStarted;
            int CurrentLength = Convert.ToInt32(dt.Rows[StartIndex]["length"].ToString());
            int CurrentFirstLetter = Convert.ToInt32(dt.Rows[StartIndex]["first"].ToString());
            if (CurrentLength == Length && FirstLetter == CurrentFirstLetter)
            {
                int CompletedCount = Convert.ToInt32(dt.Rows[StartIndex]["CompletedCount"].ToString());
                StartIndex++;
                if (CompletedCount == GroupItemsCount)
                    return TransactionFinished;
                else
                    return TransactionStarted;
            }
            while (StartIndex < dt.Rows.Count && (CurrentLength < Length || (CurrentLength == Length && CurrentFirstLetter < FirstLetter)))
            {
                StartIndex++;
                CurrentLength = Convert.ToInt32(dt.Rows[StartIndex]["length"].ToString());
                CurrentFirstLetter = Convert.ToInt32(dt.Rows[StartIndex]["first"].ToString());
                if (CurrentLength == Length && FirstLetter == CurrentFirstLetter)
                {
                    int CompletedCount = Convert.ToInt32(dt.Rows[StartIndex]["CompletedCount"].ToString());
                    StartIndex++;
                    if (CompletedCount == GroupItemsCount)
                        return TransactionFinished;
                    else
                        return TransactionStarted;
                }
                
            }
            return TransactionNotStarted;
        }

        private DataTable GetTransactionsStatesDataTable(int Length, int FirstLetter)// OK
        {
            string result = TransactionStarted;
            DataTable dt = new DataTable();
            con.Open();
            int MinL = Length;
            int MaxL = Length;
            if (!IsAValidLength(Length))
            {
                MinL = MinLength;
                MaxL = MaxLength;
            }

            int MinFirstLetter = FirstLetter;
            int MaxFirstLetter = FirstLetter;
            if (FirstLetter > 28 || FirstLetter<1)
            {
                MinFirstLetter = 1;
                MaxFirstLetter = 28;
            }

            DA_Transactions2.SelectCommand.Parameters[0].Value = MinL.ToString();
            DA_Transactions2.SelectCommand.Parameters[1].Value = MaxL.ToString();
            DA_Transactions2.SelectCommand.Parameters[2].Value = MinFirstLetter.ToString();
            DA_Transactions2.SelectCommand.Parameters[3].Value = MaxFirstLetter.ToString();

            DA_Transactions2.Fill(dt);

           con.Close();
            return dt;
        }

        private void AddCompletedTransaction(int Length, int FirstLetter, int B, int C, int D, int Method)
        {
            InputProcessMutex.WaitOne();
            con.Open();
            DA_Transactions.InsertCommand.Parameters[0].Value = Length.ToString();
            DA_Transactions.InsertCommand.Parameters[1].Value = FirstLetter.ToString();
            DA_Transactions.InsertCommand.Parameters[2].Value = B.ToString();
            DA_Transactions.InsertCommand.Parameters[3].Value = C.ToString();
            DA_Transactions.InsertCommand.Parameters[4].Value = D.ToString();
            DA_Transactions.InsertCommand.Parameters[5].Value = Method.ToString();
            try
            {
                DA_Transactions.InsertCommand.ExecuteNonQuery();
            }
            catch { }
            con.Close();
            InputProcessMutex.ReleaseMutex();
        }

        private bool IsAValidLength(int Length)
        {
            bool result = false;
            if (Length >= 8 && Length <= 28)
                result = true;
            return result;
        }

        private void RefreshTransactionsState(int Length)
        {
            DataTable dt = GetTransactionsStatesDataTable(Length, 0);
            List<int> LengthList = new List<int>();

            bool ValidLength = IsAValidLength(Length);           

            if (ValidLength)
            {
                LengthList.Add(Length);
            }
            else
            {
                for (int i = MinLength; i <= MaxLength; i++)
                    LengthList.Add(i);
            }

            dgvTransactions.Rows.Clear();
            int StartIndex = 0;
            for (int i = 0; i < LengthList.Count; i++)
            {
                int L = LengthList[i];
                for (int S = 1; S <= 28; S++)
                {
                    dgvTransactions.Rows.Add();
                    int index = dgvTransactions.Rows.Count - 1;
                    string State = GetTransactionState(dt, ref StartIndex, L, S); 
                    dgvTransactions.Rows[index].Cells[0].Value = L.ToString();
                    dgvTransactions.Rows[index].Cells[1].Value = Abjad.GetLetterByMinorAbjadNumber(S).ToString();
                    dgvTransactions.Rows[index].Cells[2].Value = State;
                }
            }
        }

        //private void RefreshTransactionsStatesssss(int Length)
        //{
        //    con.Open();
        //    if (Length > 0)
        //    {
        //        DA_Transactions.SelectCommand.Parameters[0].Value = Length.ToString();
        //        DA_Transactions.SelectCommand.Parameters[1].Value = Length.ToString();
        //    }
        //    else
        //    {
        //        DA_Transactions.SelectCommand.Parameters[0].Value = MinLength.ToString();
        //        DA_Transactions.SelectCommand.Parameters[1].Value = MaxLength.ToString();
        //    }
        //    DA_Transactions.SelectCommand.Parameters[2].Value = 1;// (1).ToString();
        //    DA_Transactions.SelectCommand.Parameters[3].Value = 28;// (28).ToString();
        //    DA_Transactions.SelectCommand.Parameters[4].Value = 0;// (0).ToString();
        //    DA_Transactions.SelectCommand.Parameters[5].Value = 1;// (1).ToString();

        //    DataTable dt = new DataTable();
        //    DA_Transactions.Fill(dt);
        //    dgvTransactions.DataSource = dt;
        //    con.Close();
        //}
      


        
        public void GenerateInputs(int Length, int FirstLetter)
        {          
            int LastLetter = InputManagement.GetLastLetter(FirstLetter); int MinorAbjadSummation = InputManagement.GetMinorAbjadSummation(Length, FirstLetter);

            int MiddleLength = Length - 2; int MiddleMinorAbjadSummation = MinorAbjadSummation - (FirstLetter + LastLetter);
            char FirstChar = Abjad.GetLetterByMinorAbjadNumber(FirstLetter);

          
            //  MessageBox.Show(cc.ToString());
            //InsertIntoGeneratedInputs(Length, FirstLetter, Inputs[0]);

        }

        public static int GetRank(string s)
        {
            string temp = MiscMethods.RemoveDelimiters(s.Trim());
            int Length = temp.Length;
            if (Length < 8) return 0;
            int[] ArrayString = new int[Length];
            for (int i = 0; i < Length; i++)
            {
                ArrayString[i] = Abjad.MinorAbjadNumber(temp[i]);
                if (ArrayString[i] == 0)
                    return -1;
            }
            return Boddooh101Table.Conditions_InputManagment(ArrayString);
        }

        public static int GetRank(int[] InputArray)
        {
            return Boddooh101Table.Conditions_InputManagment(InputArray);
        }
        public static string GetInputText(int[] InputArray)
        {
            string result = Abjad.LettersArrayToString(InputArray);
            return result;
        }
        
        public FormInputManagment()
        {
            InitializeComponent();
        }


        private void ProcessAFeasibleInputTextArray(int[] InputTextArray)
        {
            int Rank = Boddooh101Table.Conditions_InputManagment(InputTextArray);
            if (Rank > 0)
            {

            }
        }

        private void DeleteForInitialization()
        {
            try
            {
                DeleteAllTransactions();
                DeleteAllGeneratedInputs();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DeleteAllTransactions()
        {
            con.Open();
            DA_Transactions.DeleteCommand.ExecuteNonQuery();
            con.Close();
        }
        private void DeleteAllGeneratedInputs()
        {
            con.Open();
            DA_GeneratedInputs2.DeleteCommand.ExecuteNonQuery();
            con.Close();
        }
        private void Delete(string InputText)
        {
            try
            {
                ArrayList Inputs = ReadInputsFromFile();
                int index = GetIndexOf(Inputs, InputText);
                while (index >= 0)
                {
                    Inputs.RemoveAt(index);
                    index = GetIndexOf(Inputs, InputText);
                }
                WriteInputsToFile(Inputs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetIndexOf(ArrayList Inputs, string InputText)
        {
            string TempInputText = InputText;
            TempInputText = MiscMethods.NormalizePersianString(TempInputText.Trim());
            TempInputText = MiscMethods.RemoveDelimiters(TempInputText);
            for (int i = 0; i < Inputs.Count; i++)
            {
                string CurrentInputText = (string)Inputs[i];
                string TempCurrentInputText = CurrentInputText;
                TempCurrentInputText = MiscMethods.NormalizePersianString(TempCurrentInputText.Trim());
                TempCurrentInputText = MiscMethods.RemoveDelimiters(TempCurrentInputText);
                if (TempCurrentInputText == TempInputText)
                    return i;
            }
            return -1;
        }

        
                      

        private void RefreshForm()
        {
            try
            {
                dgvTransactions.Rows.Clear();
                ArrayList Inputs = ReadInputsFromFile();
                for (int i = 0; i < Inputs.Count; i++)
                {
                    string InputText = (string)Inputs[i];
                    string WD = WDString(InputText);
                    string WODFBSTM = FormInputList.WODFBSTMString(InputText);
                    string WODFRTL = FormInputList.WODFBSTMString(InputText);
                    dgvTransactions.Rows.Add("", "", "");
                    dgvTransactions.Rows[i].Cells["InputText"].Value = InputText;
                    dgvTransactions.Rows[i].Cells["WODFBSTM"].Value = WODFBSTM;
                    dgvTransactions.Rows[i].Cells["WODFRTL"].Value = WODFRTL;
                    dgvTransactions.Rows[i].Cells["WD"].Value = WD;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //Done();
        }


        //private void InitializeTransactions()
        //{
        //    con.Open();
        //    for (int l = 0; l < InputLengthArray.Length; l++)
        //    {
        //        int length = InputLengthArray[l];
        //        DA_Transactions.InsertCommand.Parameters[0].Value = length.ToString();

        //        for (int start = 1; start <= 28; start++)
        //        {
        //            DA_Transactions.InsertCommand.Parameters[1].Value = start.ToString();
        //            List<int[]> AllStarts = AllBoddooh4By4Tables.GetAllFirstBoddooh4By4TablesStartingWithA(start);
        //            for (int i = 0; i < AllStarts.Count; i++)
        //            {
        //                DA_Transactions.InsertCommand.Parameters[2].Value = AllStarts[i][1].ToString();
        //                DA_Transactions.InsertCommand.Parameters[3].Value = AllStarts[i][2].ToString();
        //                DA_Transactions.InsertCommand.Parameters[4].Value = AllStarts[i][3].ToString();
        //                DA_Transactions.InsertCommand.Parameters[5].Value = (0).ToString();
        //                DA_Transactions.InsertCommand.ExecuteNonQuery();
        //            }
        //        }
        //    }
        //    con.Close();
        //}

       

       
       
        public static ArrayList ReadInputsFromFile()
        {
            ArrayList result = new ArrayList();
            //try
            //{
            //    InputFile IF = new InputFile(FileName);
            //    IF.Open();
            //    bool Done = false;
            //    while (!Done)
            //    {
            //        string InputText = IF.ReadLine();
            //        if (InputText != null)
            //        {
            //            result.Add(InputText);
            //        }
            //        else
            //        {
            //            Done = true;
            //        }
            //    }

            //    IF.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            return result;

        }

        public void WriteInputsToFile(ArrayList Inputs)
        {
            //try
            //{
            //    OutputFile OF = new OutputFile(FileName);
            //    OF.Open();
            //    for (int i = 0; i < Inputs.Count; i++)
            //    {
            //        string InputText = (string)Inputs[i];
            //        OF.WriteLine(InputText);
            //    }

            //    OF.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public static void InsertInput(string input)
        {
            //int LengthWD = 0, LengthWoD = 0, MinorASWD = 0, MinorASWoD = 0;
            //string InputText = input;
            //InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            //string InputTextWoD = MiscMethods.RemoveDelimiters(InputText);

            //if (InputTextWoD.Length == 0)
            //{
            //    return;
            //}
            //if (Abjad.ContainsNonAlphabet(InputTextWoD))
            //{
            //    return;
            //}
            //if (Abjad.ContainsNonAbjabAlphabet(InputTextWoD))
            //{
            //    return;
            //}
            //string InputTextWD = Boddooh.OmitDuplicateLetters(InputTextWoD);
            //LengthWD = InputTextWD.Length;
            //LengthWoD = InputTextWoD.Length;
            //MinorASWD = Abjad.MinorAbjadSummation(InputTextWD);
            //MinorASWoD = Abjad.MinorAbjadSummation(InputTextWoD);

            ////  OleDbConnection con = new OleDbConnection(ConnectionString);

            //string WoD = LengthWoD.ToString() + " " + "حرف، جمع : " + MinorASWoD.ToString();
            //string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString();


            //OleDbCommand com;
            //int newid = new_id();
            //com = new OleDbCommand("insert into Inputs Values(?,?,?,?)", con);
            ////com.Parameters.Add("@id", newid);
            //com.Parameters.Add("@wod", WoD);
            //com.Parameters.Add("@wd", WD);

            //com.Parameters.Add("@it", input);
            //try
            //{
            //    con.Open();
            //    com.ExecuteNonQuery();
            //    con.Close();
            //    MessageBox.Show("ورودی مربوطه با موفقیت ذخیره شد.", "ذخیره ورودی" ,MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        private void New()
        {
            //string InputText = txtInputText.Text;
            //InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            //try
            //{
            //    ArrayList Inputs = ReadInputsFromFile();
            //    if (GetIndexOf(Inputs, InputText) == -1)
            //    {
            //        Inputs.Add(InputText);
            //    }
            //    WriteInputsToFile(Inputs);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Edit()
        {
            //string InputText = txtInputText.Text;
            //InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            //if (InputText == SelectedInputText)
            //    return;
            //try
            //{
            //    ArrayList Inputs = ReadInputsFromFile();
            //    int index = GetIndexOf(Inputs, SelectedInputText);
            //    while (index >= 0)
            //    {
            //        Inputs.RemoveAt(index);
            //        index = GetIndexOf(Inputs, SelectedInputText);
            //    }
            //    Inputs.Add(InputText);
            //    WriteInputsToFile(Inputs);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //OleDbConnection con = new OleDbConnection(ConnectionString);
            //int LengthWD = 0, LengthWoD = 0, MinorASWD = 0, MinorASWoD = 0;
            //RefreshInputStatus(ref LengthWD, ref LengthWoD, ref MinorASWD, ref MinorASWoD);
            //string WoD = LengthWoD.ToString() + " " + "حرف، جمع : " + MinorASWoD.ToString();
            //string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString();


            //OleDbCommand com;
            //com = new OleDbCommand("update Inputs set inputtext=?, wod=?, wd=? where id=? ", con);
            //com.Parameters.Add("@it", txtInputText.Text);
            //com.Parameters.Add("@wod", WoD);
            //com.Parameters.Add("@wd", WD);
            //com.Parameters.Add("@id", iid);

            //try
            //{
            //    con.Open();
            //    com.ExecuteNonQuery();
            //    con.Close();
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        private void FillForm()
        {
            //txtInputText.Text = SelectedInputText;
        }


        private void dataGridViewContactsList_SelectionChanged(object sender, EventArgs e)
        {
            //Done();
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            Select();
        }

       

        private void dataGridViewInputList_DoubleClick(object sender, EventArgs e)
        {
            
            SelectTransaction();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInputText_TextChanged(object sender, EventArgs e)
        {
            //int LengthWD = 0, LengthWoD = 0, MinorASWD = 0, MinorASWoD = 0;
            //lblLengthWOD.Text = "";
            //lblLengthWD.Text = "";
            //lblMinorASWOD.Text = "";
            //lblMinorASWD.Text = "";
            //RefreshInputStatus(ref LengthWD, ref LengthWoD, ref MinorASWD, ref MinorASWoD);
            //if (LengthWD == 0 || LengthWoD == 0 || MinorASWD == 0 || MinorASWoD == 0)
            //    return;
            //lblLengthWD.Text = Convert.ToString(LengthWD);
            //lblLengthWOD.Text = Convert.ToString(LengthWoD);
            //lblMinorASWD.Text = Convert.ToString(MinorASWD);
            //lblMinorASWD.Text += (" " + "= K28");
            //if (MinorASWD % BoddoohNumbers.TwentyEight > 0)
            //    lblMinorASWD.Text += (" + " + (MinorASWD % BoddoohNumbers.TwentyEight).ToString());
            //lblMinorASWOD.Text = Convert.ToString(MinorASWoD);
            //lblMinorASWOD.Text += (" " + "= K28");
            //if (MinorASWoD % BoddoohNumbers.TwentyEight > 0)
            //    lblMinorASWOD.Text += (" + " + (MinorASWoD % BoddoohNumbers.TwentyEight).ToString());




        }
        private void RefreshInputStatus(ref int LengthWD, ref int LengthWoD, ref int MinorASWD, ref int MinorASWoD)
        {
            //LengthWD = LengthWoD = MinorASWD = MinorASWoD = 0;
            //string InputText = txtInputText.Text;
            //InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            //string InputTextWoD = MiscMethods.RemoveDelimiters(InputText);

            //if (InputTextWoD.Length == 0)
            //{
            //    txtInputText.Focus();
            //    return;
            //}
            //if (Abjad.ContainsNonAlphabet(InputTextWoD))
            //{
            //    txtInputText.Focus();
            //    return;
            //}
            //if (Abjad.ContainsNonAbjabAlphabet(InputTextWoD))
            //{
            //    txtInputText.Focus();
            //    return;
            //}
            //string InputTextWD = Boddooh.OmitDuplicateLetters(InputTextWoD);
            //LengthWD = InputTextWD.Length;
            //LengthWoD = InputTextWoD.Length;
            //MinorASWD = Abjad.MinorAbjadSummation(InputTextWD);
           // MinorASWoD = Abjad.MinorAbjadSummation(InputTextWoD);

        }

        private void ShowSelectedInput()
        {
            //string InputText = "";
            //if (dataGridViewInputList.SelectedRows.Count > 0)
            //    InputText = dataGridViewInputList.SelectedRows[0].Cells["InputText"].Value.ToString();

            //txtInputText.Text = InputText;
            //iid = id;
            //if (iid > 0)
            //{
            //    FillForm();
            //    Mode = "view";
            //    ShowInputText();
            //}
        }

        private string WDString(string InputText)
        {
            int LengthWD = 0, MinorASWD = 0;
            string TempWD = InputText;
            TempWD = MiscMethods.NormalizePersianString(TempWD.Trim());
            TempWD = MiscMethods.RemoveDelimiters(TempWD);

            LengthWD = TempWD.Length;
            MinorASWD = Abjad.MinorAbjadSummation(TempWD);

            string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString() + " " + "= K28";
            if (MinorASWD % BoddoohNumbers.TwentyEight > 0)
                WD += (" + " + (MinorASWD % BoddoohNumbers.TwentyEight).ToString());
            return WD;
        }

       

        private void dataGridViewInputList_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridViewInputList_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Return)
            {
                SelectTransaction();
            }
            if (e.KeyChar == (char)Keys.Delete)
            {
                //toolStripButtonDelete_Click(null, null);
            }
            e.Handled = true;
        }

        private void FormInputList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyChar == (char)Keys.Return)
            {
                Select();
            }
            if (e.KeyChar == (char)Keys.Delete)
            {
                //toolStripButtonDelete_Click(null, null);
            }
            e.Handled = true;
        }

        private void dataGridViewInputList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectTransaction();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //InputGeneration .GenerateInputs(6, 2, listBox1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            //GenerateInputs(6, 1, OS);
            //Transactions(0);
            //InsertIntoTransactions();
            
           // MessageBox.Show("Done");
            //DeleteAllTransactions();
            //Insert(9, 1, " 3|");
        }

        //private void GetStateStackAndValuation(int Length, char StartLetter, ref string state, ref string stack, ref string array)
        //{
        //    con.Open();
        //    DA_Transactions2.SelectCommand.Parameters[0].Value = Length.ToString();
        //    DA_Transactions2.SelectCommand.Parameters[1].Value = StartLetter.ToString();
        //    DataTable dt = new DataTable();
        //    DA_Transactions2.Fill(dt);
        //    if (dt.Rows.Count==1)
        //    {

        //        state = Convert.ToString(dt.Rows[0]["state"]);
        //        stack = Convert.ToString(dt.Rows[0]["stack"]);
        //        array = Convert.ToString(dt.Rows[0]["array"]);
        //    }
        //    con.Close();
        //}

        private void SetStateStackAndValuation(int Length, char StartLetter, string state, string stack, string array)
        {
            con.Open();
            DA_Transactions2.UpdateCommand.Parameters[0].Value = state;
            DA_Transactions2.UpdateCommand.Parameters[1].Value = stack;
            DA_Transactions2.UpdateCommand.Parameters[2].Value = array;
            DA_Transactions2.UpdateCommand.Parameters[3].Value = Length.ToString();
            DA_Transactions2.UpdateCommand.Parameters[4].Value = StartLetter.ToString();
            DA_Transactions2.UpdateCommand.ExecuteNonQuery();
            con.Close();
        }



        private void GenerationProcess(int Length, char StartLetter)
        {

        }


        private void StartOrResumeGeneration(int Length, char StartLetter, int MinRank)
        {
            //int FirstLetter = Abjad.MinorAbjadNumber(StartLetter);
            //string state = "", stack = "", array = "";
            ////GetStateStackAndValuation(Length, StartLetter, ref state, ref stack, ref array);
            ////if (state == TransactionNotStarted || state == TransactionStarted)
            ////{
            //Stack OptionsStack = new Stack();
            //int LastLetter = GetLastLetter(FirstLetter); int MinorAbjadSummation = GetMinorAbjadSummation(Length, FirstLetter);
            //int MiddleLength = Length - 2; int MiddleMinorAbjadSummation = MinorAbjadSummation - (FirstLetter + LastLetter);
            //IntQuadruple IQ;
            //for (int i = 1; i <= 28; i++)
            //{
            //    IQ = new IntQuadruple(0, i, MiddleMinorAbjadSummation - i, -1);
            //    OptionsStack.Push(IQ);
            //}
            //            //   Stack OptionsStack = MiscMethods.StringToStack(stack, Length, FirstLetter);
            //   // int[] ValuationArray = MiscMethods.CSVStringToArray(array);
            //int[] ValuationArray = new int[MiddleLength];
            //    GenerateInputs(Length, FirstLetter, OptionsStack, ValuationArray, MinRank);
            ////}
            //if (state == TransactionFinished)
            //{
            //    MessageBox.Show("خطا");
            //}
        }








        private void ShowGeneratedInputs(int Length, int MinRank, int Letter1, int Letter2, int Letter3, int Letter4)
        {
            tstxtLengthG.Text = Length.ToString();
            tstxtStartG.Text = Abjad.GetLetterByMinorAbjadNumber(Letter1).ToString();
            con.Open();
            DA_GeneratedInputs.SelectCommand.Parameters[0].Value = Length.ToString();
            DA_GeneratedInputs.SelectCommand.Parameters[1].Value = MinRank.ToString();
            if (Letter1 < 1 || Letter1 > 28)
            {                
                DA_GeneratedInputs.SelectCommand.Parameters[2].Value = (1).ToString();                
                DA_GeneratedInputs.SelectCommand.Parameters[3].Value = (28).ToString();                
            }
            else
            {
                DA_GeneratedInputs.SelectCommand.Parameters[2].Value = Letter1.ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[3].Value = Letter1.ToString();                
            }
            if (Letter2 < 1 || Letter2 > 28)
            {
                DA_GeneratedInputs.SelectCommand.Parameters[4].Value = (1).ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[5].Value = (28).ToString();
            }
            else
            {
                DA_GeneratedInputs.SelectCommand.Parameters[4].Value = Letter2.ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[5].Value = Letter2.ToString();
            }
            if (Letter3 < 1 || Letter3 > 28)
            {
                DA_GeneratedInputs.SelectCommand.Parameters[6].Value = (1).ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[7].Value = (28).ToString();
            }
            else
            {
                DA_GeneratedInputs.SelectCommand.Parameters[6].Value = Letter3.ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[7].Value = Letter3.ToString();
            }
            if (Letter4 < 1 || Letter4 > 28)
            {
                DA_GeneratedInputs.SelectCommand.Parameters[8].Value = (1).ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[9].Value = (28).ToString();
            }
            else
            {
                DA_GeneratedInputs.SelectCommand.Parameters[8].Value = Letter4.ToString();
                DA_GeneratedInputs.SelectCommand.Parameters[9].Value = Letter4.ToString();
            }
            
            DataTable dt = new DataTable();
            DA_GeneratedInputs.Fill(dt);
            dgvGeneratedInputs.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvGeneratedInputs.Rows.Add();
                dgvGeneratedInputs.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                dgvGeneratedInputs.Rows[i].Cells[1].Value = dt.Rows[i][1].ToString();
                dgvGeneratedInputs.Rows[i].Cells[2].Value = dt.Rows[i][2].ToString();

            }
               // dgvGeneratedInputs.DataSource = dt;
            con.Close();
        }

        private void GetFirstSecondThirdAndForthLetters(string strLetters, ref int Letter1, ref int Letter2, ref int Letter3, ref int Letter4)
        {
             Letter1 = 0;
             Letter2 = 0;
             Letter3 = 0;
             Letter4 = 0;
            string s = MiscMethods.RemoveDelimiters(strLetters).Trim() ; 
            int Length = s.Length;
            try
            {
                if (Length > 0)
                    Letter1 = Abjad.MinorAbjadNumber(Convert.ToChar(s.Substring(0,1)));
                if (Length > 1)
                    Letter2 = Abjad.MinorAbjadNumber(Convert.ToChar(s.Substring(1, 1)));
                if (Length > 2)
                    Letter3 = Abjad.MinorAbjadNumber(Convert.ToChar(s.Substring(2, 1)));
                if (Length > 3)
                    Letter4 = Abjad.MinorAbjadNumber(Convert.ToChar(s.Substring(3, 1)));

            }
            catch { }

        }
        private void FilterGeneratedInputs(string strLength, string strStartLetter, string strMinRank)
        {
            StopComputingJobsThreads();
            int Length = 0;
            int Letter1 = 0;
            int Letter2 = 0;
            int Letter3 = 0;
            int Letter4 = 0;
            int MinRank = 0;
            char StartChar = ' ';
            try
            {
                StartChar = Convert.ToChar(strStartLetter.Trim());
                GetFirstSecondThirdAndForthLetters(strStartLetter, ref Letter1, ref  Letter2, ref Letter3, ref Letter4);
                Length = Convert.ToInt32(strLength);
                MinRank = Convert.ToInt32(strMinRank);
               
            }
            catch {}

            if (IsAValidLength(Length))
            {
                    ShowGeneratedInputs(Length,MinRank , Letter1, Letter2, Letter3, Letter4);
            }
        }


        private void Generate(int Length, int StartLetter)
        {
            
        }

       
        

        private void tsBtnView_Click(object sender, EventArgs e)
        {
            SelectTransaction();
        }

        private void SelectTransaction()
        {
            StopComputingJobsThreads();
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                int Length = Convert.ToInt32(dgvTransactions.SelectedRows[0].Cells["length"].Value.ToString());
                char StartChar = Convert.ToChar(dgvTransactions.SelectedRows[0].Cells["start"].Value.ToString());
                int start = Abjad.MinorAbjadNumber(StartChar);
                ShowGeneratedInputs(Length, 0, start, 0, 0, 0);
            }
        }

        private void tsBtnViewG_Click(object sender, EventArgs e)
        {
            FilterGeneratedInputs(tstxtLengthG.Text, tstxtStartG.Text, tstxtMinRankG.Text);
        }

        
       

        //private void ShowGeneratedInputs(int Length, int FirstLetter)
        //{
        //    con.Open();
        //    if (FirstLetter > 0)
        //    {
        //        DA_GeneratedInputs.SelectCommand.Parameters[0].Value = Length.ToString();
        //        DA_GeneratedInputs.SelectCommand.Parameters[1].Value = Length.ToString();
        //    }
        //    else
        //    {
        //        DA_GeneratedInputs.SelectCommand.Parameters[0].Value = InputLengthArray[0].ToString();
        //        DA_GeneratedInputs.SelectCommand.Parameters[1].Value = InputLengthArray[InputLengthArray.Length - 1].ToString();
        //    }
        //    DataTable dt = new DataTable();
        //    DA_Transactions.Fill(dt);
        //    dgvTransactions.DataSource = dt;
        //    con.Close();
        //}


        private void Generate(string strLength, string strStart, bool Primary)
        {
            int Length = 0;
            int Letter1 = 0;
            int Letter2 = 0;
            int Letter3 = 0;
            int Letter4 = 0;
            char StartChar = ' ';
            try
            {               
                GetFirstSecondThirdAndForthLetters(strStart, ref Letter1, ref  Letter2, ref Letter3, ref Letter4);
                Length = Convert.ToInt32(strLength);
            }
            catch { }

            List<int> ListStart = new List<int>();

            if (IsAValidLength(Length))
            {
                Process(Length, Letter1,   Letter2,  Letter3,  Letter4, Primary);
            }                                
        
        }

        private DataTable SetOfFinishedTransactions(int Length, int Letter1, int  Letter2, int Letter3, int Letter4, bool Primary)
        {
            con.Open();
            DA_Transactions.SelectCommand.Parameters[0].Value = Length.ToString();
            DA_Transactions.SelectCommand.Parameters[1].Value = Length.ToString();
            int Method = 0;
            if (Primary) Method = 1; else Method = 2;

            DA_Transactions.SelectCommand.Parameters[2].Value = Method.ToString();
            if (Letter1 < 1 || Letter1 > 28)
            {
                DA_Transactions.SelectCommand.Parameters[3].Value = (1).ToString();
                DA_Transactions.SelectCommand.Parameters[4].Value = (28).ToString();
            }
            else
            {
                DA_Transactions.SelectCommand.Parameters[3].Value = Letter1.ToString();
                DA_Transactions.SelectCommand.Parameters[4].Value = Letter1.ToString();
            }
            if (Letter2 < 1 || Letter2 > 28)
            {
                DA_Transactions.SelectCommand.Parameters[5].Value = (1).ToString();
                DA_Transactions.SelectCommand.Parameters[6].Value = (28).ToString();
            }
            else
            {
                DA_Transactions.SelectCommand.Parameters[5].Value = Letter2.ToString();
                DA_Transactions.SelectCommand.Parameters[6].Value = Letter2.ToString();
            }
            if (Letter3 < 1 || Letter3 > 28)
            {
                DA_Transactions.SelectCommand.Parameters[7].Value = (1).ToString();
                DA_Transactions.SelectCommand.Parameters[8].Value = (28).ToString();
            }
            else
            {
                DA_Transactions.SelectCommand.Parameters[7].Value = Letter3.ToString();
                DA_Transactions.SelectCommand.Parameters[8].Value = Letter3.ToString();
            }
            if (Letter4 < 1 || Letter4 > 28)
            {
                DA_Transactions.SelectCommand.Parameters[9].Value = (1).ToString();
                DA_Transactions.SelectCommand.Parameters[10].Value = (28).ToString();
            }
            else
            {
                DA_Transactions.SelectCommand.Parameters[9].Value = Letter4.ToString();
                DA_Transactions.SelectCommand.Parameters[10].Value = Letter4.ToString();
            }

            DataTable dt = new DataTable();
            DA_Transactions.Fill(dt);            
            con.Close();
            return dt;        
        }


        private void Process(int Length, int Letter1,int Letter2, int Letter3, int Letter4, bool Primary)
        {
            if (Primary) PrimaryProcess(Length, Letter1, Letter2,  Letter3,  Letter4);
            else ComplementaryProcess(Length, Letter1, Letter2,  Letter3,  Letter4);
        }

        private List<int[]> SetOfNotFinishedTransactions(int Length, int Letter1, int Letter2, int Letter3, int Letter4, bool Primary)//OK
        {
            DataTable dt = SetOfFinishedTransactions(Length,  Letter1,   Letter2,  Letter3,  Letter4, Primary);
            List<int[]> AllStarts = new List<int[]>();
            List<int[]> result = new List<int[]>();
            if (Primary)
                AllStarts = AllBoddooh4By4Tables.GetAllFirstBoddooh4By4TablesStartingWithA(Letter1, Letter2, Letter3, Letter4);
            else
                AllStarts = ComplementaryInputManagement.GetAllQuadraplesStartingWithA(Letter1, Letter2, Letter3, Letter4);
            bool[, , ,] NotFinishedTransactions = new bool[28, 28, 28, 28];

            for (int i = 0; i <28; i++)
                for (int j = 0; j < 28; j++)
                    for (int k = 0; k < 28; k++)
                        for (int l = 0; l < 28; l++)
                            NotFinishedTransactions[i, j, k, l] = true;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int A = Convert.ToInt32(dt.Rows[i][1].ToString());
                int B = Convert.ToInt32(dt.Rows[i][2].ToString());
                int C = Convert.ToInt32(dt.Rows[i][3].ToString());
                int D = Convert.ToInt32(dt.Rows[i][4].ToString());
                NotFinishedTransactions[A - 1, B - 1, C - 1, D - 1] = false;
            }

            for (int i = 0; i < AllStarts.Count; i++)
            {
                int[] AStart = AllStarts[i];
                if (NotFinishedTransactions[AStart[0] - 1, AStart[1] - 1, AStart[2] - 1, AStart[3] - 1])
                {
                    int[] Temp = new int[4];
                    Temp[0] = AStart[0]; Temp[1] = AStart[1]; Temp[2] = AStart[2]; Temp[3] = AStart[3];
                    result.Add(Temp);
                }
            }
            return result;
        }


        private void StopComputingJobsThreads()
        {
            if (con.State == ConnectionState.Open) con.Close();
             if (BackgroundThreadsState == 0)
                return;

             if (BackgroundThread.ThreadState == ThreadState.Running)
                 BackgroundThread.Abort();
            
           
if (BackgroundThread.ThreadState != ThreadState.Stopped)
           {
               BackgroundThread.Abort();
           }
           for (int i = 0; i<ComputingJobsCount; i++)
           {
               ComputingJobs[i].Abort();
           }
           
           this.Cursor = Cursors.Default;
        }              


        private void PrimaryProcess(int Length, int Letter1, int  Letter2, int Letter3, int Letter4)
        {
            //List<int[]> AllStarts = SetOfNotFinishedTransactions(Length, StartLetter, true);
            //for (int i = 0; i < AllStarts.Count; i++)
            //{
            //    IntPentuple IP = new IntPentuple(Length, StartLetter, AllStarts[i][1], AllStarts[i][2], AllStarts[i][3]);
            //    PrimaryProcess(IP);
            //}
            //PrimaryProcess(12, 11, 10, 17, 8);








            ComputingJobs = new Thread[ComputingJobsCount];
            for (int i = 0; i < ComputingJobsCount; i++)
            {
                ParameterizedThreadStart start = new ParameterizedThreadStart(PrimaryProcess);
                ComputingJobs[i] = new Thread(start);

            }


            AllStarts = SetOfNotFinishedTransactions(Length,  Letter1,   Letter2,  Letter3,  Letter4, true);
            MaxProgressCount = AllStarts.Count;
            int TaskSize = AllStarts.Count / ComputingJobsCount;
            TaskSize++;
            BackgroundThreadsState = 1;
            for (int index = 0; index < ComputingJobsCount; index++)
            {
                int a = index * TaskSize;
                int b = Math.Min((index + 1) * TaskSize - 1, AllStarts.Count - 1);
                IntTriple IT = new IntTriple(Length, a, b);
                ComputingJobs[index].Start(IT);
            }
        }


        private void ComplementaryProcess(int Length, int Letter1, int  Letter2, int Letter3, int Letter4)
        {
            //VirtualCores = new Semaphore(ComputingJobsCount, ComputingJobsCount);
            //ComputingJobsInformation = new List<int[]>();
            //int[] Temp;
            //for (int i = 0; i < ComputingJobsCount; i++)
            //{
            //    Temp = new int[4]; Temp[0] = Temp[1] = Temp[2] = Temp[3] = -1;
            //    ComputingJobsInformation.Add(Temp);
            //}

            ComputingJobs = new Thread[ComputingJobsCount];
            for (int i = 0; i < ComputingJobsCount; i++)
            {
                ParameterizedThreadStart start = new ParameterizedThreadStart(ComplementaryProcess);
                ComputingJobs[i] = new Thread(start);

            }     

            AllStarts = SetOfNotFinishedTransactions(Length, Letter1,   Letter2,  Letter3,  Letter4, false);
            MaxProgressCount = AllStarts.Count;
            int TaskSize = AllStarts.Count / ComputingJobsCount;
            TaskSize++;
            BackgroundThreadsState = 1;
            for (int index = 0; index < ComputingJobsCount; index++)
            {
                int a = index * TaskSize;
                int b = Math.Min((index + 1) * TaskSize - 1, AllStarts.Count-1);
                IntTriple IT = new IntTriple(Length, a ,b);
                ComputingJobs[index].Start(IT);
            }

            //for (int i = 0; i < AllStarts.Count; i++)
            //{
                //mutex1.WaitOne();
                //int index = -1;
                //for (int j = 0; j < ComputingJobsCount; j++)
                //{
                //    int[] Temp1 = ComputingJobsInformation[j];
                //    if (Temp1[0] == -1 && Temp1[1] == -1 && Temp1[2] == -1 && Temp1[3] == -1)
                //    {
                //        index = j;
                //        ComputingJobsInformation[j][0] = StartLetter; ComputingJobsInformation[j][1] = AllStarts[i][1];
                //        ComputingJobsInformation[j][2] = AllStarts[i][2]; ComputingJobsInformation[j][3] = AllStarts[i][3];
                //        break;
                //    }
                //}
                //mutex1.ReleaseMutex();
                //ParameterizedThreadStart start = new ParameterizedThreadStart(ComplementaryProcess);
                //ComputingJobs[index] = new Thread(start);
                //IntPentuple IP = new IntPentuple(Length, StartLetter, AllStarts[i][1], AllStarts[i][2], AllStarts[i][3]);
               
                //ComplementaryProcess(IP);
                
                
            //}
        }

        private void PrimaryProcess(object InfoObject)

        {
            IntTriple IT = (IntTriple)InfoObject;
            int Length = IT.First;
            for (int index = IT.Second; index <= IT.Third; index++)
            {
                int A = AllStarts[index][0]; int B = AllStarts[index][1]; int C = AllStarts[index][2]; int D = AllStarts[index][3];

                InputManagement.DGV = dgvGeneratedInputs;
                InputManagement.GenerateAllInputs(Length, A, B, C, D);

                AddCompletedTransaction(Length, A, B, C, D, 1);
                ProgressCountMutex.WaitOne();
                ProgressCount++;

                ProgressCountMutex.ReleaseMutex();
                int v = (int)Math.Round(((float)(ProgressCount * 100)) / ((float)MaxProgressCount));
                if (0 <= v && v <= 100)
                {
                    RefreshProgressBar(v);
                }


            }





           // InputManagment.Initialize();

            //mutex1.WaitOne();
            //for (int j = 0; j < ComputingJobsCount; j++)
            //{
            //    int[] Temp1 = ComputingJobsInformation[j];
            //    if (Temp1[0] == A && Temp1[1] == B && Temp1[2] == C && Temp1[3] == D)
            //    {
            //        ComputingJobsInformation[j][0] = -1; ComputingJobsInformation[j][1] = -1;
            //        ComputingJobsInformation[j][2] = -1; ComputingJobsInformation[j][3] = -1;
            //        break;
            //    }
            //}
            //mutex1.ReleaseMutex();

            //VirtualCores.Release();


        }
        private void ComplementaryProcess(object InfoObject)
        {
            IntTriple IT = (IntTriple)InfoObject;
            int Length = IT.First;
            for (int index = IT.Second; index <= IT.Third; index++)
            {
                int A = AllStarts[index][0]; int B = AllStarts[index][1]; int C = AllStarts[index][2]; int D = AllStarts[index][3];
                List<int[]> Inputs = ComplementaryInputManagement.FindInputs(Length, A, B, C, D);
                for (int i = 0; i < Inputs.Count; i++)
                {
                    ProcessAGeneratedInput(Length, A, B, C, D, Inputs[i], 2);
                }
                AddCompletedTransaction(Length, A, B, C, D, 2);
                ProgressCountMutex.WaitOne();
                ProgressCount++;

                ProgressCountMutex.ReleaseMutex();
                    int v = (int)Math.Round(((float)(ProgressCount * 100)) / ((float)MaxProgressCount));
                    if (0 <= v && v <= 100)
                    {
                        RefreshProgressBar(v);
                    }
                

            }

            
        //   // ComplementaryInputManagement.DGV = dgvGeneratedInputs;

             //mutex1.WaitOne();
             //for (int j = 0; j < ComputingJobsCount; j++)
             //{
             //    int[] Temp1 = ComputingJobsInformation[j];
             //    if (Temp1[0] == A && Temp1[1] == B && Temp1[2] == C && Temp1[3] == D)
             //    {
             //        ComputingJobsInformation[j][0] = -1; ComputingJobsInformation[j][1] = -1; 
             //        ComputingJobsInformation[j][2] = -1; ComputingJobsInformation[j][3] = -1;
             //        break;
             //    }
             //}
             //mutex1.ReleaseMutex();

             //VirtualCores.Release();
            
        }

        private void FillLengthDropDownList()
        {
            tsddlLength.Items.Clear();
            for (int i = 8; i <= 28; i++)
                tsddlLength.Items.Add(i.ToString());
        }

        private void FormLoad()
        {
            FillLengthDropDownList();
            RefreshTransactionsState(0);
        }

        private void StartBackgroundThread(bool Primary)
        {
            MinRank = 0;
            try { MinRank = Convert.ToInt32(tstxtMinRankG.Text); }
            catch { }
            ProgressCount = 0;
            StopComputingJobsThreads();
            ProgressCountMutex = new Mutex();
            InputProcessMutex = new Mutex();
            this.Cursor = Cursors.WaitCursor;
            if (Primary)
                BackgroundThread = new Thread(new ThreadStart(PrimaryQuestionFindingProcess));
            else
                BackgroundThread = new Thread(new ThreadStart(ComplementaryQuestionFindingProcess));
            WriteLabel("در حال محاسبه ورودی ها ...");
            BackgroundThread.Start();
        }

        private void PrimaryQuestionFindingProcess()
        {
            InputManagement.Initialize(this);            
            Generate(tstxtLengthG.Text, tstxtStartG.Text, true);
            WriteLabel(FinishedString);
        }
        private void ComplementaryQuestionFindingProcess()
        {
            InputManagement.Initialize(this);
            ComplementaryInputManagement.Initialize(this);
            Generate(tstxtLengthG.Text, tstxtStartG.Text, false);
            WriteLabel(FinishedString);
        }

        public void ProcessAGeneratedInput(int Length, int A, int B, int C, int D, int[] InputArray, int Method)
        {
            try
            {
                InputProcessMutex.WaitOne();
                // DGV.Rows.Add();

                //  int index = DGV.Rows.Count - 1;
                string s = FormInputManagment.GetInputText(InputArray);
                //FormInputManagment.AddTextTolistIM(
                //LB.Items.Add(s);
                int Rank = GetRank(InputArray);

                if (Rank >= MinRank)
                {
                    InsertIfNotAlreadyInserted(Length, A, B, C, D, s, Rank, Method);

                    AddRowToDGV(s, Rank);
                }
                InputProcessMutex.ReleaseMutex();
            }
            catch { }

        }

        private delegate void stringDelegate2(string s);
        public void WriteLabel(string s)
        {
            return;
            if (lblStatus.InvokeRequired)
            {
                stringDelegate2 sd = new stringDelegate2(WriteLabel);
                this.Invoke(sd, new object[] { s });
            }
            else
            {
                lblStatus.Text = s;
            }
        } 

        private delegate void stringDelegate(string s, int rank);
        public void AddRowToDGV(string s, int rank)
        {
           
            if (dgvGeneratedInputs.InvokeRequired)
            {
                stringDelegate sd = new stringDelegate(AddRowToDGV);
                this.Invoke(sd, new object[] { s, rank });
            }
            else
            {
                dgvGeneratedInputs.Rows.Add();
                int index = dgvGeneratedInputs.Rows.Count - 1;
                dgvGeneratedInputs.Rows[index].Cells[1].Value = rank.ToString();
                dgvGeneratedInputs.Rows[index].Cells[0].Value = s;
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
                progressBar.Value = v;
            }
        }
        private void FormInputManagment_Load(object sender, EventArgs e)
        {
            BackgroundThreadsState = 0;
            FillLengthDropDownList();
            FormLoad();
        }
        private bool ValidLengthAndFirstLetter(int Length, int StartLetterMinor)
        {
            return false;
             //int index = MiscMethods.GetIndexOf(InputLengthArray,Length);
             //return (index >= 0 && StartLetterMinor >= 1 && StartLetterMinor <= 28);
        }

        private void tsBtnSelectInput_Click(object sender, EventArgs e)
        {
           
            ToggleInputSelected();
            FilterGeneratedInputs(tstxtLengthG.Text, tstxtStartG.Text, tstxtMinRankG.Text);
        }
        private void ToggleInputSelected()
        {
            StopComputingJobsThreads();
            if (dgvGeneratedInputs.SelectedRows.Count > 0)
            {
                string inputtext = dgvGeneratedInputs.SelectedRows[0].Cells["inputtext"].Value.ToString();
                string selected = dgvGeneratedInputs.SelectedRows[0].Cells["isselected"].Value.ToString();
                if (selected.Trim().Length == 0)
                    ToggleInputSelected(inputtext, false);
                else
                    ToggleInputSelected(inputtext, true);
            }
        }
        private void ToggleInputSelected(string inputtext, bool Selected)
        {
            con.Open();
            if (Selected)
                DA_GeneratedInputs.UpdateCommand.Parameters[0].Value = "";
            else
                DA_GeneratedInputs.UpdateCommand.Parameters[0].Value = InputSelected;
            DA_GeneratedInputs.UpdateCommand.Parameters[1].Value = inputtext;
            DA_GeneratedInputs.UpdateCommand.ExecuteNonQuery();
            con.Close();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
        {
            DialogResult Answer = MessageBox.Show("آیا می خواهید همه ورودی های ساخته شده را حذف کنید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
            if (Answer == DialogResult.Yes)
            {
                DeleteForInitialization();
                RefreshTransactionsState(0);
            }
    
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Random R = new Random(100);
            for (int ii = 0; ii < 1;)
            {
                int i = MiscMethods.EquivalentNumber( ((R.Next() + R.Next()) % 28) + 1);
                int L = InputManagement.GetLastLetter(i);
                int j = MiscMethods.EquivalentNumber( ((R.Next() + R.Next()) % 28) + 1);
                if (i != j && j!=L)
                {
                    int k = MiscMethods.EquivalentNumber( ((R.Next() + R.Next()) % 28) + 1);
                    if (i != k && k != j && k != L)
                    {
                        int l = MiscMethods.EquivalentNumber(((R.Next() + R.Next()) % 28) + 1);
                        if (i != l && l != j && k != l && l != L) 
                        {
                            List<int[]> A = InputManagement.GenerateAllInputs(12, i,j,k,l);
                            if (A.Count>0)
                            MessageBox.Show(A.Count.ToString());
                            ii++;
                        }
                        //for (int i = 1;i<=28;)
                    }
                    

                }

            }
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            //InputManagment.Initialize();
            List<int[]> All = new List<int[]>();

            for (int iii = 1; iii <= 1; iii++)
            {
               // List<int[]> L = 
                  ///  Process(12, 11);
                //if (L.Count > 0)
                 //   All.AddRange(L);
                //
            }
            for (int i = 0; i < All.Count; i++)
                MessageBox.Show(FormInputManagment.GetInputText(All[i]));
            //Process(12, 11, 10, 17, 8);
        }

       

        private void lblStatus_TextChanged(object sender, EventArgs e)
        {
            if (string.Compare(lblStatus.Text, FinishedString) == 0)
                this.Cursor = Cursors.Default;
        }

        private void tsBtnProcessInput_Click(object sender, EventArgs e)
        {
            StopComputingJobsThreads();
            if (BackgroundThreadsState == Started)
                StopGeneration();
            ProcessSeletedInput();
        }

        private void ProcessSeletedInput()
        {
            if (dgvGeneratedInputs.SelectedRows.Count > 0)
            {
                string input = dgvGeneratedInputs.SelectedRows[0].Cells[0].Value.ToString();
                OutputLabel.Text = input;
            }
            else
            {
                OutputLabel.Text = "";
            }
            this.Close();
        }

        private void tsBtnGenerateG1_Click(object sender, EventArgs e)
        {
            
            StartBackgroundThread(true);
        }

        private void tsBtnGenerateG2_Click(object sender, EventArgs e)
        {
            StartBackgroundThread(false);
        }
        

        private void tsBtnStopGeneration_Click(object sender, EventArgs e)
        {
            StopGeneration();
        }
        private void StopGeneration()
        {
            StopComputingJobsThreads();
           
        }

      

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tsddlLength_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tsddlLength.SelectedIndex >= 0)
            {
                int Length = Convert.ToInt32(tsddlLength.SelectedIndex)+8;
                RefreshTransactionsState(Length);
            }
            else
                RefreshTransactionsState(0);
            
        }

        private void tsddlLength_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnFilterTransactions_Click(object sender, EventArgs e)
        {
            tsddlLength_SelectedIndexChanged(null,null);
        }

        private void tsBtnDelete_Click(object sender, EventArgs e)
        {

            DeleteGeneratedInputs(tstxtLengthG.Text, tstxtStartG.Text, tstxtMaxRankG.Text);
        }
        private void DeleteGeneratedInputs(string strLength, string strStartLetter, string strMaxRank)
        {
            StopComputingJobsThreads();
            int Length = 0;
            int StartLetter = 0;
            int MaxRank = 0;
            char StartChar = ' ';
            try
            {
                StartChar = Convert.ToChar(strStartLetter.Trim());
                StartLetter = Abjad.MinorAbjadNumber(StartChar);
                Length = Convert.ToInt32(strLength);
                MaxRank = Convert.ToInt32(strMaxRank);
                
            }
            catch { }

            if (IsAValidLength(Length))
            {
                string s = "";
                if (MaxRank==0)
                {
                    s = "همه ورودی ها";
                }
                else
                {
                    s = "ورودی های با کمتر از " + MaxRank.ToString() + " امتیاز";
                }

                DialogResult Answer = MessageBox.Show("آیا می خواهید " +s+ " را از لیست حذف کنید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                if (Answer != DialogResult.Yes)
                    return;


                if (1 <= StartLetter && StartLetter <= 28)
                    DeleteGeneratedInputs(Length, StartLetter, MaxRank);
                else
                    DeleteGeneratedInputs(Length, 0, MaxRank);
            }
        }

        private void DeleteGeneratedInputs(int Length, int StartLetter, int MaxRank)
        {
            con.Open();
            DA_GeneratedInputs.DeleteCommand.Parameters[0].Value = Length.ToString();
            if (StartLetter < 1 || StartLetter > 28)
            {
                DA_GeneratedInputs.DeleteCommand.Parameters[1].Value = (1).ToString();
                DA_GeneratedInputs.DeleteCommand.Parameters[2].Value = (28).ToString();
            }
            else
            {
                DA_GeneratedInputs.DeleteCommand.Parameters[1].Value = StartLetter.ToString();
                DA_GeneratedInputs.DeleteCommand.Parameters[2].Value = StartLetter.ToString();
            }
            if (MaxRank == 0)
                DA_GeneratedInputs.DeleteCommand.Parameters[3].Value = (1000000).ToString();
            else
                DA_GeneratedInputs.DeleteCommand.Parameters[3].Value = MaxRank.ToString();

            DA_GeneratedInputs.DeleteCommand.ExecuteNonQuery();
            con.Close();
            tsBtnViewG_Click(null, null);
        }

        private void dgvTransactions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormInputManagment_FormClosing(object sender, FormClosingEventArgs e)
        {
           // MessageBox.Show("");
            StopComputingJobsThreads();
        }
       

        

       
    }
}
