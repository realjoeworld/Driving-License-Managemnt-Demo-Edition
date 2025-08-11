using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussniss;

namespace DVLDInterface
{
    public partial class ctrlDrivingLicenseAppInfo: UserControl
    {
        public ctrlDrivingLicenseAppInfo()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        public int PersonID { get; set; }
        public int LocalLicenseApplicationID { get; set; }
        public string ClassName { get; set; } 

        public string FullName { get; set; }

        public int ApplicationID { get; set; }
        public void LoadData(int LocalLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName, string UserName, string ApplicationStatus, DateTime LastStatusDate) {
        
            lblAppID.Text = LocalLicenseApplicationID.ToString();
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
            lblLicenseType.Text = ClassName;
            this.ClassName = ClassName;
            lblAppBasicInfoID.Text = ApplicationID.ToString();
            lblStatus.Text = ApplicationStatus;
            lblFees.Text = "15";
            lblAppType.Text = "New Local Driving License Application";
            lblApplicantName.Text = $"{FirstName} {SecondName} {ThirdName} {LastName}";
            FullName = $"{FirstName} {SecondName} {ThirdName} {LastName}";
            lblDate.Text = ApplicationDate.ToString("dd/MM/yyyy");
            lblDateStatus.Text = LastStatusDate.ToString("dd/MM/yyyy");
            lblUserName.Text = UserName;
            PersonID = ApplicantPersonID;
            this.ApplicationID = ApplicationID;


        }

        public void LoadPassedTest(string PassedTest)
        {
            lblPassedTests.Text = PassedTest;
        }

        private void linklblShowPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Address = string.Empty, Phone = string.Empty, Email = string.Empty, ImagePath = string.Empty, CountryName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;

            if (clsPerson.GetPersonInfoByID(PersonID,ref  FirstName,ref SecondName,ref ThirdName,ref LastName ,ref NationalNO,ref DateOfBirth, ref Gender,ref Phone, ref Email, ref CountryName,ref Address,ref ImagePath)) {
                
                PersonDetails frmPersonDetails = new PersonDetails(PersonID,FirstName, SecondName, ThirdName,LastName, NationalNO,  DateOfBirth,  Gender,Address, Phone, Email, CountryName, ImagePath);
                frmPersonDetails.ShowDialog();
            
            }

        }


    }
}
