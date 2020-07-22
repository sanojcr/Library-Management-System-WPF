using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryMSWF.Entity
{
    public class RequestedBook
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string DateRequested { get; set; }
    }
}
