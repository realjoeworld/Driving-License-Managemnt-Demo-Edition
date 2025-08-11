using PersonDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DVLDBussniss
{
    public class clsUser
    {

        public int UserID { get; set; }

        public int PersonID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }

        public clsUser()
        {
            UserID = 0;
            PersonID = 0;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = true;
        }

        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }


        public static bool CheckIfUserExist(ref int UserID, ref int PersonID, string UserName, string Password,ref bool IsActive)
        {
            return clsUserDataAccess.CheckIfUserExist(ref UserID, ref PersonID, UserName, Password,ref IsActive);
        }

        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }

        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            return clsUserDataAccess.AddNewUser(PersonID, UserName, Password, IsActive);
        }

        public static DataTable GetAllUsersPersonIDtartWith(string PersonIDStartWith)
        {
            return clsUserDataAccess.GetAllUsersPersonIDStartWith(PersonIDStartWith);
        }

        public static DataTable GetAllUsersUserIDStartWith(string UserID)
        {
            return clsUserDataAccess.GetAllUsersUserIDStartWith(UserID);
        }

        public static DataTable GetAllUsersUserNameStartWith(string UserNameStartWith)
        {
            return clsUserDataAccess.GetAllUsersUserNameStartWith(UserNameStartWith);
        }

        public static DataTable GetAllUsersFullNameStartWith(string FullNameStartWith)
        {
            return clsUserDataAccess.GetAllUsersFullNameStartWith(FullNameStartWith);
        }

        public static DataTable GetAllUsersActive()
        {
            return clsUserDataAccess.GetAllUsersWhereAllUsersIsActive();
        }

        public static DataTable GetAllUsersInActive()
        {
            return clsUserDataAccess.GetAllUsersWhereAllUsersIsUnActive();
        }

        public static bool DeleteUserByUserID(int UserID)
        {
            return clsUserDataAccess.DeleteUserByUserID(UserID);
        }

        public static bool GetUserInfoByUserID(int UserID, ref string UserName, ref string Password, ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref string Gender, ref string Phone, ref string Email, ref string CountryName, ref string Address, ref string ImagePath, ref bool IsActive)
        {
            return clsUserDataAccess.GetUserInfoByUserID(UserID, ref UserName, ref Password, ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath,ref IsActive);
        }

        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            return clsUserDataAccess.UpdateUser(UserID, UserName, Password, IsActive);
        }

        public static bool UpdateUserPassword(int UserID, string Password)
        {
            return clsUserDataAccess.UpdateUserPassword(UserID, Password);
        }

        public static bool CheckIfUserNameAlreadyExist(string UserName)
        {
            return clsUserDataAccess.CheckIfUserNameAlreadyExist(UserName);
        }


    }
}
