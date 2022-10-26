using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace plumbusS
{
    public partial class teacher : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=PlumbusDB;Integrated Security=True");
        public teacher()
        {
            InitializeComponent();
        }

        private void Enter_Key_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                otpravit_Click(sender, e);
            }
        }

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            INPUT input = new INPUT();
            input.Show();
            this.Close();
        }

        private void otpravit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string homework = DZ.Text;
                int id_pupil = Convert.ToInt32(idychenik.Text);
                int mark = Convert.ToInt32(score.Text);
                int id_mark = 0;

                // Добавление домашнего задания
                if (homework.Length > 0)
                {
                    SqlCommand add_homework = new SqlCommand("INSERT INTO Homework (description) VALUES (@description)", con);
                    add_homework.CommandType = System.Data.CommandType.Text;
                    add_homework.Parameters.AddWithValue("@description", homework);
                    con.Open();
                    add_homework.ExecuteNonQuery();
                    con.Close();
                }

                // Добавление оценки ученику
                if(id_pupil > 0)
                {
                    if (mark < 2 || mark > 5)
                    {
                        MessageBox.Show("Оценки только от 2 до 5!");
                        return;
                    }
                    else
                    {
                        id_mark = mark - 1;
                        SqlCommand add_mark = new SqlCommand("INSERT INTO PupilMark VALUES (@id_mark, @id_pupil)", con);
                        add_mark.CommandType = System.Data.CommandType.Text;
                        add_mark.Parameters.AddWithValue("@id_pupil", id_pupil);
                        add_mark.Parameters.AddWithValue("@id_mark", id_mark);
                        con.Open();
                        add_mark.ExecuteNonQuery();
                        con.Close();
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
