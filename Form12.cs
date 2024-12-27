using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace NewProject
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ED3FJNU;Initial Catalog=carsharing ;Integrated Security=True");
            string Sql = $"select fio from [dbo].[Registration/Login] where login = '{DataSend.text}'";
            SqlCommand scmd = new SqlCommand(Sql, con);
            con.Open();
            SqlDataReader sur = scmd.ExecuteReader();
            while (sur.Read())
            {
                string fio = sur["fio"].ToString();
                label2.Text = fio;
            }
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form5();
            myForm.Show();
            this.Hide();

        }
    }
}
