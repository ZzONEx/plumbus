using System;
using System.Data.SqlClient;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Data;

namespace plumbusS
{
    public partial class REGISTR : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=PlumbusDB;Integrated Security=True");
        public REGISTR()
        {
            InitializeComponent();
        }

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void enter_key_down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Button_Click_1(sender, e);
            }
        }

        // Переход на окно входа
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            INPUT iNPUT = new INPUT();
            iNPUT.Show();
            this.Close();
        }

        // Регистрация Ученика/Завода
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Random rndr = new Random();
            int pupil_group = rndr.Next(1, 5);

            string login = loginreg.Text;
            string password = pass.Password;
            string password2 = pass2.Password;

            if ((login.Length == 0 || password.Length == 0) || (password != password2) ||
                    (login.Any(Char.IsWhiteSpace) || password.Any(Char.IsWhiteSpace)))
                {
                    MessageBox.Show("Логин или пароль введен неверно!");
                    return;
                }
            
            // Выбрана роль Ученик
            if (cbx_role_signup.SelectedIndex == 0)
            {
                con.Open();
                string query = "SELECT COUNT(1) FROM Pupil WHERE username=@username";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", login);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                con.Close();

                if (count == 1)
                    MessageBox.Show("Такой логин уже существует");
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Pupil Values (@username, @password, @pupil_group)", con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.Parameters.AddWithValue("@pupil_group", pupil_group);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    // Получение ИД ученика, чтобы показывать статистику для данного ученика
                    con.Open();
                    SqlCommand get_id_pupil = new SqlCommand("SELECT id FROM Pupil" +
                        " WHERE username = @username AND password = @password", con);
                    get_id_pupil.CommandType = CommandType.Text;
                    get_id_pupil.Parameters.AddWithValue("@username", login);
                    get_id_pupil.Parameters.AddWithValue("@password", password);
                    get_id_pupil.ExecuteNonQuery();
                    int id_pupil = Convert.ToInt32(get_id_pupil.ExecuteScalar());
                    con.Close();

                    STUDENT sTUDENT = new STUDENT(id_pupil);
                    sTUDENT.Show();
                    this.Close();
                }
            }
            // Выбрана роль Завод
            else if (cbx_role_signup.SelectedIndex == 1)
            {
                con.Open();
                string query = "SELECT COUNT(1) FROM Plant WHERE username=@username";
                SqlCommand sqlCmd = new SqlCommand(query, con);
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.Parameters.AddWithValue("@username", login);
                int count = Convert.ToInt32(sqlCmd.ExecuteScalar());
                con.Close();

                if (count == 1)
                    MessageBox.Show("Такой логин уже существует");
                else
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO Plant Values (@username, @password)", con);
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Parameters.AddWithValue("@username", login);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ZAVOD zAVOD = new ZAVOD();
                    zAVOD.Show();
                    this.Close();
                }
            }
        }
    }
}
