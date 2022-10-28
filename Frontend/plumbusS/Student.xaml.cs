using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace plumbusS
{
    public partial class Student : Window
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["PlumbusDBConnection"].ConnectionString);
        public int pupilId;

        public Student(int pupilID)
        {
            InitializeComponent();
            pupilId = pupilID;
            GetStatistics_Click(null, null);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }

        private void GetHomework_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getHomeworks = new SqlCommand("SELECT id AS [Код ДЗ], description AS [Описание]," +
                " creation_time AS [Дата создания] FROM Homework", sqlConnection);
            SqlDataReader records = getHomeworks.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(records);
            sqlConnection.Close();
            g2.ItemsSource = dt.DefaultView;
        }
        
        private void GetStatistics_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection.Open();
            SqlCommand getMarks = new SqlCommand("SELECT PupilMark.id AS [Код оценки]," +
                " id_pupil AS [Код ученика], Mark.mark AS [Оценка] FROM PupilMark" +
                " LEFT JOIN Mark ON PupilMark.id_mark = Mark.id" +
                " WHERE PupilMark.id_pupil = @id_pupil", sqlConnection);
            getMarks.CommandType = CommandType.Text;
            getMarks.Parameters.AddWithValue("@id_pupil", pupilId);
            SqlDataReader records = getMarks.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(records);
            sqlConnection.Close();
            g2.ItemsSource = dt.DefaultView;
        }
    }
}
