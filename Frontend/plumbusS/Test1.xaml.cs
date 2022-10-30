using System.Windows;
using System.Windows.Controls;

namespace plumbusS
{
    public partial class Test1 : Window
    {
        public Test1()
        {
            InitializeComponent();
        }

        private void ChoiceOfAnswer_Click(object sender, RoutedEventArgs e)
        {
            int score = 0;
            // Получаем кнопку, которая вызвала данную функцию
            Button srcButton = e.Source as Button;

            if (srcButton.Name == "mortimalen")
            {
                score++;
                MessageBox.Show($"Вы ответили верно!\nВаш счёт: {score}");
            }
            else
            {
                MessageBox.Show($"Вы ответили неверно!\nВаш счёт: {score}");
            }
            Test2 test2 = new Test2(score);
            test2.Show();
            Close();
        }
    }
}
