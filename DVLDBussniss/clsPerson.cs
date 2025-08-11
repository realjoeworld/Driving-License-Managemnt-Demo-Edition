using System;
using System.Data;
using System.Data.SqlClient;
using DVLDBussniss;
using Microsoft.SqlServer.Server;
using PersonDataAccess;

namespace DVLDBussniss
{
    public class clsPerson
    {

        public int PersonID { get; set; }

        public string NationalNumber { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Gender { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public byte NationalityCountryID { get; set; }

        public string ImagePath { get; set; }


        public static int AddNewPerson(string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth, byte Gender, string Address, string Phone, string Email, byte CountryID, string ImagePath)
        {
            return clsPersonDataAccess.AddNewPerson(FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
        }

        public static DataTable GetAllPersonsInfo()
        {
            return clsPersonDataAccess.GetAllPersonsInfo();
        }

        public static bool GetPersonInfo(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref int Gender, ref string Phone, ref string Email, ref int CountryID, ref string Address, ref string ImagePath)
        {
            return clsPersonDataAccess.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryID, ref Address, ref ImagePath);
        }
        public static bool CheckIfNationalNumberExists(string NationalNumber)
        {
            return clsPersonDataAccess.CheckIfNationalNumberExist(NationalNumber);
        }

        public static DataTable GetAllPersonsFirstNameStartWith(string FirstNameStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsFirstNameStartWith(FirstNameStartWith);
        }

        public static DataTable GetAllPersonsSecondNameStartWith(string SecondNameStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsSecondNameStartWith(SecondNameStartWith);
        }

        public static DataTable GetAllPersonsThirdNameStartWith(string ThirdNameStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsThirdNameStartWith(ThirdNameStartWith);
        }

        public static DataTable GetAllPersonsLastNameStartWith(string LastNameStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsLastNameStartWith(LastNameStartWith);
        }

        public static DataTable GetAllPersonsNationalNoStartWith(string LastNameStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsNationalNoStartWith(LastNameStartWith);
        }

        public static DataTable GetAllPersonsPersonIDStartWith(string PersonIDStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsPersonIDStartWith(PersonIDStartWith);
        }

        public static DataTable GetAllPersonsCountryNaemStartWith(string CountryNameStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsNationalityStartWith(CountryNameStartWith);
        }
        public static DataTable GetAllPersonsWithMaleGender()
        {
            return clsPersonDataAccess.GetAllPersonsGenderMale();
        }

        public static DataTable GetAllPersonsWithFeMaleGender()
        {
            return clsPersonDataAccess.GetAllPersonsGenderFeMale();
        }

        public static DataTable GetAllPersonsWithPhoneStartWith(string PhoneStartWith)
        {
            return clsPersonDataAccess.GetAllPersonsPhoneStartWith(PhoneStartWith);
        }

        public static DataTable GetAllPersonsWithEmailStartWith(string EmailtartWith)
        {
            return clsPersonDataAccess.GetAllPersonsEmailStartWith(EmailtartWith);
        }

        public static bool UpdatePersonInfo(int PersonID, string FirstName, string SecondName, string ThirdName, string LastName, string NationalNo, DateTime DateOfBirth, string Gender, string Address, string Phone, string Email, int CountryID, string ImagePath)
        {
            return clsPersonDataAccess.UpdatePerson(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNo, DateOfBirth, Gender, Address, Phone, Email, CountryID, ImagePath);
        }

        public static bool DeletePerson(int PersonID)
        {
            return clsPersonDataAccess.DeletePersonByPersonID(PersonID);
        }

        public static bool GetPersonInfoByNationalNo(ref int ID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string NationalNo, ref DateTime DateOfBirth, ref int Gender, ref string Phone, ref string Email, ref int CountryID, ref string Address, ref string ImagePath)
        {
            return clsPersonDataAccess.GetPersonInfoByNationalNo(ref ID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNo, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryID, ref Address, ref ImagePath);
        }

        public static bool CheckIfThisPersonIsUser(int PersonID)
        {
            return clsPersonDataAccess.CheckIfThisPersonIsUser(PersonID);
        }

        public static bool GetPersonInfoByID(int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref string NationalNO, ref DateTime DateOfBirth, ref string Gender, ref string Phone, ref string Email, ref string CountryName, ref string Address, ref string ImagePath)
        {
            return clsPersonDataAccess.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath);
        }

        public static bool GerPersonInfoByNationalO(ref int PersonID, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LsatName, ref DateTime DateOfBirth, string NationalNO, ref string Gender, ref string Phone, ref string Email, ref string CountryName, ref string Address, ref string ImagePath)
        {
            return clsPersonDataAccess.GetPersonInfoByNationalO(ref PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LsatName, NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath);
        }

        public static int CheckIfPersonHasApplicationItsStatusNewAndSameLicenseClass(int PersonID, int LicenseClass)
        {
            return clsPersonDataAccess.CheckIfPersonHasApplicationItsStatusNewAndSameLicenseClass(PersonID, LicenseClass);
        }

        public static int AddNewApplicationForLocalLicense(int PersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int UserID)
        {
            return clsPersonDataAccess.AddNewApplication(PersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, UserID);
        }

        public static int AddNewLocalLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            return clsPersonDataAccess.AddNewLocalLicenseApplication(ApplicationID, LicenseClassID);
        }

