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
    /// Interaction logic for AdminUpdateBook.xaml
    /// </summary>
    public partial class AdminUpdateBook : Window
    {
        public int bookId;
        //INITIALIZE THE BOOKS UPDATE =>PL
        public AdminUpdateBook()
        {
            InitializeComponent();
            this.bookId = AdminBooks.updateBook.BookId;
            tbBName.Text = AdminBooks.updateBook.BookName;
            tbBAuthor.Text = AdminBooks.updateBook.BookAuthor;
            tbBISBN.Text = AdminBooks.updateBook.BookISBN;
            tbBPrice.Text = AdminBooks.updateBook.BookPrice.ToString();
            tbBCopy.Text = AdminBooks.updateBook.BookCopies.ToString();
        }
        //UPDATE BOOK DETAILS FROM BOOK TABLE
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (tbBName.Text != string.Empty && tbBAuthor.Text != string.Empty && tbBISBN.Text != string.Empty && tbBPrice.Text != string.Empty &&
                tbBCopy.Text != string.Empty
                )
            {
                try
                {
                    BookBL bookBL = new BookBL();
                    string isDone = bookBL.UpdateBookBL(this.bookId, tbBName.Text, tbBAuthor.Text, tbBISBN.Text, double.Parse(tbBPrice.Text), int.Parse(tbBCopy.Text));
                    if (isDone == "true")
                    {
                        MessageBox.Show("Book updated successfuly..");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(isDone+" Try later..");
                    }
                }
                catch(FormatException)
                {
                    MessageBox.Show("Invalid Book price or Book copy!!!,\nThey should not be a string, Try again..");
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
