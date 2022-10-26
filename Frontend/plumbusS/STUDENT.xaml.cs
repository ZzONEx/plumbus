using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace plumbusS
{
    public partial class STUDENT : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=PlumbusDB;Integrated Security=True");        
        public int id_pupil;

        public STUDENT(int ID_pupil)
        {
            InitializeComponent();
            id_pupil = ID_pupil;
            statistica_Click(null, null);
        }

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            INPUT iNPUT = new INPUT();
            iNPUT.Show();
            this.Close();
        }

        private void homework_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand select_hw = new SqlCommand("SELECT id AS [Код ДЗ], description AS [Описание]," +
                " creation_time AS [Дата создания] FROM Homework", con);
            if (con.State == ConnectionState.Closed)
                con.Open();
            DataTable dt = new DataTable();
            SqlDataReader sdr = select_hw.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g2.ItemsSource = dt.DefaultView;
        }

        private void statistica_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand select_marks = new SqlCommand("SELECT PupilMark.id AS [Код оценки]," +
                " id_pupil AS [Код ученика], Mark.mark AS [Оценка] FROM PupilMark" +
                " LEFT JOIN Mark ON PupilMark.id_mark = Mark.id" +
                " WHERE PupilMark.id_pupil = @id_pupil", con);
            select_marks.CommandType = CommandType.Text;
            select_marks.Parameters.AddWithValue("@id_pupil", id_pupil);
            if (con.State == ConnectionState.Closed)
                con.Open();
            DataTable dt = new DataTable();
            SqlDataReader sdr = select_marks.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            g2.ItemsSource = dt.DefaultView;
        }
    }
}
