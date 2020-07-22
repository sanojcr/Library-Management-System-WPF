using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Data.Sql;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using LibraryMSWF.BL;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LibraryMSWF.Entity;
using System.Collections.ObjectModel;

namespace LibraryManagementSystem
{
    /// <summary>
    /// Interaction logic for AdminBooks.xaml
    /// </summary>
    public partial class AdminBooks : UserControl
    {
        public static Book updateBook = new Book();
        //INITIALIZE THE BOOKS GV =>PL
        public AdminBooks()
        {
            InitializeComponent();
            InitializeAdminBooks();
        }
        public void InitializeAdminBooks()
        {
            try
            {
                BookBL bookBl = new BookBL();
                DataSet ds = bookBl.GetAllBooksBL();

                ObservableCollection<Book> lst = new ObservableCollection<Book>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lst.Add(new Book
                    {
                        BookName = Convert.ToString(dr["BookName"]),
                        BookId = Convert.ToInt32(dr["BookId"]),
                        BookAuthor = Convert.ToString(dr["BookAuthor"]),
                        BookISBN = Convert.ToString(dr["BookISBN"]),
                        BookCopies = Convert.ToInt32(dr["BookCopies"]),
                        BookPrice = Convert.ToInt32(dr["BookPrice"]),
                    });
                }
                dgBooks.ItemsSource = lst;
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }
            
        }

        //OPEN UPDATE BOOK WINDOW =>PL
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Book book = dgBooks.SelectedItem as Book;
            if (book!= null)
            {
                updateBook = book;
                AdminUpdateBook adminUpdateBook = new AdminUpdateBook();
                adminUpdateBook.Show();
            }
            else
            {
                MessageBox.Show("Select a book to update...");
            }
        }
        //DELETE THE BOOK FROM BOOK TABLE =>PL
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Book book = dgBooks.SelectedItem as Book;

                if (book != null)
                {
                    BookBL bookBL = new BookBL();
                    bool isDone = bookBL.DeleteBookBL(book.BookId);
                    if (isDone)
                    {
                        MessageBox.Show("Book deleted successfuly..");
                        InitializeAdminBooks();
                    }
                    else
                    {
                        MessageBox.Show("Try later..");
                    }
                }
                else
                {
                    MessageBox.Show("Select a book to delete...");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some unknown exception is occured!!!, Try again..");
            }

        }
        //OPEN ADD BOOK WINDOW =>PL
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AdminAddBook adminAddBook = new AdminAddBook();
            adminAddBook.Show();
        }
    }
}
