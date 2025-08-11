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
    public partial class ctrlInternationalDrivingLicenseInfo : UserControl
    {
        public ctrlInternationalDrivingLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadData(string FullName, int InternationalLicenseID, int LicenseID, string NationalNo, string Gender, string IssueDate, int ApplicationID, string IsActive, string DateOfBirth, int DriverID, string ExpirationDate)
        {
            lblName.Text = FullName;
            lblIntLicenseID.Text = InternationalLicenseID.ToString();
            lblLicenseID.Text = LicenseID.ToString();
            lblNationalNo.Text = NationalNo;
            lblGender.Text = Gender;
            lblIssueDate.Text = IssueDate;
            lblApplicationID.Text = ApplicationID.ToString();
            lblIsActive.Text = IsActive;
            lblDateOfBirth.Text = DateOfBirth;
            lblDriveID.Text = DriverID.ToString();
            lblExpirationDate.Text = ExpirationDate;


        }
    
    
    
    }
}
