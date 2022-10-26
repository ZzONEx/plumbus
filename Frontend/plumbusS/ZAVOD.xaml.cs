using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace plumbusS
{
    public partial class ZAVOD : Window
    {
        SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=PlumbusDB;Integrated Security=True");
        public ZAVOD()
        {
            InitializeComponent();
        }

        private void Enter_Key_Down(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Send_Click(sender, e);
            }
        }

        private void Назад_Click(object sender, RoutedEventArgs e)
        {
            INPUT iNPUT = new INPUT();
            iNPUT.Show();
            this.Close();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        { 
            try
            {
                int UID = Convert.ToInt32(Employee_TB.Text);
                int Norm = Convert.ToInt32(Norm_TB.Text);
                int Brak = Convert.ToInt32(Brak_TB.Text);

                if (Norm > 0)
                {
                    for (int i = 1; i <= Norm; i++)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Plumbus Values (@reject, @creator)", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@reject", 0);
                        cmd.Parameters.AddWithValue("@creator", UID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                if (Brak > 0)
                {
                    for (int i = 1; i <= Brak; i++)
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO Plumbus Values (@reject, @creator)", con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@reject", 1);
                        cmd.Parameters.AddWithValue("@creator", UID);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                MessageBox.Show("Всё прошло успешно!");
            }
            catch
            {
                MessageBox.Show("Введите корректные данные!");
            }            
        }
    }
}
