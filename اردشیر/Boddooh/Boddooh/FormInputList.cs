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

namespace Boddooh
{
    
    public partial class FormInputList : Form
    {

        public static int PartLength = 255;
        
        string Mode;
        int iid;

        
        public TextBox OutputTextBox;
        public FormInputList()
        {
            InitializeComponent();
        }

        private void FormInputList_Load(object sender, EventArgs e)
        {
            RefreshForm();            
        }
        private void toolStripButtonNew_Click(object sender, EventArgs e)
        {
            txtInputText.Clear();
            groupBoxInputList.Enabled = false;
            groupBoxInputText.Enabled = true;
            Mode = "new";
            ShowInputText();
        }

        private void ShowInputText()
        {
            if (Mode == "edit" || Mode == "view")
                FillForm();
            txtInputText.Enabled = (Mode != "view");
            txtInputText.Select();
        }

        private void toolStripButtonView_Click(object sender, EventArgs e)
        {
            ShowSelectedInput();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (dataGridViewInputList.SelectedRows.Count > 0)
                id = Convert.ToInt32(dataGridViewInputList.SelectedRows[0].Cells["id"].Value);
           
            iid = id;
            if (iid > 0)
            {                
                groupBoxInputList.Enabled = false;
                groupBoxInputText.Enabled = true;
                Mode = "edit";
                ShowInputText();
            }
        }

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (dataGridViewInputList.SelectedRows.Count > 0)
                id = Convert.ToInt32(dataGridViewInputList.SelectedRows[0].Cells["id"].Value.ToString());
            if (id>0)
            {
                DialogResult Answer = MessageBox.Show("آیا می خواهید ورودی انتخاب شده را از لیست حذف کنید؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1);
                if (Answer==DialogResult.Yes )
                    Delete(id);
            }
            RefreshForm();
        }
        private void Delete(int id)
        {
            try
            {
                con.Open();
                da.DeleteCommand.Parameters[0].Value = id.ToString();
                da.DeleteCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private DataTable FormatDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn DC1 =  new DataColumn("Text");
            DataColumn DC2 =  new DataColumn("WOD");
            DataColumn DC3 =  new DataColumn("WD");
            dt.Columns.Add(DC1);
            dt.Columns.Add(DC2);
            dt.Columns.Add(DC3);
            return dt;
        }

        private void RefreshForm()
        {            
            try
            {
                DataTable dt = new DataTable();
                con.Open();
                da.Fill(dt);    
                con.Close();
                dataGridViewInputList.Rows.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataGridViewInputList.Rows.Add();
                    dataGridViewInputList.Rows[i].Cells[0].Value = dt.Rows[i][0].ToString();
                    dataGridViewInputList.Rows[i].Cells[2].Value = dt.Rows[i][1].ToString();
                    dataGridViewInputList.Rows[i].Cells[3].Value = dt.Rows[i][2].ToString();

                    string s = "";
                    for (int ii = 0; ii < 20; ii++)
                        s += dt.Rows[i][3+ii].ToString()  ;
   

                    dataGridViewInputList.Rows[i].Cells[1].Value = s;
                }
                dataGridViewInputList.Columns[1].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }




       

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Done();
        }

        private void Done()
        {
            txtInputText.Text = "";
            groupBoxInputText.Enabled = false;
            groupBoxInputList .Enabled = true;
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            string InputText = txtInputText.Text.Trim();
            InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            string Temp = MiscMethods.RemoveDelimiters(InputText);
            if (Abjad.ContainsNonAlphabet(Temp) || Abjad.ContainsNonAbjabAlphabet(Temp))
                return;
            if (InputText.Length == 0)
                return;

            if (Mode == "new")
                New();
            if (Mode == "edit")
                Edit();

            Done();
            RefreshForm();
        }


