using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace plumbusS
{
    public partial class Plant: Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlumbusDBConnection"].ConnectionString);
        public Plant()
        {
            InitializeComponent();
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddPlumbus_Click(sender, e);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void AddPlumbus_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                int userId = Convert.ToInt32(Employee_TB.Text);
                int notRejectNumber = Convert.ToInt32(Norm_TB.Text);
                int rejectNumber = Convert.ToInt32(Brak_TB.Text);

                // Добавляет НЕбракованные Плюмбусы
                if (notRejectNumber > 0)
                {
                    for (int i = 1; i <= notRejectNumber; i++)
                    {
                        SqlCommand addPlumbus = new SqlCommand("INSERT INTO Plumbus" +
                            " Values (@reject, @creator)", sqlConnection);
                        addPlumbus.CommandType = CommandType.Text;
                        addPlumbus.Parameters.AddWithValue("@reject", 0);
                        addPlumbus.Parameters.AddWithValue("@creator", userId);
                        sqlConnection.Open();
                        addPlumbus.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                // Добавляет бракованные Плюмбусы
                if (rejectNumber > 0)
                {
                    for (int i = 1; i <= rejectNumber; i++)
                    {
                        SqlCommand addPlumbus = new SqlCommand("INSERT INTO Plumbus" +
                            " Values (@reject, @creator)", sqlConnection);
                        addPlumbus.CommandType = CommandType.Text;
                        addPlumbus.Parameters.AddWithValue("@reject", 1);
                        addPlumbus.Parameters.AddWithValue("@creator", userId);
                        sqlConnection.Open();
                        addPlumbus.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
                MessageBox.Show("Всё прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!");
            }            
        }
    }
}
