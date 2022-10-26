using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class test3 : Window
    {
        public test3()
        {
            InitializeComponent();
        }

        private void ydheri_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"У САММЕР\"");
            test4 test4 = new test4();
            test4.Show();
            this.Close();
        }

        private void yseba_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"У САММЕР\"");
            test4 test4 = new test4();
            test4.Show();
            this.Close();
        }

        private void ysamer_Click(object sender, RoutedEventArgs e)
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
            test4 test4 = new test4();
            test4.Show();
            this.Close();
        }

        private void yrika_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"У САММЕР\"");
            test4 test4 = new test4();
            test4.Show();
            this.Close();
        }
    }
}
