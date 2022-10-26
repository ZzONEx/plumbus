using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class test2 : Window
    {
        public test2()
        {
            InitializeComponent();
        }

        private void krombopulus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ЮНИТИ\"");
            test3 test3 = new test3();
            test3.Show();
            this.Close();
        }

        private void karandahylik_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ЮНИТИ\"");
            test3 test3 = new test3();
            test3.Show();
            this.Close();
        }

        private void misiks_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ЮНИТИ\"");
            test3 test3 = new test3();
            test3.Show();
            this.Close();
        }

        private void yniti_Click(object sender, RoutedEventArgs e)
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
            test3 test3 = new test3();
            test3.Show();
            this.Close();
        }
    }
}
