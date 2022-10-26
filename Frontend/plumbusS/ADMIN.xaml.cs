using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace plumbusS
{
    public partial class ADMIN : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=PlumbusDB;Integrated Security=True");
        public ADMIN()
        {
            InitializeComponent();
            teacher_Click(null, null);
        }
        public string role = "";
        public string column = "";

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            INPUT iNPUT = new INPUT();
            iNPUT.Show();
            this.Close();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            int uid;
            try
            {
                uid = Convert.ToInt32(textGrid.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целое число!");
                return;
            }

            if (role == "Pupil")
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                // Удаление Ученика
                SqlCommand delete_pupil = new SqlCommand("DELETE FROM Pupil WHERE id = @uid", con);
                delete_pupil.CommandType = System.Data.CommandType.Text;
                delete_pupil.Parameters.AddWithValue("@uid", uid);
                delete_pupil.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"Ученик с ИД {uid} был удален!");
            }
            else if (role == "Employee")
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                // Удаление Сотрудника
                SqlCommand delete_employee = new SqlCommand("DELETE FROM Employee WHERE id = @uid", con);
                delete_employee.CommandType = System.Data.CommandType.Text;
                delete_employee.Parameters.AddWithValue("@uid", uid);
                delete_employee.ExecuteNonQuery();
                con.Close();
                MessageBox.Show($"Сотрудник с ИД {uid} был удален!");
            }
            else
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                // Удаление Учителя, Плюмбуса или Завода
                SqlCommand delete_somebody = new SqlCommand($"DELETE FROM {role} WHERE id = @uid", con);
                delete_somebody.CommandType = System.Data.CommandType.Text;
                delete_somebody.Parameters.AddWithValue("@uid", uid);
                delete_somebody.ExecuteNonQuery();
                con.Close();
                if(role == "Plumbus")
                    MessageBox.Show($"Плюмбус с ИД {uid} был удален!");
                else
                    MessageBox.Show($"Пользователь с ИД {uid} был удален!");
            }
        }

        // Поиск пользователя по ИД
        private void search_Click(object sender, RoutedEventArgs e)
        {
            int uid;
            try
            {
                uid = Convert.ToInt32(textGrid.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целое число!");
                return;
            }
            
            if (con.State == ConnectionState.Closed)
                con.Open();
            if (role == "Pupil")
            {
                // Поиск Ученика
                SqlCommand search_pupil = new SqlCommand("SELECT Pupil.id AS [Код ученика], username AS [Имя пользователя]," +
                " password AS [Пароль], mark AS [Оценка]" +
                " FROM Pupil LEFT JOIN PupilMark ON Pupil.id = PupilMark.id_pupil" +
                " LEFT JOIN Mark ON PupilMark.id_mark = Mark.id WHERE Pupil.id = @uid" +
                " ORDER BY id_pupil", con);
                search_pupil.Parameters.AddWithValue("@uid", uid);
                DataTable dt = new DataTable();
                SqlDataReader records = search_pupil.ExecuteReader();
                dt.Load(records);
                con.Close();
                g1.ItemsSource = dt.DefaultView;
            }
            else if (role == "Employee")
            {
                // Поиск Работника
                SqlCommand search_employee = new SqlCommand("SELECT Employee.id AS [Код работника], Plumbus.id AS [Код плюмбуса]," +
                " Plumbus.reject AS [Брак] FROM Employee LEFT JOIN Plumbus ON Employee.id = Plumbus.creator" +
                " WHERE Employee.id = @uid ORDER BY Employee.id", con);
                search_employee.Parameters.AddWithValue("@uid", uid);
                DataTable dt = new DataTable();
                SqlDataReader records = search_employee.ExecuteReader();
                dt.Load(records);
                con.Close();
                g1.ItemsSource = dt.DefaultView;
            }
            else if(role == "Plumbus")
            {
                //Поиск плюмбуса
                SqlCommand search_plumbus = new SqlCommand("SELECT id AS [Код плюмбуса], reject AS [Брак]," +
                    " creator AS [Код работника] FROM Plumbus WHERE id = @uid", con);
                search_plumbus.Parameters.AddWithValue("@uid", uid);
                DataTable dt = new DataTable();
                SqlDataReader records = search_plumbus.ExecuteReader();
                dt.Load(records);
                con.Close();
                g1.ItemsSource = dt.DefaultView;
            }           
            else
            {
                if (role == "Teacher") column = "учителя";
                else column = "завода";
                // Поиск Учителя или Завода
                SqlCommand search_somebody = new SqlCommand($"SELECT id AS [Код {column}], username AS [Имя пользователя]," +
                    $" password AS [Пароль] FROM {role} WHERE id = @uid", con);
                search_somebody.Parameters.AddWithValue("@uid", uid);
                DataTable dt = new DataTable();
                SqlDataReader records = search_somebody.ExecuteReader();
                dt.Load(records);
                con.Close();
                g1.ItemsSource = dt.DefaultView;
            }
        }

        private void teacher_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT id AS [Код учителя], username AS [Имя пользователя]," +
              " password AS [Пароль] FROM Teacher", con);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Teacher";
        }

        private void student_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Pupil.id AS [Код ученика], username AS [Имя пользователя]," +
                " password AS [Пароль], mark AS [Оценка]" +
                " FROM Pupil LEFT JOIN PupilMark ON Pupil.id = PupilMark.id_pupil" +
                " LEFT JOIN Mark ON PupilMark.id_mark = Mark.id ORDER BY id_pupil", con);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Pupil";
        }

        private void Employee_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT Employee.id AS [Код работника], Plumbus.id AS [Код плюмбуса]," +
                " Plumbus.reject AS [Брак] FROM Employee LEFT JOIN Plumbus" +
                " ON Employee.id = Plumbus.creator ORDER BY Employee.id", con);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Employee";
        }

        private void plant_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT id AS [Код завода], username AS [Имя пользователя]," +
                " password AS [Пароль] FROM Plant", con);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Plant";
        }

        private void Plumbus_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT id AS [Код плюмбуса], reject AS [Брак]," +
               " creator AS [Код работника] FROM Plumbus", con);
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g1.ItemsSource = dt.DefaultView;
            role = "Plumbus";
        }
    }
}