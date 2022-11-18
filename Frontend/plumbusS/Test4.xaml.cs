using System.Windows;
using System.Windows.Controls;

namespace plumbusS
{
    public partial class Test4 : Window
    {
        private int score;
        private bool flag = true;

        public Test4(int score)
        {
            this.score = score;
            InitializeComponent();
        }

        private void ChoiceOfAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, которая вызвала данную функцию
            Button srcButton = e.Source as Button;

            if (srcButton.Name == "money")
            {
                if (flag == true)
                {
                    score++;
                }
                MessageBox.Show($"Вы ответили верно!\nВаш счёт: {score}");
            }
            else
            {
                MessageBox.Show($"Вы ответили неверно!\nВаш счёт: {score}");
            }
            flag = false;
        }

        private void ToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow()
            {
                WindowStartupLocation = WindowStartupLocation,
                Left = Left,
                Top = Top
            };
            mainWindow.Show();
            Close();
        } 
    }
}
