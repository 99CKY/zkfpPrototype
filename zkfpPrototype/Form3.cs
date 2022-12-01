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
        
        
        public Form3()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            string columnName = tbName.Text;
            string dataType = tbDataType.Text;
            string selectedItem = cmbType.Items[cmbType.SelectedIndex].ToString();
            MessageBox.Show($"Column: {columnName}\nData type: {selectedItem}");
           

            /*cn.Open();
            cmd = new SqlCeCommand("INSERT INTO Art(id,name,buy_price,sell_price,mr,group_id,subgroup_id) VALUES(@id,@name,@buy_price,@sell_price,@mr,@group_id,@subgroup_id)", cn);
            cmd.Parameters.Add("@id", textBox1.Text);
            cmd.Parameters.AddWithValue("@name", textBox2.Text);*/
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbDataType.Text = "";
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
