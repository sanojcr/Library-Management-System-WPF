using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryMSWF.DAL;
using System.Data;
using System.Threading.Tasks;

namespace LibraryMSWF.BL
{
    public class UserReturnBL
    {
        //ADD THE BOOK RETURN INTO RETURN TABLE =>BL
        public bool AddReturnBL(int bookId, string bookName, int userId)
        {
            UserDAL userDAL = new UserDAL();
            string userName = userDAL.TakeUserNameDAL(userId);
            UserReturnDAL userReturnDAL = new UserReturnDAL();
            bool isDone = userReturnDAL.AddReturntDAL(bookId, bookName, userId, userName);
            return isDone;
        }

        //RETURN THE COMPLETE RETURN BOOKS FROM RETURN TABLE  =>BL
        public DataSet GetAllReturnBL()
        {
            UserReturnDAL userReturnDAL = new UserReturnDAL();
            DataSet ds = userReturnDAL.GetAllReturnDAL();
            return ds;
        }
        //DELETE THE BOOK RETURN FROM RETURN TABLE =>BL
        public bool DeleteReturnBL(int bookId, int userId)
        {
            UserReturnDAL userReturnDAL = new UserReturnDAL();
            bool isDone = userReturnDAL.DeleteReturntDAL(bookId, userId);
            return isDone;
        }
    }
}
