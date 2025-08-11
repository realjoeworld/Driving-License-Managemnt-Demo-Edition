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
    public partial class ctrlInternationalApplicationInfo: UserControl
    {
        public ctrlInternationalApplicationInfo()
        {
            InitializeComponent();
        }

        public int Fees { get; set; }

        private void ctrlInternationalApplicationInfo_Load(object sender, EventArgs e)
        {
            lblApplicationDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblIssueDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToString("dd/MM/yyyy");
            Fees = clsDriver.GetInternationaLicenseIDFees();
            lblFees.Text = Fees.ToString();
           // lblCreatedBy.Text = clsCurrentUser.CurrentUser.UserName;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void SetLicenseID(int LicenseID)
        {
            lblLocalLicenseID.Text = LicenseID.ToString();
        }

        public void SetCreatedBy(string UserName)
        {
            lblCreatedBy.Text = UserName;
        }

        public void SetApplicationID(int ApplicationID)
        {
            lblApplicationID.Text = ApplicationID.ToString();
        }
        public void SetInternationalLicenseID(int InternationalLicenseID)
        {
            lblInternationalLicenseID.Text = InternationalLicenseID.ToString();
        }

    }
}
