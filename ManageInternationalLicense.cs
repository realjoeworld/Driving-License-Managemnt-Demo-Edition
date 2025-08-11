using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLDBussniss;

namespace DVLDInterface
{
    public partial class ManageInternationalLicense: Form
    {
        public ManageInternationalLicense()
        {
            InitializeComponent();
        }

        private void ManageInternationalLicense_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDriver.GetAllInternationalLicense();
        }

        public int IndexRowSelected = 0;
        int LocalLicenseID = 0;
        int InternationalLicenseID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;
                LocalLicenseID = (int)dataGridView1.Rows[IndexRowSelected].Cells["IssuedUsingLocalLicenseID"].Value;
                InternationalLicenseID = (int)dataGridView1.Rows[IndexRowSelected].Cells["InternationalLicenseID"].Value;
            }
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if ((PersonID = clsDriver.GetPersonIDByLicenseID(LocalLicenseID)) != -1)
            {
                LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID);
                frmLicenseHistory.ShowDialog();
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Address = string.Empty, Phone = string.Empty, Email = string.Empty, ImagePath = string.Empty, CountryName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1;

            if ((PersonID = clsDriver.GetPersonIDByLicenseID(LocalLicenseID)) != -1)
            {

                if (clsPerson.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath))
                {

                    PersonDetails frmPersonDetails = new PersonDetails(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNO, DateOfBirth, Gender, Address, Phone, Email, CountryName, ImagePath);
                    frmPersonDetails.ShowDialog();

                }
            }
        }

        private void RefreshPersonInfo()
        {

        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FullName = string.Empty, NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty;
            int LocalLicenseID = 0, DriverID = 0, ApplicationID = 0;

           

            if (clsDriver.GetInternationalLicenseInfo(InternationalLicenseID, ref FullName, ref LocalLicenseID, ref NationalNo, ref Gender, ref IssueDate, ref ApplicationID, ref IsActive, ref DateOfBirth, ref DriverID, ref ExpirationDate))
            {

                InternationalDriverLicenseInfo frmInternationalDriverLicenseInfo = new InternationalDriverLicenseInfo(FullName, InternationalLicenseID, LocalLicenseID, NationalNo, Gender, IssueDate, ApplicationID, IsActive, DateOfBirth, DriverID, ExpirationDate);
                frmInternationalDriverLicenseInfo.ShowDialog();
            }
        }
    }
}
