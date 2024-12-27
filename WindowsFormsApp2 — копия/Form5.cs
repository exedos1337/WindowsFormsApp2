using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form5 : Form
    {

        public Form5()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Games\123.jpg");



        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            var myForm = new Form8();
            myForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var myForm = new Form6();
            myForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myForm = new Form7();
            myForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }

}

