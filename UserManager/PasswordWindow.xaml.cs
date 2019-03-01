using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace UserManager
{
    /// <summary>
    /// Логика взаимодействия для PasswordWindow.xaml
    /// </summary>
    public partial class PasswordWindow : Window
    {

        public PasswordWindow()
        {
            InitializeComponent();
            txtLogin.Focus();
        }

        private void LogOn()
        {
            string login = this.txtLogin.Text;
            string password = this.passwordBox.Password;

            App application = ((App)Application.Current);

            try
            {
                application.IdentifyUser(login, password);
                this.Hide();
                MainWindow mainWindow = new MainWindow();
                mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                mainWindow.Show();
            }
            catch
            {

            }
        }
        
        private void Login_Click(object sender, RoutedEventArgs e) => LogOn();

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Application.Current.Shutdown();
        }

        private void PasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter) LogOn();
        }
    }
}