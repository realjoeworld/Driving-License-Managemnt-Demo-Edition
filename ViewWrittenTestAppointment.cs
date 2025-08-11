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
    public partial class ViewWrittenTestAppointment : Form
    {

        public delegate void SendDataBack();
        public event SendDataBack DataBack;
        string FirstName { get; set; }
        string LastName { get; set; }

        string SecondName { get; set; }

        string ThirdName { get; set; }

        string ClassName { get; set; }

        int LocalLicenseApplicationID { get; set; }

        DateTime ApplicationDate { get; set; }

        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsPerson.GetAllWrittenAppointmentsForDLLicenseApp(LocalLicenseApplicationID);
        }

        public ViewWrittenTestAppointment(int LocalLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName, string UserName, string ApplicationStatus, DateTime LastStatusDate)
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
            dataGridView1.DataSource = clsPerson.GetAllWrittenAppointmentsForDLLicenseApp(LocalLicenseApplicationID);
            this.Size = new Size(830, 800);
        }

        private void btnAddApointment_Click(object sender, EventArgs e)
        {
            if (clsPerson.CheckIfThisPersonPassedTheWrritenTest(LocalLicenseApplicationID))
            {
                MessageBox.Show("This Person Already Passed The Written Test , Can't Set An Appointment");
            }

            else
            {

                if (clsPerson.CheckIfThisPersonHasWrritenAppointment(ctrlDrivingLicenseAppInfo1.PersonID))
                {
                    MessageBox.Show("This person already has an appointment for Written test.", "Appointment Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    if (clsPerson.CheckIfThisPersonFailedTheWrritenTest(LocalLicenseApplicationID))
                    {

                        bool IsForReTake = true; // Indicate that this is a retake appointment

                        ScheduleWrritenTest frmScheduleWrritenTest = new ScheduleWrritenTest(IsForReTake, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName, SecondName, ThirdName, LastName);
                        frmScheduleWrritenTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                        frmScheduleWrritenTest.ShowDialog();


                    }

                    else
                    {
                        ScheduleWrritenTest frmScheduleWrritenTest = new ScheduleWrritenTest(ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName, SecondName, ThirdName, LastName);
                        frmScheduleWrritenTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                        frmScheduleWrritenTest.ShowDialog();

                    }
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
                    ScheduleWrritenTest frmScheduleWrritenTest = new ScheduleWrritenTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, AppointmentDate, FirstName, SecondName, ThirdName, LastName);
                    frmScheduleWrritenTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                    frmScheduleWrritenTest.ShowDialog();
                }

                else
                {
                    ScheduleWrritenTest frmScheduleWrritenTest = new ScheduleWrritenTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, AppointmentDate, FirstName, SecondName, ThirdName, LastName, IsLocked);
                    frmScheduleWrritenTest.ShowDialog();
                }
            }
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

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeWrritenTest frmTakeTest = new TakeWrritenTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName + " " + SecondName + " " + ThirdName + " " + LastName, ApplicationDate);
            frmTakeTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
            frmTakeTest.ShowDialog();
        }

        private void ViewWrittenTestAppointment_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke(); // Notify subscribers to refresh data when the form is closing 
        }
    }
}
