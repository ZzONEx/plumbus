using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace plumbusS
{
    public partial class INPUT : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=PlumbusDB;Integrated Security=True");
        public INPUT()
        {
            InitializeComponent();
        }

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void buttonbekreg_Click(object sender, RoutedEventArgs e)
        {
            REGISTR rEGISTR = new REGISTR();
            rEGISTR.Show();
            this.Close();
        }

        private void enter_key_down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                enter_Click(sender, e);
            }
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            string login = loginent.Text;
            string password = passwordB.Password;
            string query;
            int count;

            // Выбрана роль Админа
            if (cbx_role_signin.SelectedIndex == 0)
            {   
                con.Open();
                query = "SELECT COUNT(1) FROM Administrator WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", login);
                sqlCmd.Parameters.AddWithValue("@password", password);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                con.Close();

                if (count == 1)
                {
                    ADMIN admin = new ADMIN();
                    admin.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: неправильно введен логин или пароль");
                }
            }
            // Выбрана роль Учителя
            else if (cbx_role_signin.SelectedIndex == 1)
            {
                con.Open();
                query = "SELECT COUNT(1) FROM Teacher WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", login);
                sqlCmd.Parameters.AddWithValue("@password", password);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                con.Close();
                
                if (count == 1)
                {
                    teacher teacher = new teacher();
                    teacher.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: неправильно введен логин или пароль");
                }
            }
            // Выбран роль Ученика
            else if (cbx_role_signin.SelectedIndex == 2)
            {
                con.Open();
                query = "SELECT COUNT(1) FROM Pupil WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", login);
                sqlCmd.Parameters.AddWithValue("@password", password);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                con.Close();

                if (count == 1)
                {
                    // Получение ИД ученика, чтобы показывать статистику для данного ученика
                    con.Open();
                    string get_id_pupil = "SELECT * FROM Pupil WHERE username=@username AND password=@password";
                    SqlCommand cmd = new SqlCommand(get_id_pupil, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    int id_pupil = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();

                    STUDENT student = new STUDENT(id_pupil);
                    student.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: неправильно введен логин или пароль");
                }
            }
            // Выбрана роль Завода
            else if (cbx_role_signin.SelectedIndex == 3)
            {
                con.Open();
                query = "SELECT COUNT(1) FROM Plant WHERE username=@username AND password=@password";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", login);
                sqlCmd.Parameters.AddWithValue("@password", password);
                count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                con.Close();

                if (count == 1)
                {
                    ZAVOD zAVOD = new ZAVOD();
                    zAVOD.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка: неправильно введен логин или пароль");
                }
            }
        }
    }
}
