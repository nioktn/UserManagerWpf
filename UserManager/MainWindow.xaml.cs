using System.Windows;

namespace UserManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            var passwordWindow = new PasswordWindow();
            passwordWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            passwordWindow.ShowDialog();
        }
        
        private void AppExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();                
    }
}