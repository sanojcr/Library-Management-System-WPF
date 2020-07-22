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
using LibraryMSWF.BL;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for UserLogin.xaml
    /// </summary>
    public partial class UserLogin : Window
    {
        public static int userId;
        public UserLogin()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ((tbUserEmail.Text != string.Empty || tbUserPass.Text != string.Empty) || (tbUserEmail.Text != string.Empty && tbUserPass.Text != string.Empty))
            {
                try
                {
                    UserBL userBL = new UserBL();
                    int isDone = userBL.UserLoginBL(tbUserEmail.Text, tbUserPass.Text);
                    if (isDone != 0)
                    {
                        userId = isDone;
                        MessageBox.Show("Logged in successfully...");
                        UserHome userHome = new UserHome();
                        userHome.Show();
                        tbUserEmail.Clear();
                        tbUserPass.Clear();
                    }
                    else
                    {
                        alertUser.Content = "Invalid email id or password...";
                        tbUserEmail.Clear();
                        tbUserPass.Clear();
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                }
            }
            else
            { 
                alertUser.Content = "Enter the fields properly...";
            }

        }
    }
}
