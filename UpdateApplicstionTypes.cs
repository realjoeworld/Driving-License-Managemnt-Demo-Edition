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
    public partial class UpdateApplicstionTypes: Form
    {

        public delegate void DataBackEventHandler();
        public event DataBackEventHandler DataBack;

        int ID { get; set; }

        string ApplicationTitle { get; set; }

        int Fees { get; set; }

        public UpdateApplicstionTypes(int ID, string ApplicationTitle, int Fees)
        {
            InitializeComponent();
            this.ID = ID;
            this.ApplicationTitle = ApplicationTitle;
            this.Fees = Fees;

            lblID.Text = ID.ToString();
            txtboxApplicationTitle.Text = ApplicationTitle;
            txtboxApplicationFees.Text = Fees.ToString();

        }

        private void UpdateApplicstionTypes_Load(object sender, EventArgs e)
        {

        }

        private void lblID_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxApplicationTitle_Validating(object sender, CancelEventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtboxApplicationTitle.Text))
            {
                MessageBox.Show("Please enter an application title.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxApplicationTitle.Focus();
            }

        }

        private void txtboxApplicationFees_Validating(object sender, CancelEventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtboxApplicationFees.Text))
            {
                MessageBox.Show("Please enter an application Fees.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxApplicationFees.Focus();
            }

        }

        private void txtboxApplicationFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!(string.IsNullOrEmpty(txtboxApplicationTitle.Text) && string.IsNullOrEmpty(txtboxApplicationFees.Text)))
            {
                if(clsApplicationTypes.UpdateApplicationType(this.ID, txtboxApplicationTitle.Text,Convert.ToInt32(txtboxApplicationFees.Text)))
                {
                    MessageBox.Show("Application Type Updated Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(); // Notify subscribers that data has been updated
                }
                else
                {
                    MessageBox.Show("Failed to update Application Type. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        
        }
    
    
    
    }
}
