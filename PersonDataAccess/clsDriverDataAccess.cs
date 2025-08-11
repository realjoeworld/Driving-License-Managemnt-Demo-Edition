using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace PersonDataAccess
{
    public class clsDriverDataAccess
    {

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreationDate)
        {
            int ID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "insert into Drivers\r\nvalues(@PersonID,@CreatedByUserID,@CreatedDate); select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@CreatedDate", CreationDate);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
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

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpireIssueDate, string Notes, int PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {

            int ID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "insert into Licenses\r\nvalues(@ApplicationID,@DriverID,@LicenseClass,@IssueDate,@ExpirationDate,@Notes,@PaidFees,@IsActive,@IssueReason,@CreatedByUserID);\r\n\r\nselect SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@LicenseClass", LicenseClassID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpireIssueDate);

            if (string.IsNullOrEmpty(Notes))
                Command.Parameters.AddWithValue("@Notes", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@Notes", Notes);

            Command.Parameters.AddWithValue("@PaidFees", PaidFees);
            Command.Parameters.AddWithValue("@IsActive", IsActive);
            Command.Parameters.AddWithValue("@IssueReason", IssueReason);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
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


        public static int GetDrivingClassFromApplicationID(int ApplicationID)
        {

            int ClassID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT LicenseClasses.LicenseClassID\r\nFROM   Applications INNER JOIN\r\n             LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID INNER JOIN\r\n             LicenseClasses ON LocalDrivingLicenseApplications.LicenseClassID = LicenseClasses.LicenseClassID\r\n\t\t\t where LocalDrivingLicenseApplications.ApplicationID = @ApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
                {
                    ClassID = Convert.ToInt32(Result);
                }


            }
            catch (Exception)
            {
                ClassID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return ClassID;


        }

        public static bool GetDriverLicenseInfo(int LocalLicenseAppID, ref string ClassName, ref string FullName, ref int LicenseID, ref string NationalNo, ref string Gender, ref string IssueDate, ref string IssueReason, ref string Notes, ref string IsActive, ref string DateOfBirth, ref int DriveID, ref string ExpirationDate, ref string IsDetained, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    LicenseClasses.ClassName, \r\n    People.FirstName, \r\n    People.SecondName, \r\n    People.ThirdName, \r\n    People.LastName, \r\n    Licenses.LicenseID, \r\n    People.NationalNo, \r\n    CASE \r\n        WHEN People.Gendor = 0 THEN 'Male' \r\n        WHEN People.Gendor = 1 THEN 'Female' \r\n        ELSE 'Unknown' \r\n    END AS Gender,\r\n    Licenses.IssueDate, \r\n Licenses.Notes,   Licenses.IssueReason, \r\n    CASE \r\n        WHEN Licenses.IsActive = 1 THEN 'Yes' \r\n        WHEN Licenses.IsActive = 0 THEN 'No' \r\n        ELSE 'Unknown' \r\n    END AS IsActive,\r\n    People.DateOfBirth, \r\n    Drivers.DriverID, \r\n    Licenses.ExpirationDate, People.ImagePath \r\nFROM LicenseClasses \r\nINNER JOIN LocalDrivingLicenseApplications \r\n    ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID \r\nINNER JOIN Applications \r\n    ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID \r\nINNER JOIN People \r\n    ON Applications.ApplicantPersonID = People.PersonID \r\nINNER JOIN Licenses \r\n    ON LicenseClasses.LicenseClassID = Licenses.LicenseClass \r\n    AND Applications.ApplicationID = Licenses.ApplicationID \r\nINNER JOIN Drivers \r\n    ON People.PersonID = Drivers.PersonID \r\n    AND Licenses.DriverID = Drivers.DriverID\r\nWHERE LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseAppID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    ClassName = Reader["ClassName"].ToString();
                    FullName = $"{Reader["FirstName"]} {Reader["SecondName"]} {Reader["ThirdName"]} {Reader["LastName"]}";
                    LicenseID = Convert.ToInt32(Reader["LicenseID"]);
                    NationalNo = Reader["NationalNo"].ToString();
                    Gender = Reader["Gender"].ToString();

                    DateTime dtmIssueDate = Convert.ToDateTime(Reader["IssueDate"].ToString());

                    IssueDate = dtmIssueDate.ToString("dd/MM/yyyy");
                    IssueReason = Reader["IssueReason"].ToString();
                    Notes = Reader["Notes"].ToString();
                    IsActive = Reader["IsActive"].ToString();

                    dtmIssueDate = Convert.ToDateTime(Reader["DateOfBirth"].ToString());

                    DateOfBirth = dtmIssueDate.ToString("dd/MM/yyyy");

                    DriveID = Convert.ToInt32(Reader["DriverID"]);

                    dtmIssueDate = Convert.ToDateTime(Reader["ExpirationDate"].ToString());

                    ExpirationDate = dtmIssueDate.ToString("dd/MM/yyyy");

                    ImagePath = Reader["ImagePath"].ToString();

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


        public static bool GetDriverLicenseInfoByLicenseID(int LicenseIDToSearch, ref string ClassName, ref string FullName, ref int LicenseID, ref string NationalNo, ref string Gender, ref string IssueDate, ref string IssueReason, ref string Notes, ref string IsActive, ref string DateOfBirth, ref int DriveID, ref string ExpirationDate, ref string IsDetained, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT    LicenseClasses.ClassName,    People.FirstName,   People.SecondName,   People.ThirdName,     People.LastName,   Licenses.LicenseID,    People.NationalNo,   CASE       WHEN People.Gendor = 0 THEN 'Male'       WHEN People.Gendor = 1 THEN 'Female'       ELSE 'Unknown'   END AS Gender,  Licenses.IssueDate,  Licenses.Notes,   Licenses.IssueReason,    CASE        WHEN Licenses.IsActive = 1 THEN 'Yes'        WHEN Licenses.IsActive = 0 THEN 'No'        ELSE 'Unknown'  END AS IsActive,   People.DateOfBirth,   Drivers.DriverID,    Licenses.ExpirationDate, People.ImagePath  FROM LicenseClasses INNER JOIN LocalDrivingLicenseApplications     ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID INNER JOIN Applications    ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN People     ON Applications.ApplicantPersonID = People.PersonID INNER JOIN Licenses     ON LicenseClasses.LicenseClassID = Licenses.LicenseClass     INNER JOIN Drivers    ON People.PersonID = Drivers.PersonID      AND Licenses.DriverID = Drivers.DriverID WHERE Licenses.LicenseID = @LicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseIDToSearch);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    ClassName = Reader["ClassName"].ToString();
                    FullName = $"{Reader["FirstName"]} {Reader["SecondName"]} {Reader["ThirdName"]} {Reader["LastName"]}";
                    LicenseID = Convert.ToInt32(Reader["LicenseID"]);
                    NationalNo = Reader["NationalNo"].ToString();
                    Gender = Reader["Gender"].ToString();

                    DateTime dtmIssueDate = Convert.ToDateTime(Reader["IssueDate"].ToString());

                    IssueDate = dtmIssueDate.ToString("dd/MM/yyyy");
                    IssueReason = Reader["IssueReason"].ToString();
                    Notes = Reader["Notes"].ToString();
                    IsActive = Reader["IsActive"].ToString();

                    dtmIssueDate = Convert.ToDateTime(Reader["DateOfBirth"].ToString());

                    DateOfBirth = dtmIssueDate.ToString("dd/MM/yyyy");

                    DriveID = Convert.ToInt32(Reader["DriverID"]);

                    dtmIssueDate = Convert.ToDateTime(Reader["ExpirationDate"].ToString());

                    ExpirationDate = dtmIssueDate.ToString("dd/MM/yyyy");

                    ImagePath = Reader["ImagePath"].ToString();

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

        public static bool CheckIfThisPersonIsDriver(int PersonID)
        {

            bool IsDriver = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT R1 = 'Yes' FROM Drivers WHERE PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
                {

                    IsDriver = true;

                }



            }
            catch (Exception)
            {
                IsDriver = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsDriver;

        }


        public static bool CheckIfThisPersonHasInternationalLicense (int PersonID)
        {

            bool HasLicense = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT R1 = 'Yes'\r\nFROM   InternationalLicenses INNER JOIN\r\n             Applications ON InternationalLicenses.ApplicationID = Applications.ApplicationID INNER JOIN\r\n             People ON Applications.ApplicantPersonID = People.PersonID\r\nWHERE (PersonID = @PersonID)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && Result != DBNull.Value)
                {

                    HasLicense = true;

                }



            }
            catch (Exception)
            {
                HasLicense = false;
            }
            finally
            {
                Connection.Close();
            }

            return HasLicense;

        }
        public static int GetDriverIdByUsingPersonID(int PersonID)
        {

            int DriverID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select Drivers.DriverID from Drivers where PersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    DriverID = ID;
                }

            }
            catch (Exception)
            {
                DriverID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return DriverID;

        }

        public static DataTable GetAllDrivers()
        {

            DataTable dtDrivers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select Drivers_View.DriverID, Drivers_View.PersonID, Drivers_View.NationalNo, Drivers_View.FullName, CreatedDate, case when NumberOfActiveLicenses = 0 then 'Not Active' else 'Active' end As IsActive  from Drivers_View;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtDrivers.Load(Reader);
                }
            }

            catch (Exception)
            {
                dtDrivers = null;
            }

            finally
            {
                Connection.Close();
            }

            return dtDrivers;

        }

        public static DataTable GetAllDriversWhereDriverIDStartWith(string DriverIDStartWith)
        {


            DataTable drDrivers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT *, \r\n       CASE WHEN NumberOfActiveLicenses = 0 THEN 'Not Active' ELSE 'Active' END AS IsActive  \r\nFROM Drivers_View where DriverID like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", DriverIDStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    drDrivers.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                drDrivers = null;
            }
            finally
            {
                Connection.Close();
            }

            return drDrivers;

        }

        public static DataTable GetAllDriversWherePersonIDStartWith(string DriverIDStartWith)
        {


            DataTable drDrivers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT *, \r\n       CASE WHEN NumberOfActiveLicenses = 0 THEN 'Not Active' ELSE 'Active' END AS IsActive  \r\nFROM Drivers_View where PersonID like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", DriverIDStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    drDrivers.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                drDrivers = null;
            }
            finally
            {
                Connection.Close();
            }

            return drDrivers;

        }

        public static DataTable GetAllDriversWhereFullNameStartWith(string DriverIDStartWith)
        {


            DataTable drDrivers = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT *, \r\n       CASE WHEN NumberOfActiveLicenses = 0 THEN 'Not Active' ELSE 'Active' END AS IsActive  \r\nFROM Drivers_View where FullName like '' + @StartWith + '%'";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@StartWith", DriverIDStartWith);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    drDrivers.Load(Reader);
                }

                Reader.Close();

            }
            catch (Exception)
            {
                drDrivers = null;
            }
            finally
            {
                Connection.Close();
            }

            return drDrivers;

        }



        public static bool GetDriverLicenseInfoByLicenseID(int LicenseID, ref string ClassName, ref string FullName, ref string NationalNo, ref string Gender, ref string IssueDate, ref string IssueReason, ref string Notes, ref string IsActive, ref string DateOfBirth, ref int DriveID, ref string ExpirationDate, ref string IsDetained, ref string ImagePath)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT     LicenseClasses.ClassName,    People.FirstName,     People.SecondName,     People.ThirdName,     People.LastName, Licenses.LicenseID,     People.NationalNo,    CASE         WHEN People.Gendor = 0 THEN 'Male'       WHEN People.Gendor = 1 THEN 'Female'       ELSE 'Unknown'     END AS Gender, Licenses.IssueDate,  Licenses.Notes,   Licenses.IssueReason, CASE       WHEN Licenses.IsActive = 1 THEN 'Yes'       WHEN Licenses.IsActive = 0 THEN 'No'        ELSE 'Unknown'     END AS IsActive, People.DateOfBirth,    Drivers.DriverID,     Licenses.ExpirationDate, People.ImagePath FROM LicenseClasses INNER JOIN LocalDrivingLicenseApplications ON LicenseClasses.LicenseClassID = LocalDrivingLicenseApplications.LicenseClassID INNER JOIN Applications     ON LocalDrivingLicenseApplications.ApplicationID = Applications.ApplicationID INNER JOIN People ON Applications.ApplicantPersonID = People.PersonID INNER JOIN Licenses ON LicenseClasses.LicenseClassID = Licenses.LicenseClass  INNER JOIN Drivers ON People.PersonID = Drivers.PersonID    AND Licenses.DriverID = Drivers.DriverID WHERE (Licenses.LicenseID = @LicenseID) and (Licenses.IsActive = 1);";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    ClassName = Reader["ClassName"].ToString();
                    FullName = $"{Reader["FirstName"]} {Reader["SecondName"]} {Reader["ThirdName"]} {Reader["LastName"]}";
                    LicenseID = Convert.ToInt32(Reader["LicenseID"]);
                    NationalNo = Reader["NationalNo"].ToString();
                    Gender = Reader["Gender"].ToString();

                    DateTime dtmIssueDate = Convert.ToDateTime(Reader["IssueDate"].ToString());

                    IssueDate = dtmIssueDate.ToString("dd/MM/yyyy");
                    IssueReason = Reader["IssueReason"].ToString();
                    Notes = Reader["Notes"].ToString();
                    IsActive = Reader["IsActive"].ToString();

                    dtmIssueDate = Convert.ToDateTime(Reader["DateOfBirth"].ToString());

                    DateOfBirth = dtmIssueDate.ToString("dd/MM/yyyy");

                    DriveID = Convert.ToInt32(Reader["DriverID"]);

                    dtmIssueDate = Convert.ToDateTime(Reader["ExpirationDate"].ToString());

                    ExpirationDate = dtmIssueDate.ToString("dd/MM/yyyy");

                    ImagePath = Reader["ImagePath"].ToString();

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

        public static int GetInternationaLicenseIDFees()
        {

            int Fees = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select ApplicationFees from ApplicationTypes where ApplicationTypeID = 6;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    Fees = Convert.ToInt32(Result);
                }

            }
            catch (Exception)
            {
                Fees = -1;
            }
            finally
            {
                Connection.Close();
            }

            return Fees;

        }

        public static int GetInternationalLicenseID(int LocalLicenseID)
        {

            int InternationalLicenseID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select InternationalLicenseID from InternationalLicenses where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", LocalLicenseID);

            try
            {

                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    InternationalLicenseID = Convert.ToInt32(Result);
                }
                else
                {
                    InternationalLicenseID = -1;
                }
            }
            catch (Exception)
            {
                InternationalLicenseID = -1;
            }
            finally
            {
                Connection.Close();

            }
            return InternationalLicenseID;
        }

        public static bool CheckIfThisLicenseIsThirdClass(int LocalLicenseID)
        {
            int LicenseClassID = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select LicenseClass from Licenses where LicenseID = @LicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LocalLicenseID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    LicenseClassID = Convert.ToInt32(Result);

                }

            }
            catch (Exception)
            {
                LicenseClassID = 0;
            }
            finally
            {
                Connection.Close();
            }

            return (LicenseClassID == 3) ? true : false;

        }

        public static bool GetRequiredInternationalLicenseInfo(int LocalLicenseID, ref int PersonID, ref int DriverID)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Drivers.DriverID, People.PersonID\r\nFROM   Applications INNER JOIN\r\n             Licenses ON Applications.ApplicationID = Licenses.ApplicationID INNER JOIN\r\n             Drivers ON Licenses.DriverID = Drivers.DriverID INNER JOIN\r\n             People ON Applications.ApplicantPersonID = People.PersonID\r\nWHERE (Licenses.LicenseID = @LicenseID)";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LocalLicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    PersonID = Convert.ToInt32(Reader["PersonID"]);
                    DriverID = Convert.ToInt32(Reader["DriverID"]);
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

        public static int AddNewInternaTionalLicense(int LocalLicenseID, int ApplicationID, int DriverID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "INSERT INTO InternationalLicenses\r\n    (ApplicationID, DriverID, IssuedUsingLocalLicenseID, IssueDate, ExpirationDate, IsActive, CreatedByUserID)\r\nVALUES\r\n    (@ApplicationID, @DriverID, @LocalLicenseID, @IssueDate, @ExpirationDate, @IsActive, @CreatedByUserID);\r\n\r\nSELECT SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalLicenseID", LocalLicenseID);
            Command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            Command.Parameters.AddWithValue("@DriverID", DriverID);
            Command.Parameters.AddWithValue("@IssueDate", IssueDate);
            Command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsActive", IsActive);

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

        public static bool GetInternationalLicenseInfo(int InternationalLicenseID, ref string FullName, ref int LicenseID, ref string NationalNo, ref string Gender, ref string IssueDate, ref int ApplicationID, ref string IsActive, ref string DateOfBirth, ref int DriverID, ref string ExpirationDate)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT \r\n    People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName AS FullName,\r\n    InternationalLicenses.InternationalLicenseID,\r\n    Licenses.LicenseID,\r\n    People.NationalNo,\r\n    CASE People.Gendor \r\n        WHEN 0 THEN 'Male'\r\n        WHEN 1 THEN 'Female'\r\n        ELSE 'Unknown'\r\n    END AS Gender,\r\n    InternationalLicenses.IssueDate,\r\n    Applications.ApplicationID,\r\n    CASE InternationalLicenses.IsActive \r\n        WHEN 1 THEN 'Yes'\r\n        WHEN 0 THEN 'No'\r\n        ELSE 'Unknown'\r\n    END AS IsActive,\r\n    People.DateOfBirth,\r\n    Drivers.DriverID,\r\n    InternationalLicenses.ExpirationDate\r\nFROM Applications\r\nINNER JOIN People ON Applications.ApplicantPersonID = People.PersonID\r\nINNER JOIN Drivers ON People.PersonID = Drivers.PersonID\r\nINNER JOIN InternationalLicenses ON Drivers.DriverID = InternationalLicenses.DriverID\r\nINNER JOIN Licenses ON Applications.ApplicationID = Licenses.ApplicationID \r\n    AND Drivers.DriverID = Licenses.DriverID \r\n    AND InternationalLicenses.IssuedUsingLocalLicenseID = Licenses.LicenseID where InternationalLicenses.InternationalLicenseID = @InternationalLicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {

                    IsFound = true;

                    FullName = Reader["FullName"].ToString();
                    LicenseID = Convert.ToInt32(Reader["LicenseID"]);
                    NationalNo = Reader["NationalNo"].ToString();
                    Gender = Reader["Gender"].ToString();

                    DateTime dtmIssueDate = Convert.ToDateTime(Reader["IssueDate"].ToString());
                    IssueDate = dtmIssueDate.ToString("dd/MM/yyyy");

                    IsActive = Reader["IsActive"].ToString();

                    dtmIssueDate = Convert.ToDateTime(Reader["DateOfBirth"].ToString());
                    DateOfBirth = dtmIssueDate.ToString("dd/MM/yyyy");

                    DriverID = Convert.ToInt32(Reader["DriverID"]);

                    dtmIssueDate = Convert.ToDateTime(Reader["ExpirationDate"].ToString());
                    ExpirationDate = dtmIssueDate.ToString("dd/MM/yyyy");

                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);

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


        public static int GetPersonIDByLicenseID(int LicenseID)
        {
            int PersonID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Drivers.PersonID\r\nFROM   Licenses INNER JOIN\r\nDrivers ON Licenses.DriverID = Drivers.DriverID\r\nwhere LicenseID = @LicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    PersonID = Convert.ToInt32(Result);
                }


            }
            catch (Exception)
            {
                PersonID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return PersonID;

        }

        public static DataTable GetAllLicenseForPersonID(int PersonID)
        {

            DataTable dtLicenses = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Licenses.LicenseID, Licenses.ApplicationID, LicenseClasses.ClassName, Licenses.IssueDate, Licenses.ExpirationDate, Licenses.IsActive\r\nFROM   Licenses INNER JOIN\r\n             Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN\r\n             LicenseClasses ON Licenses.LicenseClass = LicenseClasses.LicenseClassID\r\n\t\t\t where ApplicantPersonID = @ApplicantPersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ApplicantPersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtLicenses.Load(Reader);
                }

            }
            catch (Exception)
            {
                dtLicenses = null;
            }

            finally
            {
                Connection.Close();
            }

            return dtLicenses;

        }


        public static DataTable GetAllInternationalLicenseForPersonID(int PersonID)
        {

            DataTable dtLicenses = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT InternationalLicenses.InternationalLicenseID, Applications.ApplicationID, InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive\r\nFROM   Applications INNER JOIN\r\n             InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID\r\n\t\t\t where Applications.ApplicantPersonID = @PersonID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtLicenses.Load(Reader);
                }

            }
            catch (Exception)
            {
                dtLicenses = null;
            }

            finally
            {
                Connection.Close();
            }

            return dtLicenses;

        }

        public static DataTable GetAllInternationalLicense()
        {
            DataTable dtInternationalLicenses = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT InternationalLicenses.InternationalLicenseID, Applications.ApplicationID, Drivers.DriverID , InternationalLicenses.IssuedUsingLocalLicenseID, InternationalLicenses.IssueDate, InternationalLicenses.ExpirationDate, InternationalLicenses.IsActive\r\nFROM   Applications INNER JOIN\r\n             InternationalLicenses ON Applications.ApplicationID = InternationalLicenses.ApplicationID INNER JOIN\r\n             Drivers ON InternationalLicenses.DriverID = Drivers.DriverID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dtInternationalLicenses.Load(Reader);
                }


            }
            catch (Exception)
            {
                dtInternationalLicenses = null;
            }
            finally
            {
                Connection.Close();
            }
            return dtInternationalLicenses;
        }

        public static bool SetLicenseToInactive(int LicenseID)
        {
            bool IsSuccess = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "Update Licenses set IsActive = 0 where LicenseID = @LicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                int RowsAffected = Command.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    IsSuccess = true;
                }
            }
            catch (Exception)
            {
                IsSuccess = false;
            }
            finally
            {
                Connection.Close();
            }
            return IsSuccess;


        }

        public static bool GetApplicationIDAndLicenseClassFromLocalLicense(int LocalLicense,ref int PersonID,ref int ApplicationID, ref int LicenseClass)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Applications.ApplicantPersonID, Licenses.ApplicationID, Licenses.LicenseClass FROM   Licenses INNER JOIN             Applications ON Licenses.ApplicationID = Applications.ApplicationID where LicenseID = @LicenseID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LocalLicense);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    PersonID = Convert.ToInt32(Reader["ApplicantPersonID"]);
                    ApplicationID = Convert.ToInt32(Reader["ApplicationID"]);
                    LicenseClass = Convert.ToInt32(Reader["LicenseClass"]);
                    
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

        public static int GetDriverIDByLicenseID(int LocalLicense)
        {
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "select DriverID from Licenses where LicenseID = @LicenseID;\r\n";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LocalLicense);

            int DriverID = -1;

            try {
            
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    DriverID = Convert.ToInt32(Result);
                }


            }
            catch (Exception)
            {
                DriverID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return DriverID;


        }


        public static int GetLocalLicenseIDByLocalLicenseID(int LocalLicenseApplication)
        {

            int LocalLicenseID = -1;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Licenses.LicenseID,Licenses.ApplicationID\r\nFROM   Licenses INNER JOIN\r\n             Applications ON Licenses.ApplicationID = Applications.ApplicationID INNER JOIN\r\n             LocalDrivingLicenseApplications ON Applications.ApplicationID = LocalDrivingLicenseApplications.ApplicationID\r\n\t\t\t where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID;";


            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalLicenseApplication);

            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();

                if (Result != null)
                {
                    LocalLicenseID = Convert.ToInt32(Result);
                }

            }
            catch (Exception)
            {
                LocalLicenseID = -1;
            }
            finally
            {
                Connection.Close();
            }

            return LocalLicenseID;
        
        }


        public static bool CheckIfLicenseIsAlreadyDetained(int LicenseID)
        {
            bool IsDetained = false;
            
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);
            
            string Query = "select R1 = 'Yes' from DetainedLicenses where (LicenseID = @LicenseID) and (IsReleased = 0);";
            
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            try
            {
                Connection.Open();

                object Result = Command.ExecuteScalar();
                
                if (Result != null)
                {
                    IsDetained = true;
                }
            }
            catch (Exception)
            {
                IsDetained = false;
            }
            finally
            {
                Connection.Close();
            }

            return IsDetained;
        
        }


        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID, bool IsRealsed)
        {
            int ID = -1;
            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);
            
            string Query = "insert into DetainedLicenses(LicenseID,DetainDate,FineFees,CreatedByUserID,IsReleased,ReleaseDate,ReleasedByUserID,ReleaseApplicationID)  \r\nvalues(@LicenseID,@DetainDate,@FineFees,@CreatedByUserID,@IsReleased,null,null,null);\r\n\r\nselect SCOPE_IDENTITY();";
            
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@LicenseID", LicenseID);
            Command.Parameters.AddWithValue("@DetainDate", DetainDate);
            Command.Parameters.AddWithValue("@FineFees", FineFees);
            Command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            Command.Parameters.AddWithValue("@IsReleased", IsRealsed);


            try
            {
                Connection.Open();
                
                object Result = Command.ExecuteScalar();
                
                if (Result != null && Result != DBNull.Value)
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


        public static bool GetDetainInfo(int LicenseID ,ref int DetainID, ref DateTime DetainDate, ref string UserName)
        {

            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT DetainedLicenses.DetainID, DetainedLicenses.DetainDate, Users.UserName\r\nFROM   DetainedLicenses INNER JOIN\r\n             Users ON DetainedLicenses.CreatedByUserID = Users.UserID\r\n\t\t\t where LicenseID = @LicenseID and IsReleased = 0;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@LicenseID", LicenseID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    DetainID = Convert.ToInt32(Reader["DetainID"]);
                    DetainDate = Convert.ToDateTime(Reader["DetainDate"]);
                    UserName = Reader["UserName"].ToString();
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


        public static bool UpdateDetainDate(int DetainID,int ReleasedUserID, int ReleaseApplicationID)
        {

            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "update DetainedLicenses set IsReleased = 1, ReleaseDate = @ReleaseDate,ReleasedByUserID = @UserID,ReleaseApplicationID = @ReleaseApplicationID where DetainID = @DetainID;";

            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@ReleaseDate", DateTime.Now);
            Command.Parameters.AddWithValue("@UserID", ReleasedUserID);
            Command.Parameters.AddWithValue("@ReleaseApplicationID", ReleaseApplicationID);
            Command.Parameters.AddWithValue("@DetainID", DetainID);

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

        public static DataTable GetAllDetainedLicense()
        {
            DataTable dtDetainedLicenese = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDLVDDataAccessSettings.ConnectionSettings);

            string Query = "SELECT Drivers.DriverID, Licenses.LicenseID, DetainedLicenses.DetainDate, DetainedLicenses.IsReleased, DetainedLicenses.FineFees, DetainedLicenses.ReleaseDate, People.NationalNo, People.FirstName + ' ' + People.SecondName + ' ' + People.ThirdName + ' ' + People.LastName as FullName, \r\n             DetainedLicenses.ReleaseApplicationID\r\nFROM   Drivers INNER JOIN\r\n             Licenses ON Drivers.DriverID = Licenses.DriverID INNER JOIN\r\n             DetainedLicenses ON Licenses.LicenseID = DetainedLicenses.LicenseID INNER JOIN\r\n             People ON Drivers.PersonID = People.PersonID";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.HasRows)
                {
                    dtDetainedLicenese.Load(Reader);
                }

            }
            catch (Exception)
            {
                dtDetainedLicenese = null;
            }
            finally
            {
                Connection.Close();
            }

            return dtDetainedLicenese;

        }


    }
}