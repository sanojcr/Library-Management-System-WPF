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
    /// Interaction logic for AdminRequests.xaml
    /// </summary>
    public partial class AdminRequests : UserControl
    {
        //INITIALIZE THE REQUESTS GV =>PL
        public AdminRequests()
        {
            InitializeComponent();
            InitializeRequests();
        }
        public void InitializeRequests()
        {
            try
            {
                UserRequestBL userRequestBL = new UserRequestBL();
                DataSet ds = userRequestBL.GetAllRequestBL();

                ObservableCollection<RequestedBook> lst = new ObservableCollection<RequestedBook>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(new RequestedBook
                    {
                        BookName = Convert.ToString(dr["BookName"]),
                        BookId = Convert.ToInt32(dr["BookId"]),
                        UserId = Convert.ToInt32(dr["UserId"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        DateRequested = Convert.ToString(Convert.ToDateTime(dr["DateRequested"]).ToShortDateString()),


                    });
                }
                dgRequests.ItemsSource = lst;
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
        //ACCEPT THE REQUESTED BOOK =>PL
        private void BtnAccept_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RequestedBook request = dgRequests.SelectedItem as RequestedBook;
                if (request != null)
                {
                    UserRecieveBL userRecieveBL = new UserRecieveBL();
                    bool isDone1 = userRecieveBL.AddRecieveBL(request.BookId, request.BookName, request.UserId, request.UserName);
                    UserRequestBL userRequest = new UserRequestBL();
                    bool isDone2 = userRequest.DeleteRequestBL(request.BookId, request.UserId);
                    if (isDone1 == true && isDone2 == true)
                    {
                        MessageBox.Show("Accepted request successfully...");
                        InitializeRequests();
                    }
                    else
                    {
                        MessageBox.Show("Try again latter...");
                    }
                }
                else
                {
                    MessageBox.Show("Select book properly...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
        }
        //REJECT THE REQUESTED BOOK =>PL
        private void BtnReject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RequestedBook request = dgRequests.SelectedItem as RequestedBook;
                if (request != null)
                {
                    BookBL bookBL = new BookBL();
                    bool isDone1 = bookBL.IncBookCopyBL(request.BookId);
                    UserRequestBL userRequest = new UserRequestBL();
                    bool isDone2 = userRequest.DeleteRequestBL(request.BookId, request.UserId);
                    if (isDone1 == true && isDone2 == true)
                    {
                        MessageBox.Show("Rejected request successfully...");
                        InitializeRequests();
                    }
                    else
                    {
                        MessageBox.Show("Try again latter...");
                    }
                }
                else
                {
                    MessageBox.Show("Select book properly...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }

        }
    }
}
