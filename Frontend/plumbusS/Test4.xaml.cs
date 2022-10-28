using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class Test4 : Window
    {
        public Test4()
        {
            InitializeComponent();
        }

        private void Popygai_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ДЕНЬГИ\"");
            StreamReader f = new StreamReader("test.txt");
            string s = f.ReadLine();
            f.Close();
            int q = Convert.ToInt32(s);
            StreamWriter x = new StreamWriter("test.txt");
            x.WriteLine(q);
            x.Close();
            MessageBox.Show($"Вы набрали {q} баллов");
        }

        private void Ingridient_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ДЕНЬГИ\"");
            StreamReader f = new StreamReader("test.txt");
            string s = f.ReadLine();
            f.Close();
            int q = Convert.ToInt32(s);
            StreamWriter x = new StreamWriter("test.txt");
            x.WriteLine(q);
            x.Close();
            MessageBox.Show($"Вы набрали {q} баллов");
        }

        private void Planet_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ответ неверный. Правильный ответ: \"ДЕНЬГИ\"");
            StreamReader f = new StreamReader("test.txt");
            string s = f.ReadLine();
            f.Close();
            int q = Convert.ToInt32(s);
            StreamWriter x = new StreamWriter("test.txt");
            x.WriteLine(q);
            x.Close();
            MessageBox.Show($"Вы набрали {q} баллов");
        }

        private void Money_Click(object sender, RoutedEventArgs e)
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
            MessageBox.Show($"Вы набрали {q} баллов");
        }

        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
