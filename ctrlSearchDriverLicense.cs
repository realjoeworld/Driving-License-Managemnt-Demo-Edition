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
using System.Globalization;

namespace DVLDInterface
{
    public partial class ctrlSearchDriverLicense: UserControl
    {

       public int DriverID { get; set; }
       public int ApplicationID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public ctrlSearchDriverLicense()
        {
            InitializeComponent();
        }

     
        public event Action <int> OnSearchComplete;

        protected virtual void SearchComplete(int Result)
        {
            Action<int> handler = OnSearchComplete;

            if (handler != null)
            {
                handler(Result);
            }

        }

        public event Action<bool> OnRenewCompleted;

        protected virtual void RenewCompleted(bool EnableReNewButton)
        {
            Action<bool> handler = RenewCompleted;

            if (handler != null)
            {
                handler(EnableReNewButton);
            }

        }

        public int LocalLicenseID { get; set; }
        public bool IsFound { get; set; }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string ClassName = string.Empty, FullName = string.Empty, NationalNo = string.Empty, Gender = string.Empty, IssueDate = string.Empty, IssueReason = string.Empty, Notes = string.Empty, IsActive = string.Empty, DateOfBirth = string.Empty, ExpirationDate = string.Empty, IsDetained = string.Empty, ImagePath = string.Empty;
            int DriveID = 0;

            if (clsDriver.GetDriverLicenseInfoByLicenseID(Convert.ToInt32(txtboxSearch.Text),ref ClassName,ref FullName,ref NationalNo,ref Gender,ref IssueDate,ref IssueReason,ref Notes,ref IsActive,ref DateOfBirth,ref DriveID,ref ExpirationDate,ref IsDetained,ref ImagePath)) {

                ctrlDrivingLicenseInfo1.LoadDrivingLicenseInfo(ClassName, FullName, Convert.ToInt32(txtboxSearch.Text), NationalNo, Gender, IssueDate, IssueReason, Notes, IsActive, DateOfBirth, DriveID, ExpirationDate, IsDetained, ImagePath);
                
                LocalLicenseID = Convert.ToInt32(txtboxSearch.Text);
                
                this.DriverID = DriveID;

                IsFound = true;
                
                this.ExpirationDate = DateTime.ParseExact(ExpirationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);


                if (OnSearchComplete != null)
                {
                    OnSearchComplete(LocalLicenseID);

                    

                }

            }
            
            else
            {
                LocalLicenseID = -1;
                IsFound = false;

                MessageBox.Show("The license ID You Entered Does Not Exist Or Is Not Active. Please try again.", "License Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);

                if (OnSearchComplete != null)
                {
                    OnSearchComplete(LocalLicenseID);
                }
            }


        }

        private void txtboxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }
    }
}
