using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace plumbusS
{
    public partial class Teacher : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlumbusDBConnection"].ConnectionString);
        public Teacher()
        {
            InitializeComponent();
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddMark_Click(sender, e);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login()
            {
                WindowStartupLocation = WindowStartupLocation,
                Left = Left,
                Top = Top
            };
            login.Show();
            this.Close();
        }

        private void AddMark_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string homework = DZ.Text;
                int pupilId = Convert.ToInt32(pupilId_Tbx.Text);
                int mark = Convert.ToInt32(mark_Tbx.Text);

                int markId;

                // Добавление домашнего задания
                if (homework.Length > 0)
                {
                    SqlCommand addHomework = new SqlCommand("INSERT INTO Homework (description)" +
                        " VALUES (@description)", sqlConnection);
                    addHomework.CommandType = System.Data.CommandType.Text;
                    addHomework.Parameters.AddWithValue("@description", homework);
                    sqlConnection.Open();
                    addHomework.ExecuteNonQuery();
                    sqlConnection.Close();
                }

                // Добавление оценки ученику
                if(pupilId > 0)
                {
                    if (mark < 2 || mark > 5)
                    {
                        MessageBox.Show("Оценки только от 2 до 5!");
                        return;
                    }
                    else
                    {
                        markId = mark - 1;
                        SqlCommand addMark = new SqlCommand("INSERT INTO PupilMark" +
                            " VALUES (@id_mark, @id_pupil)", sqlConnection);
                        addMark.CommandType = System.Data.CommandType.Text;
                        addMark.Parameters.AddWithValue("@id_pupil", pupilId);
                        addMark.Parameters.AddWithValue("@id_mark", markId);
                        sqlConnection.Open();
                        addMark.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }               
                MessageBox.Show("Оценка была добавлена!");
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!");
            }
        }
    }
}
