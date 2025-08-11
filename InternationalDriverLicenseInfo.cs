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
    public partial class InternationalDriverLicenseInfo: Form
    {
        public InternationalDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public InternationalDriverLicenseInfo(string FullName, int InternationalLicenseID, int LicenseID, string NationalNo, string Gender, string IssueDate, int ApplicationID, string IsActive, string DateOfBirth, int DriverID, string ExpirationDate)
        {
            InitializeComponent();
            ctrlInternationalDrivingLicenseInfo1.LoadData(FullName, InternationalLicenseID, LicenseID, NationalNo, Gender, IssueDate, ApplicationID, IsActive, DateOfBirth, DriverID, ExpirationDate);
        }

    }
}
