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
    public partial class ViewStreetTestAppointment : Form
    {
        public ViewStreetTestAppointment()
        {
            InitializeComponent();
        }

        public delegate void SendDataBack();
        public event SendDataBack DataBack;

        string ClassName { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string ThirdName { get; set; }

        string LastName { get; set; }

        int LocalLicenseApplicationID { get; set; }

        DateTime ApplicationDate { get; set; }

        public ViewStreetTestAppointment(int LocalLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName, string UserName, string ApplicationStatus, DateTime LastStatusDate)
        {
            InitializeComponent();
            ctrlDrivingLicenseAppInfo1.LoadData(LocalLicenseApplicationID, ApplicationID, ApplicantPersonID, ApplicationDate, ClassName, FirstName, SecondName, ThirdName, LastName, UserName, ApplicationStatus, LastStatusDate);
            this.Size = new Size(800, 800);
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.LastName = LastName;
            this.ClassName = ClassName;
            this.ApplicationDate = ApplicationDate;
            this.LocalLicenseApplicationID = LocalLicenseApplicationID;
            dataGridView1.DataSource = clsPerson.GetAllStreetAppointmentsForDLLicenseApp(LocalLicenseApplicationID);
        }

        private void btnAddApointment_Click(object sender, EventArgs e)
        {
            if (clsPerson.CheckIfThisPersonPassedTheStreetTest(LocalLicenseApplicationID))
            {
                MessageBox.Show("This Person Already Passed The Street Test , Can't Set An Appointment");
            }

            else
            {

                if (clsPerson.CheckIfThisPersonHasStreetAppointment(ctrlDrivingLicenseAppInfo1.PersonID))
                {
                    MessageBox.Show("This Person Already Has An Appointment For Street Test.", "Appointment Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    if (clsPerson.CheckIfThisPersonFailedTheStreetTest(LocalLicenseApplicationID))
                    {

                        bool IsForReTake = true; // Indicate that this is a retake appointment

                        ScheduleStreetTest frmScheduleStreetTest = new ScheduleStreetTest(IsForReTake, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName, SecondName, ThirdName, LastName);
                        frmScheduleStreetTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                        frmScheduleStreetTest.ShowDialog();


                    }

                    else
                    {
                        ScheduleStreetTest frmScheduleStreetTest = new ScheduleStreetTest(ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName, SecondName, ThirdName, LastName);
                        frmScheduleStreetTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                        frmScheduleStreetTest.ShowDialog();

                    }
                }
            }
        }


        public void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsPerson.GetAllStreetAppointmentsForDLLicenseApp(ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID);
        }

        public int IndexRowSelected = 0;
        int IDForSelectedRow = 0;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                IndexRowSelected = e.RowIndex;

                if (!string.IsNullOrEmpty(Convert.ToString(dataGridView1.Rows[IndexRowSelected].Cells[0].Value)))
                {
                    IDForSelectedRow = (int)dataGridView1.Rows[IndexRowSelected].Cells[0].Value;
                }

                else
                {
                    MessageBox.Show("Please Select A Valid Row", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime AppointmentDate = DateTime.Now;

            bool IsLocked = Convert.ToBoolean(dataGridView1.Rows[IndexRowSelected].Cells[3].Value);

            if (clsPerson.GetAppointmentDate(IDForSelectedRow, ref AppointmentDate))
            {

                if (!IsLocked)
                {
                    ScheduleStreetTest frmScheduleStreetTest = new ScheduleStreetTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, AppointmentDate, FirstName, SecondName, ThirdName, LastName);
                    frmScheduleStreetTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                    frmScheduleStreetTest.ShowDialog();
                }

                else
                {
                    ScheduleStreetTest frmScheduleStreetTest = new ScheduleStreetTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, AppointmentDate, FirstName, SecondName, ThirdName, LastName, IsLocked);
                    frmScheduleStreetTest.ShowDialog();
                }

            }
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeStreetTest frmTakeStreetTest = new TakeStreetTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName + " " + SecondName + " " + ThirdName + " " + LastName, ApplicationDate);
            frmTakeStreetTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
            frmTakeStreetTest.ShowDialog();
        }

        private void ViewStreetTestAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke(); // Notify subscribers to refresh data when the form is closing
        }
    }
}
