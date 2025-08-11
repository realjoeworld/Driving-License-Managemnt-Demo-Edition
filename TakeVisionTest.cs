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
    public partial class TakeVisionTest: Form
    {

        public delegate void SendDataBack();
        public event SendDataBack DataBack;


        int TestAppointmentID { get; set; }
        public TakeVisionTest(int TestAppointmentID,int DrivingLicenseID, string ClassName, string FullName,DateTime ApplicationDate)
        {

            InitializeComponent();
            lblDLAppID.Text = DrivingLicenseID.ToString();
            lblDrivingClass.Text = ClassName;
            lblDate.Text = ApplicationDate.ToShortDateString();
            lblFullName.Text = FullName;
            this.TestAppointmentID = TestAppointmentID;
            this.Size = new Size(550, 680);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool IsPassed = false;

            if (rdbPassed.Checked)
                IsPassed = true;

            int ID = -1;


            if ((ID = clsPerson.AddNewTest(TestAppointmentID, IsPassed, txtboxNotes.Text, clsCurrentUser.CurrentUser.UserID)) != -1)
            {
                MessageBox.Show("Test result saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblTestID.Text = ID.ToString();

                if (clsPerson.UpdateTestAppointmentToBeLocked(TestAppointmentID))
                {
                    MessageBox.Show("Test appointment has been locked successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(); // Notify subscribers to refresh data
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to lock the test appointment. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

            else
            {
                MessageBox.Show("Failed to save test result. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void TakeVisionTest_Load(object sender, EventArgs e)
        {

        }
    }
}
