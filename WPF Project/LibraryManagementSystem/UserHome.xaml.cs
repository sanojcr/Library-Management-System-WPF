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

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for UserHome.xaml
    /// </summary>
    public partial class UserHome : Window
    {
        public UserHome()
        {
            InitializeComponent();
            UserBorrow userBorrow = new UserBorrow();
            userStackPanel.Children.Clear();
            userStackPanel.Children.Add(userBorrow);
        }
        //SHOW BOOK BORROW MENU
        private void BtnBorrow_Click(object sender, RoutedEventArgs e)
        {
            UserBorrow userBorrow = new UserBorrow();
            userStackPanel.Children.Clear();
            userStackPanel.Children.Add(userBorrow);
        }
        //SHOW BOOK REQUEST AND BOOK RECIEVED MENU
        private void BtnTransaction_Click(object sender, RoutedEventArgs e)
        {
            UserTransaction userTransaction = new UserTransaction();
            userStackPanel.Children.Clear();
            userStackPanel.Children.Add(userTransaction);
        }
        //LOGOUT USER HOME
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
