using System;
using System.IO;
using System.Windows;

namespace plumbusS
{
    public partial class test4 : Window
    {
        public test4()
        {
            InitializeComponent();
        }

        private void popygai_Click(object sender, RoutedEventArgs e)
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

        private void ingridient_Click(object sender, RoutedEventArgs e)
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

        private void planet_Click(object sender, RoutedEventArgs e)
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

        private void money_Click(object sender, RoutedEventArgs e)
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
            MessageBox.Show($"Вы набрали {q} баллов");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
