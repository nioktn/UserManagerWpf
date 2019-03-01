using System;
using System.Windows;
using UserManager.BLL;
using UserManager.DAL;
using UserManager.Domain;

namespace UserManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listUser.Visibility = System.Windows.Visibility.Hidden;
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
            var passwordWindow = new PasswordWindow();
            passwordWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            passwordWindow.ShowDialog();
        }

        private void ShowUser(object sender, RoutedEventArgs e)
        {
            listUser.Visibility = System.Windows.Visibility.Visible;
            ShowList();
        }

        // додання до list користувачів
        private void ShowList()
        {
            listUser.Items.Clear();
            UserDataManager userDataManager = new UserDataManager();
            foreach (User user in userDataManager.GetAll())
            {
                listUser.Items.Add(user.LastName + "\t" + user.Name);
            }
        }

        // запуск форми для додавання даних
        private void AddUser(object sender, RoutedEventArgs e)
        {
            Data date = new Data();
            date.Owner = this;
            date.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            date.Show();
        }

        // додавання даних
        public void Add(User user)
        {
            try
            {
                Manager manager = new Manager();
                manager.AddUser(user);
                ShowList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // зміна даних
        private void ChangeUser(object sender, RoutedEventArgs e)
        {
            if (listUser.SelectedIndex.Equals(-1))
                MessageBox.Show("Не вибраний елемент для зміни!");
            else
            {
                Manager manager = new Manager();
                Data date = new Data(manager.getUserFromSelectedIndex(listUser.SelectedIndex), 0);
                date.Owner = this;
                date.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                date.Show();
            }
        }

        // запуск форми для зміни даних
        public void Change(User user)
        {
            Manager manager = new Manager();
            manager.ChangeUser(user, listUser.SelectedIndex);
            ShowList();
        }


        private void AppExit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void DeleteUser(object sender, RoutedEventArgs e)
        {

        }

        private void GetStyle1(object sender, RoutedEventArgs e)
        {
            DocumentRoot.Style = (Style)DocumentRoot.FindResource("GridStyle");
            menu1.Style = (Style)menu1.FindResource("MenuStyle");
            menu2.Style = (Style)menu2.FindResource("MenuStyle");
            menu3.Style = (Style)menu3.FindResource("MenuStyle");
            listUser.Style = (Style)listUser.FindResource("ListBoxStyle");
        }

        private void ExitApplication(object sender, RoutedEventArgs e)
        {

        }
    }
}