        public static DataTable GetAllLocalLicenseInfo()
        {
            return clsPersonDataAccess.GetAllLocalLicenseInfo();
        }

        public static DataTable GetAllLocalLicenseNoStartWith(string NoStartWith)
        {
            return clsPersonDataAccess.GetAllLocalLicenseNoStartWith(NoStartWith);
        }
        public static DataTable GetAllLocalLicenseAppIDStartWith(string PersonIDStartWith)
        {
            return clsPersonDataAccess.GetAllLocalLicenseAppIDStartWith(PersonIDStartWith);
        }

        public static DataTable GetAllLocalLicenseFullNameStartWith(string FullNameStartWith)
        {
            return clsPersonDataAccess.GetAllLocalLicenseFullNameStartWith(FullNameStartWith);
        }

        public static DataTable GetAllLocalLicenseByItsStatus(string Status)
        {
            return clsPersonDataAccess.GetAllLocalLicenseByItsStatus(Status);
        }

        public static bool CancelApplication(int AppID)
        {
            return clsPersonDataAccess.CancelApplication(AppID);
        }

        public static int GetApplicationIDFromLocalLicenseApplication(int LocalLicenceID)
        {
            return clsPersonDataAccess.GetApplicationIDFromLocalLicenseApplication(LocalLicenceID);
        }

        public static bool GetLocalLicenseApplicationInfo(int LocalLicenseApplicationID, ref int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref string ClassName, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref string UserName, ref string ApplicationStatus, ref DateTime LastStatusDate)
        {
            return clsPersonDataAccess.GetLocalLicenseApplicationInfo(LocalLicenseApplicationID, ref ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ClassName, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref UserName, ref ApplicationStatus, ref LastStatusDate);
        }

        public static bool CheckIfThisPersonHasAnAppointment(int PersonID)
        {
            return clsPersonDataAccess.CheckIfThisPersonHasAnAppointment(PersonID);
        }
        public static DataTable GetAllAppointmentsForDLLicenseApp(int ID)
        {
            return clsPersonDataAccess.GetAllAppointmentsForDLLicenseApp(ID);
        }
        public static int AddNewAppointments(int TestTypeID, int LocalLicenseID, DateTime AppointmentDate, int PaidFees, int UserID)
        {
            return clsPersonDataAccess.AddNewAppointments(TestTypeID, LocalLicenseID, AppointmentDate, PaidFees, UserID);
        }
        public static bool UpdateTestAppointment(int TestID, DateTime NewAppointmentDate)
        {
            return clsPersonDataAccess.UpdateTestAppointment(TestID, NewAppointmentDate);
        }
        public static bool GetAppointmentDate(int TestAppointmentID, ref DateTime AppointmentDate)
        {
            return clsPersonDataAccess.GetAppointmentDate(TestAppointmentID, ref AppointmentDate);
        }
        public static int AddNewTest(int TestAppointemntID, bool TestResult, string Notes, int UserID)
        {
            return clsPersonDataAccess.AddNewTest(TestAppointemntID, TestResult, Notes, UserID);
        }

