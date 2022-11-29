using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using libzkfpcsharp;
using Sample;
using zkemkeeper;

namespace test1
{
    public partial class Form1 : Form
    {
        CZKEM objCZKEM = new CZKEM();

        // DeviceManipulator manipulator = new DeviceManipulator();

        // Code from zkfinger sdk windows zk10
        IntPtr mDevHandle = IntPtr.Zero;
        IntPtr mDBHandle = IntPtr.Zero;
        IntPtr FormHandle = IntPtr.Zero;
        bool bIsTimeToDie = false;
        bool IsRegister = false;
        bool bIdentify = true;
        byte[] FPBuffer;
        int RegisterCount = 0;
        const int REGISTER_FINGER_COUNT = 3;

        byte[][] RegTmps = new byte[3][];
        byte[] RegTmp = new byte[2048];
        byte[] CapTmp = new byte[2048];

        int cbCapTmp = 2048;
        int cbRegTmp = 0;
        int iFid = 1;

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

        private void button1_Click(object sender, EventArgs e)
        {
            /*string value1 = textBox1.Text;
            int value2 = Convert.ToInt32(textBox2.Text);
            bool resultBool = objCZKEM.Connect_Net(value1, value2);
            result.Text = Convert.ToString(resultBool);

*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // //Console.WriteLine("Getting Connection ...");
            var datasource = @"DBSERV\SQL2K8";//your server
            var database = "testScan"; //your database name
            var username = "fis"; //username of server to connect
            var password = "fis"; //password

            //your connection string 
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                                + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;

            //create instanace of database connection
            SqlConnection conn = new SqlConnection(connString);

            //Console.WriteLine("Openning Connection ...");

            //open connection
            conn.Open();
            textRes.AppendText("Connect successful");
            SqlCommand myCommand = new SqlCommand("select * from hr_employee", conn);
            SqlDataReader myReader = myCommand.ExecuteReader();
            while (myReader.Read())
            {
                //Console.WriteLine(myReader["emp_firstname"].ToString());
            }

            conn.Close();

        }

     

        private void button3_Click(object sender, EventArgs e)
        {
            /*int callBackCode = fpInstance.Init();
            if (zkfp.ZKFP_ERR_OK == callBackCode)
            {
                int nCount = fpInstance.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int index = 1; index <= nCount; index++)
                    {
                        // Hold these indexes somewere
                        // It represents the index of the device you wish to connect to 
                        ConnectDevice(index);
                    }
                    // Connected Successfully
                    label6.Text = "Connected Successfully";

                }
            }
            else {  *//* Unable to initialize, Clear previous resources *//*
                label6.Text = "Connected Failed";
            }*/

        }

        public void ConnectDevice(int deviceIndex)
        {

        }

        // Code from zkfinger sdk windows zk10
        private void bnInit_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Program start");
            cmbIdx.Items.Clear();
            int ret = zkfperrdef.ZKFP_ERR_OK;
            //Console.WriteLine("int ret = zkfp error code");
            //Console.WriteLine("Call method Init() return value a");
            if ((ret = zkfp2.Init()) == zkfperrdef.ZKFP_ERR_OK)
            {
                //Console.WriteLine("If ret = a");
                //Console.WriteLine("\tOutput initialize success\nCall method GetDeviceCount() return b");
                int nCount = zkfp2.GetDeviceCount();
                if (nCount > 0)
                {
                    for (int i = 0; i < nCount; i++)
                    {
                        cmbIdx.Items.Add(i.ToString());
                    }
                    cmbIdx.SelectedIndex = 0;
                    bnInit.Enabled = false;
                    bnFree.Enabled = true;
                    bnOpen.Enabled = true;
                    MessageBox.Show($"Initialize success!\nNumber of device connect: {nCount}");
                    //Console.WriteLine("\tIf b > 0 \n\toutput connect successful");
                }
                else
                {
                    zkfp2.Terminate();
                    MessageBox.Show("No device connected!");
                    //Console.WriteLine("Else\n\tOutput connect failed");
                }
            }
            else
            {
                MessageBox.Show("Initialize fail, ret=" + ret + " !");

                //Console.WriteLine("Else\n\tOutput initialize failed");
            }
        }

