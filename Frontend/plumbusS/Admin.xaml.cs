using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace plumbusS
{
    public partial class Admin : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlumbusDBConnection"].ConnectionString);
        public Admin()
        {
            InitializeComponent();
            GetTeachers_Click(null, null);
        }
        string role = "";
        string column = "";

        private void EnterKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchUserById_Click(null, null);
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

        private void DeleteUserById_Click(object sender, RoutedEventArgs e)
        {
            int userId;
            try
            {
                userId = Convert.ToInt32(textGrid.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целое число!");
                return;
            }

            // Удаление Ученика
            if (role == "Pupil")
            {
                sqlConnection.Open();
                SqlCommand deletePupil = new SqlCommand("DELETE FROM Pupil" +
                    " WHERE id = @uid", sqlConnection);
                deletePupil.CommandType = CommandType.Text;
                deletePupil.Parameters.AddWithValue("@uid", userId);
                deletePupil.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show($"Ученик с ИД {userId} был удален!");
            }
            // Удаление Сотрудника
            else if (role == "Employee")
            {
                sqlConnection.Open();
                SqlCommand deleteEmployee = new SqlCommand("DELETE FROM Employee" +
                    " WHERE id = @uid", sqlConnection);
                deleteEmployee.CommandType = CommandType.Text;
                deleteEmployee.Parameters.AddWithValue("@uid", userId);
                deleteEmployee.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show($"Сотрудник с ИД {userId} был удален!");
            }
            // Удаление Учителя, Плюмбуса или Завода
            else
            {
                sqlConnection.Open();
                SqlCommand deleteUser = new SqlCommand($"DELETE FROM {role}" +
                    $" WHERE id = @uid", sqlConnection);
                deleteUser.CommandType = CommandType.Text;
                deleteUser.Parameters.AddWithValue("@uid", userId);
                deleteUser.ExecuteNonQuery();
                sqlConnection.Close();
                if(role == "Plumbus")
                    MessageBox.Show($"Плюмбус с ИД {userId} был удален!");
                else
                    MessageBox.Show($"Пользователь с ИД {userId} был удален!");
            }
        }

        private void SearchUserById_Click(object sender, RoutedEventArgs e)
        {
            int userId;
            try
            {
                userId = Convert.ToInt32(textGrid.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целое число!");
                return;
            }
            
            sqlConnection.Open();
            if (role == "Pupil")
            {
                // Поиск Ученика
                SqlCommand getPupils = new SqlCommand("SELECT Pupil.id AS [Код ученика], username AS [Имя пользователя]," +
                " password AS [Пароль], mark AS [Оценка]" +
                " FROM Pupil LEFT JOIN PupilMark ON Pupil.id = PupilMark.id_pupil" +
                " LEFT JOIN Mark ON PupilMark.id_mark = Mark.id WHERE Pupil.id = @uid" +
                " ORDER BY id_pupil", sqlConnection);
                getPupils.Parameters.AddWithValue("@uid", userId);
                DataTable dt = new DataTable();
                SqlDataReader records = getPupils.ExecuteReader();
                dt.Load(records);
                sqlConnection.Close();
                g1.ItemsSource = dt.DefaultView;
            }
            else if (role == "Employee")
            {
                SqlCommand getEmployees = new SqlCommand("SELECT Employee.id AS [Код работника], Plumbus.id AS [Код плюмбуса]," +
                " Plumbus.reject AS [Брак] FROM Employee LEFT JOIN Plumbus ON Employee.id = Plumbus.creator" +
                " WHERE Employee.id = @uid ORDER BY Employee.id", sqlConnection);
                getEmployees.Parameters.AddWithValue("@uid", userId);
                DataTable dt = new DataTable();
                SqlDataReader records = getEmployees.ExecuteReader();
                dt.Load(records);
                sqlConnection.Close();
                g1.ItemsSource = dt.DefaultView;
            }
            else if(role == "Plumbus")
            {
                SqlCommand getPlumbuses = new SqlCommand("SELECT id AS [Код плюмбуса], reject AS [Брак]," +
                    " creator AS [Код работника] FROM Plumbus WHERE id = @uid", sqlConnection);
                getPlumbuses.Parameters.AddWithValue("@uid", userId);
                DataTable dt = new DataTable();
                SqlDataReader records = getPlumbuses.ExecuteReader();
                dt.Load(records);
                sqlConnection.Close();
                g1.ItemsSource = dt.DefaultView;
            }           
            else
            {
                if (role == "Teacher")
                {
                    column = "учителя";
                }
                else
                {
                    column = "завода";
                }
                SqlCommand getUsers = new SqlCommand($"SELECT id AS [Код {column}], username AS [Имя пользователя]," +
                    $" password AS [Пароль] FROM {role} WHERE id = @uid", sqlConnection);
                getUsers.Parameters.AddWithValue("@uid", userId);
                DataTable dt = new DataTable();
                SqlDataReader records = getUsers.ExecuteReader();
                dt.Load(records);
                sqlConnection.Close();
                g1.ItemsSource = dt.DefaultView;
            }
        }

        private void GetTeachers_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getTeachers = new SqlCommand("SELECT id AS [Код учителя], username AS [Имя пользователя]," +
              " password AS [Пароль] FROM Teacher", sqlConnection);
            DataTable dt = new DataTable();
            SqlDataReader records = getTeachers.ExecuteReader();
            dt.Load(records);
            sqlConnection.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Teacher";
        }

        private void GetPupils_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getPupils = new SqlCommand("SELECT Pupil.id AS [Код ученика], username AS [Имя пользователя]," +
                " password AS [Пароль], mark AS [Оценка]" +
                " FROM Pupil LEFT JOIN PupilMark ON Pupil.id = PupilMark.id_pupil" +
                " LEFT JOIN Mark ON PupilMark.id_mark = Mark.id ORDER BY id_pupil", sqlConnection);
            DataTable dt = new DataTable();
            SqlDataReader records = getPupils.ExecuteReader();
            dt.Load(records);
            sqlConnection.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Pupil";
        }

        private void GetEmployees_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getEmployees = new SqlCommand("SELECT Employee.id AS [Код работника], Plumbus.id AS [Код плюмбуса]," +
                " Plumbus.reject AS [Брак] FROM Employee LEFT JOIN Plumbus" +
                " ON Employee.id = Plumbus.creator ORDER BY Employee.id", sqlConnection);
            DataTable dt = new DataTable();
            SqlDataReader records = getEmployees.ExecuteReader();
            dt.Load(records);
            sqlConnection.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Employee";
        }

        private void GetPlants_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getPlants = new SqlCommand("SELECT id AS [Код завода], username AS [Имя пользователя]," +
                " password AS [Пароль] FROM Plant", sqlConnection);
            DataTable dt = new DataTable();
            SqlDataReader records = getPlants.ExecuteReader();
            dt.Load(records);
            sqlConnection.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Plant";
        }

        private void GetPlumbuses_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getPlumbuses = new SqlCommand("SELECT id AS [Код плюмбуса], reject AS [Брак]," +
               " creator AS [Код работника] FROM Plumbus", sqlConnection);
            DataTable dt = new DataTable();
            SqlDataReader records = getPlumbuses.ExecuteReader();
            dt.Load(records);
            sqlConnection.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Plumbus";
        }
    }
}