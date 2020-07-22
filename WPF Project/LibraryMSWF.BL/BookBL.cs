using System;
using System.Collections.Generic;
using System.Linq;
using LibraryMSWF.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMSWF.BL
{
    public class BookBL
    {
        //VALIDATION METHOD FOR VALIDATE BOOK DETAILS
        public string BookValidate(string bookName, string bookAuthor, string bookISBN, double bookPrice, int bookCopies)
        {
            if (bookName.Equals(string.Empty)||bookName.Length>30 || bookName.Length<3)
            {
                return "Invalid Book name!!!,\nminimum 3 maximum 30 characters are allowed,";
            }
            else if(bookAuthor.Equals(string.Empty) || bookAuthor.Length > 30 || bookAuthor.Length < 3)
            {
                return "Invalid Author name!!!,\nminimum 3 maximum 30 characters are allowed,";
            }
            else if (bookName.Any(char.IsDigit))
            {
                return "Invalid Book name!!!,\nname should not contain digits,";
            }
            else if (bookAuthor.Any(char.IsDigit))
            {
                return "Invalid Author name!!!,\nname should not contain digits,";
            }
            else if (bookISBN.Equals(string.Empty) || bookISBN.Length > 15 || bookISBN.Length < 3)
            {
                return "Invalid book ISBN!!!, \nminimum 3 maximum 15 characters are allowed, ";
            }
            else if(bookPrice==0 || bookPrice <= 10)
            {
                return "Invalid book price!!!,\nit not be less than 10,";
            }
            else if(bookCopies<0 || bookCopies > 200)
            {
                return "Invalid book copies!!!, \nit not be greater than 200,";
            }
            else
            {
                return "true";
            }
            
        }
        //RETURN THE COMPLETE BOOKS FROM BOOK TABLE =>BL
        public DataSet GetAllBooksBL()
        {
            BookDAL bookDal = new BookDAL();
            DataSet ds = bookDal.GetAllBooksDAL();
            return ds;
        }
        //ADD BOOK INTO BOOK TABLE => BL
        public string AddBookBL(string bookName, string bookAuthor, string bookISBN, double bookPrice, int bookCopies)
        {
            string isBookValid = BookValidate(bookName,bookAuthor,bookISBN,bookPrice,bookCopies);
            if (isBookValid=="true")
            {
                BookDAL bookDAL = new BookDAL();
                bool isDone = bookDAL.AddBookDAL(bookName, bookAuthor, bookISBN, bookPrice, bookCopies);
                if (isDone!=true)
                {
                    return "Server error, ";
                }
                else
                {
                    return "true";
                }
            }
            else
            {
                return isBookValid;
            }
            
        }
        //UPDATE THE BOOK FROM BOOK TABLE =>BL
        public string UpdateBookBL(int bookId, string bookName, string bookAuthor, string bookISBN, double bookPrice, int bookCopies)
        {
            string isBookValid = BookValidate(bookName, bookAuthor, bookISBN, bookPrice, bookCopies);
            if (isBookValid == "true")
            {
                BookDAL bookDAL = new BookDAL();
                bool isDone = bookDAL.UpdateBookDAL(bookId, bookName, bookAuthor, bookISBN, bookPrice, bookCopies);
                if (isDone != true)
                {
                    return "Server error, ";
                }
                else
                {
                    return "true";
                }
            }
            else
            {
                return isBookValid;
            }
        }
        /*public bool UpdateBookBL(int bookId, string bookName, string bookAuthor, string bookISBN, double bookPrice, int bookCopies)
        {
            BookDAL bookDAL = new BookDAL();
            bool isDone = bookDAL.UpdateBookDAL(bookId, bookName, bookAuthor, bookISBN, bookPrice, bookCopies);
            return isDone;
        }*/
        //DELETE THE BOOK FROM BOOK TABLE =>BL
        public bool DeleteBookBL(int bookId)
        {
            BookDAL bookDAL = new BookDAL();
            bool isDone = bookDAL.DeleteBookDAL(bookId);
            return isDone;
        }
        //INCREMENT THE BOOK COPIES OF A BOOK BY 1 =>BL
        public bool IncBookCopyBL(int bookId)
        {
            BookDAL bookDAL = new BookDAL();
            bool isDone = bookDAL.IncBookCopyDAL(bookId);
            return isDone;
        }

    }
}
