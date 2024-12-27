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
using static WindowsFormsApp2.Form4;

namespace WindowsFormsApp2
{
    public partial class Form9 : Form
    {
        private string connectionString = "Data Source=DESKTOP-ED3FJNU;Initial Catalog=carsharing;Integrated Security=True";

        public Form9()
        {

            InitializeComponent();
            LoadCars();
        }

        private void LoadCars()
        {

            carComboBox.Items.Add("Haval F7");
            carComboBox.Items.Add("Chery Tiggo 4 Pro");
            carComboBox.Items.Add("Rolls-Royce Wraith");
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из TextBox и ComboBox
                string phoneNumber = phoneTextBox.Text;
                string car = carComboBox.SelectedItem.ToString();

                // Проверяем, что поля не пустые
                if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(car))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                    return;
                }

                // Создаем подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Открываем соединение
                    connection.Open();

                    // SQL запрос для вставки данных
                    string query = "INSERT INTO Cars (phonenumber, car) VALUES (@phonenumber, @car)";

                    // Создаем команду с параметрами
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@phonenumber", phoneNumber);
                        command.Parameters.AddWithValue("@car", car);

                        // Выполняем запрос
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Вы успешно забронировали автомобиль, ожидайте звонка!");

                // Очищаем поля после сохранения
                phoneTextBox.Clear();
                carComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}");
            }
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void phoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем значения из TextBox и ComboBox
                string phoneNumber = phoneTextBox.Text;
                string car = carComboBox.SelectedItem?.ToString(); // Используем безопасный вызов

                // Проверяем, что поля не пустые
                if (string.IsNullOrWhiteSpace(phoneNumber) || string.IsNullOrWhiteSpace(car))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля!");
                    return;
                }

                // Создаем подключение к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Открываем соединение
                    connection.Open();

                    // SQL запрос для удаления данных
                    string query = "DELETE FROM Cars WHERE phonenumber = @phonenumber AND car = @car";

                    // Создаем команду с параметрами
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавляем параметры
                        command.Parameters.AddWithValue("@phonenumber", phoneNumber);
                        command.Parameters.AddWithValue("@car", car);

                        // Выполняем запрос
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Бронирование успешно отменено!");
                        }
                        else
                        {
                            MessageBox.Show("Не найдено бронирование с указанными данными.");
                        }
                    }
                }

                // Очищаем поля после удаления
                phoneTextBox.Clear();
                carComboBox.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при отмене бронирования: {ex.Message}");
            }
        }

        private void buttonBook_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            phoneTextBox.Text = UserInfo.PhoneNumber; // Автоматически заполняем номер телефона
        }
    }
}

