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
using LibraryMSWF.BL;
using LibraryMSWF.Entity;
using System.Data;
using System.Collections.ObjectModel;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for UserTransaction.xaml
    /// </summary>
    public partial class UserTransaction : UserControl
    {
        public int userId;
        //INITIALIZE THE REQUEST GV AND RETURN GV =>PL
        public UserTransaction()
        {
            InitializeComponent();
            InitializeUserTransaction();
        }
        public void InitializeUserTransaction()
        {
            try
            {
                userId = UserLogin.userId;
                UserRequestBL userRequestBL = new UserRequestBL();
                DataSet ds1 = userRequestBL.GetAllRequestUserBL(userId);
                ObservableCollection<RequestedBook> lstRequest = new ObservableCollection<RequestedBook>();
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    lstRequest.Add(new RequestedBook
                    {
                        BookName = Convert.ToString(dr["BookName"]),
                        BookId = Convert.ToInt32(dr["BookId"]),
                        DateRequested = Convert.ToString(Convert.ToDateTime(dr["DateRequested"]).ToShortDateString()),
                    }); ;
                }
                dgRequest.ItemsSource = lstRequest;

                UserRecieveBL userRecieveBL = new UserRecieveBL();
                DataSet ds2 = userRecieveBL.GetAllRecieveUserBL(userId);
                ObservableCollection<AcceptedBook> lstReceived = new ObservableCollection<AcceptedBook>();
                foreach (DataRow dr2 in ds2.Tables[0].Rows)
                {
                    lstReceived.Add(new AcceptedBook
                    {
                        BookName = Convert.ToString(dr2["BookName"]),
                        BookId = Convert.ToInt32(dr2["BookId"]),
                        DateRecieved = Convert.ToString(Convert.ToDateTime(dr2["DateRecieved"]).ToShortDateString()),
                    }); ;
                }
                dgReturn.ItemsSource = lstReceived;
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
        //RETURN RECIEVED BOOK FROM RECIEVED BOOK TABLE
        private void BtnReturn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AcceptedBook accepted = dgReturn.SelectedItem as AcceptedBook;
                if (accepted != null)
                {
                    UserReturnBL userReturnBL = new UserReturnBL();
                    bool isDone3 = userReturnBL.AddReturnBL(accepted.BookId, accepted.BookName, userId);
                    UserRecieveBL userRecieveBL = new UserRecieveBL();
                    bool isDone1 = userRecieveBL.DeleteRecieveBL(accepted.BookId, userId);
                    /*BookBL bookBL = new BookBL();
                    bool isDone2 = bookBL.IncBookCopyBL(accepted.BookId);*/
                    if (isDone1 == true && isDone3 == true)
                    {
                        MessageBox.Show("Book returned successfully...");
                        InitializeUserTransaction();
                    }
                    else
                    {
                        MessageBox.Show("Try again...");
                    }
                }
                else
                {
                    MessageBox.Show("Select a book properly...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
    }
}
