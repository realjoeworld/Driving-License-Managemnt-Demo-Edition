using System;
using System.Data;
using PersonDataAccess;

namespace DVLDBussniss
{
    public class clsDriver
    {

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreationDate)
        {
            return clsDriverDataAccess.AddNewDriver(PersonID, CreatedByUserID, CreationDate);
        }

        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClassID, DateTime IssueDate, DateTime ExpireIssueDate, string Notes, int PaidFees, bool IsActive, int IssueReason, int CreatedByUserID)
        {
            return clsDriverDataAccess.AddNewLicense(ApplicationID, DriverID, LicenseClassID, IssueDate, ExpireIssueDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        public static int GetDrivingClassFromApplicationID(int ApplicationID)
        {
            return clsDriverDataAccess.GetDrivingClassFromApplicationID(ApplicationID);
        }

        public static bool GetDriverLicenseInfo(int LocalLicenseAppID, ref string ClassName, ref string FullName, ref int LicenseID, ref string NationalNo, ref string Gender, ref string IssueDate, ref string IssueReason, ref string Notes, ref string IsActive, ref string DateOfBirth, ref int DriveID, ref string ExpirationDate, ref string IsDetained, ref string ImagePath)
        {
            return clsDriverDataAccess.GetDriverLicenseInfo(LocalLicenseAppID, ref ClassName, ref FullName, ref LicenseID, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriveID, ref ExpirationDate, ref IsDetained, ref ImagePath);
        }

        public static bool GetDriverLicenseInfoByLicenseID(int LicenseIDToSearch, ref string ClassName, ref string FullName, ref int LicenseID, ref string NationalNo, ref string Gender, ref string IssueDate, ref string IssueReason, ref string Notes, ref string IsActive, ref string DateOfBirth, ref int DriveID, ref string ExpirationDate, ref string IsDetained, ref string ImagePath)
        {
            return clsDriverDataAccess.GetDriverLicenseInfoByLicenseID(LicenseIDToSearch, ref ClassName, ref FullName, ref LicenseID, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriveID, ref ExpirationDate, ref IsDetained, ref ImagePath);
        }


        public static bool CheckIfThisPersonIsDriver(int PersonID)
        {
            return clsDriverDataAccess.CheckIfThisPersonIsDriver(PersonID);
        }

        public static int GetDriverIdByUsingPersonID(int PersonID)
        {
            return clsDriverDataAccess.GetDriverIdByUsingPersonID(PersonID);
        }

        public static DataTable GetAllDrivers()
        {
            return clsDriverDataAccess.GetAllDrivers();
        }

        public static DataTable GetAllDriversWhereDriverIDStartWith(string DriverIDStartWith)
        {
            return clsDriverDataAccess.GetAllDriversWhereDriverIDStartWith(DriverIDStartWith);
        }

        public static DataTable GetAllDriversWherePersonIDStartWith(string DriverIDStartWith)
        {
            return clsDriverDataAccess.GetAllDriversWherePersonIDStartWith(DriverIDStartWith);
        }

        public static DataTable GetAllDriversWhereFullNameStartWith(string DriverIDStartWith)
        {
            return clsDriverDataAccess.GetAllDriversWhereFullNameStartWith(DriverIDStartWith);
        }

        public static bool GetDriverLicenseInfoByLicenseID(int LicenseID, ref string ClassName, ref string FullName, ref string NationalNo, ref string Gender, ref string IssueDate, ref string IssueReason, ref string Notes, ref string IsActive, ref string DateOfBirth, ref int DriveID, ref string ExpirationDate, ref string IsDetained, ref string ImagePath)
        {
            return clsDriverDataAccess.GetDriverLicenseInfoByLicenseID(LicenseID, ref ClassName, ref FullName, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriveID, ref ExpirationDate, ref IsDetained, ref ImagePath);
        }

        public static int GetInternationaLicenseIDFees() {
            return clsDriverDataAccess.GetInternationaLicenseIDFees();
        }

        public static int GetInternationalLicenseID(int LocalLicenseID)
        {
            return clsDriverDataAccess.GetInternationalLicenseID(LocalLicenseID);
        }

        public static bool CheckIfThisLicenseIsThirdClass(int LocalLicenseID)
        {
            return clsDriverDataAccess.CheckIfThisLicenseIsThirdClass(LocalLicenseID);
        }
        public static bool GetRequiredInternationalLicenseInfo(int LocalLicenseID, ref int PersonID, ref int DriverID)
        {
            return clsDriverDataAccess.GetRequiredInternationalLicenseInfo(LocalLicenseID, ref PersonID, ref DriverID);
        }

        public static int AddNewInternaTionalLicense(int LocalLicenseID, int ApplicationID, int DriverID, DateTime IssueDate, DateTime ExpirationDate, bool IsActive, int CreatedByUserID)
        {
            return clsDriverDataAccess.AddNewInternaTionalLicense(LocalLicenseID, ApplicationID, DriverID, IssueDate, ExpirationDate, IsActive, CreatedByUserID);
        }

        public static bool GetInternationalLicenseInfo(int InternationalLicenseID, ref string FullName, ref int LicenseID, ref string NationalNo, ref string Gender, ref string IssueDate, ref int ApplicationID, ref string IsActive, ref string DateOfBirth, ref int DriverID, ref string ExpirationDate)
        {
            return clsDriverDataAccess.GetInternationalLicenseInfo(InternationalLicenseID, ref FullName, ref LicenseID, ref NationalNo, ref Gender, ref IssueDate, ref ApplicationID, ref IsActive, ref DateOfBirth, ref DriverID, ref ExpirationDate);
        }

        public static int GetPersonIDByLicenseID(int LicenseID)
        {
            return clsDriverDataAccess.GetPersonIDByLicenseID(LicenseID);
        }

        public static DataTable GetAllLicenseForPersonID(int PersonID)
        {
            return clsDriverDataAccess.GetAllLicenseForPersonID(PersonID);
        }
        public static DataTable GetAllInternationalLicenseForPersonID(int PersonID)
        {
            return clsDriverDataAccess.GetAllInternationalLicenseForPersonID(PersonID);
        }

        public static DataTable GetAllInternationalLicense()
        {
            return clsDriverDataAccess.GetAllInternationalLicense();
        }

        public static bool SetLicenseToInactive(int LicenseID)
        {
            return clsDriverDataAccess.SetLicenseToInactive(LicenseID);
        }

        public static bool GetPersonIDAndApplicationIDAndLicenseClassFromLocalLicense(int LocalLicense, ref int PersonID, ref int ApplicationID, ref int LicenseClass)
        {
            return clsDriverDataAccess.GetApplicationIDAndLicenseClassFromLocalLicense(LocalLicense, ref PersonID, ref ApplicationID, ref LicenseClass);
        }

        public static int GetDriverIDByLicenseID(int LocalLicense)
        {
            return clsDriverDataAccess.GetDriverIDByLicenseID(LocalLicense);
        }

        public static int GetLocalLicenseIDByLocalLicenseID(int LocalLicenseApplication)
        {
            return clsDriverDataAccess.GetLocalLicenseIDByLocalLicenseID(LocalLicenseApplication);
        }

        public static bool CheckIfLicenseIsAlreadyDetained(int LicenseID)
        {
            return clsDriverDataAccess.CheckIfLicenseIsAlreadyDetained(LicenseID);
        }

        public static int AddNewDetainedLicense(int LicenseID, DateTime DetainDate, int FineFees, int CreatedByUserID, bool IsRealsed)
        {
            return clsDriverDataAccess.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID, IsRealsed);
        }

        public static bool GetDetainInfo(int LicenseID, ref int DetainID, ref DateTime DetainDate, ref string UserName)
        {
            return clsDriverDataAccess.GetDetainInfo(LicenseID, ref DetainID, ref DetainDate, ref UserName);
        }

        public static bool UpdateDetainDate(int DetainID, int ReleasedUserID, int ReleaseApplicationID)
        {
            return clsDriverDataAccess.UpdateDetainDate(DetainID, ReleasedUserID, ReleaseApplicationID);
        }

        public static DataTable GetAllDetainedLicense()
        {
            return clsDriverDataAccess.GetAllDetainedLicense();
        }

        public static bool CheckIfThisPersonHasInternationalLicense(int PersonID)
        {
            return clsDriverDataAccess.CheckIfThisPersonHasInternationalLicense(PersonID);
        }


    }

}
