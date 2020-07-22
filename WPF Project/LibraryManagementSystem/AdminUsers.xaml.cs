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
using System.Data;
using LibraryMSWF.BL;
using LibraryMSWF.Entity;
using System.Collections.ObjectModel;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminUsers.xaml
    /// </summary>
    public partial class AdminUsers : UserControl
    {
        public static User updateUser = new User();
        //INITIALIZE THE USERS GV =>PL
        public AdminUsers()
        {
            InitializeComponent();
            InitializeAdminUsers();
        }
        public void InitializeAdminUsers()
        {
            try
            {
                UserBL userBl = new UserBL();
                DataSet ds = userBl.GetAllUsersBL();
                ObservableCollection<User> lst = new ObservableCollection<User>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(new User
                    {
                        UserName = Convert.ToString(dr["UserName"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserEmail = Convert.ToString(dr["UserEmail"]),
                        UserPass = Convert.ToString(dr["UserPass"]),
                        UserAdNo = Convert.ToInt32(dr["UserAdNo"]),

                    });
                }
                dgUsers.ItemsSource = lst;
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
        //OPEN UPDATE USER WINDOW
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = dgUsers.SelectedItem as User;
                if (user != null)
                {
                    updateUser = user;
                    AdminUpdateUser adminUpdateUser = new AdminUpdateUser();
                    adminUpdateUser.Show();
                }
                else
                {
                    MessageBox.Show("Select a user to update...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
        //DELTE USER FROM USER TABLE
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = dgUsers.SelectedItem as User;
                if (user != null)
                {
                    UserBL userBL = new UserBL();
                    bool isDone = userBL.DeleteUserBL(user.UserId);
                    if (isDone == true)
                    {
                        MessageBox.Show("User deleted successfully...");
                        InitializeAdminUsers();
                    }
                    else
                    {
                        MessageBox.Show("Server is in maintainance try again later...");
                    }
                }
                else
                {
                    MessageBox.Show("Select a user to delete...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
        //OPEN ADD USER WINDOW =>PL
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminAddUser adminAddUser = new AdminAddUser();
            adminAddUser.Show();
        }
    }
    
}
