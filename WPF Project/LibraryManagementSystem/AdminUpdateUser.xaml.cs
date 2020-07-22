using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AdminUpdateUser.xaml
    /// </summary>
    public partial class AdminUpdateUser : Window
    {
        public int userId;
        //INITIALIZE THE USERS UPDATE =>PL
        public AdminUpdateUser()
        {
            InitializeComponent();
            userId = AdminUsers.updateUser.UserId;
            tbUName.Text = AdminUsers.updateUser.UserName;
            tbUAdNo.Text = AdminUsers.updateUser.UserAdNo.ToString();
            tbUEmail.Text = AdminUsers.updateUser.UserEmail;
            tbUPass.Text = AdminUsers.updateUser.UserPass;
        }
        //UPDATE USER DETAILS FROM USER TABLE
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbUName.Text != string.Empty && tbUAdNo.Text != string.Empty && tbUEmail.Text != string.Empty && tbUPass.Text != string.Empty)
            {
                try
                {
                    UserBL userBL = new UserBL();
                    string isDone = userBL.UpdateUserBL(userId, tbUName.Text, int.Parse(tbUAdNo.Text), tbUEmail.Text, tbUPass.Text);
                    if (isDone == "true")
                    {
                        MessageBox.Show("User updated successfuly..");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(isDone + " Try later..");
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Invalid Admission number!!!,\nIt should not be a string, Try again..");
                }
                catch (Exception)
                {
                    MessageBox.Show("Some unknown exception is occured!!!, Try again..");
                }
            }
            else
            {
                MessageBox.Show("Enter the fields properly!!!, Every field is required..");
            }
        }
    }
}
