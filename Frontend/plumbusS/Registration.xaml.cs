using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data;
using System.Configuration;

namespace plumbusS
{
    public partial class Registration : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlumbusDBConnection"].ConnectionString);

        public Registration()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation,
                Left = Left,
                Top = Top
            };
            mainWindow.Show();
            this.Close();
        }

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                RegisterUser_Click(sender, e);
            }
        }

        private void BackToLogin_Click(object sender, RoutedEventArgs e)
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

        // Регистрация Ученика/Завода
        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            bool isExist;

            Random random = new Random();
            int pupilGroup = random.Next(1, 5);

            string login = loginreg.Text;
            string password = pass.Password;
            string password2 = pass2.Password;

            if ((login.Length == 0 || password.Length == 0) || (password != password2) ||
                    (login.Any(Char.IsWhiteSpace) || password.Any(Char.IsWhiteSpace)))
                {
                    MessageBox.Show("Неверно введен логин или пароль!");
                    return;
                }
            
            // Выбрана роль Ученик
            if (cbx_role_signup.SelectedIndex == 0)
            {
                sqlConnection.Open();
                SqlCommand getUsername = new SqlCommand("SELECT COUNT(1) FROM Pupil" +
                    " WHERE username=@username", sqlConnection);
                getUsername.CommandType = CommandType.Text;
                getUsername.Parameters.AddWithValue("@username", login);
                isExist = Convert.ToBoolean(getUsername.ExecuteScalar());
                sqlConnection.Close();

                if (isExist)
                {
                    MessageBox.Show("Такой логин уже существует");
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand addPupil = new SqlCommand("INSERT INTO Pupil" +
                        " Values (@username, @password, @pupil_group)", sqlConnection);
                    addPupil.CommandType = CommandType.Text;
                    addPupil.Parameters.AddWithValue("@username", login);
                    addPupil.Parameters.AddWithValue("@password", password);
                    addPupil.Parameters.AddWithValue("@pupil_group", pupilGroup);
                    addPupil.ExecuteNonQuery();
                    sqlConnection.Close();

                    // Получение ИД ученика, чтобы показывать статистику для данного ученика
                    sqlConnection.Open();
                    SqlCommand getPupilId = new SqlCommand("SELECT id FROM Pupil" +
                        " WHERE username = @username AND password = @password", sqlConnection);
                    getPupilId.CommandType = CommandType.Text;
                    getPupilId.Parameters.AddWithValue("@username", login);
                    getPupilId.Parameters.AddWithValue("@password", password);
                    getPupilId.ExecuteNonQuery();
                    int pupilId = Convert.ToInt32(getPupilId.ExecuteScalar());
                    sqlConnection.Close();

                    Student student = new Student(pupilId, login)
                    {
                        WindowStartupLocation = WindowStartupLocation,
                        Left = Left,
                        Top = Top
                    };
                    student.Show();
                    this.Close();
                }
            }
            // Выбрана роль Завод
            else if (cbx_role_signup.SelectedIndex == 1)
            {
                sqlConnection.Open();
                SqlCommand getUsername = new SqlCommand("SELECT COUNT(1) FROM Plant" +
                    " WHERE username=@username", sqlConnection);
                getUsername.CommandType = CommandType.Text;
                getUsername.Parameters.AddWithValue("@username", login);
                isExist = Convert.ToBoolean(getUsername.ExecuteScalar());
                sqlConnection.Close();

                if (isExist)
                {

                    MessageBox.Show("Такой логин уже существует");
                }
                else
                {
                    sqlConnection.Open();
                    SqlCommand addPlant = new SqlCommand("INSERT INTO Plant" +
                        " Values (@username, @password)", sqlConnection);
                    addPlant.CommandType = CommandType.Text;
                    addPlant.Parameters.AddWithValue("@username", login);
                    addPlant.Parameters.AddWithValue("@password", password);
                    addPlant.ExecuteNonQuery();
                    sqlConnection.Close();

                    Plant plant = new Plant()
                    {
                        WindowStartupLocation = WindowStartupLocation,
                        Left = Left,
                        Top = Top
                    };
                    plant.Show();
                    this.Close();
                }
            }
        }
    }
}
