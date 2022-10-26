using System.Windows;

namespace plumbusS
{
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            REGISTR registr = new REGISTR();
            registr.Show();
            this.Close();
                
        }

        private void protest_Click(object sender, RoutedEventArgs e)
        {
            test1 test1 = new test1(); 
            test1.Show();
            this.Close();
        }
    }
}