        private void bnFree_Click(object sender, EventArgs e)
        {
            zkfp2.Terminate();
            cbRegTmp = 0;
            bnInit.Enabled = true;
            bnFree.Enabled = false;
            bnOpen.Enabled = false;
            bnClose.Enabled = false;
            bnEnroll.Enabled = false;
            bnVerify.Enabled = false;
            bnIdentify.Enabled = false;
            btMatch.Enabled = false;
        }

        private void bnOpen_Click(object sender, EventArgs e)
        {

            int ret = zkfp.ZKFP_ERR_OK;
            if (IntPtr.Zero == (mDevHandle = zkfp2.OpenDevice(cmbIdx.SelectedIndex)))
            {
                MessageBox.Show("Open Device fail");
                return;
            }
            if (IntPtr.Zero == (mDBHandle = zkfp2.DBInit()))
            {
                MessageBox.Show("Init DB fail");
                zkfp2.CloseDevice(mDevHandle);
                mDevHandle = IntPtr.Zero;
                return;
            }
            bnInit.Enabled = false;
            bnFree.Enabled = true;
            bnOpen.Enabled = false;
            bnClose.Enabled = true;
            bnEnroll.Enabled = true;
            bnVerify.Enabled = true;
            bnIdentify.Enabled = true;
            btnOutput.Enabled = true;
            btMatch.Enabled = true;
            btnImport.Enabled = true;
            RegisterCount = 0;
            cbRegTmp = 0;
            iFid = 1;
            for (int i = 0; i < 3; i++)
            {
                RegTmps[i] = new byte[2048];
            }
            byte[] paramValue = new byte[4];
            int size = 4;
            zkfp2.GetParameters(mDevHandle, 1, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpWidth);
            textRes.AppendText("");
            size = 4;
            zkfp2.GetParameters(mDevHandle, 2, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

            FPBuffer = new byte[mfpWidth * mfpHeight];

            size = 4;
            zkfp2.GetParameters(mDevHandle, 3, paramValue, ref size);
            zkfp2.ByteArray2Int(paramValue, ref mfpDpi);

            textRes.AppendText("reader parameter, image width:" + mfpWidth + ", height:" + mfpHeight + ", dpi:" + mfpDpi + "\n");

            Thread captureThread = new Thread(new ThreadStart(DoCapture));
            //Console.WriteLine("Call method DoCapture()\n");
            captureThread.IsBackground = true;
            captureThread.Start();
            bIsTimeToDie = false;
            textRes.AppendText("Open succ\n");
        }

        private void DoCapture()
        {
            while (!bIsTimeToDie)
            {
                cbCapTmp = 2048;
                int ret = zkfp2.AcquireFingerprint(mDevHandle, FPBuffer, CapTmp, ref cbCapTmp);

                if (ret == zkfp.ZKFP_ERR_OK)
                {
                    SendMessage(FormHandle, MESSAGE_CAPTURED_OK, IntPtr.Zero, IntPtr.Zero);
                    //Console.WriteLine("Call method AcquireFingerPrint()");

                }
                Thread.Sleep(200);
            }
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
                        this.picFPImg.Image = bmp;
                        String strShow = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                        // textRes.AppendText("capture template data:" + strShow + "\n");
                        // //Console.WriteLine("Line 293 - Boolean IsRegister: " + IsRegister);
                        if (IsRegister)
                        {
                            //Console.WriteLine("If  IsRegister = true\n");
                            int ret = zkfp.ZKFP_ERR_OK;
                            int fid = 0, score = 0;
                            ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                            //Console.WriteLine("\tCall method DBIdentify() and return value c");
                            if (zkfp.ZKFP_ERR_OK == ret)
                            {
                                textRes.AppendText("This finger was already register by " + fid + "!\n");
                                //Console.WriteLine("If zkfp error code = c\n\t Output this finger was already register message");
                                return;
                            }

                            if (RegisterCount > 0 && zkfp2.DBMatch(mDBHandle, CapTmp, RegTmps[RegisterCount - 1]) <= 0)
                            {
                                textRes.AppendText("Please press the same finger 3 times for the enrollment.\n");
                                return;
                            }

                            Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                            String strBase64 = zkfp2.BlobToBase64(CapTmp, cbCapTmp);
                            byte[] blob = zkfp2.Base64ToBlob(strBase64);
                            //Console.WriteLine("Value of RegisterCount before + 1: " + RegisterCount);
                            RegisterCount++;
                            //Console.WriteLine("Value of RegisterCount after + 1: " + RegisterCount);

                            if (RegisterCount >= REGISTER_FINGER_COUNT)
                            {
                                RegisterCount = 0;
                                if (zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBMerge(mDBHandle, RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref cbRegTmp)) &&
                                       zkfp.ZKFP_ERR_OK == (ret = zkfp2.DBAdd(mDBHandle, iFid, RegTmp)))
                                {
                                    iFid++;
                                    textRes.AppendText($"Registered template data: {RegTmp}");
                                    textRes.AppendText("enroll success\n");
                                    //Console.WriteLine("Call method DBMerge() and return value d\nCall method DBAdd() and return value e\n");
                                    //Console.WriteLine("If ret = d && ret = e");
                                    //Console.WriteLine("\n\tOutput register success");

                                }
                                else
                                {
                                    textRes.AppendText("enroll fail, error code=" + ret + "\n");
                                    //Console.WriteLine("Else\n\tOutput register fail");
                                }
                                IsRegister = false;
                                return;
                            }
                            else
                            {
                                textRes.AppendText("You need to press the " + (REGISTER_FINGER_COUNT - RegisterCount) + " times fingerprint\n");
                            }
                        }
                        else
                        {
                            if (cbRegTmp <= 0)
                            {
                                textRes.AppendText("Please register your finger first!\n");
                                return;
                            }
                            if (bIdentify)
                            {
                                int ret = zkfp.ZKFP_ERR_OK;
                                int fid = 0, score = 0;
                                ret = zkfp2.DBIdentify(mDBHandle, CapTmp, ref fid, ref score);
                                //Console.WriteLine("Call method DBIdentify() and return value g");
                                if (zkfp.ZKFP_ERR_OK == ret)
                                {
                                    textRes.AppendText("Identify succ, fid= " + fid + ",score=" + score + "!\n");
                                    //Console.WriteLine("If zkfp erro code = g\n\tOutput identify success message");
                                    return;
                                }
                                else
                                {
                                    textRes.AppendText("Identify fail, ret= " + ret + "\n");
                                    //Console.WriteLine("Else \n\tOutput identify fail message");
                                    return;
                                }
                            }
                            else
                            {

                                int ret = zkfp2.DBMatch(mDBHandle, CapTmp, RegTmp);
                                //Console.WriteLine("Call method DBMatch() method and return value f\n");
                                //Console.WriteLine("Value of ret: " + ret);
                                if (0 < ret)
                                {
                                    textRes.AppendText("Match finger succ, score=" + ret + "!\n");
                                    //Console.WriteLine("If f > 0 \n\tOutput match finger success message");
                                    return;
                                }
                                else
                                {
                                    textRes.AppendText("Match finger fail, ret= " + ret + "\n");
                                    //Console.WriteLine("Else \n\tOutput match finger fail message");
                                    return;
                                }
                            }
                        }
                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
        }

