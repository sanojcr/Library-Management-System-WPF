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
    /// Interaction logic for AdminHome.xaml
    /// </summary>
    public partial class AdminHome : Window
    {
        //SHOW BOOK MENU USER CONTROLLER ONLY =>PL
        public AdminHome()
        {
            InitializeComponent();
            AdminBooks adminBooks = new AdminBooks();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminBooks); 
         }
        //SHOW BOOK MENU USER CONTROLLER ONLY =>PL
        private void BtnBooks_Click(object sender, RoutedEventArgs e)
        {
            
            AdminBooks adminBooks = new AdminBooks();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminBooks);
        }
        //SHOW USER MENU USER CONTROLLER ONLY =>PL
        private void BtnUsers_Click(object sender, RoutedEventArgs e)
        {
            AdminUsers adminUsers = new AdminUsers();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminUsers);
        }
        //SHOW REQUEST MENU USER CONTROLLER ONLY =>PL
        private void BtnRequests_Click(object sender, RoutedEventArgs e)
        {
            AdminRequests adminRequests = new AdminRequests();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminRequests);

        }
        //SHOW ACCEPTED MENU USER CONTROLLER ONLY =>PL
        private void BtnAccepted_Click(object sender, RoutedEventArgs e)
        {
            AdminAccepted adminAccepted = new AdminAccepted();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminAccepted);

        }
        //LOGOUT ADMIN HOME =>PL
        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        //SHOW RETURB MENU USER CONTROLLER ONLY =>PL
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            AdminReturn adminReturn = new AdminReturn();
            adminStackPanel.Children.Clear();
            adminStackPanel.Children.Add(adminReturn);
        }
    }
}
