using System.Windows;
using System.Windows.Controls;

namespace plumbusS
{
    public partial class Test3 : Window
    {
        private int score;

        public Test3(int score)
        {
            this.score = score;
            InitializeComponent();
        }

        private void ChoiceOfAnswer_Click(object sender, RoutedEventArgs e)
        {
            // Получаем кнопку, которая вызвала данную функцию
            Button srcButton = e.Source as Button;

            if (srcButton.Name == "ysamer")
            {
                score++;
                MessageBox.Show($"Вы ответили верно!\nВаш счёт: {score}");
            }
            else
            {
                MessageBox.Show($"Вы ответили неверно!\nВаш счёт: {score}");
            }
            Test4 test4 = new Test4(score);
            test4.Show();
            Close();
        }
    }
}
