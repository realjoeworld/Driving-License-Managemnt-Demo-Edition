using DVLDBussniss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDInterface
{
    public partial class IssueDrivingLicenseForFirstTime : Form
    {
        public IssueDrivingLicenseForFirstTime()
        {
            InitializeComponent();
        }

        public delegate void SendDataBack();
        public event SendDataBack DataBack;

        public IssueDrivingLicenseForFirstTime(int LocalLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName, string UserName, string ApplicationStatus, DateTime LastStatusDate)
        {
            InitializeComponent();
            ctrlDrivingLicenseAppInfo1.LoadData(LocalLicenseApplicationID, ApplicationID, ApplicantPersonID, ApplicationDate, ClassName, FirstName, SecondName, ThirdName, LastName, UserName, ApplicationStatus, LastStatusDate);
            this.Size = new Size(800, 600);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int ID = -1;

            if (!clsDriver.CheckIfThisPersonIsDriver(ctrlDrivingLicenseAppInfo1.PersonID))
            {

                if ((ID = clsDriver.AddNewDriver(ctrlDrivingLicenseAppInfo1.PersonID, clsCurrentUser.CurrentUser.UserID, DateTime.Now)) != -1)
                {

                    MessageBox.Show("Driver Added Successfully, ID: " + ID);

                    int ClassID = clsDriver.GetDrivingClassFromApplicationID(ctrlDrivingLicenseAppInfo1.ApplicationID);

                    int LicenseID = -1;

                    bool IsActive = true;

                    if ((ClassID != -1) && ((LicenseID = clsDriver.AddNewLicense(ctrlDrivingLicenseAppInfo1.ApplicationID, ID, ClassID, DateTime.Now, DateTime.Now.AddYears(10), txtboxNotes.Text, 15, IsActive, 1, clsCurrentUser.CurrentUser.UserID)) != -1) && clsPerson.SetApplicationToBeCompleted(ctrlDrivingLicenseAppInfo1.ApplicationID))
                    {

                        MessageBox.Show("License Issued Successfully With ID: " + LicenseID);
                        DataBack?.Invoke();

                    }
                    else
                    {
                        MessageBox.Show("Error Issuing License, Please Try Again Later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
            }

            else
            {

                MessageBox.Show("This Person Already A Driver In The System");

                int ClassID = clsDriver.GetDrivingClassFromApplicationID(ctrlDrivingLicenseAppInfo1.ApplicationID);

                int LicenseID = -1;

                int DriverID = clsDriver.GetDriverIdByUsingPersonID(ctrlDrivingLicenseAppInfo1.PersonID);

                bool IsActive = true;

                if ((ClassID != -1) && ((LicenseID = clsDriver.AddNewLicense(ctrlDrivingLicenseAppInfo1.ApplicationID, DriverID, ClassID, DateTime.Now, DateTime.Now.AddYears(10), txtboxNotes.Text, 15, IsActive, 1, clsCurrentUser.CurrentUser.UserID)) != -1) && clsPerson.SetApplicationToBeCompleted(ctrlDrivingLicenseAppInfo1.ApplicationID))
                {

                    MessageBox.Show("License Issued Successfully With ID: " + LicenseID);
                    DataBack?.Invoke();

                }
                else
                {
                    MessageBox.Show("Error Issuing License, Please Try Again Later", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void IssueDrivingLicenseForFirstTime_Load(object sender, EventArgs e)
        {

        }
    }
}
