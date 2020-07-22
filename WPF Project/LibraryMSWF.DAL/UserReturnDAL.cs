using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LibraryMSWF.DAL
{
    public class UserReturnDAL
    {
        //ADD THE BOOK RETURN INTO RETURN TABLE =>DAL
        public bool AddReturntDAL(int bookId, string bookName, int userId, string userName)
        {
            SqlConnection conn = new SqlConnection("Server=IAMSAN; Database=LibraryMSWF; Integrated Security=true");
            SqlCommand cmd = new SqlCommand("AddReturn @bId, @bName, @date, @uId, @uName", conn);
            cmd.Parameters.Add(new SqlParameter("@bId", bookId));
            cmd.Parameters.Add(new SqlParameter("@bName", bookName));
            cmd.Parameters.Add(new SqlParameter("@date", DateTime.Now.Date));
            cmd.Parameters.Add(new SqlParameter("@uId", userId));
            cmd.Parameters.Add(new SqlParameter("@uName", userName));
            conn.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //RETURN THE COMPLETE RETURN BOOKS FROM RETURN TABLE  =>DAL
        public DataSet GetAllReturnDAL()
        {
            SqlConnection conn = new SqlConnection("Server=IAMSAN; Database=LibraryMSWF; Integrated Security=true");
            SqlDataAdapter da = new SqlDataAdapter("GetAllReturn", conn);
            DataSet ds = new DataSet("Returns");
            da.Fill(ds);
            return ds;
        }
        //DELETE THE BOOK RETURN FROM RETURN TABLE =>DAL
        public bool DeleteReturntDAL(int bookId, int userId)
        {
            SqlConnection conn = new SqlConnection("Server=IAMSAN; Database=LibraryMSWF; Integrated Security=true");
            SqlCommand cmd = new SqlCommand("DeleteReturn @bId, @uId", conn);
            cmd.Parameters.Add(new SqlParameter("@bId", bookId));
            cmd.Parameters.Add(new SqlParameter("@uId", userId));
            conn.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            conn.Close();
            if (rowAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
