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

namespace GroupChat.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChatroomPage.xaml
    /// </summary>
    public partial class ChatroomPage : Page
    {
        public ChatroomPage()
        {
            InitializeComponent();
        }
        public Chatroom _chatroom;
        public ChatMessage message;
        public Employee employee;
        public EmployeesChatrooms roomChat;
        public ChatroomPage(Chatroom chatroom)
        {
            InitializeComponent();
            var chat = chatroom.Id;
            LvUser.ItemsSource = Connection.connect.EmployeesChatrooms.Where(z => z.ChatroomsID == chat).ToList();
            _chatroom = chatroom;
            this.DataContext = _chatroom;
            LvMessages.ItemsSource = Connection.connect.ChatMessage.Where(z => z.ChatroomID == chatroom.Id).ToList();
        }

        private void Refreshmessage()
        {
            LvMessages.ItemsSource = Connection.connect.ChatMessage.Where(z => z.ChatroomID == _chatroom.Id).ToList();
        }
        private void BtnAddUser_Click(object sender, RoutedEventArgs e)
        {
            //NavigationService.Navigate(new EmployeeSearchPage(_chatroom.Id_Chatroom));
        }

        private void BtnChangeTopic_Click(object sender, RoutedEventArgs e)
        {
            SelectTopicWindow selectTopic = new SelectTopicWindow(_chatroom);
            selectTopic.Show();
        }

        private void LeaveChatroom_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMessage.Text))
            {
                MessageBox.Show("You can't send an empty message!!!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var message = new ChatMessage()
                {
                    SenderID = MainWindow.emp.ID,
                    ChatroomID = _chatroom.Id,
                    Date = DateTime.Now,
                    Message = TxtMessage.Text,
                };
                Connection.connect.ChatMessage.Add(message);
                Connection.connect.SaveChanges();
                Refreshmessage();
                TxtMessage.Text = "";
            }

        }
    }
}
