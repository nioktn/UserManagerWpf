using System;
using System.Windows;
using UserManager.BLL;
using UserManager.Domain;

namespace UserManager
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        // Властивості класу App
        // Відкриті властивості доступні в всих об'єктах додатку
        public User User = null;

        private PasswordWindow passwordWindow = new PasswordWindow();

        private void AppStartUp(object sender, StartupEventArgs args)
        {
            try
            {

                this.passwordWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                passwordWindow.ShowDialog();
                if (this.User != null && User.Active == 1)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;

                }
                else
                {
                    this.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AppExit(Object sender, ExitEventArgs e)
        {
            // Закриття вікна запросу пароля
            this.passwordWindow.Close();
            // Закриття додатку
            this.Shutdown();
        }

        public void IdentifyUser(string login, string password)
        {
            try
            {
                Manager userManager = new Manager();
                User user = userManager.GetUser(login, password);

                if (user != null)
                {
                    this.User = user;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
        }
    }
}
