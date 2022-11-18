using System.Windows;

namespace plumbusS
{
    /*
     * This application was developed by students of UETK SGU:
     *      Maksim - TeamLeader
     *      Konstantin - Front-end
     *      Mikhail - Back-end
     *      Egor - FullStack
     *      Nikita - Tester
     */
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ToRegistration_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = new Registration()
            {
                WindowStartupLocation = WindowStartupLocation,
                Left = Left,
                Top = Top
            };
            registration.Show();
            this.Close();
        }
        
        private void RunTest_Click(object sender, RoutedEventArgs e)
        {
            Test1 test1 = new Test1()
            {
                WindowStartupLocation = WindowStartupLocation,
                Left = Left,
                Top = Top
            };
            test1.Show();
            this.Close();
        }
    }
}
