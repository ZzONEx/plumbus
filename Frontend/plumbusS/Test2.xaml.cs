using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class Test2 : Window
    {
        public Test2()
        {
            InitializeComponent();
        }

        private void Krombopulus_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ЮНИТИ\"");
            Test3 test3 = new Test3();
            test3.Show();
            this.Close();
        }

        private void Karandahylik_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ЮНИТИ\"");
            Test3 test3 = new Test3();
            test3.Show();
            this.Close();
        }

        private void Misiks_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ЮНИТИ\"");
            Test3 test3 = new Test3();
            test3.Show();
            this.Close();
        }

        private void Uniti_Click(object sender, RoutedEventArgs e)
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
            Test3 test3 = new Test3();
            test3.Show();
            this.Close();
        }
    }
}
