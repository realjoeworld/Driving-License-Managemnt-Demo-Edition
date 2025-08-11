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
    public partial class ViewVisionTestAppoinments: Form
    {

        public delegate void SendDataBack();
        public event SendDataBack DataBack;

        string ClassName { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string ThirdName { get; set; }

        string LastName { get; set; }

        int LocalLicenseApplicationID { get; set; }

        DateTime ApplicationDate { get; set; }

        public ViewVisionTestAppoinments(int LocalLicenseApplicationID, int ApplicationID, int ApplicantPersonID, DateTime ApplicationDate, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName, string UserName, string ApplicationStatus, DateTime LastStatusDate)
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
            dataGridView1.DataSource = clsPerson.GetAllAppointmentsForDLLicenseApp(LocalLicenseApplicationID);
        }
        
        public void RefreshDataGridView()
        {
            dataGridView1.DataSource = clsPerson.GetAllAppointmentsForDLLicenseApp(ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID);
        }   
        private void btnAddApointment_Click(object sender, EventArgs e)
        {
            if (clsPerson.CheckIfThisPersonPassedTheVisionTest(LocalLicenseApplicationID))
            {
                MessageBox.Show("This Person Already Passed The Vision Test , Can't Set An Appointment");
            }

            else
            {

                if (clsPerson.CheckIfThisPersonHasAnAppointment(ctrlDrivingLicenseAppInfo1.PersonID))
                {
                    MessageBox.Show("This person already has an appointment for vision test.", "Appointment Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {

                    if(clsPerson.CheckIfThisPersonFailedTheVisionTest(LocalLicenseApplicationID)) {
                       
                        bool IsForReTake = true; // Indicate that this is a retake appointment
                      
                        ScheduleVisionTest frmScheduleVisionTest = new ScheduleVisionTest(IsForReTake,ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName, SecondName, ThirdName, LastName);
                        frmScheduleVisionTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                        frmScheduleVisionTest.ShowDialog();


                    }

                    else
                    {
                        ScheduleVisionTest frmScheduleVisionTest = new ScheduleVisionTest(ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName, SecondName, ThirdName, LastName);
                        frmScheduleVisionTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                        frmScheduleVisionTest.ShowDialog();

                    }
                       
                }

            }

        }

        private void ctrlDrivingLicenseAppInfo1_Load(object sender, EventArgs e)
        {

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

            if (clsPerson.GetAppointmentDate(IDForSelectedRow,ref AppointmentDate)) {

                if (!IsLocked)
                {
                    ScheduleVisionTest frmScheduleVisionTest = new ScheduleVisionTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, AppointmentDate, FirstName, SecondName, ThirdName, LastName);
                    frmScheduleVisionTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
                    frmScheduleVisionTest.ShowDialog();
                }

                else
                {
                    ScheduleVisionTest frmScheduleVisionTest = new ScheduleVisionTest(IDForSelectedRow, ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, AppointmentDate, FirstName, SecondName, ThirdName, LastName,IsLocked);
                    frmScheduleVisionTest.ShowDialog();
                }

            }

        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TakeVisionTest frmTakeTest = new TakeVisionTest(IDForSelectedRow,ctrlDrivingLicenseAppInfo1.LocalLicenseApplicationID, ClassName, FirstName + " " + SecondName + " " + ThirdName + " " + LastName, ApplicationDate);
            frmTakeTest.DataBack += RefreshDataGridView; // Subscribe to the event to refresh the data grid view
            frmTakeTest.ShowDialog();
        }

        private void ViewTestAppoinments_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataBack?.Invoke(); // Notify subscribers to refresh data when the form is closing
        }
    }
}
