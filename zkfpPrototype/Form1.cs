using System;
using System.Collections;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using libzkfpcsharp;
using Sample;

namespace zkfpPrototype
{
    public partial class Form1 : Form
    {
        readonly string datasource = @"DBSERV\SQL2K8";//server name
        readonly string database = "testScan"; //database name
        readonly string username = "fis"; //username
        readonly string password = "fis"; //password
        readonly string localDatabase = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\demo\\Desktop\\fingerprint Project\\test1\\zkfpPrototype\\Database1.mdf\";Integrated Security=True";
        //SqlConnection conn = new SqlConnection();

        private static ArrayList ListFpTemplate = new ArrayList();
        private static ArrayList ListId = new ArrayList();
        private static ArrayList ListTime = new ArrayList();
        private static ArrayList ListEmpId1 = new ArrayList();
        private static ArrayList ListEmpId = new ArrayList();
        private static ArrayList ListName = new ArrayList();
        private static ArrayList ListAllFpTemplate = new ArrayList();
        private static ArrayList ListAllId = new ArrayList();
        private static ArrayList ListAllTime = new ArrayList();
        private static ArrayList ListAllEmpId = new ArrayList();


        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;

        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        bool isExist = false;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];

        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        //int iFid = 1;
        int nCount; // Count connect device
        int zkfpErrOk = zkfperrdef.ZKFP_ERR_OK;// ZKDP_ERR_OK = 0, operation success
        private int mfpWidth = 0;
        private int mfpHeight = 0;
        private int mfpDpi = 0;
        const int MESSAGE_CAPTURED_OK = 0x0400 + 6;

