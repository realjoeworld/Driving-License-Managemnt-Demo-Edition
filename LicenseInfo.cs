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
    public partial class LicenseInfo: Form
    {
        public LicenseInfo()
        {
            InitializeComponent();
        }

        public LicenseInfo(string ClassName, string FullName, int LicenseID, string NationalNo, string Gender, string IssueDate, string IssueReason, string Notes, string IsActive, string DateOfBirth, int DriveID, string ExpirationDate, string IsDetained, string ImagePath)
        {
            InitializeComponent();
            ctrlDrivingLicenseInfo1.LoadDrivingLicenseInfo(ClassName, FullName, LicenseID, NationalNo, Gender, IssueDate, IssueReason, Notes, IsActive, DateOfBirth,  DriveID, ExpirationDate, IsDetained, ImagePath);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LicenseInfo_Load(object sender, EventArgs e)
        {
            this.Size = new Size(750, 550);
        }
    }
}