        private void bnClose_Click(object sender, EventArgs e)
        {
            bIsTimeToDie = true;
            RegisterCount = 0;
            Thread.Sleep(1000);
            zkfp2.CloseDevice(mDevHandle);
            bnInit.Enabled = false;
            bnFree.Enabled = true;
            bnOpen.Enabled = true;
            bnClose.Enabled = false;
            bnEnroll.Enabled = false;
            bnVerify.Enabled = false;
            bnIdentify.Enabled = false;
            btMatch.Enabled = false;
        }

        private void bnEnroll_Click(object sender, EventArgs e)
        {
            if (!IsRegister)
            {
                IsRegister = true;
                RegisterCount = 0;
                cbRegTmp = 0;
                textRes.AppendText("Please press your finger 3 times!\n");
            }
        }

        private void bnIdentify_Click(object sender, EventArgs e)
        {
            textRes.AppendText("Enter Identify Mode!\n");
            if (!bIdentify)
            {
                bIdentify = true;
                textRes.AppendText("Please press your finger!\n");
            }
        }

        private void bnVerify_Click(object sender, EventArgs e)
        {
            textRes.AppendText("Enter Match Mode!\n");

            if (bIdentify)
            {
                //Console.WriteLine("Start verifying");
                bIdentify = false;
                textRes.AppendText("Please press your finger!\n");
            }
        }

