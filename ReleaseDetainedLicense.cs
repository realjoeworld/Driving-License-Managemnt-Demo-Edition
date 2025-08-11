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
    public partial class ReleaseDetainedLicense : Form
    {
        public ReleaseDetainedLicense()
        {
            InitializeComponent();
        }

        public delegate void SendDataBack();
        public event SendDataBack DataBack;

        int DetainID = -1;

        private void ctrlSearchDriverLicense1_OnSearchComplete(int obj)
        {
            if (obj != -1)
            {
                lblLicenseID.Text = obj.ToString();
             

               
                DateTime DetainDate = DateTime.Now;
                string UserName = string.Empty;
                
                if (clsDriver.GetDetainInfo(ctrlSearchDriverLicense1.LocalLicenseID, ref DetainID, ref DetainDate, ref UserName))
                {
                    lblDetainID.Text = DetainID.ToString();
                    lblDetainDate.Text = DetainDate.ToString("dd/MM/yyyy");
                    lblCreatedby.Text = UserName;
                    linklblShowLicenseHistory.Enabled = true;
                    btnIssue.Enabled = true;
                }
                else
                {
                    MessageBox.Show("This License Does Not Detained", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblDetainID.Text = "???";
                    lblDetainDate.Text = "???";
                    lblCreatedby.Text = "???";
                    linklblShowLicenseHistory.Enabled = false;
                    btnIssue.Enabled = false;

                }
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
            {
                string FullName = string.Empty, NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty;
                int LocalLicenseID = 0, DriverID = 0, ApplicationID = 0;

                if (clsDriver.GetInternationalLicenseInfo(ctrlSearchDriverLicense1.LocalLicenseID, ref FullName, ref LocalLicenseID, ref NationalNo, ref Gender, ref IssueDate, ref ApplicationID, ref IsActive, ref DateOfBirth, ref DriverID, ref ExpirationDate))
                {

                    InternationalDriverLicenseInfo frmInternationalDriverLicenseInfo = new InternationalDriverLicenseInfo(FullName, ctrlSearchDriverLicense1.LocalLicenseID, LocalLicenseID, NationalNo, Gender, IssueDate, ApplicationID, IsActive, DateOfBirth, DriverID, ExpirationDate);
                    frmInternationalDriverLicenseInfo.ShowDialog();
                }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if(clsDriver.CheckIfLicenseIsAlreadyDetained(ctrlSearchDriverLicense1.LocalLicenseID))
            {

                int PersonID = -1;

                if((PersonID = clsDriver.GetPersonIDByLicenseID(ctrlSearchDriverLicense1.LocalLicenseID)) != -1)
                {
                    int ApplicationID = -1;

                    if((ApplicationID = clsPerson.AddNewReleaseDetainedLicenseApplication(PersonID,clsCurrentUser.CurrentUser.UserID)) != -1)
                    {
                        MessageBox.Show($"Release application created successfully With ID = {ApplicationID}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblApplicationID.Text = ApplicationID.ToString();
                        if (clsDriver.UpdateDetainDate(DetainID, clsCurrentUser.CurrentUser.UserID, ApplicationID))
                        {
                            linklblShowLicenseInfo.Enabled = true;
                            DataBack?.Invoke(); // Notify subscribers that data has been updated
                        }

                    }
                    else
                    {
                        MessageBox.Show("Failed to create a release application for the detained license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Person ID not found for the given License ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("This license is not detained To Release It ! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReleaseDetainedLicense_Load(object sender, EventArgs e)
        {
            this.Size = new Size(730, 680); // Set a fixed size for the form

        }
    }
}