        public static ArrayList ReadInputsFromFile()
        {
            ArrayList result = new ArrayList();
            try
            {
                //InputFile IF = new InputFile(FileName);
                //IF.Open();
                //bool Done = false;                
                //while (!Done)
                //{
                //    string InputText = IF.ReadLine();
                //    if (InputText != null)
                //    {
                //        result.Add(InputText);
                //    }
                //    else
                //    {
                //        Done = true;
                //    }                    
                //}

                //IF.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;

        }

        public void WriteInputsToFile(ArrayList Inputs)
        {
            try
            {
                //OutputFile OF = new OutputFile(FileName);
                //OF.Open();
                //for (int i = 0; i < Inputs.Count ; i++)
                //{
                //    string InputText = (string)Inputs[i];
                //    OF.WriteLine(InputText);
                //}

                //OF.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Insert(string input)
        {
            int LengthWD = 0, LengthWoDFBSTM = 0, LengthWoDFRTL = 0, MinorASWD = 0, MinorASWoDFBSTM = 0, MinorASWoDFRTL;
            string InputText = input;
            InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            string InputTextWD = MiscMethods.RemoveDelimiters(InputText);

            if (InputTextWD.Length == 0)
            {
                return;
            }
            if (Abjad.ContainsNonAlphabet(InputTextWD))
            {
                return;
            }
            if (Abjad.ContainsNonAbjabAlphabet(InputTextWD))
            {
                return;
            }
            string InputTextWoDFBSTM = Boddooh.OmitDuplicateLetters(InputTextWD, true);
            string InputTextWoDFRTL = Boddooh.OmitDuplicateLetters(InputTextWD, false);
            LengthWD = InputTextWD.Length;
            LengthWoDFBSTM = InputTextWoDFBSTM.Length;
            LengthWoDFRTL = InputTextWoDFRTL.Length;
            MinorASWD = Abjad.MinorAbjadSummation(InputTextWD);
            MinorASWoDFBSTM = Abjad.MinorAbjadSummation(InputTextWoDFBSTM);
            MinorASWoDFRTL = Abjad.MinorAbjadSummation(InputTextWoDFRTL);

          //  OleDbConnection con = new OleDbConnection(ConnectionString);

            string WoDFBSTM = LengthWoDFBSTM.ToString() + " " + "حرف، جمع : " + MinorASWoDFBSTM.ToString();
            string WoDFRTL = LengthWoDFRTL.ToString() + " " + "حرف، جمع : " + MinorASWoDFRTL.ToString();
            string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString();


            //OleDbCommand com;
            //int newid = new_id();
            //com = new OleDbCommand("insert into Inputs Values(?,?,?,?)", con);
            ////com.Parameters.Add("@id", newid);
            //com.Parameters.Add("@wod", WoD);
            //com.Parameters.Add("@wd", WD);

            //com.Parameters.Add("@it", input);
            try
            {
                con.Open();
                da.InsertCommand.Parameters[0].Value = id.ToString();
                da.InsertCommand.Parameters[0].Value = id.ToString();
                da.InsertCommand.Parameters[0].Value = id.ToString();
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("ورودی مربوطه با موفقیت ذخیره شد.", "ذخیره ورودی", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        private void FillForm()
        {
            try
            {             
                con.Open();
                da3.SelectCommand.Parameters[0].Value = iid.ToString();
                OleDbDataReader dr = da3.SelectCommand.ExecuteReader();
                if (dr.Read())
                {

                    string s = "";
                    for (int i = 0; i < 20; i++)
                        s += dr[3 + i].ToString();
                    txtInputText.Text = s;
                    
                }
                
                dr.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        

        private void New()
        {
            int LengthWD = 0, LengthWoD = 0, MinorASWD = 0, MinorASWoD = 0;
            string InputTextWD="", InputTextWoDFRTL="", InputTextWoDFBSTM="";
            RefreshInputStatus(ref LengthWD, ref LengthWoD, ref MinorASWD, ref MinorASWoD, ref InputTextWD, ref InputTextWoDFRTL, ref InputTextWoDFBSTM);

            string WoD = LengthWoD.ToString() + " " + "حرف، جمع : " + MinorASWoD.ToString() 
                                + " " + "، امتیاز با حذف از راست: " + FormInputManagment.GetRank(InputTextWoDFRTL).ToString() +" " + " طرفین: " + FormInputManagment.GetRank(InputTextWoDFBSTM).ToString();

            string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString()
                + " " + "، امتیاز: " + FormInputManagment.GetRank(InputTextWD).ToString();
            //string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string s = txtInputText.Text.Trim();
            if (s.Length>1000)
            s = MiscMethods.RemoveDelimiters(s);
           string[] S_Array = MiscMethods. TrimAndSplitStringIntoParts(s, 20);


            iid = new_id();
            da.InsertCommand.Parameters[0].Value = iid.ToString();
            da.InsertCommand.Parameters[1].Value = WD;
            da.InsertCommand.Parameters[2].Value = WoD;

            for (int i = 0; i < S_Array.Length; i++)
                da.InsertCommand.Parameters[3+i].Value = S_Array[i];
            //MessageBox.Show(s1.Length.ToString()); MessageBox.Show(s2.Length.ToString()); MessageBox.Show(s3.Length.ToString()); MessageBox.Show(s4.Length.ToString());
            //MessageBox.Show(s5.Length.ToString()); MessageBox.Show(s6.Length.ToString()); MessageBox.Show(s7.Length.ToString()); MessageBox.Show(s8.Length.ToString());
            try
            {
                con.Open();
                da.InsertCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Edit()
        {
            int LengthWD = 0, LengthWoD = 0, MinorASWD = 0, MinorASWoD = 0;


            string InputTextWD = "", InputTextWoDFRTL = "", InputTextWoDFBSTM = "";
            RefreshInputStatus(ref LengthWD, ref LengthWoD, ref MinorASWD, ref MinorASWoD, ref InputTextWD, ref InputTextWoDFRTL, ref InputTextWoDFBSTM);

            string WoD = LengthWoD.ToString() + " " + "حرف، جمع : " + MinorASWoD.ToString()
                                + " " + "، امتیاز با حذف از راست: " + FormInputManagment.GetRank(InputTextWoDFRTL).ToString() + " " + " طرفین: " + FormInputManagment.GetRank(InputTextWoDFBSTM).ToString();

            string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString()
                + " " + "، امتیاز: " + FormInputManagment.GetRank(InputTextWD).ToString();

            //string s1 = ""; string s2 = ""; string s3 = ""; string s4 = ""; string s5 = ""; string s6 = ""; string s7 = ""; string s8 = "";
            string s = txtInputText.Text.Trim();

            if (s.Length > 1000)
                s = MiscMethods.RemoveDelimiters(s);

            string[] S_Array= MiscMethods. TrimAndSplitStringIntoParts(s, 20);

            da.UpdateCommand.Parameters[0].Value = WD;
            da.UpdateCommand.Parameters[1].Value = WoD;
            for (int i = 0; i < S_Array.Length; i++)
                da.UpdateCommand.Parameters[2 + i].Value = S_Array[i];

            da.UpdateCommand.Parameters[2 + S_Array.Length].Value = iid.ToString();

            try
            {
                con.Open();
                da.UpdateCommand.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

          
            //string WoD = LengthWoD.ToString() + " " + "حرف، جمع : " + MinorASWoD.ToString();
            //string WD = LengthWD.ToString() + " " + "حرف، جمع : " + MinorASWD.ToString();


            //OleDbCommand com;
            //int newid = new_id();
            //com = new OleDbCommand("insert into Inputs Values(?,?,?,?)", con);
            //com.Parameters.Add("@id", newid);
            //com.Parameters.Add("@wod", WoD);
            //com.Parameters.Add("@wd", WD);

            //com.Parameters.Add("@it", input);
            //try
            //{
            //    con.Open();
            //    com.ExecuteNonQuery();
            //    con.Close();
            //    MessageBox.Show("ورودی مربوطه با موفقیت ذخیره شد.", "ذخیره ورودی", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

     

        private void dataGridViewContactsList_SelectionChanged(object sender, EventArgs e)
        {
            Done();
        }

        private void toolStripButtonSelect_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void Select()
        {
            string InputText = "";
            if (dataGridViewInputList.SelectedRows.Count > 0)
                InputText = dataGridViewInputList.SelectedRows[0].Cells["InputText"].Value.ToString();
            if (chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Checked)
                InputText = Boddooh.OmitDuplicateLetters(InputText, false);
            if (chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Checked)
                InputText = Boddooh.OmitDuplicateLetters(InputText, true);

            OutputTextBox.Text = InputText;// MiscMethods.PutOneSpaceBetweenAdjacentLetters(); 
            this.Close();
        }

        private void dataGridViewInputList_DoubleClick(object sender, EventArgs e)
        {
            Select();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtInputText_TextChanged(object sender, EventArgs e)
        {
            int LengthWD = 0, LengthWoD = 0, MinorASWD = 0, MinorASWoD = 0;
            int RankWD = 0, RankWoDFRTL = 0, RankWoDFBSTM = 0;
            lblLengthWODFRTL.Text = "";
            lblLengthWODFBSTM.Text = "";
            lblLengthWD.Text = "";
            
            lblMinorASWODFRTL.Text = "";
            lblMinorASWODFBSTM.Text = "";
            lblMinorASWD.Text = "";
            
           
            int MinorASWoDFBSTM = 0, MinorASWoDFRTL = 0;
            string InputTextWD = "", InputTextWoDFRTL = "", InputTextWoDFBSTM = "";

            RefreshInputStatus(ref LengthWD, ref LengthWoD, ref MinorASWD, ref MinorASWoD, ref InputTextWD, ref InputTextWoDFRTL, ref InputTextWoDFBSTM);

            if (LengthWD == 0 || LengthWoD == 0 || MinorASWD == 0 || MinorASWoD == 0)
                return;
            lblLengthWD.Text = Convert.ToString(LengthWD);
            lblLengthWODFBSTM.Text = lblLengthWODFRTL.Text = Convert.ToString(LengthWoD);
            lblMinorASWD.Text = Convert.ToString(MinorASWD);
            lblMinorASWD.Text += (" " + "= K28");
            if (MinorASWD % BoddoohNumbers.TwentyEight >0)
                lblMinorASWD.Text += (" + " + (MinorASWD % BoddoohNumbers.TwentyEight).ToString());
            

            lblMinorASWODFRTL.Text = Convert.ToString(MinorASWoD);
            lblMinorASWODFRTL.Text += (" " + "= K28");
            if (MinorASWoD % BoddoohNumbers.TwentyEight > 0)
                lblMinorASWODFRTL.Text += (" + " + (MinorASWoD % BoddoohNumbers.TwentyEight).ToString());
            lblMinorASWODFBSTM.Text = lblMinorASWODFRTL.Text;

            lblRankWD.Text = FormInputManagment.GetRank(InputTextWD).ToString();
            lblRankWODFRTL.Text = FormInputManagment.GetRank(InputTextWoDFRTL).ToString();
            lblRankWODFBSTM.Text = FormInputManagment.GetRank(InputTextWoDFBSTM).ToString();



        }
        private bool RefreshInputStatus(ref int LengthWD, ref int LengthWoD, ref int MinorASWD, ref int MinorASWoD, ref string InputTextWD, ref string InputTextWoDFRTL, ref string InputTextWoDFBSTM)
        {
            LengthWD = LengthWoD = MinorASWD = MinorASWoD = 0;
            string InputText =  txtInputText.Text;
            InputText = MiscMethods.NormalizePersianString(InputText.Trim());
            InputTextWD = MiscMethods.RemoveDelimiters(InputText);

            if (InputTextWD.Length == 0)
            {
                txtInputText.Focus();
                return false;
            }
            if (Abjad.ContainsNonAlphabet(InputTextWD))
            {
                txtInputText.Focus();
                return false;
            }
            if (Abjad.ContainsNonAbjabAlphabet(InputTextWD))
            {
                txtInputText.Focus();
                return false;
            }
             InputTextWoDFRTL = Boddooh.OmitDuplicateLetters(InputTextWD, false);
             InputTextWoDFBSTM = Boddooh.OmitDuplicateLetters(InputTextWD, true);
            LengthWD = InputTextWD.Length;
            LengthWoD = InputTextWoDFRTL.Length;
            MinorASWD = Abjad.MinorAbjadSummation(InputTextWD);
            MinorASWoD = Abjad.MinorAbjadSummation(InputTextWoDFRTL);            
            return true;

        }

        private void ShowSelectedInput()
        {
            int id = 0;
            if (dataGridViewInputList.SelectedRows.Count > 0)
                id = Convert.ToInt32(dataGridViewInputList.SelectedRows[0].Cells["id"].Value);

            iid = id;
            if (iid > 0)
            {
                Mode = "view";
                ShowInputText();
            }
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

        public static string WODFBSTMString(string InputText)
        {
            int LengthWODFBSTM = 0, MinorASWODFBSTM = 0;
            string WODFBSTM = InputText;
            WODFBSTM = MiscMethods.NormalizePersianString(WODFBSTM.Trim());
            WODFBSTM = MiscMethods.RemoveDelimiters(WODFBSTM);
            WODFBSTM = Boddooh.OmitDuplicateLetters(WODFBSTM, true);
            LengthWODFBSTM = WODFBSTM.Length;
            MinorASWODFBSTM = Abjad.MinorAbjadSummation(WODFBSTM);
            string Result = LengthWODFBSTM.ToString() + " " + "حرف، جمع : " + MinorASWODFBSTM.ToString() + " " + "= K28";
            if (MinorASWODFBSTM % BoddoohNumbers.TwentyEight > 0)
                Result += (" + " + (MinorASWODFBSTM % BoddoohNumbers.TwentyEight).ToString());
            return Result;
        }
        public static string WODFRTLString(string InputText)
        {
            int LengthWODFRTL = 0, MinorASWODFRTL = 0;
            string WODFRTL = InputText;
            WODFRTL = MiscMethods.NormalizePersianString(WODFRTL.Trim());
            WODFRTL = MiscMethods.RemoveDelimiters(WODFRTL);
            WODFRTL = Boddooh.OmitDuplicateLetters(WODFRTL, false);
            LengthWODFRTL = WODFRTL.Length;
            MinorASWODFRTL = Abjad.MinorAbjadSummation(WODFRTL);
            string Result = LengthWODFRTL.ToString() + " " + "حرف، جمع : " + MinorASWODFRTL.ToString() + " " + "= K28";
            if (MinorASWODFRTL % BoddoohNumbers.TwentyEight > 0)
                Result += (" + " + (MinorASWODFRTL % BoddoohNumbers.TwentyEight).ToString());
            return Result;
        }

       

        private void dataGridViewInputList_KeyPress(object sender, KeyPressEventArgs e)
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
                toolStripButtonDelete_Click(null, null);
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
                toolStripButtonDelete_Click(null, null);
            }
            e.Handled = true;
        }

        private void dataGridViewInputList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //InputGeneration .GenerateInputs(6, 2, listBox1);
        }

        private int new_id()
        {
            int id = 0;
            OleDbDataReader dr;
            try
            {
                con.Open();                
                dr = da2.SelectCommand.ExecuteReader();
                try
                {
                    if (dr.Read())
                        id = Convert.ToInt32(dr["maxid"]) + 1;
                    else id = 1;
                }
                catch (Exception ex)
                {
                    id = 1;
                }

                dr.Close();
                con.Close();
                return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
        }

        private void chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Checked)
                chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Checked = false;
        }

        private void chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDoOmitDuplicateLettersFromBothSidesToMiddleBeforeSelect.Checked)
                chkDoOmitDuplicateLettersFromRightToLeftBeforeSelect.Checked = false;

        }

       

        

    }
}
