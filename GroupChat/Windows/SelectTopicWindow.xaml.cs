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
    /// Логика взаимодействия для SelectTopicWindow.xaml
    /// </summary>
    public partial class SelectTopicWindow : Window
    {
        Chatroom _chatroom;
        public SelectTopicWindow(Chatroom chatroom)
        {
            InitializeComponent();
            _chatroom = chatroom;
            this.DataContext = _chatroom;
        }
        private void BtnSAve_Click(object sender, RoutedEventArgs e)
        {
            Connection.connect.SaveChanges();
            MessageBox.Show("Saved!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
