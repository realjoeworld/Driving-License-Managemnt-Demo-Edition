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
    public partial class ScheduleStreetTest: Form
    {
        public ScheduleStreetTest()
        {
            InitializeComponent();
        }

        bool IsForEdit = false; // Flag to indicate if the form is for editing an existing appointment

        bool IsForReTake = false;
        public int DLAppID { get; set; }

        public int AppointmentID { get; set; }
        public ScheduleStreetTest(int LocalDrivingLicenseID, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName)
        {
            InitializeComponent();
            lblFullName.Text = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            lblDrivingClass.Text = ClassName;
            lblDLAppID.Text = LocalDrivingLicenseID.ToString();
            DLAppID = LocalDrivingLicenseID;

        }

        public ScheduleStreetTest(int AppointmentID, int LocalDrivingLicenseID, string ClassName, DateTime AppointmentDate, string FirstName, string SecondName, string ThirdName, string LastName)
        {
            InitializeComponent();
            this.AppointmentID = AppointmentID;
            lblFullName.Text = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            lblDrivingClass.Text = ClassName;
            lblDLAppID.Text = LocalDrivingLicenseID.ToString();
            DLAppID = LocalDrivingLicenseID;
            dateTimePicker1.Value = AppointmentDate; // Set the date picker to the existing appointment date
            IsForEdit = true; // Set the flag to indicate this is for editing an existing appointment

        }

        public ScheduleStreetTest(int AppointmentID, int LocalDrivingLicenseID, string ClassName, DateTime AppointmentDate, string FirstName, string SecondName, string ThirdName, string LastName, bool IsLocked)
        {
            InitializeComponent();
            this.AppointmentID = AppointmentID;
            lblFullName.Text = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            lblDrivingClass.Text = ClassName;
            lblDLAppID.Text = LocalDrivingLicenseID.ToString();
            DLAppID = LocalDrivingLicenseID;
            dateTimePicker1.Value = AppointmentDate; // Set the date picker to the existing appointment date
            btnSave.Enabled = false;
            dateTimePicker1.Enabled = false; // Disable the date picker if the appointment is locked
            lblBlocked.Visible = true; // Show a label indicating the appointment is locked

        }

        public ScheduleStreetTest(bool IsForReTake, int LocalDrivingLicenseID, string ClassName, string FirstName, string SecondName, string ThirdName, string LastName)
        {
            InitializeComponent();
            lblFullName.Text = FirstName + " " + SecondName + " " + ThirdName + " " + LastName;
            lblDrivingClass.Text = ClassName;
            lblDLAppID.Text = LocalDrivingLicenseID.ToString();
            DLAppID = LocalDrivingLicenseID;
            this.IsForReTake = true;
            lblRetakeFees.Text = "5";
            lblRetakeTotalFees.Text = "40";
            label1.Text = "Schedule Retake Test";
            groupBox1.Enabled = true;


        }



        public delegate void SendDataBack();

        public event SendDataBack DataBack;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!IsForEdit)
            {
                int ID = -1;

                // Handle Retake Appointment
                if (IsForReTake)
                {
                    ID = clsPerson.AddNewAppointments(3, DLAppID, dateTimePicker1.Value, 40, clsCurrentUser.CurrentUser.UserID);

                    if (ID != -1)
                    {
                        MessageBox.Show("Retake appointment for vision test has been scheduled successfully.",
                            "Appointment Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataBack?.Invoke(); // Notify the main form to refresh the data grid view
                        lblRetakeAppID.Text = ID.ToString();
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Failed to schedule retake appointment. Please try again later.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                // Handle New Appointment
                else
                {
                    ID = clsPerson.AddNewAppointments(3, DLAppID, dateTimePicker1.Value, 35, clsCurrentUser.CurrentUser.UserID);

                    if (ID != -1)
                    {
                        MessageBox.Show($"Appointment for vision test has been scheduled successfully. With ID = {ID}",
                            "Appointment Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataBack?.Invoke(); // Notify the main form to refresh the data grid view
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to schedule appointment for vision test. Please try again later.",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Handle Edit Appointment
                if (clsPerson.UpdateTestAppointment(AppointmentID, dateTimePicker1.Value))
                {
                    MessageBox.Show("Appointment for vision test has been updated successfully.",
                        "Appointment Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DataBack?.Invoke(); // Notify the main form to refresh the data grid view
                }
                else
                {
                    MessageBox.Show("Failed to update appointment for vision test. Please try again later.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ScheduleStreetTest_Load(object sender, EventArgs e)
        {
            this.Size = new Size(500, 600);

        }
    }
}
