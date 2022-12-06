using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace zkfpPrototype
{
    public partial class Form3 : Form
    {

        SqlConnection conn = new SqlConnection();
        readonly string localDatabase = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\demo\\Desktop\\fingerprint Project\\test1\\zkfpPrototype\\Database1.mdf\";Integrated Security=True";
        Form1 form1 = new Form1();
        IntPtr FormHandle = IntPtr.Zero;

        public Form3()
        {
            InitializeComponent();
            
        }

        private void Save_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(localDatabase);
            string empName = tbName.Text;
            string id = tbId.Text;
            int empId = Int32.Parse(id);
            MessageBox.Show($"Id: {id}\nName: {empName}");
            string query = "INSERT INTO Table_fp (Id, emp_name)";
            query += " VALUES (@Id, @emp_name)";
            try
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(query, conn);
                myCommand.Parameters.AddWithValue("@Id", empId);
                myCommand.Parameters.AddWithValue("@emp_name", empName);
                myCommand.ExecuteNonQuery();
                form1.secondMessageBox.AppendText($"\nRegister success\nEmployee Id: {id}\nEmployee Name: {empName}");
                System.Windows.Forms.Application.Exit();
                
            }
            catch (Exception ex)
            {
                form1.secondMessageBox.AppendText($"\nError message: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }


        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tbId.Text = "";
            tbName.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FormHandle = this.Handle;
        }
    }
}
