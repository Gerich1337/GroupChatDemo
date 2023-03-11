using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GroupChat.DB;
using GroupChat.Classes;
using GroupChat.Windows;

namespace GroupChat.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }
        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PBPassword.Password) || string.IsNullOrEmpty(TBLogin.Text))
            {
                MessageBox.Show("Please fill in the fields", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var employee = Connection.connect.Employee.Where(z => z.Password == PBPassword.Password && z.Username == TBLogin.Text).FirstOrDefault();
                if (employee!= null)
                {
                    MainWindow.emp = employee;
                    UsersWindow usersWindow = new UsersWindow();
                    usersWindow.Show();
                    MessageBox.Show($"Welcome {employee.Name}", "Login", MessageBoxButton.OK, MessageBoxImage.Information);
                    App.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Authorization error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
