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

namespace GroupChat
{
    public partial class MainWindow : Window
    {
        public static Employee emp;
        public MainWindow()
        {
            InitializeComponent();
            AuthorizationWindow win = new AuthorizationWindow();
            win.Show();
            this.Close();
        }
    }
}
