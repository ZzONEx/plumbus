using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class test1 : Window
    {
        public test1()
        {
            InitializeComponent();
        }

        private void gazorp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"МОРТИ МЛАДШИЙ\"");
            test2 test2 = new test2();
            test2.Show();
            this.Close();
        }

        private void ralf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"МОРТИ МЛАДШИЙ\"");
            test2 test2 = new test2();
            test2.Show();
            this.Close();
        }

        private void mortimalen_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы ответили верно!");
            StreamReader f = new StreamReader("test.txt");
            string s = f.ReadLine();
            f.Close();
            int q = Convert.ToInt32(s);
            q = q + 1;
            StreamWriter x = new StreamWriter("test.txt");
            x.WriteLine(q);
            x.Close();
            test2 test2 = new test2();
            test2.Show();
            this.Close();
        }

        private void minimorti_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"МОРТИ МЛАДШИЙ\"");
            test2 test2 = new test2();
            test2.Show();
            this.Close();
        }
    }
}
