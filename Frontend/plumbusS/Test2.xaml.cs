using System.Windows;
using System.Windows.Controls;

namespace plumbusS
{
    public partial class Test2 : Window
    {
        private int score;

        public Test2(int score)
        {
            this.score = score;
            InitializeComponent();
        }

        private void ChoiceOfAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, которая вызвала данную функцию
            Button srcButton = e.Source as Button;

            if (srcButton.Name == "yniti")
            {
                score++;
                MessageBox.Show($"Вы ответили верно!\nВаш счёт: {score}");
            }
            else
            {
                MessageBox.Show($"Вы ответили неверно!\nВаш счёт: {score}");
            }
            Test3 test3 = new Test3(score);
            test3.Show();
            Close();
        }
    }
}
