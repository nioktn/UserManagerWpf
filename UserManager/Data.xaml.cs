using System.Windows;
using UserManager.Domain;

namespace UserManager
{
    /// <summary>
    /// Логика взаимодействия для Date.xaml
    /// </summary>
    public partial class Data : Window
    {
        int add = 1;
        public Data()
        {
            InitializeComponent();
            this.Title = "Введіть дані";
        }

        public Data(User user, int add)
        {
            InitializeComponent();
            this.Title = "Змініть дані користувача";
            fam.Text = user.LastName;
            nm.Text = user.Name;
            log.Text = user.Login;
            pass.Text = user.Password;
            act.Text = user.Active.ToString();
            this.add = add;
        }

        private void Cancle_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mwind = this.Owner as MainWindow;
            if (fam.Text == string.Empty || nm.Text == string.Empty || log.Text == string.Empty ||
                pass.Text == string.Empty || act.Text == string.Empty)
            {
                MessageBox.Show("Не введені данні");
            }
            else
            {
                User user = new User(fam.Text, nm.Text, log.Text, pass.Text, int.Parse(act.Text));
                if (add.Equals(1))
                    mwind.Add(user);
                else
                    mwind.Change(user);
                mwind.Show();
                this.Close();
            }
        }
    }
}
