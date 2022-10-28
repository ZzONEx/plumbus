using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class Test1 : Window
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void Gazorp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"МОРТИ МЛАДШИЙ\"");
            Test2 test2 = new Test2();
            test2.Show();
            this.Close();
        }

        private void Ralf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"МОРТИ МЛАДШИЙ\"");
            Test2 test2 = new Test2();
            test2.Show();
            this.Close();
        }

        private void Mortimalen_Click(object sender, RoutedEventArgs e)
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
            Test2 test2 = new Test2();
            test2.Show();
            this.Close();
        }

        private void Minimorti_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"МОРТИ МЛАДШИЙ\"");
            Test2 test2 = new Test2();
            test2.Show();
            this.Close();
        }
    }
}
