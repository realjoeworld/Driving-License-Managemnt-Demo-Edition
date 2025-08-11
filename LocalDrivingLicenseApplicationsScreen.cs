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
    public partial class LocalDrivingLicenseApplicationsScreen: Form
    {
        public LocalDrivingLicenseApplicationsScreen()
        {
            InitializeComponent();
        }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsPerson.GetAllLocalLicenseInfo();
        }

        private void LocalDrivingLicenseApplicationsScreen_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clsPerson.GetAllLocalLicenseInfo();
            FilterComboBox.SelectedIndex = 0; 
            this.Size = new Size(900, 600); // Set the initial size of the form
        }

        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(FilterComboBox.SelectedIndex == 0)
            {
                txtboxSearch.Visible = false;
                txtboxSearch.Items.Clear();
                txtboxSearch.Text = "";
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseInfo();

            }

            else if(FilterComboBox.SelectedIndex == 4)
            {
                txtboxSearch.Visible = true;
                txtboxSearch.DropDownStyle = ComboBoxStyle.DropDownList;
                txtboxSearch.Items.Add("New");
                txtboxSearch.Items.Add("Completed");
                txtboxSearch.Items.Add("Cancelled");
                txtboxSearch.SelectedIndex = 0;

            }

            else
            {
                txtboxSearch.Visible = true;
                txtboxSearch.DropDownStyle = ComboBoxStyle.Simple;
                txtboxSearch.Items.Clear();
                txtboxSearch.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNewLocalLicense frmAddNewLocalLicense = new AddNewLocalLicense();
            frmAddNewLocalLicense.ShowDialog();

        }

        private void txtboxSearch_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void txtboxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FilterComboBox.SelectedIndex == 4 && txtboxSearch.SelectedIndex == 0)
            {
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseByItsStatus("New");
            }

            else if (FilterComboBox.SelectedIndex == 4 && txtboxSearch.SelectedIndex == 1)
            {
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseByItsStatus("Completed");
            }

            else if (FilterComboBox.SelectedIndex == 4 && txtboxSearch.SelectedIndex == 2)
            {
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseByItsStatus("Can");
            }

        }

        private void txtboxSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (FilterComboBox.SelectedIndex == 1)
            {
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseAppIDStartWith(txtboxSearch.Text);
            }

            else if (FilterComboBox.SelectedIndex == 2)
            {
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseNoStartWith(txtboxSearch.Text);
            }

            else if (FilterComboBox.SelectedIndex == 3)
            {
                dataGridView1.DataSource = clsPerson.GetAllLocalLicenseFullNameStartWith(txtboxSearch.Text);
            }
        }
        public int IndexRowSelected = 0;
        int IDForSelectedRow = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;

                if(!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells["LocalDrivingLicenseApplicationID"].Value))) {
                    IDForSelectedRow = (int)dataGridView1.Rows[IndexRowSelected].Cells["LocalDrivingLicenseApplicationID"].Value;
                }
                else
                {
                    MessageBox.Show("Please Select A Valid Row", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            try
            {
                if (Convert.ToByte(dataGridView1.Rows[IndexRowSelected].Cells[5].Value) == 0 && (Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells[6].Value) == "New"))
                {
                    schduleVisionTestToolStripMenuItem.Enabled = true;
                    scheduleWriteTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showLicenseHistoryToolStripMenuItem.Enabled = false;
                    editApplicationsToolStripMenuItem.Enabled = true;
                    cancelToolStripMenuItem.Enabled = true;
                    deleteApplicationsToolStripMenuItem.Enabled = true;
                    sceToolStripMenuItem.Enabled = true;

                }
                else if (Convert.ToByte(dataGridView1.Rows[IndexRowSelected].Cells[5].Value) == 1 && (Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells[6].Value) == "New"))
                {
                    schduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWriteTestToolStripMenuItem.Enabled = true;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showLicenseHistoryToolStripMenuItem.Enabled = false;
                    editApplicationsToolStripMenuItem.Enabled = true;
                    cancelToolStripMenuItem.Enabled = true;
                    deleteApplicationsToolStripMenuItem.Enabled = true;
                    sceToolStripMenuItem.Enabled = true;




                }
                else if (Convert.ToByte(dataGridView1.Rows[IndexRowSelected].Cells[5].Value) == 2 && (Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells[6].Value) == "New"))
                {
                    schduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWriteTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = true;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showLicenseHistoryToolStripMenuItem.Enabled = false;
                    editApplicationsToolStripMenuItem.Enabled = true;
                    cancelToolStripMenuItem.Enabled = true;
                    deleteApplicationsToolStripMenuItem.Enabled = true;
                    sceToolStripMenuItem.Enabled = true;



                }

                else if (Convert.ToByte(dataGridView1.Rows[IndexRowSelected].Cells[5].Value) == 3 && (Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells[6].Value) == "New"))
                {
                    sceToolStripMenuItem.Enabled = false;
                    schduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWriteTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = true;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showLicenseHistoryToolStripMenuItem.Enabled = false;
                    editApplicationsToolStripMenuItem.Enabled = true;
                    cancelToolStripMenuItem.Enabled = true;
                    deleteApplicationsToolStripMenuItem.Enabled = true;
                    

                }

                else if (Convert.ToByte(dataGridView1.Rows[IndexRowSelected].Cells[5].Value) == 3 && (Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells[6].Value) == "Completed"))
                {
                    sceToolStripMenuItem.Enabled = false;
                    schduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWriteTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = true;
                    showLicenseHistoryToolStripMenuItem.Enabled = true;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    editApplicationsToolStripMenuItem.Enabled = false;
                    cancelToolStripMenuItem.Enabled = false;
                    deleteApplicationsToolStripMenuItem.Enabled = false;

                }


                else
                        {
                    sceToolStripMenuItem.Enabled = false;
                    schduleVisionTestToolStripMenuItem.Enabled = false;
                    scheduleWriteTestToolStripMenuItem.Enabled = false;
                    scheduleStreetTestToolStripMenuItem.Enabled = false;
                    issueDrivingLicenseToolStripMenuItem.Enabled = false;
                    editApplicationsToolStripMenuItem.Enabled = false;
                    cancelToolStripMenuItem.Enabled = false;
                    deleteApplicationsToolStripMenuItem.Enabled = false;
                    showDrivingLicenseInfoToolStripMenuItem.Enabled = false;
                    showLicenseHistoryToolStripMenuItem.Enabled = false;


                }
            }

            catch(Exception)
            {

            }


        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure You Want To Cancel This Application?", "Cancel Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                int AppID = 0;

                if ((AppID = clsPerson.GetApplicationIDFromLocalLicenseApplication(IDForSelectedRow)) != 0)
                {

                    if (clsPerson.CancelApplication(AppID))
                    {
                        MessageBox.Show("Application Cancelled Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = clsPerson.GetAllLocalLicenseInfo();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Cancel Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Failed To Cancel Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Application Not Cancelled", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void schduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = 0,  ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            string ClassName = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, UserName = string.Empty, ApplicationStatus = string.Empty;


            if(clsPerson.GetLocalLicenseApplicationInfo(IDForSelectedRow,ref ApplicationID,ref ApplicantPersonID,ref ApplicationDate, ref ClassName,ref FirstName,ref SecondName,ref ThirdName,ref LastName,ref UserName,ref ApplicationStatus,ref LastStatusDate)) {

                ViewVisionTestAppoinments frmViewTestAppoinments = new ViewVisionTestAppoinments(IDForSelectedRow, ApplicationID, ApplicantPersonID, ApplicationDate, ClassName, FirstName, SecondName, ThirdName, LastName, UserName, ApplicationStatus, LastStatusDate);
                frmViewTestAppoinments.DataBack += RefreshDataGridView;
                frmViewTestAppoinments.ShowDialog();

            }
            


        }

        private void scheduleWriteTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ApplicationID = 0, ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            string ClassName = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, UserName = string.Empty, ApplicationStatus = string.Empty;


            if (clsPerson.GetLocalLicenseApplicationInfo(IDForSelectedRow, ref ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ClassName, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref UserName, ref ApplicationStatus, ref LastStatusDate))
            {

                ViewWrittenTestAppointment frmViewWrittenTestAppointment = new ViewWrittenTestAppointment(IDForSelectedRow, ApplicationID, ApplicantPersonID, ApplicationDate, ClassName, FirstName, SecondName, ThirdName, LastName, UserName, ApplicationStatus, LastStatusDate);
                frmViewWrittenTestAppointment.DataBack += RefreshDataGridView;
                frmViewWrittenTestAppointment.ShowDialog();

            }

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            int ApplicationID = 0, ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            string ClassName = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, UserName = string.Empty, ApplicationStatus = string.Empty;


            if (clsPerson.GetLocalLicenseApplicationInfo(IDForSelectedRow, ref ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ClassName, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref UserName, ref ApplicationStatus, ref LastStatusDate))
            {

                ViewStreetTestAppointment frmViewStreetTestAppointment = new ViewStreetTestAppointment(IDForSelectedRow, ApplicationID, ApplicantPersonID, ApplicationDate, ClassName, FirstName, SecondName, ThirdName, LastName, UserName, ApplicationStatus, LastStatusDate);
                frmViewStreetTestAppointment.DataBack += RefreshDataGridView;
                frmViewStreetTestAppointment.ShowDialog();

            }
        }

        private void issueDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ApplicationID = 0, ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.Now, LastStatusDate = DateTime.Now;
            string ClassName = string.Empty, FirstName = string.Empty, SecondName = string.Empty, ThirdName = string.Empty, LastName = string.Empty, UserName = string.Empty, ApplicationStatus = string.Empty;


            if (clsPerson.GetLocalLicenseApplicationInfo(IDForSelectedRow, ref ApplicationID, ref ApplicantPersonID, ref ApplicationDate, ref ClassName, ref FirstName, ref SecondName, ref ThirdName, ref LastName, ref UserName, ref ApplicationStatus, ref LastStatusDate))
            {

                IssueDrivingLicenseForFirstTime frmIssueDrivingLicenseForFirstTime = new IssueDrivingLicenseForFirstTime(IDForSelectedRow, ApplicationID, ApplicantPersonID, ApplicationDate, ClassName, FirstName, SecondName, ThirdName, LastName, UserName, ApplicationStatus, LastStatusDate);
                frmIssueDrivingLicenseForFirstTime.DataBack += RefreshDataGridView;
                frmIssueDrivingLicenseForFirstTime.ShowDialog();

            }
        }

        private void showDrivingLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            string ClassName = string.Empty, FullName = string.Empty, NationalNo = string.Empty , Gender = string.Empty, IssueDate = string.Empty, IssueReason = string.Empty, Notes = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty , ExpirationDate = string.Empty, IsDetained = string.Empty, ImagePath = string.Empty;
             int LicenseID = 0, DriveID = 0;

            if (clsDriver.GetDriverLicenseInfo(IDForSelectedRow,ref ClassName, ref FullName, ref LicenseID, ref NationalNo, ref Gender, ref IssueDate, ref IssueReason, ref Notes, ref IsActive, ref DateOfBirth, ref DriveID, ref ExpirationDate, ref IsDetained, ref ImagePath))
            {
                LicenseInfo frmLicenseInfo = new LicenseInfo(ClassName, FullName,  LicenseID,  NationalNo, Gender,  IssueDate,  IssueReason,  Notes,  IsActive,  DateOfBirth,  DriveID,  ExpirationDate,  IsDetained,  ImagePath);
                frmLicenseInfo.ShowDialog();
            } 
        }

        private void dataGridView1_CellBorderStyleChanged(object sender, EventArgs e)
        {

        }

        private void showLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = -1;

            int LocalLicenseID = -1;

            if ((LocalLicenseID = clsDriver.GetLocalLicenseIDByLocalLicenseID(IDForSelectedRow)) != -1)
            {
                if ((PersonID = clsDriver.GetPersonIDByLicenseID(LocalLicenseID)) != -1)
                {
                    LicenseHistory frmLicenseHistory = new LicenseHistory(PersonID);
                    frmLicenseHistory.ShowDialog();
                }
            }
            else
            {

            }
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
