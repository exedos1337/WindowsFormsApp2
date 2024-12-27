using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NewProject;

namespace WindowsFormsApp2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Прерываем выполнение метода, если поля пустые
            }

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ED3FJNU;Initial Catalog=carsharing;Integrated Security=True");
            con.Open();

            SqlCommand command = new SqlCommand("SELECT COUNT(1) FROM [dbo].[Registration/Login] WHERE login = @Login AND pass = @Pass", con);
            command.Parameters.Add("@Login", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = textBox2.Text;

            int count = Convert.ToInt32(command.ExecuteScalar());

            con.Close();

            if (count == 1)
            {
                // Логин и пароль верны
                MessageBox.Show("Вы успешно авторизировались!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Form12 frm = new Form12();
                frm.Show();
                this.Hide();
            }
            else
            {
                // Неверные данные
                MessageBox.Show("Неверный логин или пароль!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var myForm = new Form4();
            myForm.Show();
            this.Hide();
        }
    }
}