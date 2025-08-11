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
    public partial class ListDetainedLicense: Form
    {
        public ListDetainedLicense()
        {
            InitializeComponent();
        }


        private void ListDetainedLicense_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsDriver.GetAllDetainedLicense();
            dataGridView1.Columns[0].Width = 60;
            dataGridView1.Columns[1].Width = 60;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[8].HeaderText = "R.App ID";
            dataGridView1.Columns[8].Width = 90; // Adjust the width of the "R.App ID" column
            this.Size = new Size(850, 600); // Set a fixed size for the form


        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsDriver.GetAllDetainedLicense();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReleaseDetainedLicense frmReleaseDetainedLicense = new ReleaseDetainedLicense();
            frmReleaseDetainedLicense.DataBack += RefreshDataGridView;
            frmReleaseDetainedLicense.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DetainLicense frmDetainLicense = new DetainLicense();
            frmDetainLicense.DataBack += RefreshDataGridView;
            frmDetainLicense.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, NationalNO = string.Empty, Gender = string.Empty, Address = string.Empty, Phone = string.Empty, Email = string.Empty, ImagePath = string.Empty, CountryName = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            int PersonID = -1;

            if ((PersonID = clsDriver.GetPersonIDByLicenseID(LicenseID)) != -1)
            {

                if (clsPerson.GetPersonInfoByID(PersonID, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref NationalNO, ref DateOfBirth, ref Gender, ref Phone, ref Email, ref CountryName, ref Address, ref ImagePath))
                {

                    PersonDetails frmPersonDetails = new PersonDetails(PersonID, FirstName, SecondName, ThirdName, LastName, NationalNO, DateOfBirth, Gender, Address, Phone, Email, CountryName, ImagePath);
                    frmPersonDetails.ShowDialog();

                }
            }
        }

        public int IndexRowSelected = 0;
        int LicenseID = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["LicenseID"].Value)))
                {
                    LicenseID = (int)dataGridView1.Rows[IndexRowSelected].Cells["LicenseID"].Value;
                }
                else
                {
                    MessageBox.Show("Please Select A Valid Row", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ClassName = string.Empty, FullName = string.Empty, NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IssueReason = string.Empty, Notes = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty, IsDetained = string.Empty, ImagePath = string.Empty;
            int LocalLicenseID = 0, DriveID = 0;

            
                if (clsDriver.GetDriverLicenseInfoByLicenseID(LicenseID, ref ClassName, ref FullName, ref LocalLicenseID, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriveID, ref ExpirationDate, ref IsDetained, ref ImagePath))
                {
                    LicenseInfo frmLicenseInfo = new LicenseInfo(ClassName, FullName, LicenseID, NationalNo, Gender, IssueDate, IssueReason, Notes, IsActive, DateOfBirth, DriveID, ExpirationDate, IsDetained, ImagePath);
                    frmLicenseInfo.ShowDialog();
                }
            
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = -1;
            if ((PersonID = clsDriver.GetPersonIDByLicenseID(LicenseID)) != -1)
            {
                LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID);
                frmLicenseHistory.ShowDialog();
            }
        }


    }
}
