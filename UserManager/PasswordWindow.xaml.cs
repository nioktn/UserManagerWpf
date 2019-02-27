using System;
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

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            this.LogOn();
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            App application = ((App)Application.Current);
            this.Close();
            application.Shutdown();
        }
    }
}