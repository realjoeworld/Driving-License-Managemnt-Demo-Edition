using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussniss;

namespace DVLDInterface
{
    public partial class IssueInternationalLicense: Form
    {
        public IssueInternationalLicense()
        {
            InitializeComponent();
        }

        private void IssueInternationalLicense_Load(object sender, EventArgs e)
        {
            ctrlInternationalApplicationInfo1.SetCreatedBy(clsCurrentUser.CurrentUser.UserName);
            this.Top = 0;

            // Maximize the form height to fill the screen (excluding taskbar)
            this.Height = Screen.FromControl(this).WorkingArea.Height;
        }

        private void ctrlSearchDriverLicense1_OnSearchComplete(int obj)
        {
            ctrlInternationalApplicationInfo1.SetLicenseID(obj);

            if(obj != -1)
            {
                btnIssue.Enabled = true;
                linklblShowLicenseHistory.Enabled = true;
            }
            else
            {
                linklblShowLicenseHistory.Enabled = false;
                btnIssue.Enabled = false;
               // MessageBox.Show("Driver License not found. Please check the License ID and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int LicenseID = -1;

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int ID = -1;

            int PersonID1 = clsDriver.GetPersonIDByLicenseID(ctrlSearchDriverLicense1.LocalLicenseID);

            if ((ID = clsDriver.GetInternationalLicenseID(ctrlSearchDriverLicense1.LocalLicenseID)) != -1)
            {

                MessageBox.Show($"International License already issued for this Driver With ID = {ID}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            else
            {

                if (clsDriver.CheckIfThisLicenseIsThirdClass(ctrlSearchDriverLicense1.LocalLicenseID))
                {

                    int PersonID = 0, DriverID = 0;

                    if (clsDriver.GetRequiredInternationalLicenseInfo(ctrlSearchDriverLicense1.LocalLicenseID, ref PersonID, ref DriverID))
                    {
                        bool IsActive = true;
                        int AppID = -1;

                       

                        if ((AppID = clsPerson.AddNewApplicationForInternationalLicense(PersonID, DateTime.Now, 6, 3, DateTime.Now, ctrlInternationalApplicationInfo1.Fees, clsCurrentUser.CurrentUser.UserID)) != -1)
                        {
                            if ((LicenseID = clsDriver.AddNewInternaTionalLicense(ctrlSearchDriverLicense1.LocalLicenseID, AppID, DriverID, DateTime.Now, DateTime.Now.AddYears(1), IsActive, clsCurrentUser.CurrentUser.UserID)) != -1)
                            {
                             
                                MessageBox.Show($"International License issued successfully with ID = {LicenseID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                ctrlInternationalApplicationInfo1.SetApplicationID(AppID);
                                ctrlInternationalApplicationInfo1.SetInternationalLicenseID(LicenseID);
                                linklblShowLicenseInfo.Enabled = true;

                            }
                            else
                            {
                                MessageBox.Show("Failed to issue International License. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Failed to create application for International License. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Error Happened", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                   

                }
                else
                {
                    MessageBox.Show("This Driver License is not a Third Class License. International License can only be issued for Third Class Licenses.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             string FullName = string.Empty  ,  NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty;
            int LocalLicenseID = 0, DriverID = 0, ApplicationID = 0;

            if(clsDriver.GetInternationalLicenseInfo(LicenseID,ref FullName,ref LocalLicenseID,ref NationalNo,ref Gender,ref IssueDate,ref ApplicationID,ref IsActive,ref DateOfBirth,ref DriverID ,ref ExpirationDate))
            {

                InternationalDriverLicenseInfo frmInternationalDriverLicenseInfo = new InternationalDriverLicenseInfo(FullName, LicenseID, LocalLicenseID, NationalNo, Gender, IssueDate, ApplicationID, IsActive, DateOfBirth, DriverID, ExpirationDate);
                frmInternationalDriverLicenseInfo.ShowDialog();
            }

        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = -1;
            if((PersonID = clsDriver.GetPersonIDByLicenseID(ctrlSearchDriverLicense1.LocalLicenseID)) != -1)
            {
                LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID);
                frmLicenseHistory.ShowDialog();
            }
           
        }
    }
}