        private void btMatch_Click(object sender, EventArgs e)
        {
            byte[] blob1 = Convert.FromBase64String(txtTemplate1.Text.Trim());
            byte[] blob2 = Convert.FromBase64String(txtTemplate2.Text.Trim());

            int ret = zkfp2.DBMatch(mDBHandle, blob1, blob2);
            textRes.AppendText("Match template 1 vs template 2 score=" + ret + "!\n");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            Byte[] finger = new Byte[2048];
            int fingerlen = 0;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "";
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picFPImg.ImageLocation = openFileDialog1.FileName;

                int ret = zkfp2.ExtractFromImage(mDBHandle, openFileDialog1.FileName, 500, finger, ref fingerlen);

                if (ret == 0)
                {
                    String strBase64 = zkfp2.BlobToBase64(finger, fingerlen);
                    textRes.AppendText("ExtractFromImage success, data len:" + fingerlen + " base64 data:" + strBase64 + "\n");
                }
                else
                {
                    textRes.AppendText("ExtractFromImage failed" + ret + "!\n");
                }
            }
        }

        private void btCaptureBmp_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "fingertemplate.bmp";
            saveFileDialog1.RestoreDirectory = true;

            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = saveFileDialog1.FileName.ToString();
                if (fileName != "" && fileName != null && picFPImg.Image != null)
                {
                    //http://www.wischik.com/lu/programmer/1bpp.html
                    Bitmap bmp = new Bitmap(picFPImg.Image.Width, picFPImg.Image.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.DrawImage(picFPImg.Image, 0, 0, bmp.Width, bmp.Height);

                    }
                    Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                    System.Drawing.Imaging.BitmapData bmpData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);
                    IntPtr ptr = bmpData.Scan0;
                    int bytes = bmpData.Stride * bmpData.Height;
                    byte[] rgbValues = new byte[bytes];
                    System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
                    Rectangle rect2 = new Rectangle(0, 0, bmp.Width, bmp.Height);

                    Bitmap bit = new Bitmap(bmp.Width, bmp.Height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);
                    System.Drawing.Imaging.BitmapData bmpData2 = bit.LockBits(rect2, System.Drawing.Imaging.ImageLockMode.ReadWrite, bit.PixelFormat);
                    IntPtr ptr2 = bmpData2.Scan0;
                    int bytes2 = bmpData2.Stride * bmpData2.Height;
                    byte[] rgbValues2 = new byte[bytes2];
                    System.Runtime.InteropServices.Marshal.Copy(ptr2, rgbValues2, 0, bytes2);
                    double colorTemp = 0;
                    for (int i = 0; i < bmpData.Height; i++)
                    {
                        for (int j = 0; j < bmpData.Width * 3; j += 3)
                        {
                            colorTemp = rgbValues[i * bmpData.Stride + j + 2] * 0.299 + rgbValues[i * bmpData.Stride + j + 1] * 0.578 + rgbValues[i * bmpData.Stride + j] * 0.114;
                            rgbValues2[i * bmpData2.Stride + j / 3] = (byte)colorTemp;
                        }
                    }
                    System.Runtime.InteropServices.Marshal.Copy(rgbValues2, 0, ptr2, bytes2);
                    bmp.UnlockBits(bmpData);
                    ColorPalette tempPalette;
                    {
                        using (Bitmap tempBmp = new Bitmap(1, 1, System.Drawing.Imaging.PixelFormat.Format8bppIndexed))
                        {
                            tempPalette = tempBmp.Palette;
                        }
                        for (int i = 0; i < 256; i++)
                        {
                            tempPalette.Entries[i] = Color.FromArgb(i, i, i);
                        }
                        bit.Palette = tempPalette;
                    }
                    bit.UnlockBits(bmpData2);

                    bit.Save(fileName, picFPImg.Image.RawFormat);

                    bit.Dispose();
                }
            }
        }

    }
}
