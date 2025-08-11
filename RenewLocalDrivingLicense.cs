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
    public partial class RenewLocalDrivingLicense: Form
    {

        int LocalLicenseID = 0;
        public RenewLocalDrivingLicense()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void RenewLocalDrivingLicense_Load(object sender, EventArgs e)
        {
            this.Top = 0;
            this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            lblApplicationDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblExpirationDate.Text = DateTime.Now.AddYears(10).ToString("yyyy-MM-dd");
            lblCreatedBy.Text = clsCurrentUser.CurrentUser.UserName;
        }

        private void ctrlSearchDriverLicense1_OnSearchComplete(int obj)
        {
            lblOldLicenseID.Text = obj.ToString();
            
            if(obj != -1)
            {
                LocalLicenseID = obj;
                linklblShowLicenseHistory.Enabled = true;
                btnIssue.Enabled = true;
            }
            else
            {
                LocalLicenseID = -1;
                linklblShowLicenseHistory.Enabled = false;
                btnIssue.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
        int NewLicenseID = 0;
        private void btnIssue_Click(object sender, EventArgs e)
        {

            if(ctrlSearchDriverLicense1.IsFound)
            {

                if(ctrlSearchDriverLicense1.ExpirationDate > DateTime.Now)
                {
                    MessageBox.Show($"The license is still valid. You cannot renew it, Expiration Date: {ctrlSearchDriverLicense1.ExpirationDate.ToString("dd/MM/yyyy")}", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    if(clsDriver.SetLicenseToInactive(LocalLicenseID))
                    {
                        MessageBox.Show($"The license With ID: {LocalLicenseID} has been set to inactive successfully.", "License Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        int ApplicataionID = 0, LicenseClass = 0, PersonID = 0;

                        if(clsDriver.GetPersonIDAndApplicationIDAndLicenseClassFromLocalLicense(LocalLicenseID,ref PersonID,ref ApplicataionID,ref LicenseClass))
                        {
                            int ReNewApplicationID = -1;

                            if ((ReNewApplicationID = clsPerson.AddNewRenewLicenseApplication(PersonID,clsCurrentUser.CurrentUser.UserID)) != -1)
                            {
                                
                                MessageBox.Show($"A new application has been created with ID: {ReNewApplicationID} for the person with ID: {PersonID}.", "Application Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                int DriverID = -1;

                                if((DriverID = clsDriver.GetDriverIDByLicenseID(LocalLicenseID)) != -1)
                                {
                                    if((NewLicenseID = clsDriver.AddNewLicense(ReNewApplicationID,DriverID,LicenseClass,DateTime.Now,DateTime.Now.AddYears(10),txtboxNotes.Text,20,true,2,clsCurrentUser.CurrentUser.UserID)) != -1)
                                    {
                                        MessageBox.Show($"A new license has been issued with ID: {NewLicenseID} for the person with ID: {PersonID}.", "License Issued", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        linklblShowNewLicenseInfo.Enabled = true;
                                        btnIssue.Enabled = false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to issue a new license. Please try again later.", "License Issuance Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Failed to retrieve the driver ID from the local license. Please try again later.", "Driver ID Retrieval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }


                            }
                            else
                            {
                                MessageBox.Show("Failed to create a new application for the person. Please try again later.", "Application Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
 
                        }
                        else
                        {
                            MessageBox.Show("Failed to retrieve the person ID, application ID, or license class from the local license. Please try again later.", "Data Retrieval Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }

                }


            }
            else
            {
                MessageBox.Show("Please search for a valid license before issuing a new one.", "Invalid License", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

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

        private void linklblShowNewLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string ClassName = string.Empty, FullName = string.Empty, NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IssueReason = string.Empty, Notes = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty, IsDetained = string.Empty, ImagePath = string.Empty;
            int LicenseID = 0, DriveID = 0;

            if (NewLicenseID == 0)
            {
                MessageBox.Show("Please issue a new license first.", "No License Issued", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {

               // int ID = clsDriver.GetPersonIDAndApplicationIDAndLicenseClassFromLocalLicense(NewLicenseID, ref LicenseID, ref DriveID, ref ClassName);

                if (clsDriver.GetDriverLicenseInfoByLicenseID(NewLicenseID, ref ClassName, ref FullName, ref LicenseID, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriveID, ref ExpirationDate, ref IsDetained, ref ImagePath))
                {
                    LicenseInfo frmLicenseInfo = new LicenseInfo(ClassName, FullName, LicenseID, NationalNo, Gender, IssueDate, IssueReason, Notes, IsActive, DateOfBirth, DriveID, ExpirationDate, IsDetained, ImagePath);
                    frmLicenseInfo.ShowDialog();
                }
            }
        }
    }
}
