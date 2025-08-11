using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Security.Policy;

namespace PersonDataAccess
{
    public class clsPersonDataAccess
    {


        public static DataTable GetAllPersonsInfo()
        {

            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtPersons.Load(Reader);
                }


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

        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref int Gender, ref string Phone, ref string Email, ref int CountryID, ref string Address, ref string ImagePath)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from People where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"].ToString();
                    LsatName = Reader["LastName"].ToString();
                    NationalNO = Reader["NationalNo"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Convert.ToSByte(Reader["Gendor"]);
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"].ToString();
                    CountryID = Convert.ToInt16(Reader["NationalityCountryID"]);
                    Address = Reader["Address"].ToString();
                    ImagePath = Reader["ImagePath"].ToString();
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

        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNO, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, byte CountryID, string ImagePath)
        {



            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"insert into People
                            values(@NationalNO,@FirstName, @SecondName,@ThirdName,@LastName, @DateOfBirth, @Gender, @Address, @Phone, @Email, @CountryID, @ImagePath)
                            SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNO", NationalNO);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != string.Empty)
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);

            else
                Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);


            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Gender", Gender);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != string.Empty)
                Command.Parameters.AddWithValue("@Email", Email);

            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            Command.Parameters.AddWithValue("@CountryID", CountryID);

            if (ImagePath != string.Empty)
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);


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


        public static bool CheckIfNationalNumberExist(string NationalNo)
        {

            bool IsExist = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select R1 = 1 from People where NationalNo = @NationalNo;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

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

        public static DataTable GetAllPersonsFirstNameStartWith(string FirstNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where FirstName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", FirstNameStartWith);

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


        public static DataTable GetAllPersonsSecondNameStartWith(string SecondNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where SecondName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", SecondNameStartWith);

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


        public static DataTable GetAllPersonsThirdNameStartWith(string ThirdNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where ThirdName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", ThirdNameStartWith);

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

        public static DataTable GetAllPersonsLastNameStartWith(string LastNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where LastName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", LastNameStartWith);

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


        public static DataTable GetAllPersonsNationalNoStartWith(string NationalNoStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where NationalNo like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", NationalNoStartWith);

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


        public static DataTable GetAllPersonsPersonIDStartWith(string PersonIDStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where PersonID like '' + @StartWith + '%'";

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

        public static DataTable GetAllPersonsNationalityStartWith(string NationalityStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where CountryName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", NationalityStartWith);

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



        public static DataTable GetAllPersonsGenderMale()
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where Gendor = 0";

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



        public static DataTable GetAllPersonsGenderFeMale()
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where Gendor = 1";

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


        public static DataTable GetAllPersonsPhoneStartWith(string PhoneStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where Phone like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", PhoneStartWith);

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



        public static DataTable GetAllPersonsEmailStartWith(string EmailStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.PersonID,\r\n    People.NationalNo,\r\n    People.FirstName,\r\n    People.SecondName,\r\n    People.ThirdName,\r\n    People.LastName,\r\n    People.DateOfBirth,\r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male'\r\n        WHEN People.Gendor = 1 THEN 'FeMale'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    People.Address,\r\n    People.Phone,\r\n    People.Email,\r\n    Countries.CountryName,\r\n    People.ImagePath\r\nFROM People\r\nINNER JOIN Countries ON People.NationalityCountryID = Countries.CountryID where Email like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", EmailStartWith);

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


        public static bool UpdatePerson(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNumber, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Update People set FirstName = @FirstName, SecondName = @SecondName, ThirdName = @ThirdName, LastName = @LastName, NationalNo = @NationalNo, DateOfBirth = @DateOfBirth, Gendor = @Gendor, Address = @Address, Phone = @Phone, Email = @Email, NationalityCountryID = @NationalityCountryID, ImagePath = @ImagePath where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@NationalNo", NationalNumber);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);


            if (Gender == "Male")
                Command.Parameters.AddWithValue("@Gendor", 0);

            else
                Command.Parameters.AddWithValue("@Gendor", 1);



            Command.Parameters.AddWithValue("@Address", Address);



            Command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != string.Empty)
                Command.Parameters.AddWithValue("@Email", Email);

            else
                Command.Parameters.AddWithValue("@Email", DBNull.Value);

            Command.Parameters.AddWithValue("@NationalityCountryID", CountryID);

            if (ImagePath != string.Empty)
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);

            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);



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


        public static bool DeletePersonByPersonID(int PersonID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Delete from People where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

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


        public static bool GetPersonInfoByNationalNo(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref int Gender, ref string Phone, ref string Email, ref int CountryID, ref string Address, ref string ImagePath)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from People where NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNO);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"].ToString();
                    LsatName = Reader["LastName"].ToString();
                    //  NationalNO = Reader["NationalNo"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Convert.ToSByte(Reader["Gendor"]);
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"].ToString();
                    CountryID = Convert.ToInt16(Reader["NationalityCountryID"]);
                    Address = Reader["Address"].ToString();
                    ImagePath = Reader["ImagePath"].ToString();
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


        public static bool CheckIfThisPersonIsUser(int PersonID)
        {
            bool IsUser = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);


            string Query = "SELECT R1 = 1 FROM Users where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    IsUser = true;
                }


            }
            catch (Exception)
            {
                IsUser = false;
            }
            finally
            {
                Connection.Close();

            }
            return IsUser;
        }



        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref string Gender, ref string Phone, ref string Email, ref string CountryName, ref string Address, ref string ImagePath)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, CASE WHEN Gendor = 0 THEN 'Male' WHEN Gendor = 1 THEN 'Female' END AS Gender, People.Address, People.Phone, People.Email, \r\n             People.ImagePath, Countries.CountryName\r\nFROM   People INNER JOIN\r\n             Countries ON People.NationalityCountryID = Countries.CountryID where PersonID = @PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"].ToString();
                    LsatName = Reader["LastName"].ToString();
                    NationalNO = Reader["NationalNo"].ToString();
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Reader["Gender"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"].ToString();
                    CountryName = Reader["CountryName"].ToString();
                    Address = Reader["Address"].ToString();
                    ImagePath = Reader["ImagePath"].ToString();
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



        public static bool GetPersonInfoByNationalO(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, string NationalNO, ref DateTime DateOfBirth, ref string Gender, ref string Phone, ref string Email, ref string CountryName, ref string Address, ref string ImagePath)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT People.PersonID, People.NationalNo, People.FirstName, People.SecondName, People.ThirdName, People.LastName, People.DateOfBirth, CASE WHEN Gendor = 0 THEN 'Male' WHEN Gendor = 1 THEN 'Female' END AS Gender, People.Address, People.Phone, People.Email, \r\n             People.ImagePath, Countries.CountryName\r\nFROM   People INNER JOIN\r\n             Countries ON People.NationalityCountryID = Countries.CountryID where NationalNo = @NationalNo";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@NationalNo", NationalNO);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"].ToString();
                    LsatName = Reader["LastName"].ToString();
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                    Gender = Reader["Gender"].ToString();
                    Phone = Reader["Phone"].ToString();
                    Email = Reader["Email"].ToString();
                    CountryName = Reader["CountryName"].ToString();
                    Address = Reader["Address"].ToString();
                    ImagePath = Reader["ImagePath"].ToString();
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


        public static int CheckIfPersonHasApplicationItsStatusNewAndSameLicenseClass(int PersonID, int LicenseClass)
        {
            int ApplicationID = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT top 1 Applications.ApplicationID FROM   Applications INNER JOIN            ApplicationTypes ON Applications.ApplicationTypeID = ApplicationTypes.ApplicationTypeID INNER JOIN     LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID where (Applications.ApplicantPersonID = @ApplicantPersonID) and (LocalDrivingLicenseApplications.LicenseClassID = @LicenseClassID) and (Applications.ApplicationStatus = 1 or Applications.ApplicationStatus = 3) and (Applications.ApplicationTypeID = 1);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);

            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClass);


            try
            {

                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    ApplicationID = ID;
                }

            }
            catch (Exception)
            {
                ApplicationID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;

        }


        public static int AddNewApplication(int PersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int UserID)
        {



            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"insert into Applications
                            values(@ApplicantPersonID,@ApplicationDate, @ApplicationTypeID,@ApplicationStatus,@LastStatusDate, @PaidFees, @CreatedByUserID);
                            SELECT SCOPE_IDENTITY();";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);
            Command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            Command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            Command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            Command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", UserID);

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

        public static int AddNewRenewLicenseApplication(int PersonID, int UserID)
        {
            return AddNewApplication(PersonID, DateTime.Now, 2, 3, DateTime.Now, 7, UserID);
        }

        public static int AddNewDamagedLicenseApplication(int PersonID, int UserID)
        {
            return AddNewApplication(PersonID, DateTime.Now, 4, 3, DateTime.Now, 5, UserID);
        }

        public static int AddNewLostLicenseApplication(int PersonID, int UserID)
        {
            return AddNewApplication(PersonID, DateTime.Now, 3, 3, DateTime.Now, 10, UserID);
        }

        public static int AddNewReleaseDetainedLicenseApplication(int PersonID, int UserID)
        {
            return AddNewApplication(PersonID, DateTime.Now, 5, 3, DateTime.Now, 15, UserID);
        }


        public static int AddNewLocalLicenseApplication(int ApplicationID, int LicenseClassID)
        {

            int AppID = -1;

            SqlConnection Conncetion = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "insert into LocalDrivingLicenseApplications values(@ApplicationID,@LicenseClassID); select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Conncetion);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                Conncetion.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    AppID = ID;
                }
                else
                {
                    AppID = -1;
                }

            }
            catch (Exception)
            {
                AppID = -1;
            }
            finally
            {
                Conncetion.Close();

            }
            return AppID;
        }

        public static DataTable GetAllLocalLicenseInfo()
        {

            DataTable dtLocalLicense = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from LocalDrivingLicenseApplications_View";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {

                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtLocalLicense.Load(Reader);
                }

                Reader.Close();

            }

            catch (Exception)
            {
                dtLocalLicense = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtLocalLicense;



        }


        public static DataTable GetAllLocalLicenseNoStartWith(string NoStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from LocalDrivingLicenseApplications_View where NationalNo like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", NoStartWith);

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



        public static DataTable GetAllLocalLicenseAppIDStartWith(string IDStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from LocalDrivingLicenseApplications_View where LocalDrivingLicenseApplicationID like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", IDStartWith);

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

        public static DataTable GetAllLocalLicenseFullNameStartWith(string FullNameStartWith)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from LocalDrivingLicenseApplications_View where FullName like '' + @StartWith + '%'";

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


        public static DataTable GetAllLocalLicenseByItsStatus(string Status)
        {


            DataTable dtPersons = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select * from LocalDrivingLicenseApplications_View where Status like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", Status);

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


        public static bool CancelApplication(int AppID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "update Applications set  ApplicationStatus = 2 where ApplicationID = @ApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", AppID);

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


        public static int GetApplicationIDFromLocalLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            int ApplicationID = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Applications.ApplicationID\r\nFROM   Applications INNER JOIN\r\n             LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID  where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID ";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    ApplicationID = Convert.ToInt32(Result);
                }
            }

            catch (Exception)
            {
                ApplicationID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return ApplicationID;

        }

        public static bool GetLocalLicenseApplicationInfo(int LocalLicenseApplicationID, ref int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref string ClassName, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string UserName, ref string ApplicationStatus, ref DateTime LastStatusDate)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"SELECT LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID,
       LocalDrivingLicenseApplications.ApplicationID, 
       Applications.ApplicantPersonID, 
       Applications.ApplicationDate, 
       LicenseClasses.ClassName, 
       People.FirstName, 
       People.SecondName, 
       People.ThirdName, 
       People.LastName, 
       Users.UserName, 
       CASE WHEN ApplicationStatus = 1 THEN 'New' 
            WHEN ApplicationStatus = 2 THEN 'Cancelled' 
            WHEN ApplicationStatus = 3 THEN 'Completed' 
       END AS Status, 
       Applications.LastStatusDate
FROM LocalDrivingLicenseApplications 
INNER JOIN Applications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID 
INNER JOIN LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID 
INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID 
INNER JOIN Users ON Applications.CreatedByUserID = Users.UserID  
WHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseApplicationID);

            bool IsFound = false;

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    ApplicantPersonID = Convert.ToInt32(Reader["ApplicantPersonID"]);
                    ApplicationDate = Convert.ToDateTime(Reader["ApplicationDate"]);
                    ClassName = Reader["ClassName"].ToString();
                    FirstName = Reader["FirstName"].ToString();
                    SecondName = Reader["SecondName"].ToString();
                    ThirdName = Reader["ThirdName"].ToString();
                    LastName = Reader["LastName"].ToString();
                    UserName = Reader["UserName"].ToString();
                    ApplicationStatus = Reader["Status"].ToString();
                    LastStatusDate = Convert.ToDateTime(Reader["LastStatusDate"]);
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

        public static bool CheckIfThisPersonHasAnAppointment(int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT R1 = 'Yes' FROM   TestAppointments INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID\r\nwhere Applications.ApplicantPersonID = @PersonID and IsLocked = 0 and TestAppointments.TestTypeID = 1;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    IsFound = true;
                }

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

        public static DataTable GetAllAppointmentsForDLLicenseApp(int ID)
        {
            DataTable dtAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT TestAppointments.TestAppointmentID AS AppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked\r\nFROM   TestAppointments INNER JOIN\r\n             LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN\r\n             TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID\r\nWHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) and (TestAppointments.TestTypeID = 1)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", ID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAppointments.Load(Reader);
                }

            }
            catch (Exception)
            {
                dtAppointments = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtAppointments;

        }


        public static int AddNewAppointments(int TestTypeID, int LocalLicenseID, DateTime AppointmentDate, int PaidFees, int UserID)
        {
            int ID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"insert into TestAppointments(TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked) 
            values(@TestTypeID, @LocalLicenseID, @AppointmentDate, @PaidFees, @UserID, 0);
            select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            Command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@UserID", UserID);



            try
            {

                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    ID = Convert.ToInt32(Result);
                }

            }
            catch (Exception)
            {
                ID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return ID;

        }


        public static bool UpdateTestAppointment(int TestID, DateTime NewAppointmentDate)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"Update TestAppointments
            set AppointmentDate = @AppointmentDate where TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestID);
            Command.Parameters.AddWithValue("@AppointmentDate", NewAppointmentDate);


            int AffectedRows = 0;

            try
            {

                Connection.Open();

                AffectedRows = Command.ExecuteNonQuery();


            }
            catch (Exception)
            {
                AffectedRows = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (AffectedRows > 0);

        }

        public static bool GetAppointmentDate(int TestAppointmentID, ref DateTime AppointmentDate)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT AppointmentDate FROM TestAppointments where TestAppointmentID = @TestAppointmentID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    AppointmentDate = Convert.ToDateTime(Result);
                }

            }

            catch (Exception)
            {
                AppointmentDate = DateTime.Now;
            }

            finally {
                Connection.Close();
            }

            return (AppointmentDate != DateTime.Now);

        }


        public static int AddNewTest(int TestAppointemntID, bool TestResult, string Notes, int UserID)
        {
            int ID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = @"insert into Tests(TestAppointmentID,TestResult,Notes,CreatedByUserID) 
            values(@TestAppointemntID, @TestResult, @Notes, @UserID);
            select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointemntID", TestAppointemntID);
            Command.Parameters.AddWithValue("@TestResult", TestResult);

            if (string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", Notes);

            Command.Parameters.AddWithValue("@UserID", UserID);



            try
            {

                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    ID = Convert.ToInt32(Result);
                }

            }
            catch (Exception)
            {
                ID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return ID;

        }

        public static bool UpdateTestAppointmentToBeLocked(int TestAppointmentID)
        {
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Update TestAppointments set IsLocked = 1 where TestAppointmentID = @TestAppointmentID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

            int AffectedRows = 0;

            try
            {
                Connection.Open();
                AffectedRows = Command.ExecuteNonQuery();
            }

            catch (Exception)
            {
                AffectedRows = 0;
            }

            finally
            {
                Connection.Close();
            }

            return (AffectedRows > 0);
        }

        public static bool CheckIfThisPersonPassedTheVisionTest(int LocalLicenseID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT 'Yes' AS R1\r\nFROM   Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN\r\n             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t where (TestResult = 1) and (TestTypeID = 1) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);

            Object Result = null;

            try
            {
                Connection.Open();

                Result = Command.ExecuteScalar();

            }
            catch (Exception)
            {
                Result = null;
            }
            finally
            {
                Connection.Close();
            }

            return (Result != null && Result.ToString() == "Yes");

        }

        public static bool CheckIfThisPersonFailedTheVisionTest(int LocalLicenseID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT 'Yes' AS R1\r\nFROM   Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN\r\n             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t where (TestResult = 0) and (TestTypeID = 1) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);

            Object Result = null;

            try
            {
                Connection.Open();

                Result = Command.ExecuteScalar();

            }
            catch (Exception)
            {
                Result = null;
            }
            finally
            {
                Connection.Close();
            }

            return (Result != null && Result.ToString() == "Yes");

        }



            public static DataTable GetAllWrittenAppointmentsForDLLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            DataTable dtAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT TestAppointments.TestAppointmentID AS AppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked\r\nFROM   TestAppointments INNER JOIN\r\n             LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN\r\n             TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID\r\nWHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) and (TestAppointments.TestTypeID = 2)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAppointments.Load(Reader);
                }

            }
            catch (Exception)
            {
                dtAppointments = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtAppointments;

        }

        public static bool CheckIfThisPersonPassedTheWrritenTest(int LocalLicenseID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT 'Yes' AS R1\r\nFROM   Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN\r\n             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t where (TestResult = 1) and (TestTypeID = 2) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);

            Object Result = null;

            try
            {
                Connection.Open();

                Result = Command.ExecuteScalar();

            }
            catch (Exception)
            {
                Result = null;
            }
            finally
            {
                Connection.Close();
            }

            return (Result != null && Result.ToString() == "Yes");

        }


        public static bool CheckIfThisPersonHasWrritenAppointment(int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT R1 = 'Yes' FROM   TestAppointments INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID\r\nwhere Applications.ApplicantPersonID = @PersonID and IsLocked = 0 and TestAppointments.TestTypeID = 2;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    IsFound = true;
                }

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

        public static bool CheckIfThisPersonFailedTheWrritenTest(int LocalLicenseID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT 'Yes' AS R1\r\nFROM   Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN\r\n             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t where (TestResult = 0) and (TestTypeID = 2) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);

            Object Result = null;

            try
            {
                Connection.Open();

                Result = Command.ExecuteScalar();

            }
            catch (Exception)
            {
                Result = null;
            }
            finally
            {
                Connection.Close();
            }

            return (Result != null && Result.ToString() == "Yes");

        }


        public static bool CheckIfThisPersonPassedTheStreetTest(int LocalLicenseID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT 'Yes' AS R1\r\nFROM   Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN\r\n             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t where (TestResult = 1) and (TestTypeID = 3) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);

            Object Result = null;

            try
            {
                Connection.Open();

                Result = Command.ExecuteScalar();

            }
            catch (Exception)
            {
                Result = null;
            }
            finally
            {
                Connection.Close();
            }

            return (Result != null && Result.ToString() == "Yes");

        }


        public static bool CheckIfThisPersonHasStreetAppointment(int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT R1 = 'Yes' FROM   TestAppointments INNER JOIN LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN Applications ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID\r\nwhere Applications.ApplicantPersonID = @PersonID and IsLocked = 0 and TestAppointments.TestTypeID = 3;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    IsFound = true;
                }

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


        public static bool CheckIfThisPersonFailedTheStreetTest(int LocalLicenseID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT 'Yes' AS R1\r\nFROM   Applications INNER JOIN LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN\r\n             Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID\r\n\t\t\t where (TestResult = 0) and (TestTypeID = 3) and (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseID);

            Object Result = null;

            try
            {
                Connection.Open();

                Result = Command.ExecuteScalar();

            }
            catch (Exception)
            {
                Result = null;
            }
            finally
            {
                Connection.Close();
            }

            return (Result != null && Result.ToString() == "Yes");

        }

        public static DataTable GetAllStreetAppointmentsForDLLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            DataTable dtAppointments = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT TestAppointments.TestAppointmentID AS AppointmentID, TestAppointments.AppointmentDate, TestAppointments.PaidFees, TestAppointments.IsLocked\r\nFROM   TestAppointments INNER JOIN\r\n             LocalDrivingLicenseApplications ON TestAppointments.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID INNER JOIN\r\n             TestTypes ON TestAppointments.TestTypeID = TestTypes.TestTypeID\r\nWHERE (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) and (TestAppointments.TestTypeID = 3)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtAppointments.Load(Reader);
                }

            }
            catch (Exception)
            {
                dtAppointments = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtAppointments;

        }


        public static bool SetApplicationToBeCompleted(int AppID)
        {

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "update Applications set ApplicationStatus = 3 where ApplicationID = @ApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", AppID);

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

       


    }        
}


