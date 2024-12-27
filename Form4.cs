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

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        public static class UserInfo
        {
            public static string PhoneNumber { get; set; }
        }


        public Form4()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            TextBox textBox3 = new TextBox();
           
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "+7 (999) 000-00-00";
            maskedTextBox1.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, заполнены ли все обязательные поля
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return; 
            }

            try
            {
                using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-ED3FJNU;Initial Catalog=carsharing;Integrated Security=True"))
                {
                    con.Open();

                    
                    using (SqlCommand checkUser = new SqlCommand("SELECT COUNT(*) FROM [dbo].[Registration/Login] WHERE login = @Log", con))
                    {
                        checkUser.Parameters.Add("@Log", SqlDbType.VarChar).Value = textBox1.Text;

                        int userExists = (int)checkUser.ExecuteScalar();

                        if (userExists > 0)
                        {
                            MessageBox.Show("Пользователь с таким логином уже зарегистрирован.");
                            return; 
                        }
                    }

                    
                    using (SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Registration/Login] (login, pass, fio, phonenumber) VALUES (@Log, @Pass, @Fio, @phonenumber)", con))
                    {
                        command.Parameters.Add("@Log", SqlDbType.VarChar).Value = textBox1.Text;
                        command.Parameters.Add("@Pass", SqlDbType.VarChar).Value = HashPassword(textBox2.Text); 
                        command.Parameters.Add("@Fio", SqlDbType.VarChar).Value = textBox3.Text;
                        command.Parameters.Add("@phonenumber", SqlDbType.VarChar).Value = maskedTextBox1.Text;

                        command.ExecuteNonQuery();
                        MessageBox.Show("Вы зарегистрировались!");
                        Form3 frm = new Form3();
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
            }
        }

        
        private string HashPassword(string password)
        {
            
            return password; 
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли нажатый символ буквой или пробелом
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true; // Игнорируем ввод
            }
        }


        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void phonenumber_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (maskedTextBox1.MaskFull)
            {
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var MyForm4 = new Form2();
            this.Hide();
            MyForm4.ShowDialog();
            this.Close();
        }
    }
}
