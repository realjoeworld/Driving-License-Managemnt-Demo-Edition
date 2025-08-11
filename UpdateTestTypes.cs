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
    public partial class UpdateTestTypes: Form
    {

        public delegate void DataBackEvrntHandler();

        public event DataBackEvrntHandler DataBack;

        int ID { get; set; }
        string TestTitle { get; set; }
        string TestDescription { get; set; }
        int Fees { get; set; }

        public UpdateTestTypes(int ID, string TestTitle, string TestDescription, int Fees)
        {
            this.ID = ID;
            InitializeComponent();
            this.TestTitle = TestTitle;
            this.TestDescription = TestDescription;
            this.Fees = Fees;
            lblID.Text = ID.ToString();
            txtboxTestTitle.Text = TestTitle;
            txtboxTitleDescription.Text = TestDescription;
            txtboxTestFees.Text = Fees.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtboxTestTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtboxTestTitle.Text))
            {
                MessageBox.Show("Please enter a test title.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxTestTitle.Focus();
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtboxTitleDescription.Text))
            {
                MessageBox.Show("Please enter a test Description.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxTitleDescription.Focus();
            }
        }

        private void txtboxTestFees_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtboxTestFees.Text))
            {
                MessageBox.Show("Please enter a test fees.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtboxTestFees.Focus();
            }

        }

        private void txtboxTestFees_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore the input if it's not a digit or control character
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtboxTestTitle.Text) && string.IsNullOrEmpty(txtboxTitleDescription.Text) && string.IsNullOrEmpty(txtboxTestFees.Text)))
            {
                if (clsTestTypes.UpdateTestType(this.ID, txtboxTestTitle.Text, txtboxTitleDescription.Text, Convert.ToInt32(txtboxTestFees.Text)))
                {
                    MessageBox.Show("Test Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataBack?.Invoke(); // Trigger the event to refresh data
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update Test Type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    
    }
}