        [DllImport("user32.dll", EntryPoint = "SendMessageA")]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            int ret = zkfpErrOk;
            if ((ret = zkfp2.Init()) == zkfpErrOk)
            {
                nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int index = 0; index < nCount; index++)
                    {
                        // Hold these indexes somewere
                        // It represents the index of the device you wish to connect to 
                        cmbIdx.Items.Add(index.ToString());
                    }
                    messageBox.AppendText($"\nInitialize success!");
                    cmbIdx.SelectedIndex = 0;
                    btnInit.Enabled = false;
                    btnOpen.Enabled = true;
                    btnClose.Enabled = true;
                    btnRegister.Enabled = true;
                }
                else
                {
                    zkfp2.Terminate();
                    messageBox.AppendText("No device connected!");
                }
            }
            else
            {
                messageBox.AppendText($"\nInitialize fail, Error Code= {ret}!");
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(cmbIdx.SelectedIndex)))
            {
                messageBox.AppendText($"\nOpen device fail!");
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                messageBox.AppendText("\nOpen device fail");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }

            RegisterCount = 0;
            cbRegTmp = 0;
            //iFid = 1;
            btnInit.Enabled = false;
            btnClose.Enabled = true;
            btnRegister.Enabled = true;
            btnMatch.Enabled = true;
            btnVerify.Enabled = true;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            //get reader capture image width and height
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            size = 4;
            zkfp2.GetParameters(mDevHandle, 3, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpDpi);

            
            messageBox.AppendText($"\nOpen Success!\nReader parameter, image width: {mfpWidth} height: {mfpHeight} dpi: {mfpDpi}");
            Thread captureThread = new Thread(new ThreadStart(StartCapture));
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            btnOpen.Enabled = false;
        }
        //[HandleProcessCorruptedStateExceptions]
        //[SecurityCritical]
        private void StartCapture()
        {
            while (!bIsTimeToDie)
            {
                try
                {
                    cbCapTmp = 2048;
                    int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);
                    if (ret == zkfpErrOk)
                    {
                        SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                    }
                }
                
                catch (Exception ex)
                {
                    messageBox.AppendText($"\nError message: {ex.Message}");
                    
                }
                finally
                {
                    Thread.Sleep(200);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            zkfp2.Terminate();
            int ret = zkfp2.DBFree(mDBHandle);
            if (zkfpErrOk == ret)
            {
                messageBox.AppendText($"\nAlgorithm cache is released.");
            }
            btnClose.Enabled = false;
            btnOpen.Enabled = false;
            btnInit.Enabled = true;
            btnRegister.Enabled = false;
            btnMatch.Enabled = false;
            btnVerify.Enabled = false;
            btnTerminate.Enabled = true;
            messageBox.AppendText($"\nDevice close");
        }

        private void BtnTerminate_Click(object sender, EventArgs e)
        {
            bIsTimeToDie = true;
            RegisterCount = 0;
            Thread.Sleep(1000);
            zkfp2.CloseDevice(mDevHandle);
            btnClose.Enabled = false;
            btnOpen.Enabled = false;
            btnInit.Enabled = true;
            System.Windows.Forms.Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
        }

        protected override void DefWndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case MESSAGE_CAPTURED_OK:
                    {
                        MemoryStream ms = new MemoryStream();
                        BitmapFormat.GetBitmap(FPBuffer, mfpWidth, mfpHeight, ref ms);
                        Bitmap bmp = new Bitmap(ms);
                        bmp.SetResolution(280, 280);
                        this.picFpImg.Image = bmp;
                        String strFp = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                        SqlConnection conn = new SqlConnection(localDatabase);
                        if (IsRegister)
                        {
                            RegistrationCase(strFp, conn);
                        }
                        else
                        {
                            VerificationCse(conn);
                        }
                        break;
                    }
                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string userId = tbUserInputId.Text;
            int empId = Int32.Parse(userId);
            if (userId == "")
            {
                messageBox.AppendText($"\nPlease enter your id!");
                return;
            }
            for(int i = 0; i < ListEmpId.Count; i++)
            {
                if (ListEmpId.Count == 0 && (int)ListEmpId[i] != empId)
                {
                    messageBox.AppendText($"\nPlease register your id and name at employee page!");
                    return;
                }
            }
            messageBox.AppendText("\nStart register");
            if (!IsRegister)
            {
                IsRegister = true;
                RegisterCount = 0;
                cbRegTmp = 0;
                messageBox.AppendText("\nPlease press your finger 3 times!");
            }
            
        }

        private void BtnMatch_Click(object sender, EventArgs e)
        {
            messageBox.AppendText("\nStart matching your fingerprint");
            IsRegister = false;
            if (bIdentify)
            {
                bIdentify = false;
                messageBox.AppendText("\nPlease press your finger!");
            }
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            messageBox.AppendText("\nStart verifying your fingerprint (1:N)");
            IsRegister = false;
            if (!bIdentify)
            {
                bIdentify = true;
                messageBox.AppendText("\nPlease press your finger!");
            }
        }

        private void RegistrationCase(string strFp, SqlConnection conn)
        {
            int ret = zkfpErrOk;
            conn.Open();
            ReadFpData(conn);
            ReadAllFpData(conn);
            for (int i = 0; i < ListAllFpTemplate.Count; i++)
            {
                RegTmp = Convert.FromBase64String(ListAllFpTemplate[i].ToString());
                ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                DateTime regTime = (DateTime)ListAllTime[i];
                if (0 < ret)
                {
                    if (ListEmpId.Contains(ListAllEmpId[i]))
                    {
                        messageBox.AppendText($"\nFingerprint Id: {ListAllId[i]}\nEmployee Id: {ListAllEmpId[i]}\nName: {ListName[(int)ListAllEmpId[i] - 1]}\nStatus: Registered\nScore: {ret}\nTime registered: {regTime:dd/MM/yyyy HH:mm:ss}");
                        return;
                    }
                }
                
            }
            if (ListId.Count == 10)
            {
                messageBox.AppendText($"Your fingerprint already finish registered");
                return;
            }
            if (ret == 0)
            { 
                messageBox.AppendText($"\nRegister success");
                fpData.Rows.Clear();
                conn.Open();
                try
                {
                    ReadFpData(conn);
                    SaveFpData(conn, strFp);
                    messageBox.AppendText($"\nDatabase update success");
                }
                catch (Exception ex)
                {
                    messageBox.AppendText($"\nSave data fail, Error message: {ex.Message}");
                }
            }
            IsRegister = false;
            return;
            
            /*int ret = zkfpErrOk;
            conn.Open();
            ReadFpData(conn);
            //Check fingerprint already register or not
            for (int i = 0; i < ListFpTemplate.Count; i++)
            {
                RegTmp = Convert.FromBase64String(ListFpTemplate[i].ToString());
                ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                DateTime regTime = (DateTime)ListTime[i];
                
                //for(int j = 0; i < ListFpTemplate.Count; j++)
                //{
                    if (0 < ret)
                    {
                        messageBox.AppendText($"\nFingerprint Id: {ListId[i]}\nEmployee Id: {ListEmpId1[i]}\nName: {ListName[i]}\nStatus: Registered\nScore: {ret}\nTime registered: {regTime:dd/MM/yyyy HH:mm:ss}");
                        return;
                    }
                    /*else
                        messageBox.AppendText($"\nFingerprint already by {ListName[i]}");
                        return;*//*
                //}
                
                if (ListId.Count > 10)
                {
                    messageBox.AppendText($"Your fingerprint already finish registered");
                    return;
                }
            }
            if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
            {
                messageBox.AppendText("\nPlease press the same finger 3 times for the registration.\n");
                return;
            }

            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
            //String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
            RegisterCount++;
            if (RegisterCount >= REGISTER_FINGER_COUNT)
            {
                RegisterCount = 0;
                if (zkfpErrOk == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)))
                {
                    //iFid++;
                    messageBox.AppendText($"\nRegister success");
                    //Array.Clear(RegTmp, 0, RegTmp.Length);
                    //Array.Clear(CapTmp, 0, CapTmp.Length);

                    // Save fingerprint template to local database
                    fpData.Rows.Clear();
                    string value = "SELECT COUNT(*) FROM Table_fp";
                    int count = 0;
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand(value, conn);
                    count = (int)myCommand.ExecuteScalar();
                    try
                    {
                        ReadFpData(conn);
                        SaveFpData(conn, strFp, count);
                        messageBox.AppendText($"\nDatabase update success");
                    }
                    catch (Exception ex)
                    {
                        messageBox.AppendText($"\nSave data fail, Error message: {ex.Message}");
                    }
                }
                else
                {
                    messageBox.AppendText($"\nRegister fail, error code= {ret}");
                }
                IsRegister = false;
                return;
            }
            else
            {
                messageBox.AppendText($"\nRemaining {REGISTER_FINGER_COUNT - RegisterCount} times fingerprint");
            }*/
        }

        private void VerificationCse(SqlConnection conn)
        {
            conn.Open();
            ReadFpData(conn);
            ReadEmpData(conn);
            int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
            string userId = tbUserInputId.Text;
            int empId = Int32.Parse(userId);
            for (int i = 0; i < ListFpTemplate.Count; i++)
            {
                RegTmp = Convert.FromBase64String(ListFpTemplate[i].ToString());
                ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                if (0 == ret)
                {
                    if (i == ListFpTemplate.Count - 1)
                        {
                            messageBox.AppendText($"\nFingerprint not found, Error code= {ret} !");
                            //return;
                        }
                }
                for(int j = 0; j < ListEmpId.Count; j++)
                {
                    if (0 < ret)
                    {
                        if (empId == (int)ListEmpId[j])
                            {
                                messageBox.AppendText($"\nFingerprint found, Name= {ListName[j]}, Score= {ret}, Register fingerprint= {ListFpTemplate.Count} !");
                                isExist = false;
                                return;
                            }
                        }
                    }
                    
                }
            
        }

        private void BtnConnectDb_Click(object sender, EventArgs e)
        {
            secondMessageBox.AppendText("\nConnecting...");
            // database connection string 
            string connString = $@"Data Source= {datasource};Initial Catalog=
                               {database};Persist Security Info=True;User ID= {username};Password= {password}";
            
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(localDatabase);
            
            //open connection
            try
            {
                conn.Open();
                secondMessageBox.AppendText("\nConnect successful");
                btnConnectDb.Enabled = false;
                btnDisconnect.Enabled = true;
                ReadFpData(conn);
                ReadAllFpData(conn);
                ReadEmpData(conn);
            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nDatabase connect fail, Error message: {ex.Message}");
            }
        }

        private void ReadFpData(SqlConnection conn)
        {
            //conn.Open();
            string userId = tbUserInputId.Text;
            int empId = Int32.Parse(userId);
            string fp = $"select * from Table_fp where emp_id = {empId}";
            SqlCommand fpCommand = new SqlCommand(fp, conn);
            SqlDataReader fpReader = fpCommand.ExecuteReader();
            
            ListId.Clear();
            ListFpTemplate.Clear();
            ListTime.Clear();
            ListEmpId1.Clear();
            while (fpReader.Read())
            {
                ListId.Add(fpReader["Id"]);
                ListFpTemplate.Add(fpReader["fp_template"]);
                ListTime.Add(fpReader["time_registered"]);
                ListEmpId1.Add(fpReader["emp_id"]);
               
            }
            labelNumOfFp.Text = $"Number of fingerprint registered: {ListFpTemplate.Count}";
            conn.Close();
        }

        private void ReadAllFpData(SqlConnection conn)
        {
            conn.Open();
            string userId = tbUserInputId.Text;
            int empId = Int32.Parse(userId);
            string fp = $"select * from Table_fp";
            SqlCommand fpCommand = new SqlCommand(fp, conn);
            SqlDataReader fpReader = fpCommand.ExecuteReader();
            fpData.Rows.Clear();
            /*ListAllId.Clear();
            ListAllFpTemplate.Clear();
            ListAllTime.Clear();
            ListAllEmpId1.Clear();
            */while (fpReader.Read())
            {
                DataGridViewRow newRow = new DataGridViewRow();
                newRow.CreateCells(fpData);
                newRow.Cells[0].Value = fpReader["Id"];
                newRow.Cells[1].Value = fpReader["fp_template"];
                newRow.Cells[2].Value = fpReader["time_registered"];
                newRow.Cells[3].Value = fpReader["emp_id"];
                ListAllId.Add(fpReader["Id"]);
                ListAllFpTemplate.Add(fpReader["fp_template"]);
                ListAllTime.Add(fpReader["time_registered"]);
                ListAllEmpId.Add(fpReader["emp_id"]);
                fpData.Rows.Add(newRow);
            }
            labelNumOfFp.Text = $"Number of fingerprint registered: {ListFpTemplate.Count}";
            conn.Close();
        }

        private void ReadEmpData(SqlConnection conn)
        {
            conn.Open();
            SqlCommand empComm = new SqlCommand("select * from Table_employee", conn);
            SqlDataReader empReader = empComm.ExecuteReader();
            empData.Rows.Clear();
            ListEmpId.Clear();
            ListName.Clear();
            while (empReader.Read())
            {
                DataGridViewRow empRow = new DataGridViewRow();
                empRow.CreateCells(empData);
                empRow.Cells[0].Value = empReader["Id"];
                empRow.Cells[1].Value = empReader["emp_name"];
                ListEmpId.Add(empReader["Id"]);
                ListName.Add(empReader["emp_name"]);
                empData.Rows.Add(empRow);
            }
            conn.Close();
        }

        private void BtnAddEmp_Click(object sender, EventArgs e)
        {
            var myForm = new Form3();
            myForm.Show();
            
        }

        
        private void SaveFpData(SqlConnection conn, string strFp)
        {
            conn.Open();
            int id = ListFpTemplate.Count + 1;
            string userId = tbUserInputId.Text;
            int empId = Int32.Parse(userId);
            string query = "INSERT INTO Table_fp (Id, fp_template, time_registered, emp_id)";
            query += " VALUES (@Id, @fp_template, @time_registered, @emp_id)";
            DateTime currentTime = DateTime.Now;
            try
            {
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.Parameters.AddWithValue("@Id", id);
                myCommand.Parameters.AddWithValue("@fp_template", strFp);
                myCommand.Parameters.AddWithValue("@time_registered", currentTime);
                myCommand.Parameters.AddWithValue("@emp_id", empId);
                myCommand.ExecuteNonQuery();
                labelNumOfFp.Text = $"Number of fingerprint registered: {id}";
                
            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nError message: {ex.Message}");
            }
            finally
            {
                conn.Close();
                ReadAllFpData(conn);
            }
        }

        private void BtnDisconnect_Click(object sender, EventArgs e)
        {
            //conn.Close();
            secondMessageBox.AppendText($"\nDatabase disconnect");
            btnConnectDb.Enabled = true;
            btnDisconnect.Enabled = false;
        }

        private void BtnTestConnection_Click(object sender, EventArgs e)
        {
            secondMessageBox.AppendText("\nConnecting...");
            string datasource = tbDataSource.Text;//server name
            string dbName = tbDbName.Text; //database name
            string username = tbUserName.Text; //username
            string password = tbPassword.Text; //password
            string connString = $@"Data Source= {datasource};Initial Catalog=
                               {dbName};Persist Security Info=True;User ID= {username};Password= {password}";
            SqlConnection conn = new SqlConnection(connString);
            try
            {
                conn.Open();
                secondMessageBox.AppendText("\nConnect successful");
                tbDataSource.Enabled = false;
                tbDbName.Enabled = false;
                tbUserName.Enabled = false;
                tbPassword.Enabled = false;

            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nDatabase connect fail, Error message: {ex.Message}");
            }
            conn.Close();
        }

        private void messageBox_TextChanged(object sender, EventArgs e)
        {
            messageBox.SelectionStart = messageBox.Text.Length;
            messageBox.ScrollToCaret();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(localDatabase);
            string empName = tbName.Text;
            string id = tbId.Text;
            int empId = Int32.Parse(id);
            string query = "INSERT INTO Table_employee (Id, emp_name)";
            query += " VALUES (@Id, @emp_name)";
            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.Parameters.AddWithValue("@Id", empId);
                myCommand.Parameters.AddWithValue("@emp_name", empName);
                myCommand.ExecuteNonQuery();
                secondMessageBox.AppendText($"\nRegister success\nEmployee Id: {id}\nEmployee Name: {empName}");
                
            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nError message: {ex.Message}");
            }
            finally
            {
                conn.Close();
                ReadEmpData(conn);
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tbId.Text = "";
            tbName.Text = "";
        }
    }  
}
