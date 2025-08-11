using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDInterface
{
    public partial class ctrlDrivingLicenseInfo: UserControl
    {
        public ctrlDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void LoadDrivingLicenseInfo(string ClassName,string FullName, int LicenseID, string NationalNo,string Gender,string IssueDate,string IssueReason,string Notes,string IsActive, string DateOfBirth,int DriveID, string ExpirationDate, string IsDetained,string ImagePath) {

            lblClass.Text = ClassName;
            lblName.Text = FullName;
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = NationalNo;
            lblGender.Text = Gender;
            lblIssueDate.Text = IssueDate;
            lblIssueReason.Text = IssueReason;
            lblNotes.Text = Notes;
            lblIsActive.Text = IsActive;
            lblDateOfBirth.Text = DateOfBirth;
            lblDriveID.Text = DriveID.ToString();
            lblExpirationDate.Text = ExpirationDate;
            lblIsDetained.Text = IsDetained;
            pictureBox14.Image = Image.FromFile(ImagePath);


        }

    }
}
