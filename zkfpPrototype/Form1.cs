using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BioMetrixCore;
using libzkfpcsharp;
using Sample;
using zkemkeeper;

namespace zkfpPrototype
{
    public partial class Form1 : Form
    {
        CZKEM objCZKEM = new CZKEM();
        public ZkemClient objZkeeper = new ZkemClient();
        DeviceManipulator manipulator = new DeviceManipulator();
        readonly string datasource = @"DBSERV\SQL2K8";//server name
        readonly string database = "testScan"; //database name
        readonly string username = "fis"; //username
        readonly string password = "fis"; //password
        readonly string localDatabase = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\demo\\Desktop\\fingerprint Project\\test1\\zkfpPrototype\\Database1.mdf\";Integrated Security=True";
        readonly int machineNumber = 1;

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

        private static List<int> ListAllDeviceEmpId = new List<int>();
        private static List<int> ListAllDeviceFpId = new List<int>();
        private static List<string> ListAllDeviceTmp = new List<string>();
        private static List<string> ListAllDeviceUserName = new List<string>(); 

        HashSet<int> results = new HashSet<int>();

        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;

        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        bool isExist = true;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];

        int cbCapTmp = 2048;
        int cbRegTmp = 0;
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
                    
                }
                else
                {
                    zkfp2.Terminate();
                    messageBox.AppendText($"\nNo device connected!");
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
            Application.Exit();
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
            int empId = Convert.ToInt32(userId);
            SqlConnection conn = new SqlConnection(localDatabase);
            conn.Open();
            ReadFpData(conn);
            if (userId == "")
            {
                messageBox.AppendText($"\nPlease enter your id!");
                return;
            }
            if (!ListEmpId.Contains(empId))
            {
                messageBox.AppendText($"\nPlease register your id and name at employee page!");
                return;
            }
            
            if (ListId.Count == 10)
            {
                messageBox.AppendText($"\nYour fingerprint already finish registered");
                return;
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
                string comm = $"select * from Table_employee where Id = {ListAllEmpId[i]}";
                conn.Open();
                SqlCommand selectName = new SqlCommand(comm, conn);
                SqlDataReader nameReader = selectName.ExecuteReader();
                if (0 < ret)
                {
                    if (ListEmpId.Contains(ListAllEmpId[i]))
                    {
                        while (nameReader.Read())
                        {
                            if (Convert.ToInt32(nameReader["Id"]) == Convert.ToInt32(ListAllEmpId[i]))
                            {
                                messageBox.AppendText($"\nFingerprint Id: {ListAllId[i]}\nEmployee Id: {ListAllEmpId[i]}\nName: {nameReader["emp_name"]}\nStatus: Registered\nScore: {ret}\nTime registered: {regTime:dd/MM/yyyy HH:mm:ss}");
                                return;
                            }

                        }

                    }
                }
                conn.Close();
            }
            if (ListId.Count == 10)
            {
                messageBox.AppendText($"\nYour fingerprint already finish registered");
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
                    labelNumOfFp.Text = $"Number of fingerprint registered: {ListFpTemplate.Count + 1}";

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
                    //else
                        //messageBox.AppendText($"\nFingerprint already by {ListName[i]}");
                        //return;
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
            int empId = Convert.ToInt32(userId);
            if (ListFpTemplate.Count == 0)
            {
                messageBox.AppendText($"\nNo fingerprint in the database.");
                return;
            }
            for (int i = 0; i < ListFpTemplate.Count; i++)
            {
                RegTmp = Convert.FromBase64String(ListFpTemplate[i].ToString());
                ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                if (0 == ret)
                {
                    if (i == ListFpTemplate.Count - 1)
                        {
                            messageBox.AppendText($"\nFingerprint not found, Error code= {ret} !");
                        }
                }
                for(int j = 0; j < ListEmpId.Count; j++)
                {
                    if (0 < ret)
                    {
                        if (empId == (int)ListEmpId[j])
                            {
                                messageBox.AppendText($"\nFingerprint found, Name= {ListName[j]}, Score= {ret}, Registered fingerprint= {ListFpTemplate.Count} !");
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
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(localDatabase);
            try
            {
                conn.Open();
                secondMessageBox.AppendText("\nConnect successful");
                btnConnectDb.Enabled = false;
                btnDisconnect.Enabled = true;
                fpData.Visible = true;
                empData.Visible = true;
                cmbDeleteItem.Items.Clear();
                conn.Close();
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
            //labelNumOfFp.Text = $"Number of fingerprint registered: {ListFpTemplate.Count}";
            conn.Close();
        }

        private void ReadAllFpData(SqlConnection conn)
        {
            conn.Open();
            string fp = $"select * from Table_fp";
            SqlCommand fpCommand = new SqlCommand(fp, conn);
            SqlDataReader fpReader = fpCommand.ExecuteReader();
            fpData.Rows.Clear();
            while (fpReader.Read())
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
                cmbDeleteItem.Items.Clear();
                foreach (int num in ListAllEmpId)
                {
                    if (!cmbDeleteItem.Items.Contains(num))
                    {
                        cmbDeleteItem.Items.Add(num);
                    }
                }
                
                fpData.Rows.Add(newRow);
                
            }
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
                cmbDeleteEmp.Items.Clear();
                foreach (int num in ListEmpId)
                {
                    if (!cmbDeleteEmp.Items.Contains(num))
                    {
                        cmbDeleteEmp.Items.Add(num);
                    }
                }
            }
            conn.Close();
        }

        private void SaveFpData(SqlConnection conn, string strFp)
        {
            conn.Open();
            int id = ListFpTemplate.Count;
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
            fpData.Visible = false;
            empData.Visible = false;
                    
        }

        private void BtnDeleteItem_Click(object sender, EventArgs e)
        {
            string item = cmbDeleteItem.SelectedItem.ToString();
            if (ListAllFpTemplate.Count == 0)
            {
               
                if (!ListAllEmpId.Contains(Convert.ToInt32(item)))
                {
                    secondMessageBox.AppendText($"\nNo data in database");
                    return;
                }
            }
            
            SqlConnection conn = new SqlConnection(localDatabase);
            string query = $"DELETE FROM Table_fp where emp_id = {Convert.ToInt32(item)}";
            SqlCommand myCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                int numRow = myCommand.ExecuteNonQuery();
                secondMessageBox.AppendText($"\nDelete successful, {numRow} rows affected");
                ListAllFpTemplate.Clear();
                ListAllEmpId.Clear();
                ListAllId.Clear();

            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nDelete item fail, Error message: {ex.Message}");
            }
            conn.Close();
            ReadAllFpData(conn);
            
        }

        private void MessageBox_TextChanged(object sender, EventArgs e)
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
            for (int i = 0; i < ListEmpId.Count; i++)
            {
                if (empId == Convert.ToInt32(ListEmpId[i]))
                {
                    richTextBox1.AppendText($"\nId already register");
                    return;
                }
            }
             
            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.Parameters.AddWithValue("@Id", empId);
                myCommand.Parameters.AddWithValue("@emp_name", empName);
                myCommand.ExecuteNonQuery();
                richTextBox1.AppendText($"\nRegister success\nEmployee Id: {id}\nEmployee Name: {empName}");
                
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

        private void BtnConnectDevice_Click(object sender, EventArgs e)
        {
           try
            {
                string ip = tbIp.Text;
                string port = tbPort.Text;
                int portNum = Convert.ToInt32(port);
                bool resultBool = objZkeeper.Connect_Net(ip, portNum);
                if (resultBool)
                {
                    deviceMessageBox.AppendText($"\nConnect success");
                    tbIp.Enabled = false;
                    tbPort.Enabled = false;
                    btnUploadData.Enabled = true;
                    btnDownloadData.Enabled = true;
                    btnDisconnectDevice.Enabled = true;
                    btnConnectDevice.Enabled = false;
                    deviceData.Visible = true;
                    return;
                }
                else
                {
                    deviceMessageBox.AppendText($"\nConnect fail");
                }
            }
            catch (Exception ex)
            {
                deviceMessageBox.AppendText($"\nError message: {ex}");
            }
            
        }

        private void BtnDownloadData_Click(object sender, EventArgs e)
        {
            bool result = objCZKEM.ReadAllUserID(machineNumber);
            ListAllDeviceFpId.Clear();
            ListAllDeviceTmp.Clear();
            ListAllDeviceEmpId.Clear();
            try
            {
                ICollection<UserInfo> lstFingerPrintTemplates = manipulator.GetAllUserInfo(objZkeeper, machineNumber);
                if (lstFingerPrintTemplates != null && lstFingerPrintTemplates.Count > 0)
                {
                    deviceMessageBox.AppendText($"\n{lstFingerPrintTemplates.Count} records found ");
                    ListAllDeviceFpId = manipulator.GetFpId();
                    ListAllDeviceTmp = manipulator.GetFpTemplate();
                    ListAllDeviceEmpId = manipulator.GetEmpId();
                    ListAllDeviceUserName = manipulator.GetName();
                    ReadDeviceData(ListAllDeviceFpId, ListAllDeviceTmp, ListAllDeviceEmpId, ListAllDeviceUserName);
                    SaveDataToDb(ListAllDeviceFpId, ListAllDeviceTmp, ListAllDeviceEmpId);
                }
                else
                {
                    deviceMessageBox.AppendText($"\nRead failed");

                }
            }
            catch(Exception ex)
            {
                deviceMessageBox.AppendText($"\nError message: {ex}");
            } 
            
        }

        private void ReadDeviceData(List<int> id, List<string> tmp, List<int> empId, List<string> name)
        {
            deviceData.Rows.Clear();
            for (int i = 0; i < ListAllDeviceFpId.Count; i++)
            {
                DataGridViewRow deviceRow = new DataGridViewRow();
                deviceRow.CreateCells(deviceData);
                deviceRow.Cells[0].Value = id[i];
                deviceRow.Cells[1].Value = tmp[i];
                deviceRow.Cells[2].Value = empId[i];
                deviceRow.Cells[3].Value = name[i];
                deviceData.Rows.Add(deviceRow);

                //find out the same id between local database and database server
                if (ListEmpId.Contains(Convert.ToInt32(empId[i])))
                {
                    if (!results.Contains(Convert.ToInt32(empId[i])))
                    {
                        results.Add(Convert.ToInt32(empId[i]));
                    }
                }
                
            }
        }

        private void SaveDataToDb(List<int> id, List<string> tmp, List<int> empId)
        {
            using (SqlConnection conn = new SqlConnection(localDatabase))
            {
                conn.Open();
                DateTime currentTime = DateTime.Now;
                string query = "INSERT INTO Table_fp (Id, fp_template, time_registered, emp_id)";
                query += " VALUES (@Id, @fp_template, @time_registered, @emp_id)";
                try
                {
                    for (int i = 0; i < id.Count; i++)
                    {
                        using (SqlCommand myCommand = new SqlCommand(query, conn))
                        {
                            myCommand.Parameters.AddWithValue("@Id", id[i]);
                            myCommand.Parameters.AddWithValue("@fp_template", tmp[i]);
                            myCommand.Parameters.AddWithValue("@time_registered", currentTime);
                            myCommand.Parameters.AddWithValue("@emp_id", empId[i]);
                            myCommand.ExecuteNonQuery();
                        }
                    }

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
                
        }

       
        private void DeviceMessageBox_TextChanged(object sender, EventArgs e)
        {
            deviceMessageBox.SelectionStart = messageBox.Text.Length;
            deviceMessageBox.ScrollToCaret();
        }

        private void SecondMessageBox_TextChanged(object sender, EventArgs e)
        {
            secondMessageBox.SelectionStart = messageBox.Text.Length;
            secondMessageBox.ScrollToCaret();
        }

        private void BtnUploadData_Click(object sender, EventArgs e)
        {
            List<UserInfo> lstUserInfo = new List<UserInfo>();
            
            if (results.Count != 0)
            {
                foreach (int num in results)
                {
                    deviceMessageBox.AppendText($"\nSame id: {num}");
                    //ListAllEmpId.Remove(num);
                }
            }
            for (int i = 0; i < ListAllEmpId.Count; i++)
            {
                UserInfo fpInfo = new UserInfo();
                fpInfo.MachineNumber = 1;
                fpInfo.EnrollNumber = ListAllEmpId[i].ToString();
                for (int j = 0; j < ListName.Count; j++)
                {
                    
                    if (Convert.ToInt32(ListAllEmpId[i]) == Convert.ToInt32(ListEmpId[j]))
                    {
                        fpInfo.Name = ListName[j].ToString();
                    }
                }
                fpInfo.FingerIndex = Convert.ToInt32(ListAllId[i]);
                fpInfo.TmpData = ListAllFpTemplate[i].ToString();
                fpInfo.Privelage = 0;
                fpInfo.Password = "1234";
                fpInfo.Enabled = true;
                fpInfo.iFlag = "1";
                lstUserInfo.Add(fpInfo);
            }
            
            deviceMessageBox.AppendText($"\n{ListAllEmpId.Count} records upload");
            bool uploadResult =  manipulator.UploadFTPTemplate(objZkeeper, machineNumber, lstUserInfo);
            if (uploadResult)
            {
                deviceMessageBox.AppendText($"\nUpload success");
                ReadDeviceData(ListAllDeviceFpId, ListAllDeviceTmp, ListAllDeviceEmpId, ListAllDeviceUserName);
                return;
            }
            else
            {
                deviceMessageBox.AppendText($"\nUpload failed");
                return;
            }
        }

        private void BtnDisconnectDevice_Click(object sender, EventArgs e)
        {
            objZkeeper.Disconnect();
            btnConnectDevice.Enabled = true;
            btnDownloadData.Enabled = false;
            btnUploadData.Enabled = false;
            deviceData.Visible = false;
            deviceMessageBox.AppendText($"\nDevice disconnect");
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            bool isConnect = false;
            secondMessageBox.AppendText("\nConnecting...");
            //create instanace of database connection
            SqlConnection conn = new SqlConnection(localDatabase);
            try
            {
                conn.Open();
                secondMessageBox.AppendText("\nConnect successful");
                btnConnectDb.Enabled = false;
                btnDisconnect.Enabled = true;
                fpData.Visible = true;
                empData.Visible = true;
                cmbDeleteItem.Items.Clear();
                conn.Close();
                ReadAllFpData(conn);
                ReadEmpData(conn);
                isConnect = true;
                if (isConnect)
                {
                    timer1.Stop();
                    return;
                }
            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nDatabase connect fail, Error message: {ex.Message}");
            }
            /*try
                {
                    bool isConnect = false;
                    string ip = tbIp.Text;
                    int port = Convert.ToInt32(tbPort.Text);
                    //string port = tbPort.Text;
                    //int portNum = Convert.ToInt32(port);
                    bool resultBool = objZkeeper.Connect_Net(ip, port);
                    if (resultBool)
                    {
                        tbIp.Enabled = false;
                        tbPort.Enabled = false;
                        btnUploadData.Enabled = true;
                        btnDownloadData.Enabled = true;
                        btnDisconnectDevice.Enabled = true;
                        btnConnectDevice.Enabled = false;
                        deviceData.Visible = true;

                        deviceMessageBox.AppendText($"\nConnect success");
                        isConnect = true;
                        if (isConnect)
                        {
                            timer1.Stop();
                            return;
                        }
                    }
                    else
                    {
                        deviceMessageBox.AppendText($"\nConnect fail");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    deviceMessageBox.AppendText($"\nError message: {ex}");
                }
            */
        }

        private void BtnDeleteEmp_Click(object sender, EventArgs e)
        {
            string item = cmbDeleteEmp.SelectedItem.ToString();
            if (ListAllFpTemplate.Count == 0)
            {

                if (!ListEmpId.Contains(Convert.ToInt32(item)))
                {
                    secondMessageBox.AppendText($"\nNo data in database");
                    return;
                }
            }

            SqlConnection conn = new SqlConnection(localDatabase);
            string query = $"DELETE FROM Table_employee where Id = {Convert.ToInt32(item)}";
            SqlCommand myCommand = new SqlCommand(query, conn);
            try
            {
                conn.Open();
                int numRow = myCommand.ExecuteNonQuery();
                secondMessageBox.AppendText($"\nDelete successful, {numRow} rows affected");
                ListEmpId.Clear();
                ListName.Clear();

            }
            catch (Exception ex)
            {
                secondMessageBox.AppendText($"\nDelete item fail, Error message: {ex.Message}/nYou cannot delete this ");
            }
            conn.Close();
            ReadEmpData(conn);
        }
    }  
}
