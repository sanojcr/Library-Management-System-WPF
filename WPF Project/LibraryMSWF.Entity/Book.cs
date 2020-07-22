using System;

namespace LibraryMSWF.Entity
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public string BookISBN { get; set; }
        public int BookPrice { get; set; }
        public int BookCopies { get; set; }
    }
}
