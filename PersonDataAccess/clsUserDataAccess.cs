using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;


namespace PersonDataAccess
{
    public class clsUserDataAccess
    {

        

        public static bool CheckIfUserExist(ref int UserID, ref int PersonID, string UserName, string Password,ref bool IsActiive)
        {

            bool IsUserExist = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from Users where UserName = @UserName and Password = @Password";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
          //  Command.Parameters.AddWithValue("@IsActive", IsActiive);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsUserExist = true;
                    UserID = Convert.ToInt32(Reader["UserID"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    UserName = Reader["UserName"].ToString();
                    Password = Reader["Password"].ToString();
                    IsActiive = Convert.ToBoolean(Reader["IsActive"]);
                }

            }
            catch (Exception)
            {
                IsUserExist = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsUserExist;
        }


        public static DataTable GetAllUsers()
        {

            DataTable dtUsers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Users.UserID, Users.PersonID,FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtUsers.Load(Reader);
                }

                Reader.Close();
            }

            catch (Exception)
            {
                // Handle exception (log it, rethrow it, etc.)
                dtUsers = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtUsers;

        }



        public static int AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {



            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"insert into Users
                            values(@PersonID,@UserName,@Password,@IsActive)
                            SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

          Command.Parameters.AddWithValue("@PersonID", PersonID);
          Command.Parameters.AddWithValue("@UserName", UserName);
          Command.Parameters.AddWithValue("@Password", Password);
          Command.Parameters.AddWithValue("@IsActive", IsActive);


            int Number = -1;

            try
            {
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null)
                {
                    Number = Convert.ToInt32(Result);
                }
            }
            catch
            {
                Number = -1;
            }
            finally
            {
                Connection.Close();
            }

            return Number;
        }

        public static DataTable GetAllUsersPersonIDStartWith(string PersonIDStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Users.UserID, Users.PersonID,FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID where  Users.PersonID like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", PersonIDStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtPersons = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtPersons;

        }


        public static DataTable GetAllUsersUserIDStartWith(string UserIDStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Users.UserID, Users.PersonID,FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID where  Users.UserID like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", UserIDStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtPersons = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtPersons;

        }



        public static DataTable GetAllUsersUserNameStartWith(string UserNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Users.UserID, Users.PersonID,FullName = People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID where  Users.UserName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", UserNameStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtPersons = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtPersons;

        }



        public static DataTable GetAllUsersFullNameStartWith(string FullNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select* from(SELECT Users.UserID, Users.PersonID, People.FirstName +' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as FullName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID ) as Users where FullName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", FullNameStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtPersons = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtPersons;

        }



        public static DataTable GetAllUsersWhereAllUsersIsActive()
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from(SELECT Users.UserID, Users.PersonID, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as FullName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID) as Users where IsActive = 1;";

            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtPersons = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtPersons;

        }


        public static DataTable GetAllUsersWhereAllUsersIsUnActive()
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from(SELECT Users.UserID, Users.PersonID, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as FullName, Users.UserName, Users.IsActive FROM Users INNER JOIN People ON Users.PersonID = People.PersonID) as Users where IsActive = 0;";

            SqlCommand Command = new SqlCommand(Query, Connection);


            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                dtPersons = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtPersons;

        }


        public static bool DeleteUserByUserID(int UserID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Delete from Users where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            int RowsAffected = 0;

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);


        }



        public static bool GetUserInfoByUserID(int UserID,ref string UserName,ref string Password ,ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref string Gender, ref string Phone, ref string Email, ref string CountryName, ref string Address, ref string ImagePath, ref bool IsActive)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Users.UserID, People.PersonID, Users.UserName, Users.Password, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth,\r\n    CASE People.Gendor\r\n        WHEN 0 THEN 'Male'\r\n        WHEN 1 THEN 'Female'\r\n        ELSE 'Unknown'\r\n    END AS GenderText, People.Address, People.Phone, People.Email, People.ImagePath, People.NationalNo, \r\n             Countries.CountryName  , Users.IsActive\r\nFROM   Users INNER JOIN\r\n             People ON Users.PersonID = People.PersonID INNER JOIN\r\n             Countries ON People.NationalityCountryID = Countries.CountryID\r\n\t\t\t where Users.UserID = @UserID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;
                  //  UserID = Convert.ToInt32(Reader["UserID"]);
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    UserName = Reader["UserName"].ToString();
                    Password = Reader["Password"].ToString();
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"].ToString();
                    LsatName = Reader["LastName"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Reader["GenderText"].ToString();
                    Address = Reader["Address"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"].ToString();
                    ImagePath = Reader["ImagePath"].ToString();
                    NationalNO = Reader["NationalNo"].ToString();
                    CountryName = Reader["CountryName"].ToString();
                    IsActive = Convert.ToBoolean(Reader["IsActive"]);

                }

                Reader.Close();

            }
            catch (Exception)
            {
                IsFound = false;
            }
            finally
            {
                Connection.Close();
            }


            return IsFound;

        }


        public static bool UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Update Users set UserName = @UserName, Password = @Password, IsActive = @IsActive where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@Password", Password);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception)
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);

        }



        public static bool UpdateUserPassword(int UserID, string NewPassword)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Update Users set Password = @Password where UserID = @UserID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@UserID", UserID);        
            Command.Parameters.AddWithValue("@Password", NewPassword);

            try
            {
                Connection.Open();

                RowsAffected = Command.ExecuteNonQuery();


            }
            catch (Exception)
            {
                RowsAffected = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (RowsAffected > 0);

        }

        public static bool CheckIfUserNameAlreadyExist(string UserName)
        {

            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select R1 = 'Yes' from Users where UserName = @UserName";

            SqlCommand Command = new SqlCommand(Query, Connection);


            Command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    IsExist = true;
                }

            }
            catch (Exception)
            {
                IsExist = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsExist;

        }



    }
}
