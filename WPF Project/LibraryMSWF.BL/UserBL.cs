using System;
using System.Collections.Generic;
using LibraryMSWF.DAL;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryMSWF.BL
{
    public class UserBL
    {
        //VALIDATION METHOD FOR VALIDATE USER DETAILS => BL
        public string UserValidate(string userName, int userAdNo, string userEmail, string userPass)
        {

            if (userName.Equals(string.Empty) || userName.Length > 30 || userName.Length < 3)
            {
                return "Invalid User name!!!,\nminimum 3 maximum 30 characters are allowed,";
            }
            else if (userName.Any(char.IsDigit))
            {
                return "Invalid User name!!!,\nname should not contains digits,";
            }
            else if (!(new Regex("([\\w\\.\\-_]+)?\\w+@[\\w-_]+(\\.\\w+){1,}").IsMatch(userEmail)))
            {
                return "Invalid Email address!!!,\nemail should be an email,";
            }
            else if (userPass.Equals(string.Empty) || userPass.Length > 15 || userPass.Length < 8)
            {
                return "Invalid Password!!!, \nminimum 8 maximum 15 characters are allowed, ";
            }
            else if (userAdNo == 0 || userAdNo <= 10000)
            {
                return "Invalid Admission number!!!,\nIt should not be greater than 10000,";
            }
            else
            {
                return "true";
            }

        }

        //RETURN COMPLETE USERS FROM USER TABLE =>BL
        public DataSet GetAllUsersBL()
        {
            UserDAL userBl = new UserDAL();
            DataSet ds = userBl.GetAllUsersDAL();
            return ds;
        }
        //ADD USER INTO USER TABLE =>BL
        public string AddUserBL(string userName, int userAdNo, string userEmail, string userPass)
        {
            string isUserValid = UserValidate(userName, userAdNo, userEmail, userPass);
            if (isUserValid=="true")
            {
                UserDAL userDAL = new UserDAL();
                string isDone = userDAL.AddUserDAL(userName, userAdNo, userEmail, userPass);
                if (isDone=="false")
                {
                    return "Server error ,";
                }
                else if(isDone=="true")
                {
                    return "true";
                }
                else
                {
                    return isDone;
                }
            }
            else
            {
                return isUserValid;
            }
        }
        //UPDATE THE USER FROM USER TABLE =>BL
        public string UpdateUserBL(int userId, string userName, int userAdNo, string userEmail, string userPass)
        {
            string isUserValid = UserValidate(userName, userAdNo, userEmail, userPass);
            if (isUserValid == "true")
            {
                UserDAL userDAL = new UserDAL();
                bool isDone = userDAL.UpdateUserDAL(userId, userName, userAdNo, userEmail, userPass);
                if (isDone != true)
                {
                    return "Server error ,";
                }
                else
                {
                    return "true";
                }
            }
            else
            {
                return isUserValid;
            }
        }
        //DELETE THE USER FROM USER TABLE =>BL
        public bool DeleteUserBL(int userId)
        {
            UserDAL userDAL = new UserDAL();
            bool isDone = userDAL.DeleteUserDAL(userId);
            return isDone;
        }
        //CHECK THE USER LOGIN CREDENTIALS RETURN USER ID =>BL
        public int UserLoginBL(string userEmail, string userPass)
        {
            UserDAL userDAL = new UserDAL();
            int isDone = userDAL.UserLoginDAL(userEmail,userPass);
            return isDone;
        }
    }
}
