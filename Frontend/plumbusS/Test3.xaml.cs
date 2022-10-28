using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class Test3 : Window
    {
        public Test3()
        {
            InitializeComponent();
        }

        private void Ydheri_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"У САММЕР\"");
            Test4 test4 = new Test4();
            test4.Show();
            this.Close();
        }

        private void Yseba_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"У САММЕР\"");
            Test4 test4 = new Test4();
            test4.Show();
            this.Close();
        }

        private void Ysamer_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Вы ответили верно!");
            StreamReader f = new StreamReader("test.txt");
            string s = f.ReadLine();
            f.Close();
            int q = Convert.ToInt32(s);
            q++;
            StreamWriter x = new StreamWriter("test.txt");
            x.WriteLine(q);
            x.Close();
            Test4 test4 = new Test4();
            test4.Show();
            this.Close();
        }

        private void Yrika_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"У САММЕР\"");
            Test4 test4 = new Test4();
            test4.Show();
            this.Close();
        }
    }
}
