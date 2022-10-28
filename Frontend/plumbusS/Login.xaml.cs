using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Configuration;
using System.Windows.Input;

namespace plumbusS
{
    public partial class Login : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlumbusDBConnection"].ConnectionString);
        
        public Login()
        {
            InitializeComponent();
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LogIn_Click(sender, e);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void ToRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            this.Close();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginent.Text;
            string password = passwordB.Password;
            bool adminExist;

            // Выбрана роль Админа
            if (roles_Cbx.SelectedIndex == 0)
            {   
                sqlConnection.Open();
                SqlCommand checkAdmin = new SqlCommand("SELECT COUNT(1) FROM Administrator" +
                    " WHERE username=@username AND password=@password", sqlConnection);
                checkAdmin.CommandType = CommandType.Text;
                checkAdmin.Parameters.AddWithValue("@username", login);
                checkAdmin.Parameters.AddWithValue("@password", password);
                adminExist = Convert.ToBoolean(checkAdmin.ExecuteScalar());
                sqlConnection.Close();

                if (adminExist)
                {
                    Admin admin = new Admin();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                }
            }
            // Выбрана роль Учителя
            else if (roles_Cbx.SelectedIndex == 1)
            {
                sqlConnection.Open();
                SqlCommand checkTeacher = new SqlCommand("SELECT COUNT(1) FROM Teacher" +
                    " WHERE username = @username AND password = @password", sqlConnection);
                checkTeacher.CommandType = CommandType.Text;
                checkTeacher.Parameters.AddWithValue("@username", login);
                checkTeacher.Parameters.AddWithValue("@password", password);
                adminExist = Convert.ToBoolean(checkTeacher.ExecuteScalar());
                sqlConnection.Close();
                
                if (adminExist)
                {
                    Teacher teacher = new Teacher();
                    teacher.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                }
            }
            // Выбран роль Ученика
            else if (roles_Cbx.SelectedIndex == 2)
            {
                sqlConnection.Open();
                SqlCommand checkPupil = new SqlCommand("SELECT COUNT(1) FROM Pupil" +
                    " WHERE username=@username AND password=@password", sqlConnection);
                checkPupil.CommandType = CommandType.Text;
                checkPupil.Parameters.AddWithValue("@username", login);
                checkPupil.Parameters.AddWithValue("@password", password);
                adminExist = Convert.ToBoolean(checkPupil.ExecuteScalar());
                sqlConnection.Close();

                if (adminExist)
                {
                    // Получение ИД ученика, чтобы показывать статистику для данного ученика
                    sqlConnection.Open();
                    SqlCommand getPupilId = new SqlCommand("SELECT * FROM Pupil" +
                        " WHERE username=@username AND password=@password", sqlConnection);
                    getPupilId.CommandType = CommandType.Text;
                    getPupilId.Parameters.AddWithValue("@username", login);
                    getPupilId.Parameters.AddWithValue("@password", password);
                    int pupilId = Convert.ToInt32(getPupilId.ExecuteScalar());
                    sqlConnection.Close();

                    Student student = new Student(pupilId);
                    student.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                }
            }
            // Выбрана роль Завода
            else if (roles_Cbx.SelectedIndex == 3)
            {
                sqlConnection.Open();
                SqlCommand checkPlant = new SqlCommand("SELECT COUNT(1) FROM Plant" +
                    " WHERE username=@username AND password=@password", sqlConnection);
                checkPlant.CommandType = CommandType.Text;
                checkPlant.Parameters.AddWithValue("@username", login);
                checkPlant.Parameters.AddWithValue("@password", password);
                adminExist = Convert.ToBoolean(checkPlant.ExecuteScalar());
                sqlConnection.Close();

                if (adminExist)
                {
                    Plant plant = new Plant();
                    plant.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Неверно введен логин или пароль");
                }
            }
        }
    }
}
