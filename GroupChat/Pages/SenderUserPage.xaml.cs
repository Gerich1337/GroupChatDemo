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
using System.Windows.Navigation;
using System.Windows.Shapes;
using GroupChat.DB;
using GroupChat.Classes;
using GroupChat.Windows;
using GroupChat.Pages;

namespace GroupChat.Pages
{
    public partial class SenderUserPage : Page
    {
        public SenderUserPage()
        {
            InitializeComponent();
        }
         public static Employee _employee;
        public SenderUserPage(Employee employee)
        {
            InitializeComponent();
            _employee = employee;
            this.DataContext = _employee;
            LvChats.ItemsSource = Connection.connect.Chatroom.ToList();
        }

        //private void BtnSearch_Click(object sender, RoutedEventArgs e)
        //{
        //    NavigationService.Navigate(new EmployeeSearchPage(0));
        //}

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void LvChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var b = Connection.connect.EmployeesChatrooms.Where(z => z.EmployeesID == _employee.ID).FirstOrDefault();
            if (b != null)
            {
                var a = ((sender as ListView).SelectedItem as Chatroom);
                NavigationService.Navigate(new ChatroomPage(a));
            }
            else
            {
                MessageBox.Show("You are not a member of this chat", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
