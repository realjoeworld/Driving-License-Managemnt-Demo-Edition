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
    public partial class DetainLicense : Form
    {
        public DetainLicense()
        {
            InitializeComponent();
        }

        public delegate void SendDataBack();
        public event SendDataBack DataBack;

        int LicenseID = -1;

        private void ctrlSearchDriverLicense1_OnSearchComplete(int obj)
        {
            if (obj != -1)
            {
                lblLicenseID.Text = obj.ToString();
                linklblShowLicenseHistory.Enabled = true;
                btnIssue.Enabled = true;
            }
            else
            {
                lblLicenseID.Text = "???";
                linklblShowLicenseHistory.Enabled = false;
                btnIssue.Enabled = false;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetainLicense_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblCreatedby.Text = clsCurrentUser.CurrentUser.UserName;
            this.Size = new Size(730, 630); // Set a fixed size for the form


        }

        private void linklblShowLicenseHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int PersonID = -1;
            if ((PersonID = clsDriver.GetPersonIDByLicenseID(ctrlSearchDriverLicense1.LocalLicenseID)) != -1)
            {
                LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID);
                frmLicenseHistory.ShowDialog();
            }
        }

        private void linklblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string FullName = string.Empty, NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty;
            int LocalLicenseID = 0, DriverID = 0, ApplicationID = 0;

            if (clsDriver.GetInternationalLicenseInfo(ctrlSearchDriverLicense1.LocalLicenseID, ref FullName, ref LocalLicenseID, ref NationalNo, ref Gender, ref IssueDate, ref ApplicationID, ref IsActive, ref DateOfBirth, ref DriverID, ref ExpirationDate))
            {

                InternationalDriverLicenseInfo frmInternationalDriverLicenseInfo = new InternationalDriverLicenseInfo(FullName, ctrlSearchDriverLicense1.LocalLicenseID, LocalLicenseID, NationalNo, Gender, IssueDate, ApplicationID, IsActive, DateOfBirth, DriverID, ExpirationDate);
                frmInternationalDriverLicenseInfo.ShowDialog();
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (clsDriver.CheckIfLicenseIsAlreadyDetained(ctrlSearchDriverLicense1.LocalLicenseID))
            {
                MessageBox.Show("This license is already detained.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                int DetainID = -1;

                if ((DetainID = clsDriver.AddNewDetainedLicense(ctrlSearchDriverLicense1.LocalLicenseID, DateTime.Now,60, clsCurrentUser.CurrentUser.UserID,false)) != -1)
                {
                    MessageBox.Show($"License detained successfully, With ID = {DetainID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDetainID.Text = DetainID.ToString();
                    DataBack?.Invoke(); // Notify subscribers that data has been updated
                    linklblShowLicenseInfo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Failed to detain the license. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        
        }
    
    
    
    }
}