        public static bool UpdateTestAppointmentToBeLocked(int TestAppointmentID)
        {
            return clsPersonDataAccess.UpdateTestAppointmentToBeLocked(TestAppointmentID);
        }

        public static bool CheckIfThisPersonPassedTheVisionTest(int LocalLicenseApplicationID)
        {
           return clsPersonDataAccess.CheckIfThisPersonPassedTheVisionTest(LocalLicenseApplicationID);
        }

        public static bool CheckIfThisPersonFailedTheVisionTest(int LocalLicenseID) {
        return clsPersonDataAccess.CheckIfThisPersonFailedTheVisionTest(LocalLicenseID);
        }

        public static DataTable GetAllWrittenAppointmentsForDLLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            return clsPersonDataAccess.GetAllWrittenAppointmentsForDLLicenseApp(LocalDrivingLicenseApplicationID);
        }

        public static bool CheckIfThisPersonPassedTheWrritenTest(int LocalLicenseID)
        {
            return clsPersonDataAccess.CheckIfThisPersonPassedTheWrritenTest(LocalLicenseID);
        }
        public static bool CheckIfThisPersonHasWrritenAppointment(int PersonID)
        {
            return clsPersonDataAccess.CheckIfThisPersonHasWrritenAppointment(PersonID);
        }

        public static bool CheckIfThisPersonFailedTheWrritenTest(int LocalLicenseID)
        {
            return clsPersonDataAccess.CheckIfThisPersonFailedTheWrritenTest(LocalLicenseID);
        }

        public static bool CheckIfThisPersonPassedTheStreetTest(int LocalLicenseID)
        {
            return clsPersonDataAccess.CheckIfThisPersonPassedTheStreetTest(LocalLicenseID);
        }

        public static bool CheckIfThisPersonHasStreetAppointment(int PersonID)
        {
            return clsPersonDataAccess.CheckIfThisPersonHasStreetAppointment(PersonID);
        }

        public static bool CheckIfThisPersonFailedTheStreetTest(int LocalLicenseID)
        {
            return clsPersonDataAccess.CheckIfThisPersonFailedTheStreetTest(LocalLicenseID);
        }

        public static DataTable GetAllStreetAppointmentsForDLLicenseApp(int LocalDrivingLicenseApplicationID)
        {
            return clsPersonDataAccess.GetAllStreetAppointmentsForDLLicenseApp(LocalDrivingLicenseApplicationID);
        }

        public static bool SetApplicationToBeCompleted(int AppID)
        {
            return clsPersonDataAccess.SetApplicationToBeCompleted(AppID);
        }

        public static int AddNewApplicationForInternationalLicense(int PersonID, DateTime ApplicationDate, int ApplicationTypeID, int ApplicationStatus, DateTime LastStatusDate, int PaidFees, int UserID)
        {
            return clsPersonDataAccess.AddNewApplication(PersonID, ApplicationDate, 6, 3, LastStatusDate, PaidFees, UserID);
        }

        public static int AddNewRenewLicenseApplication(int PersonID, int UserID)
        {
            return clsPersonDataAccess.AddNewRenewLicenseApplication(PersonID, UserID);
        }
        public static int AddNewDamagedLicenseApplication(int PersonID, int UserID)
        {
            return clsPersonDataAccess.AddNewDamagedLicenseApplication(PersonID, UserID);
        }

        public static int AddNewLostLicenseApplication(int PersonID, int UserID)
        {
            return clsPersonDataAccess.AddNewLostLicenseApplication(PersonID, UserID);
        }

        public static int AddNewReleaseDetainedLicenseApplication(int PersonID, int UserID)
        {
            return clsPersonDataAccess.AddNewReleaseDetainedLicenseApplication(PersonID, UserID);
        }

    }
}
